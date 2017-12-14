using System;

namespace AccessDbToMysql {
    partial class Form1 {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTestMysqlConnection = new System.Windows.Forms.Label();
            this.buttonTestMysql = new System.Windows.Forms.Button();
            this.textBoxMysqlPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxMysqlUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxMysqlPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMysqlServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelAccessStatusConnection = new System.Windows.Forms.Label();
            this.buttonTestAccess = new System.Windows.Forms.Button();
            this.buttonSearchDatabase = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPathAccess = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonStartProcess = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelStatus = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.labelTestMysqlConnection);
            this.panel1.Controls.Add(this.buttonTestMysql);
            this.panel1.Controls.Add(this.textBoxMysqlPassword);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBoxMysqlUser);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBoxMysqlPort);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxMysqlServer);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(2, 164);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 294);
            this.panel1.TabIndex = 0;
            // 
            // labelTestMysqlConnection
            // 
            this.labelTestMysqlConnection.AutoSize = true;
            this.labelTestMysqlConnection.Font = new System.Drawing.Font("Wingdings", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.labelTestMysqlConnection.Location = new System.Drawing.Point(43, 242);
            this.labelTestMysqlConnection.Name = "labelTestMysqlConnection";
            this.labelTestMysqlConnection.Size = new System.Drawing.Size(0, 53);
            this.labelTestMysqlConnection.TabIndex = 5;
            // 
            // buttonTestMysql
            // 
            this.buttonTestMysql.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTestMysql.Location = new System.Drawing.Point(220, 242);
            this.buttonTestMysql.Name = "buttonTestMysql";
            this.buttonTestMysql.Size = new System.Drawing.Size(194, 35);
            this.buttonTestMysql.TabIndex = 4;
            this.buttonTestMysql.Text = "Test connection";
            this.buttonTestMysql.UseVisualStyleBackColor = true;
            this.buttonTestMysql.Click += new System.EventHandler(this.buttonTestMysql_Click);
            // 
            // textBoxMysqlPassword
            // 
            this.textBoxMysqlPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMysqlPassword.Location = new System.Drawing.Point(127, 201);
            this.textBoxMysqlPassword.Name = "textBoxMysqlPassword";
            this.textBoxMysqlPassword.PasswordChar = '•';
            this.textBoxMysqlPassword.Size = new System.Drawing.Size(287, 26);
            this.textBoxMysqlPassword.TabIndex = 4;
            this.textBoxMysqlPassword.Text = "root";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 204);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Password";
            // 
            // textBoxMysqlUser
            // 
            this.textBoxMysqlUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMysqlUser.Location = new System.Drawing.Point(127, 153);
            this.textBoxMysqlUser.Name = "textBoxMysqlUser";
            this.textBoxMysqlUser.Size = new System.Drawing.Size(287, 26);
            this.textBoxMysqlUser.TabIndex = 4;
            this.textBoxMysqlUser.Text = "root";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 156);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "User";
            // 
            // textBoxMysqlPort
            // 
            this.textBoxMysqlPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMysqlPort.Location = new System.Drawing.Point(127, 105);
            this.textBoxMysqlPort.Name = "textBoxMysqlPort";
            this.textBoxMysqlPort.Size = new System.Drawing.Size(287, 26);
            this.textBoxMysqlPort.TabIndex = 4;
            this.textBoxMysqlPort.Text = "3306";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 108);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Port";
            // 
            // textBoxMysqlServer
            // 
            this.textBoxMysqlServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMysqlServer.Location = new System.Drawing.Point(127, 57);
            this.textBoxMysqlServer.Name = "textBoxMysqlServer";
            this.textBoxMysqlServer.Size = new System.Drawing.Size(287, 26);
            this.textBoxMysqlServer.TabIndex = 2;
            this.textBoxMysqlServer.Text = "localhost";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "MySQL database";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.labelAccessStatusConnection);
            this.panel2.Controls.Add(this.buttonTestAccess);
            this.panel2.Controls.Add(this.buttonSearchDatabase);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBoxPathAccess);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(2, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(417, 151);
            this.panel2.TabIndex = 1;
            // 
            // labelAccessStatusConnection
            // 
            this.labelAccessStatusConnection.AutoSize = true;
            this.labelAccessStatusConnection.Font = new System.Drawing.Font("Wingdings", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.labelAccessStatusConnection.Location = new System.Drawing.Point(43, 101);
            this.labelAccessStatusConnection.Name = "labelAccessStatusConnection";
            this.labelAccessStatusConnection.Size = new System.Drawing.Size(0, 53);
            this.labelAccessStatusConnection.TabIndex = 5;
            // 
            // buttonTestAccess
            // 
            this.buttonTestAccess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTestAccess.Location = new System.Drawing.Point(220, 101);
            this.buttonTestAccess.Name = "buttonTestAccess";
            this.buttonTestAccess.Size = new System.Drawing.Size(194, 35);
            this.buttonTestAccess.TabIndex = 4;
            this.buttonTestAccess.Text = "Test connection";
            this.buttonTestAccess.UseVisualStyleBackColor = true;
            this.buttonTestAccess.Click += new System.EventHandler(this.buttonTestAccess_Click);
            // 
            // buttonSearchDatabase
            // 
            this.buttonSearchDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearchDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearchDatabase.Location = new System.Drawing.Point(384, 57);
            this.buttonSearchDatabase.Name = "buttonSearchDatabase";
            this.buttonSearchDatabase.Size = new System.Drawing.Size(30, 26);
            this.buttonSearchDatabase.TabIndex = 3;
            this.buttonSearchDatabase.Text = "...";
            this.buttonSearchDatabase.UseVisualStyleBackColor = true;
            this.buttonSearchDatabase.Click += new System.EventHandler(this.buttonSearchDatabase_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Access database";
            // 
            // textBoxPathAccess
            // 
            this.textBoxPathAccess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPathAccess.Location = new System.Drawing.Point(96, 57);
            this.textBoxPathAccess.Name = "textBoxPathAccess";
            this.textBoxPathAccess.Size = new System.Drawing.Size(282, 26);
            this.textBoxPathAccess.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 59);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Path";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonStartProcess
            // 
            this.buttonStartProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartProcess.Location = new System.Drawing.Point(11, 521);
            this.buttonStartProcess.Name = "buttonStartProcess";
            this.buttonStartProcess.Size = new System.Drawing.Size(405, 40);
            this.buttonStartProcess.TabIndex = 2;
            this.buttonStartProcess.Text = "Start";
            this.buttonStartProcess.UseVisualStyleBackColor = true;
            this.buttonStartProcess.Click += new System.EventHandler(this.buttonStartProcess_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 497);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(404, 18);
            this.progressBar1.TabIndex = 3;
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(11, 474);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(405, 20);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 571);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonStartProcess);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelStatus);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(446, 610);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Access to Mysql";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        private void Form1_Load(object sender, EventArgs e) {
            
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonTestMysql;
        private System.Windows.Forms.TextBox textBoxMysqlPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxMysqlUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxMysqlPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMysqlServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonTestAccess;
        private System.Windows.Forms.Button buttonSearchDatabase;
        private System.Windows.Forms.TextBox textBoxPathAccess;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonStartProcess;
        private System.Windows.Forms.Label labelAccessStatusConnection;
        private System.Windows.Forms.Label labelTestMysqlConnection;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelStatus;
    }
}

