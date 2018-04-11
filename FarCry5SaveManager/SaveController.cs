using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FarCry5SaveManager
{
    public class SaveController
    {
        private FC5SaveFileSystemManager saveFileSystemManager;
        // Expected shit from form to handle
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
            textBoxSaveInfo = formTextBoxSaveInfo;
            textBoxTitle = formTextBoxTitle;
            buttonBackup = formButtonBackup;
            buttonDelete = formButtonDelete;
            buttonLoadSave = formButtonLoadSave;
            updateUbiIDsStore();
            updateUbiIDsList();
            ubiIDsFullPaths = new string[0];
            backedUpSavesFullPaths = new string[0];
            textBoxSaveFolderPath.TextChanged += updateUbiIDsListHandler;
            textBoxSaveFolderPath.TextChanged += updateSaveGameInfoHandler;
            textBoxSaveFolderPath.Text = Constants.DEFAULT_SAVEGAME_LOCATION;
            textBoxSaveFolderPath.TextChanged += updateBackupButtonStateHandler;
            listBoxUbiIDs.SelectedIndexChanged += updateSaveGameInfoHandler;
            listBoxUbiIDs.SelectedIndexChanged += updateBackupButtonStateHandler;
            textBoxTitle.TextChanged += sanitiseInputHandler;
            updateBackedUpSavesStore();
            updateBackUpList();
            saveFileSystemManager.BackupsUpdatedEvent += updateBackedUpSaveGamesListHandler;
            updateDelButtonState();
            updateLoadButtonState();
            listBoxBackedUpSaveGames.SelectedIndexChanged += updateDeleteButtonStateHandler;
            saveFileSystemManager.BackupsUpdatedEvent += updateDeleteButtonStateHandler;
            saveFileSystemManager.BackupsUpdatedEvent += deselectLoadAndUpdateButtonsHandler;
            saveFileSystemManager.BackupLoadedEvent += updateSaveGameInfoHandler;
            listBoxBackedUpSaveGames.SelectedIndexChanged += updateLoadButtonStateHandler;
            listBoxUbiIDs.SelectedIndexChanged += updateLoadButtonStateHandler;
            listBoxUbiIDs.SelectedIndexChanged += deselectLoadAndUpdateButtonsHandler;
            textBoxSaveFolderPath.TextChanged += updateLoadButtonStateHandler;
        }


        // Public methods
        //---------------------------------

        // Load the backup save over the current save
        public bool LoadSave()
        {
            int indexID = listBoxUbiIDs.SelectedIndex;
            string pathToLoadOver = ubiIDsFullPaths[indexID];
            int indexBackup = listBoxBackedUpSaveGames.SelectedIndex;
            string pathOfBackup = backedUpSavesFullPaths[indexBackup];
            return saveFileSystemManager.OverWriteCurrentSaveWithBackup(pathToLoadOver, pathOfBackup);
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


        // Private methods
        //---------------------------------

        // Check if the current folder actually has FC5 saves in it
        private bool idFolderContainsSaves(string folderPath)
        {
            return saveFileSystemManager.IDDirectoryContainsSaves(folderPath);
        }


        private bool fullFolderPathContainsSaves(string folderPath)
        {
            return saveFileSystemManager.FullDirectoryContainsSaves(folderPath);
        }


        // Checks to the best of our ability if a folder is an Ubisoft Game Launcher savegames folder
        // Could use improvement
        public bool IsCurrentSaveGamesFolder()
        {
            return saveFileSystemManager.IsAUbiSavesFolder;
        }

        // Fetches current save file meta data
        private string getSaveFileInfo(string filePath)
        {
            return saveFileSystemManager.GetFileInformation(filePath);
        }


        // Fetch a list of previously backed up games
        private void updateBackedUpSavesStore()
        {
            backedUpSavesFullPaths = saveFileSystemManager.GetListOfBackedUpSaves;
        }


        private void updateBackUpList()
        {
            // If we actually have an array of paths
            if (backedUpSavesFullPaths != null && backedUpSavesFullPaths.Length > 0)
            {
                // Output them
                int savesCount = backedUpSavesFullPaths.Length;
                for (int i = 0; i < savesCount; i++)
                    listBoxBackedUpSaveGames.Items.Add(Path.GetFileName(backedUpSavesFullPaths[i]));
            }
        }


        private void updateUbiIDsStore()
        {
            // Go grab all the subfolders' full paths from the ubisoft SaveGames directory
            // There's usually only one anyway but hey we could make backups in there if we want
            ubiIDsFullPaths = saveFileSystemManager.SaveGamesSubDirectories;
        }


        private void updateUbiIDsList()
        {
            // If the currently selected SavesGames folder IS a savegames folder
            if (IsCurrentSaveGamesFolder() && ubiIDsFullPaths != null)
            {
                foreach (var dir in ubiIDsFullPaths)
                    listBoxUbiIDs.Items.Add(Path.GetFileName(dir));
            }
            else
                listBoxUbiIDs.Items.Add(Constants.NO_SAVES_FOUND);
        }


        private void updateDelButtonState()
        {
            // If there's a selected backup, we can enable button
            if (listBoxBackedUpSaveGames.SelectedIndex >= 0)
                buttonDelete.Enabled = true;
            else
                buttonDelete.Enabled = false;
        }


        private void sanitiseInput()
        {
            //Stop people typing anything but letters and numbers in the title box
            textBoxTitle.Text = string.Concat(textBoxTitle.Text.Where(char.IsLetterOrDigit));
            // Move the cursor to the end of the textbox everytime a key is pressed, thank you StackOverflow for being usful for once
            textBoxTitle.SelectionStart = textBoxTitle.Text.Length + 1;
        }


        private void updateLoadButtonState()
        {
            buttonLoadSave.Enabled = false;
            // If there's a selected ID and Backup
            if (isUbiIDsFullPathsSafeToUse())
            {
                int indexID = listBoxUbiIDs.SelectedIndex;
                int indexBackup = listBoxBackedUpSaveGames.SelectedIndex;
                if (indexID >= 0 && indexBackup >= 0)
                {
                    string currentSelectedBackUp = backedUpSavesFullPaths[indexBackup];

                    if (fullFolderPathContainsSaves(currentSelectedBackUp) && idFolderContainsSaves(ubiIDsFullPaths[indexID]))
                        buttonLoadSave.Enabled = true;
                }
            }
        }


        private void updateBackupButtonState()
        {
            buttonBackup.Enabled = false;
            // If the selected ubiID folder contains backups allow the backup button
            if (isUbiIDsFullPathsSafeToUse())
            {
                int index = listBoxUbiIDs.SelectedIndex;
                if (index >= 0 && ubiIDsFullPaths != null)
                {
                    string currentSelectedBackUp = ubiIDsFullPaths[index];
                    if (idFolderContainsSaves(currentSelectedBackUp))
                        buttonBackup.Enabled = true;
                }
            }
        }


        private void deselectLoadAndUpdateButtons()
        {
            // Deselects the load and update buttons - important to remember to run something that can enable them after this
            listBoxBackedUpSaveGames.SelectedIndex = -1;
            buttonLoadSave.Enabled = false;
            buttonDelete.Enabled = false;
        }


        private void updateSaveGameInfo()
        {
            textBoxSaveInfo.Text = Constants.FILES_NOT_FOUND;
            if (isUbiIDsFullPathsSafeToUse())
            {
                if (ubiIDsFullPaths.Length > 0)
                {
                    int index = listBoxUbiIDs.SelectedIndex;
                    if (index >= 0 && ubiIDsFullPaths != null && ubiIDsFullPaths[index] != null)
                    {
                        string currentIDDir = ubiIDsFullPaths[index];

                        if (idFolderContainsSaves(currentIDDir))
                            textBoxSaveInfo.Text = getSaveFileInfo(currentIDDir);
                    }
                }
            }

        }


        // Event Handlers
        //---------------------------------

        private bool isUbiIDsFullPathsSafeToUse()
        {
            if (ubiIDsFullPaths == null)
                return false;

            if (ubiIDsFullPaths.Length == 0)
                return false;

            return true;
        }


        private void deselectLoadAndUpdateButtonsHandler(object sender, EventArgs arguments)
        {
            deselectLoadAndUpdateButtons();
        }


        private void updateLoadButtonStateHandler(object sender, EventArgs arguments)
        {
            updateLoadButtonState();
        }


        private void sanitiseInputHandler(object sender, EventArgs arguments)
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
            updateSaveGameInfo();
        }
    }
}
