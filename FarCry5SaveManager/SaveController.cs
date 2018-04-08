using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarCry5SaveManager
{
    public class SaveController
    {
        private FC5SaveFileSystemManager fileSystemManager;
        private TextBox textBoxSaveFolderPath;
        private ListBox listBoxUbiIDs;
        private ListBox listBoxBackedUpSaveGames;
        private TextBox textBoxSaveInfo;
        private Button buttonBackup;
        private Button buttonDelete;
        // Arrays for storing full paths to locations
        private string[] ubiIDsFullPaths;
        private string[] backedUpSavesFullPaths;


        // Constructor
        //---------------------------------
        public SaveController(TextBox formTextBoxSaveFolderPath, 
                                ListBox formListBoxUbiIDs, 
                                ListBox formListBoxBackedUpSaveGames,
                                TextBox formTextBoxSaveInfo,
                                Button formButtonBackup,
                                Button formButtonDelete)
        {

            fileSystemManager = new FC5SaveFileSystemManager();
            listBoxUbiIDs = formListBoxUbiIDs;
            listBoxBackedUpSaveGames = formListBoxBackedUpSaveGames;
            textBoxSaveFolderPath = formTextBoxSaveFolderPath;
            updateUbiIDsStore();
            updateUbiIDsList();
            textBoxSaveFolderPath.TextChanged += updateUbiIDsListHandler;
            textBoxSaveFolderPath.Text = Constants.DEFAULT_SAVEGAME_LOCATION;
            listBoxUbiIDs.SelectedIndexChanged += updateSaveGameInfoHandler;
            buttonBackup = formButtonBackup;
            buttonDelete = formButtonDelete;
            listBoxUbiIDs.SelectedIndexChanged += updateBackupButtonStateHandler;
            textBoxSaveInfo = formTextBoxSaveInfo;
            updateBackedUpSavesStore();
            updateBackUpList();
            fileSystemManager.BackupsUpdatedEvent += updateBackedUpSaveGamesListHandler;
            updateDelButtonState();
            listBoxBackedUpSaveGames.SelectedIndexChanged += updateDeleteButtonStateHandler;
            fileSystemManager.BackupsUpdatedEvent += updateDeleteButtonStateHandler;
        }

        // Public methods
        //---------------------------------

        // Sets a new folder path both on screen and for management
        public void SetNewFolderPath(string folderPath)
        {
            fileSystemManager.SaveGamesFolderPath = folderPath;
            textBoxSaveFolderPath.Text = folderPath;
        }


        // Back up the current saveGame
        public bool BackupSaveFiles()
        {
            int index = listBoxUbiIDs.SelectedIndex;
            string pathToSave = ubiIDsFullPaths[index];
            return fileSystemManager.BackupSave(pathToSave);
        }

        // Delete the selected save
        public bool DeleteSaveFile()
        {
            int index = listBoxBackedUpSaveGames.SelectedIndex;
            string pathToDel = backedUpSavesFullPaths[index];
            return fileSystemManager.DeleteBackup(pathToDel);
        }


        // Fetches current save file meta data
        public string GetSaveFileInfo(string filePath)
        {
            return fileSystemManager.GetFileInformation(filePath);
        }


        // Check if the current folder actually has FC5 saves in it
        public bool CurrentFolderContainsSaves(string folderPath)
        {
            return fileSystemManager.DirectoryContainsSaves(folderPath);
        }


        // Checks to the best of our ability if a folder is an Ubisoft Game Launcher savegames folder
        public bool IsCurrentSaveGamesFolder()
        {
            return fileSystemManager.IsAUbiSavesFolder;
        }

        // Private methods
        //---------------------------------

        private void updateBackedUpSavesStore()
        {
            backedUpSavesFullPaths = fileSystemManager.GetListOfBackedUpSaves();
        }

        private void updateBackUpList()
        {
            if (backedUpSavesFullPaths != null)
            {
                foreach (var folderName in backedUpSavesFullPaths)
                    listBoxBackedUpSaveGames.Items.Add(Path.GetFileName(folderName));
            }
            else
            {
                listBoxBackedUpSaveGames.Items.Add(Constants.NO_BACKED_UP_SAVES_FOUND);
            }
        }

        private void updateUbiIDsStore()
        {
            ubiIDsFullPaths = fileSystemManager.SaveGamesSubDirectories;
        }

        private void updateUbiIDsList()
        {
            if (ubiIDsFullPaths != null)
            {
                if (IsCurrentSaveGamesFolder())
                {
                    foreach (var dir in ubiIDsFullPaths)
                        listBoxUbiIDs.Items.Add(Path.GetFileName(dir));
                }
            }
            else
                listBoxUbiIDs.Items.Add(Constants.NO_SAVES_FOUND);
        }

        private void updateDelButtonState()
        {
            if (listBoxBackedUpSaveGames.SelectedIndex >= 0)
                buttonDelete.Enabled = true;
            else
                buttonDelete.Enabled = false;
        }

        // Events
        //---------------------------------

        private void updateBackedUpSaveGamesListHandler(object sender, EventArgs arguments)
        {
            buttonDelete.Enabled = false;
            listBoxBackedUpSaveGames.Items.Clear();
            updateBackedUpSavesStore();
            updateBackUpList();         
        }

        private void updateDeleteButtonStateHandler(object sender, EventArgs arguments)
        {
            updateDelButtonState();
        }

        private void updateBackupButtonStateHandler(object sender, EventArgs arguments)
        {
            int index = listBoxUbiIDs.SelectedIndex;
            string currentSelectedBackUp = ubiIDsFullPaths[index];
            buttonBackup.Enabled = CurrentFolderContainsSaves(currentSelectedBackUp) ? true : false;
        }


        private void updateUbiIDsListHandler(object sender, EventArgs arguments)
        {
            listBoxUbiIDs.Items.Clear();
            updateUbiIDsStore();
            updateUbiIDsList();
        }


        // Output current FC5 savegame info
        private void updateSaveGameInfoHandler(object sender, EventArgs arguments)
        {
            if (listBoxUbiIDs.SelectedItem != null)
            {
                int index = listBoxUbiIDs.SelectedIndex;             
                string currentIDDir = ubiIDsFullPaths[index];

                if (CurrentFolderContainsSaves(currentIDDir))
                    textBoxSaveInfo.Text = GetSaveFileInfo(currentIDDir);
                else
                    textBoxSaveInfo.Text = Constants.FILES_NOT_FOUND;
            }
        }
    }
}
