using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarCry5SaveManager
{
    public partial class MainForm : Form
    {
        private SaveController saveController;
        public MainForm()
        {
            InitializeComponent();
            saveController = new SaveController(textBoxFolderPath, listBoxUbiIDs, listBoxBackedUpSaves, textBoxSaveInfo, buttonBackup, buttonDeleteSave);
        }
      

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            //get the user to choose the location of the saves
            FolderBrowserDialog openFolder = new FolderBrowserDialog();
            openFolder.ShowNewFolderButton = false;
            openFolder.SelectedPath = textBoxFolderPath.Text;
            //if the user correctly selected a folder
            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                saveController.SetNewFolderPath(openFolder.SelectedPath);
            }
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            buttonBackup.Enabled = false;
            Cursor = Cursors.WaitCursor;
            Thread.Sleep(50); // advance milliseconds so can't save into same folder, ever

            if (saveController.BackupSaveFiles())
                MessageBox.Show("Backup Completed OK");
            else
                MessageBox.Show("Backup Failed");

            Cursor = Cursors.Default;
            buttonBackup.Enabled = true;
        }

        private void buttonLoadSave_Click(object sender, EventArgs e)
        {

        }

        private void buttonDeleteSave_Click(object sender, EventArgs e)
        {
            buttonDeleteSave.Enabled = false;
            Cursor = Cursors.WaitCursor;
            Thread.Sleep(50);

            if (saveController.DeleteSaveFile())
                MessageBox.Show("Deleted OK");
            else
                MessageBox.Show("Delete Failed");

            Cursor = Cursors.Default;
        }
    }
}
