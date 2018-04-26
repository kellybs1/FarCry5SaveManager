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
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxBackupTitle = new System.Windows.Forms.TextBox();
            this.groupBoxStorefront = new System.Windows.Forms.GroupBox();
            this.radioButtonUPlay = new System.Windows.Forms.RadioButton();
            this.radioButtonSteam = new System.Windows.Forms.RadioButton();
            this.groupBoxStorefront.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxBackedUpSaves
            // 
            this.listBoxBackedUpSaves.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxBackedUpSaves.FormattingEnabled = true;
            this.listBoxBackedUpSaves.Location = new System.Drawing.Point(12, 390);
            this.listBoxBackedUpSaves.Name = "listBoxBackedUpSaves";
            this.listBoxBackedUpSaves.Size = new System.Drawing.Size(379, 108);
            this.listBoxBackedUpSaves.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Location of uPlay \"savegames\" directory";
            // 
            // textBoxFolderPath
            // 
            this.textBoxFolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFolderPath.Location = new System.Drawing.Point(12, 94);
            this.textBoxFolderPath.Name = "textBoxFolderPath";
            this.textBoxFolderPath.ReadOnly = true;
            this.textBoxFolderPath.Size = new System.Drawing.Size(378, 20);
            this.textBoxFolderPath.TabIndex = 3;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowse.Location = new System.Drawing.Point(408, 91);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(121, 25);
            this.buttonBrowse.TabIndex = 4;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select Ubisoft ID";
            // 
            // listBoxUbiIDs
            // 
            this.listBoxUbiIDs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxUbiIDs.FormattingEnabled = true;
            this.listBoxUbiIDs.Location = new System.Drawing.Point(12, 143);
            this.listBoxUbiIDs.Name = "listBoxUbiIDs";
            this.listBoxUbiIDs.Size = new System.Drawing.Size(517, 82);
            this.listBoxUbiIDs.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Far Cry 5 current save";
            // 
            // textBoxSaveInfo
            // 
            this.textBoxSaveInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSaveInfo.Location = new System.Drawing.Point(12, 272);
            this.textBoxSaveInfo.Name = "textBoxSaveInfo";
            this.textBoxSaveInfo.ReadOnly = true;
            this.textBoxSaveInfo.Size = new System.Drawing.Size(391, 20);
            this.textBoxSaveInfo.TabIndex = 7;
            // 
            // buttonBackup
            // 
            this.buttonBackup.Enabled = false;
            this.buttonBackup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBackup.Location = new System.Drawing.Point(409, 293);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(121, 25);
            this.buttonBackup.TabIndex = 8;
            this.buttonBackup.Text = "Backup Save";
            this.buttonBackup.UseVisualStyleBackColor = true;
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 371);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Backed up saves";
            // 
            // buttonLoadSave
            // 
            this.buttonLoadSave.BackColor = System.Drawing.Color.PaleGreen;
            this.buttonLoadSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonLoadSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoadSave.Location = new System.Drawing.Point(409, 468);
            this.buttonLoadSave.Name = "buttonLoadSave";
            this.buttonLoadSave.Size = new System.Drawing.Size(121, 30);
            this.buttonLoadSave.TabIndex = 10;
            this.buttonLoadSave.Text = "Load Save";
            this.buttonLoadSave.UseVisualStyleBackColor = false;
            this.buttonLoadSave.Click += new System.EventHandler(this.buttonLoadSave_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(14, 358);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 1);
            this.panel1.TabIndex = 12;
            // 
            // buttonDeleteSave
            // 
            this.buttonDeleteSave.BackColor = System.Drawing.Color.LightCoral;
            this.buttonDeleteSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonDeleteSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonDeleteSave.Location = new System.Drawing.Point(409, 390);
            this.buttonDeleteSave.Name = "buttonDeleteSave";
            this.buttonDeleteSave.Size = new System.Drawing.Size(121, 30);
            this.buttonDeleteSave.TabIndex = 13;
            this.buttonDeleteSave.Text = "Delete Save";
            this.buttonDeleteSave.UseVisualStyleBackColor = false;
            this.buttonDeleteSave.Click += new System.EventHandler(this.buttonDeleteSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Optional title";
            // 
            // textBoxBackupTitle
            // 
            this.textBoxBackupTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBackupTitle.Location = new System.Drawing.Point(112, 296);
            this.textBoxBackupTitle.MaxLength = 16;
            this.textBoxBackupTitle.Name = "textBoxBackupTitle";
            this.textBoxBackupTitle.Size = new System.Drawing.Size(291, 20);
            this.textBoxBackupTitle.TabIndex = 15;
            // 
            // groupBoxStorefront
            // 
            this.groupBoxStorefront.Controls.Add(this.radioButtonUPlay);
            this.groupBoxStorefront.Controls.Add(this.radioButtonSteam);
            this.groupBoxStorefront.Location = new System.Drawing.Point(15, 13);
            this.groupBoxStorefront.Name = "groupBoxStorefront";
            this.groupBoxStorefront.Size = new System.Drawing.Size(238, 49);
            this.groupBoxStorefront.TabIndex = 16;
            this.groupBoxStorefront.TabStop = false;
            this.groupBoxStorefront.Text = "Storefront";
            // 
            // radioButtonUPlay
            // 
            this.radioButtonUPlay.AutoSize = true;
            this.radioButtonUPlay.Checked = true;
            this.radioButtonUPlay.Location = new System.Drawing.Point(140, 20);
            this.radioButtonUPlay.Name = "radioButtonUPlay";
            this.radioButtonUPlay.Size = new System.Drawing.Size(51, 17);
            this.radioButtonUPlay.TabIndex = 1;
            this.radioButtonUPlay.TabStop = true;
            this.radioButtonUPlay.Text = "uPlay";
            this.radioButtonUPlay.UseVisualStyleBackColor = true;
            // 
            // radioButtonSteam
            // 
            this.radioButtonSteam.AutoSize = true;
            this.radioButtonSteam.Location = new System.Drawing.Point(34, 20);
            this.radioButtonSteam.Name = "radioButtonSteam";
            this.radioButtonSteam.Size = new System.Drawing.Size(55, 17);
            this.radioButtonSteam.TabIndex = 0;
            this.radioButtonSteam.Text = "Steam";
            this.radioButtonSteam.UseVisualStyleBackColor = true;
            this.radioButtonSteam.CheckedChanged += new System.EventHandler(this.radioButtonSteam_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(548, 510);
            this.Controls.Add(this.groupBoxStorefront);
            this.Controls.Add(this.textBoxBackupTitle);
            this.Controls.Add(this.label5);
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
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Far Cry 5 Save Manager";
            this.groupBoxStorefront.ResumeLayout(false);
            this.groupBoxStorefront.PerformLayout();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxBackupTitle;
        private System.Windows.Forms.GroupBox groupBoxStorefront;
        private System.Windows.Forms.RadioButton radioButtonUPlay;
        private System.Windows.Forms.RadioButton radioButtonSteam;
    }
}

