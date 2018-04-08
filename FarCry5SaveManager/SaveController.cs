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
        private FC5SaveFileSystemManager saveFileSystemManager;
        private TextBox textBoxSaveFolderPath;
        private ListBox listBoxUbiIDs;
        private ListBox listBoxBackedUpSaveGames;
        private TextBox textBoxSaveInfo;
        private TextBox textBoxTitle;
        private Button buttonBackup;
        private Button buttonDelete;
        private Button buttonLoadSave;
        // Arrays for storing full paths to locations
        private string[] ubiIDsFullPaths;
        private string[] backedUpSavesFullPaths;


        // Constructor
        //---------------------------------
        public SaveController(TextBox formTextBoxSaveFolderPath, 
                                ListBox formListBoxUbiIDs, 
                                ListBox formListBoxBackedUpSaveGames,
                                TextBox formTextBoxSaveInfo,
                                TextBox formTextBoxTitle,
                                Button formButtonBackup,
                                Button formButtonDelete,
                                Button formButtonLoadSave)
        {

            // Don't fuck up the order of initialisation... it's... fragile
            saveFileSystemManager = new FC5SaveFileSystemManager();
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
            buttonLoadSave = formButtonLoadSave;
            listBoxUbiIDs.SelectedIndexChanged += updateBackupButtonStateHandler;
            textBoxSaveInfo = formTextBoxSaveInfo;
            textBoxTitle = formTextBoxTitle;
            textBoxTitle.TextChanged += SanitiseInputHandler;
            updateBackedUpSavesStore();
            updateBackUpList();
            saveFileSystemManager.BackupsUpdatedEvent += updateBackedUpSaveGamesListHandler;
            updateDelButtonState();
            listBoxBackedUpSaveGames.SelectedIndexChanged += updateDeleteButtonStateHandler;
            updateLoadButtonState();
            saveFileSystemManager.BackupsUpdatedEvent += updateLoadButtonStateHandler;         
            saveFileSystemManager.BackupsUpdatedEvent += updateDeleteButtonStateHandler;
            saveFileSystemManager.BackupsUpdatedEvent += deselectLoadAndUpdateButtonsHandler;
            listBoxBackedUpSaveGames.SelectedIndexChanged += updateLoadButtonStateHandler;
            listBoxUbiIDs.SelectedIndexChanged += updateLoadButtonStateHandler;
            listBoxUbiIDs.SelectedIndexChanged += deselectLoadAndUpdateButtonsHandler;
        }

        // Public methods
        //---------------------------------

        // Load the backup save over the current save
        public void LoadSave()
        {
            saveFileSystemManager.OverWriteCurrentSaveWithBackup("penis");
        }

        // Sets a new folder path both on screen and for management
        public void SetNewFolderPath(string folderPath)
        {
            saveFileSystemManager.SaveGamesFolderPath = folderPath;
            textBoxSaveFolderPath.Text = folderPath;
        }


        // Back up the current saveGame
        public bool BackupSaveFiles()
        {
            int index = listBoxUbiIDs.SelectedIndex;
            string pathToSave = ubiIDsFullPaths[index];
            return saveFileSystemManager.BackupSave(pathToSave, textBoxTitle.Text);
        }

        // Delete the selected save
        public bool DeleteSaveFile()
        {
            int index = listBoxBackedUpSaveGames.SelectedIndex;
            string pathToDel = backedUpSavesFullPaths[index];
            return saveFileSystemManager.DeleteBackup(pathToDel);
        }


        // Fetches current save file meta data
        public string GetSaveFileInfo(string filePath)
        {
            return saveFileSystemManager.GetFileInformation(filePath);
        }


        // Check if the current folder actually has FC5 saves in it
        public bool CurrentFolderContainsSaves(string folderPath)
        {
            return saveFileSystemManager.DirectoryContainsSaves(folderPath);
        }


        // Checks to the best of our ability if a folder is an Ubisoft Game Launcher savegames folder
        public bool IsCurrentSaveGamesFolder()
        {
            return saveFileSystemManager.IsAUbiSavesFolder;
        }

        // Private methods
        //---------------------------------



        private void updateBackedUpSavesStore()
        {
            backedUpSavesFullPaths = saveFileSystemManager.GetListOfBackedUpSaves();
        }

        private void updateBackUpList()
        {
            if (backedUpSavesFullPaths != null && backedUpSavesFullPaths.Length > 0)
            {
                int savesCount = backedUpSavesFullPaths.Length;
                for (int i = 0; i < savesCount; i++)
                    listBoxBackedUpSaveGames.Items.Add(Path.GetFileName(backedUpSavesFullPaths[i]));
            }
        }

        private void updateUbiIDsStore()
        {
            ubiIDsFullPaths = saveFileSystemManager.SaveGamesSubDirectories;
        }

        private void updateUbiIDsList()
        {
                if (IsCurrentSaveGamesFolder())
                {
                    if (ubiIDsFullPaths != null)
                        foreach (var dir in ubiIDsFullPaths)
                            listBoxUbiIDs.Items.Add(Path.GetFileName(dir));
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

        private void sanitiseInput()
        {
            textBoxTitle.Text = string.Concat(textBoxTitle.Text.Where(char.IsLetterOrDigit));
            textBoxTitle.SelectionStart = textBoxTitle.Text.Length + 1;
        }

        private void updateLoadButtonState()
        {
            int index = listBoxUbiIDs.SelectedIndex;
            if (index >= 0)
            {
                string currentSelectedBackUp = ubiIDsFullPaths[index];

                if (listBoxBackedUpSaveGames.SelectedIndex >= 0 &&
                     CurrentFolderContainsSaves(currentSelectedBackUp))
                    buttonLoadSave.Enabled = true;
            }
            else
                buttonLoadSave.Enabled = false;
        }

        private void updateBackupButtonState()
        {
            int index = listBoxUbiIDs.SelectedIndex;
            string currentSelectedBackUp = ubiIDsFullPaths[index];
            buttonBackup.Enabled = CurrentFolderContainsSaves(currentSelectedBackUp) ? true : false;
        }


        private void deselectLoadAndUpdateButtons()
        {
            listBoxBackedUpSaveGames.SelectedIndex = -1;
            buttonLoadSave.Enabled = false;
            buttonDelete.Enabled = false;
        }

        // Events
        //---------------------------------

        private void deselectLoadAndUpdateButtonsHandler(object sender, EventArgs arguments)
        {
            deselectLoadAndUpdateButtons();
        }


        private void updateLoadButtonStateHandler(object sender, EventArgs arguments)
        {
            updateLoadButtonState();
        }

        private void SanitiseInputHandler(object sender, EventArgs arguments)
        {
            sanitiseInput();
        }

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
            updateBackupButtonState();
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
