using System;
using System.Threading;
using System.Windows.Forms;

namespace FarCry5SaveManager
{
    public partial class MainForm : Form
    {
        private SaveController saveController;
        public MainForm()
        {
            InitializeComponent();
            saveController = new SaveController(textBoxFolderPath, listBoxUbiIDs, listBoxBackedUpSaves,
                                                textBoxSaveInfo, textBoxBackupTitle, buttonBackup,
                                                buttonDeleteSave, buttonLoadSave);
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
            DialogResult loadResult = MessageBox.Show("Load selected save?", "Load save",
                                                    MessageBoxButtons.YesNo);

            if (loadResult == DialogResult.Yes)
            {
                buttonLoadSave.Enabled = false;
                Cursor = Cursors.WaitCursor;
                Thread.Sleep(50);

                if (saveController.LoadSave())
                    MessageBox.Show("Loaded OK", "Load save");
                else
                    MessageBox.Show("Load Failed", "Load save" );

                Cursor = Cursors.Default;
            }

        }

        private void buttonDeleteSave_Click(object sender, EventArgs e)
        {
            DialogResult delResult = MessageBox.Show("Delete selected save?", "Delete save",
                                                    MessageBoxButtons.YesNo);

            if (delResult == DialogResult.Yes)
            {
                buttonDeleteSave.Enabled = false;
                Cursor = Cursors.WaitCursor;
                Thread.Sleep(50);

                if (saveController.DeleteSaveFile())
                    MessageBox.Show("Deleted OK", "Delete save");
                else
                    MessageBox.Show("Delete Failed", "Delete save");

                Cursor = Cursors.Default;
            }
        }
    }
}
