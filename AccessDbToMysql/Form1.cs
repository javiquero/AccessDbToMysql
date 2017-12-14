using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
using System.Windows.Forms;

namespace AccessDbToMysql {
    public partial class Form1 : Form {
        private string AccessConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Persist Security Info=False;";
        private string MysqlConnectionString = "server={0}; user id={1}; password={2}; port={3}; pooling=true; database=";

        private string OdbcDriver = "";
        public Form1() {
            InitializeComponent();
            loadConfig();

            OdbcDriver = getODBCMysql();

            if (OdbcDriver == "") {
                string message = "Driver Mysql Odbc not detected, please download and install\n\nhttps://dev.mysql.com/downloads/connector/odbc/";
                string caption = "Error ODBC";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                System.Diagnostics.Process.Start("https://dev.mysql.com/downloads/connector/odbc/");
            }
        }

        private string getFactusolDirectory() {

            string programFiles = Environment.ExpandEnvironmentVariables("%ProgramW6432%");
            string programFilesX86 = Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%");

            string[] locations = new string[] {
                Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles),
                Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFilesX86),
                Path.GetPathRoot(Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFilesX86).ToString()).TrimEnd(new char[] { '\\' }),
                programFiles,
                programFilesX86
            };

            foreach (string location in locations) {
                if (Directory.Exists(location + "\\Software DELSOL\\FactuSOL\\Datos\\FS")) {
                    return location + "\\Software DELSOL\\FactuSOL\\Datos\\FS";
                }
            }
            return Path.GetPathRoot(Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFilesX86).ToString()).TrimEnd(new char[] { '\\' });

        }
        private void loadConfig() {
            textBoxPathAccess.Text = Properties.Settings.Default.PathAccess;
            textBoxMysqlServer.Text = Properties.Settings.Default.ServerMysql;
            textBoxMysqlPort.Text = Properties.Settings.Default.PortMysql;
            textBoxMysqlUser.Text = Properties.Settings.Default.UserMysql;
            textBoxMysqlPassword.Text = Properties.Settings.Default.PasswordMysql;
        }
        private bool testAccess() {
            AccessConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBoxPathAccess.Text + "; Persist Security Info=False;";
            try {
                OleDbConnection AccessConn = new OleDbConnection(AccessConnectionString);
                AccessConn.Open();
                AccessConn.Close();
                Properties.Settings.Default["PathAccess"] = textBoxPathAccess.Text;
                Properties.Settings.Default.Save();
                this.access(true);
                return true;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                this.access(false);
                return false;
            }
        }
        private void access(bool status) {
            if (status == true) {
                labelAccessStatusConnection.Text = "ü";
                labelAccessStatusConnection.ForeColor = System.Drawing.Color.Green;
            } else {
                labelAccessStatusConnection.Text = "û";
                labelAccessStatusConnection.ForeColor = System.Drawing.Color.Red;
            }
            labelAccessStatusConnection.Visible = true;
        }
        private void mysql(bool status) {
            if (status == true) {
                labelTestMysqlConnection.Text = "ü";
                labelTestMysqlConnection.ForeColor = System.Drawing.Color.Green;
            } else {
                labelTestMysqlConnection.Text = "û";
                labelTestMysqlConnection.ForeColor = System.Drawing.Color.Red;
            }
            labelTestMysqlConnection.Visible = true;
        }
        private bool testMysql() {
            MysqlConnectionString = "server=" + textBoxMysqlServer.Text + "; user id=" + textBoxMysqlUser.Text + "; password=" + textBoxMysqlPassword.Text + ";port=" + textBoxMysqlPort.Text + "; pooling=true; database=;";
            try {
                MySqlConnection MysqlConn = new MySqlConnection(MysqlConnectionString);
                MysqlConn.Open();
                MysqlConn.Close();
                Properties.Settings.Default["ServerMysql"] = textBoxMysqlServer.Text;
                Properties.Settings.Default["PortMysql"] = textBoxMysqlPort.Text;
                Properties.Settings.Default["UserMysql"] = textBoxMysqlUser.Text;
                Properties.Settings.Default["PasswordMysql"] = textBoxMysqlPassword.Text;
                Properties.Settings.Default.Save();
                this.mysql(true);
                return true;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                this.mysql(false);
                return false;
            }
        }

        private static DataTable GetSchemaTables(string connectionString) {
            using (OleDbConnection connection = new
                       OleDbConnection(connectionString)) {
                connection.Open();
                DataTable schemaTable = connection.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables,
                    new object[] { null, null, null, "TABLE" });
                return schemaTable;
            }
        }
        private static DataTable GetSchemaTable(string connectionString, string tableName) {
            using (OleDbConnection connection = new
                       OleDbConnection(connectionString)) {
                connection.Open();

                DataTable schemaTable = connection.GetSchema("Columns", new string[] { null, null, tableName, null });
                DataView dv = schemaTable.DefaultView;
                dv.Sort = "ORDINAL_POSITION ASC";
                DataTable sortedDT = dv.ToTable();
                return sortedDT;
            }
        }
        private static DataTable GetSchemaIndexTable(string connectionString, string tableName) {
            using (OleDbConnection connection = new
                       OleDbConnection(connectionString)) {
                connection.Open();

                DataTable schemaTable = connection.GetSchema("Indexes");//, new string[] { null, null, tableName, null });
                for (int i = 0; i < schemaTable.Rows.Count; i++) {
                    DataRow dr = schemaTable.Rows[i];
                    if (dr["TABLE_NAME"].ToString() != tableName)
                        dr.Delete();
                }
                schemaTable.AcceptChanges();
                DataView dv = schemaTable.DefaultView;
                dv.Sort = "PRIMARY_KEY DESC, ORDINAL_POSITION ASC";
                DataTable sortedDT = dv.ToTable();
                return sortedDT;
            }
        }

        private void buttonSearchDatabase_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = this.getFactusolDirectory();
            openFileDialog1.Filter = "Microsoft Access Database (.accdb)|*.accdb|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = false;

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) {
                textBoxPathAccess.Text = openFileDialog1.FileName;
            }
        }
        private void buttonTestAccess_Click(object sender, EventArgs e) {
            if (this.testAccess()) {
                MessageBox.Show("connection successful", "Accdb connection", MessageBoxButtons.OK);
            }
        }
        private void buttonTestMysql_Click(object sender, EventArgs e) {
            if (this.testMysql()) {
                MessageBox.Show("connection successful", "Mysql connection", MessageBoxButtons.OK);
            }
        }

        private void AccessExecute(string queryString) {
            using (OleDbConnection connection = new
                       OleDbConnection(this.AccessConnectionString)) {
                connection.Open();
                OleDbCommand command = new
                    OleDbCommand(queryString, connection);
                command.ExecuteNonQuery();
            }
        }
        private void executeMysql(string queryString) {
            if (queryString == "") return;
            using (MySqlConnection connection = new
                       MySqlConnection(MysqlConnectionString)) {
                connection.Open();
                MySqlCommand command = new
                    MySqlCommand(queryString, connection);
                try {
                    command.ExecuteNonQuery();
                } catch (Exception Ex) {
                    Console.WriteLine(Ex.Message);
                }
            }
        }

        private  string getPrimaryKeys(string TableName) {
            string primaryKeys = "ALTER TABLE " + TableName + " ADD PRIMARY KEY(";
            DataTable keys = GetSchemaIndexTable(AccessConnectionString, TableName);
            DataRow[] primary = keys.Select("PRIMARY_KEY = true");
            if (primary.Length > 0) {
                int numkeys = 0;
                foreach (DataRow dr in primary) {
                    if (numkeys == 1) {
                        primaryKeys = primaryKeys.Replace("PRIMARY KEY", "CONSTRAINT " + TableName + "_pkey PRIMARY KEY");
                    }
                    if (numkeys > 0) {
                        primaryKeys += ", ";
                    }
                    primaryKeys += dr["COLUMN_NAME"];
                    numkeys++;
                }
                primaryKeys += ");";
                return primaryKeys;
            }
            return "";
        }
        private  string getKeys(string TableName) {
            string primaryKeys = "";
            DataTable keys = GetSchemaIndexTable(AccessConnectionString, TableName);
            DataRow[] noPrimary = keys.Select("PRIMARY_KEY = false");
            if (noPrimary.Length > 0) {
                foreach (DataRow dr in noPrimary) {
                    primaryKeys += "CREATE INDEX " + TableName + "_" + dr["COLUMN_NAME"] + "_idx ON " + TableName + "(" + dr["COLUMN_NAME"] + ");";
                }
                return primaryKeys;
            }
            return "";
        }
        private  string getCreateTable(string TableName) {
            String createTable = "";
            DataTable Columns = GetSchemaTable(AccessConnectionString, TableName);
            if (Columns.Rows.Count > 0) {
                createTable = "CREATE TABLE `" + TableName + "` (";
                for (int colNum = 0; colNum < Columns.Rows.Count; colNum++) {
                    createTable += "`" + Columns.Rows[colNum].ItemArray[3].ToString() + "` ";
                    switch (Columns.Rows[colNum].ItemArray[11].ToString()) {
                        case "130":
                            if (Columns.Rows[colNum].ItemArray[14].ToString() == "0") {
                                createTable += " text COMMENT '" + Columns.Rows[colNum].ItemArray[27].ToString() + "'";
                            } else {
                                createTable += " varchar (" + Columns.Rows[colNum].ItemArray[13].ToString() + ") COMMENT '" + Columns.Rows[colNum].ItemArray[27].ToString() + "'";
                            }
                            break;
                        case "3":
                            //createTable += " bigint COMMENT '" + Columns.Rows[colNum].ItemArray[27].ToString() + "'";
                        case "2":
                            createTable += " int COMMENT '" + Columns.Rows[colNum].ItemArray[27].ToString() + "'";
                            break;
                        case "6":
                        case "4":
                            createTable += " float COMMENT '" + Columns.Rows[colNum].ItemArray[27].ToString() + "'";
                            break;
                        case "5":
                            createTable += " double COMMENT '" + Columns.Rows[colNum].ItemArray[27].ToString() + "'";
                            break;
                        case "128":
                            createTable += " blob COMMENT '" + Columns.Rows[colNum].ItemArray[27].ToString() + "'";
                            break;
                        case "7":
                            createTable += " datetime COMMENT '" + Columns.Rows[colNum].ItemArray[27].ToString() + "'";
                            break;
                        case "17":
                            createTable += " smallint COMMENT '" + Columns.Rows[colNum].ItemArray[27].ToString() + "'";
                            break;
                        default:
                            Console.WriteLine("Type {0} not expected. {1} - {2}", new object[] {
                                    Columns.Rows[colNum].ItemArray[11].ToString(), Columns.Rows[colNum].ItemArray[2].ToString(), Columns.Rows[colNum].ItemArray[3].ToString(), });
                            break;
                    }

                    if (Columns.Rows[colNum].ItemArray[8].ToString() == "") {
                        if ((int)Columns.Rows[colNum].ItemArray[11] < 50) {
                            createTable += " DEFAULT 0";
                        } else {
                            if ((bool)Columns.Rows[colNum].ItemArray[10] == false) {
                                createTable += " DEFAULT \"\"";
                            } else {
                                createTable += " DEFAULT NULL";
                            }
                        }
                    } else {
                        if (Columns.Rows[colNum].ItemArray[8].ToString().Last().ToString() == "#" && Columns.Rows[colNum].ItemArray[8].ToString().First().ToString() == "#") {
                            DateTime myDate = DateTime.Parse(Columns.Rows[colNum].ItemArray[8].ToString().Replace("#", ""));
                            createTable += "DEFAULT '" + myDate.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) + "'";
                        } else {
                            createTable += "DEFAULT " + Columns.Rows[colNum].ItemArray[8].ToString() + "";
                        }
                    }

                    if ((bool)Columns.Rows[colNum].ItemArray[10] == false) {
                        createTable += " NOT NULL";
                    }
                    if (colNum + 1 < Columns.Rows.Count) {
                        createTable += ",";
                    }
                }
                createTable += ") ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;";
            }
            return createTable;
        }
        private List<String> getInserts(string TableName) {
            List<String> response = new List<string>();

            DataTable dt = new DataTable();
            using (OleDbConnection connection = new
                OleDbConnection(this.AccessConnectionString)) {
                    OleDbDataAdapter Accessda = new OleDbDataAdapter();
                    Accessda.SelectCommand = new OleDbCommand("SELECT * FROM " + TableName + ";", connection);
                    Accessda.Fill(dt);
            }

            DataTable Columns = GetSchemaTable(AccessConnectionString, TableName);
            for (int x = 0; x < dt.Rows.Count; x++) {
                string insertString = "Insert into `" + TableName + "` VALUES (";
                for (int colNum = 0; colNum < Columns.Rows.Count; colNum++) {
                    switch (Columns.Rows[colNum].ItemArray[11].ToString()) {
                        case "130":
                        case "128":
                            insertString += " '" + dt.Rows[x].ItemArray[colNum].ToString().Replace(@"\", @"\\").Replace("'", @"\'") + "'";
                            break;
                        case "7":
                            //insertString += " DATE_FORMAT('" + dt.Rows[x].ItemArray[colNum].ToString() + "', '%d/%m/%Y %k:%i:%s')";
                            insertString += " STR_TO_DATE('" + dt.Rows[x].ItemArray[colNum].ToString() + "', '%d/%m/%Y %k:%i:%s')";
                            break;
                        case "2":
                        case "6":
                        case "4":
                        case "5":
                        case "3":
                        case "17":
                            insertString += " " + dt.Rows[x].ItemArray[colNum].ToString().Replace(",",".") ; ;
                            break;
                        default:
                            Console.WriteLine("Type {0} not expected. {1} - {2}", new object[] {
                                    Columns.Rows[colNum].ItemArray[11].ToString(), Columns.Rows[colNum].ItemArray[2].ToString(), Columns.Rows[colNum].ItemArray[3].ToString(), });
                            insertString += " '" + dt.Rows[x].ItemArray[colNum].ToString() + "'";
                            break;
                    }
                    if (colNum + 1 < Columns.Rows.Count) {
                        insertString += ",";
                    }
                }
                insertString += ");";
                response.Add(insertString);
            }
            return response;
        }
        private string getCreateDatabase() {
            string response = "CREATE DATABASE `" + DatabaseName() + "`;";
            return response;
        }
        private  string DatabaseName() {
            return Path.GetFileName(textBoxPathAccess.Text).Replace(
                    Path.GetExtension(textBoxPathAccess.Text), "");
        }

        private static string getODBCMysql() {
            string[] odbcNames = GetSystemDriverList().ToArray();
            for (int i = 0; i < odbcNames.Length; i++) {
                if (odbcNames[i].Contains("MySQL ODBC") && odbcNames[i].Contains("nicode")) {
                    return odbcNames[i];
                }
            }
            return "";
        }
        private static List<String> GetSystemDriverList() {
            List<string> names = new List<string>();
            Microsoft.Win32.RegistryKey reg = (Microsoft.Win32.Registry.LocalMachine).OpenSubKey("Software");
            if (reg != null) {
                reg = reg.OpenSubKey("ODBC");
                if (reg != null) {
                    reg = reg.OpenSubKey("ODBCINST.INI");
                    if (reg != null) {
                        reg = reg.OpenSubKey("ODBC Drivers");
                        if (reg != null) {
                            foreach (string sName in reg.GetValueNames()) {
                                names.Add(sName);
                            }
                        }
                        try {
                            reg.Close();
                        } catch {  }
                    }
                }
            }
            return names;
        }
        private void linkTable(string fromTable, string toTable) {
            Microsoft.Office.Interop.Access.Dao.DBEngine dbe = new Microsoft.Office.Interop.Access.Dao.DBEngine();
            Microsoft.Office.Interop.Access.Dao.Database db;
            Microsoft.Office.Interop.Access.Dao.Workspace wrk;
            wrk = dbe.CreateWorkspace("", "admin", "", Microsoft.Office.Interop.Access.Dao.WorkspaceTypeEnum.dbUseJet);
            db = wrk.OpenDatabase(textBoxPathAccess.Text);
            Microsoft.Office.Interop.Access.Dao.TableDef tdf = db.CreateTableDef();

            // MySQL ODBC 5.3 ANSI Driver
            tdf.Connect = "ODBC;Driver={"+ OdbcDriver + "};Server="+ textBoxMysqlServer.Text + 
                ";Port="+ textBoxMysqlPort.Text + 
                ";Database="+DatabaseName()+";User="+ textBoxMysqlUser.Text + 
                ";Password="+ textBoxMysqlPassword.Text + ";Option=3;";
            tdf.Connect = "ODBC;DSN=myDatabase";
            tdf.SourceTableName = fromTable;
            tdf.Name = toTable;
            db.TableDefs.Append(tdf);
        }

        private void buttonStartProcess_Click(object sender, EventArgs e) {
            buttonSearchDatabase.Enabled = false;
            buttonStartProcess.Enabled = false;
            buttonTestAccess.Enabled = false;
            buttonTestMysql.Enabled = false;
            textBoxPathAccess.Enabled = false;
            textBoxMysqlServer.Enabled = false;
            textBoxMysqlPort.Enabled = false;
            textBoxMysqlUser.Enabled = false;
            textBoxMysqlPassword.Enabled = false;

            if (this.testAccess() && this.testMysql()) {
                System.IO.File.Copy(textBoxPathAccess.Text, textBoxPathAccess.Text.Replace(DatabaseName(), DatabaseName() + "_backup"));
                executeMysql("DROP DATABASE IF EXISTS `" + DatabaseName() + "`;");

                executeMysql(getCreateDatabase());
                this.MysqlConnectionString = this.MysqlConnectionString.Replace("database=", "database = " + DatabaseName());

                DataTable Tables = GetSchemaTables(this.AccessConnectionString);
                for (int i = 0; i < Tables.Rows.Count ; i++) {
                    string TableName = Tables.Rows[i].ItemArray[2].ToString();
                    if (Tables.Rows[i].ItemArray[2].ToString().Contains("~TMP")) continue;
                    labelStatus.Text = "Generate " + TableName + " schema.";
                    progressBar1.Value = 0;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 3;

                    progressBar1.Value = 1;
                    executeMysql(getCreateTable(TableName));
                    progressBar1.Value = 2;
                    executeMysql(getPrimaryKeys(TableName));
                    progressBar1.Value = 3;
                    executeMysql(getKeys(TableName));

                    progressBar1.Value = 0;
                    labelStatus.Text = "Read data from " + TableName + " table.";
                    Application.DoEvents();
                    List<string> querys = getInserts(TableName);
                    labelStatus.Text = "Transfer data to " + TableName + " table.";
                    Application.DoEvents();
                    progressBar1.Maximum = querys.Count;
                    for (int numQuery = 0; numQuery < querys.Count; numQuery++ ){
                        Application.DoEvents();
                        progressBar1.Value = numQuery;
                        executeMysql(querys[numQuery]);
                    }

                    AccessExecute("DROP TABLE " + TableName + ";");
                    linkTable(TableName, TableName);
                }

                progressBar1.Value = 0;
                labelStatus.Text = "Process finished."; 

                buttonSearchDatabase.Enabled = true;
                //buttonStartProcess.Enabled = true;
                buttonTestAccess.Enabled = true;
                buttonTestMysql.Enabled = true;
                textBoxPathAccess.Enabled = true;
                textBoxMysqlServer.Enabled = true;
                textBoxMysqlPort.Enabled = true;
                textBoxMysqlUser.Enabled = true;
                textBoxMysqlPassword.Enabled = true;
            }
        }
    }
    
}
