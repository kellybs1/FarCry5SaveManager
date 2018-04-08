namespace FarCry5SaveManager
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listBoxBackedUpSaves = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFolderPath = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxUbiIDs = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSaveInfo = new System.Windows.Forms.TextBox();
            this.buttonBackup = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonLoadSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonDeleteSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxBackedUpSaves
            // 
            this.listBoxBackedUpSaves.FormattingEnabled = true;
            this.listBoxBackedUpSaves.Location = new System.Drawing.Point(11, 368);
            this.listBoxBackedUpSaves.Name = "listBoxBackedUpSaves";
            this.listBoxBackedUpSaves.Size = new System.Drawing.Size(379, 121);
            this.listBoxBackedUpSaves.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Location of uPlay \"savegames\" directory";
            // 
            // textBoxFolderPath
            // 
            this.textBoxFolderPath.Location = new System.Drawing.Point(12, 63);
            this.textBoxFolderPath.Name = "textBoxFolderPath";
            this.textBoxFolderPath.ReadOnly = true;
            this.textBoxFolderPath.Size = new System.Drawing.Size(378, 20);
            this.textBoxFolderPath.TabIndex = 3;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(408, 61);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(121, 23);
            this.buttonBrowse.TabIndex = 4;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select Ubisoft ID";
            // 
            // listBoxUbiIDs
            // 
            this.listBoxUbiIDs.FormattingEnabled = true;
            this.listBoxUbiIDs.Location = new System.Drawing.Point(12, 125);
            this.listBoxUbiIDs.Name = "listBoxUbiIDs";
            this.listBoxUbiIDs.Size = new System.Drawing.Size(517, 95);
            this.listBoxUbiIDs.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Far Cry 5 current save";
            // 
            // textBoxSaveInfo
            // 
            this.textBoxSaveInfo.Location = new System.Drawing.Point(11, 258);
            this.textBoxSaveInfo.Name = "textBoxSaveInfo";
            this.textBoxSaveInfo.ReadOnly = true;
            this.textBoxSaveInfo.Size = new System.Drawing.Size(391, 20);
            this.textBoxSaveInfo.TabIndex = 7;
            // 
            // buttonBackup
            // 
            this.buttonBackup.Enabled = false;
            this.buttonBackup.Location = new System.Drawing.Point(408, 256);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(121, 23);
            this.buttonBackup.TabIndex = 8;
            this.buttonBackup.Text = "Backup This Save";
            this.buttonBackup.UseVisualStyleBackColor = true;
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 349);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Backed up saves";
            // 
            // buttonLoadSave
            // 
            this.buttonLoadSave.Location = new System.Drawing.Point(408, 466);
            this.buttonLoadSave.Name = "buttonLoadSave";
            this.buttonLoadSave.Size = new System.Drawing.Size(121, 23);
            this.buttonLoadSave.TabIndex = 10;
            this.buttonLoadSave.Text = "Load Save";
            this.buttonLoadSave.UseVisualStyleBackColor = true;
            this.buttonLoadSave.Click += new System.EventHandler(this.buttonLoadSave_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(13, 336);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 1);
            this.panel1.TabIndex = 12;
            // 
            // buttonDeleteSave
            // 
            this.buttonDeleteSave.Location = new System.Drawing.Point(408, 368);
            this.buttonDeleteSave.Name = "buttonDeleteSave";
            this.buttonDeleteSave.Size = new System.Drawing.Size(121, 23);
            this.buttonDeleteSave.TabIndex = 13;
            this.buttonDeleteSave.Text = "Delete Save";
            this.buttonDeleteSave.UseVisualStyleBackColor = true;
            this.buttonDeleteSave.Click += new System.EventHandler(this.buttonDeleteSave_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 511);
            this.Controls.Add(this.buttonDeleteSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonLoadSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonBackup);
            this.Controls.Add(this.textBoxSaveInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.textBoxFolderPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxUbiIDs);
            this.Controls.Add(this.listBoxBackedUpSaves);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Far Cry 5 Save Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxBackedUpSaves;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFolderPath;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxUbiIDs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSaveInfo;
        private System.Windows.Forms.Button buttonBackup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonLoadSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDeleteSave;
    }
}

