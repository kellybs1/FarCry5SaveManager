using System;
using System.IO;

namespace FarCry5SaveManager
{
    public class FC5SaveFileSystemManager
    {
        public event EventHandler BackupsUpdatedEvent;
        public event EventHandler BackupLoadedEvent;

        // Constructor
        //---------------------------------

        public FC5SaveFileSystemManager()
        {
            SaveGamesFolderPath = Constants.DEFAULT_SAVEGAME_LOCATION;
        }


        // Properties
        //---------------------------------

        public bool IsAUbiSavesFolder
        {
            get
            {
                return SaveGamesFolderPath.EndsWith("savegames");
            }
        }


        public string SaveGamesFolderPath { get; set; }


        public string[] SaveGamesSubDirectories
        { get
            {
                if (Directory.Exists(SaveGamesFolderPath))
                    return Directory.GetDirectories(SaveGamesFolderPath);
                else
                    return null;
            }
        }


        // Public methods
        //---------------------------------

        public bool OverWriteCurrentSaveWithBackup(string idSaveDir, string backupSaveDir)
        {
            string gameSavesDir = "";
            // Delete current save file 
            try
            {
                gameSavesDir = idSaveDir + @"\" + Constants.FC5_GAME_ID;
                if (!Directory.Exists(gameSavesDir))
                    Directory.CreateDirectory(gameSavesDir);
                else
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(gameSavesDir);
                    FileInfo[] files = dirInfo.GetFiles();

                    if (files != null)
                        foreach (var file in files)
                            file.Delete();
                }
            }
            catch (IOException)
            {
                return false;
            }

            // Overwrite with back up
            try
            {
                if (!Directory.Exists(backupSaveDir))
                    return false;
                else
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(backupSaveDir);
                    FileInfo[] files = dirInfo.GetFiles();

                    foreach (var file in files)
                        file.CopyTo(gameSavesDir + @"\" + file.Name, false);

                    //Trigger refresh - make sure controller refreshes current save on this event
                    OnBackupLoaded();
                    return true;    
                }
            }
            catch (IOException)
            {
                return false;
            }  
        }


        public string GetFileInformation(string filePath)
        {
            // If both exist return both info
            if (IDDirectoryContainsSaves(filePath))
            {
                string savePath1 = filePath + @"\" + Constants.FC5_GAME_ID + @"\" + Constants.FC5_FIRST_SAVE_NAME;
                string savePath2 = filePath + @"\" + Constants.FC5_GAME_ID + @"\" + Constants.FC5_SECOND_SAVE_NAME;
                FileInfo saveInfo1 = new FileInfo(savePath1);
                FileInfo saveInfo2 = new FileInfo(savePath2);

                string info1 = Constants.FC5_FIRST_SAVE_NAME + " : " + saveInfo1.LastWriteTime;
                string info2 = Constants.FC5_SECOND_SAVE_NAME + " : " + saveInfo2.LastWriteTime;
                return info1 + " , " + info2;
            }
            else
            {
                // if neither exists the save isn't safe to use
                return Constants.FILES_NOT_FOUND;
            }
            
        }


        public bool FullDirectoryContainsSaves(string filePath)
        {
            // Check for saves 1 and 2
            string savePath1 = filePath + @"\" + Constants.FC5_FIRST_SAVE_NAME;
            string savePath2 = filePath + @"\" + Constants.FC5_SECOND_SAVE_NAME;

            return File.Exists(savePath1) && File.Exists(savePath2);
        }


        public bool IDDirectoryContainsSaves(string filePath)
        {
            // Check for saves 1 and 2 but include game folder
            string savePath1 = filePath + @"\" + Constants.FC5_GAME_ID + @"\" + Constants.FC5_FIRST_SAVE_NAME;
            string savePath2 = filePath + @"\" + Constants.FC5_GAME_ID + @"\" + Constants.FC5_SECOND_SAVE_NAME;

            return File.Exists(savePath1) && File.Exists(savePath2);
        }


        public bool DeleteBackup(string folderPath)
        {
            try
            {
                // Delete all the files in the directory
                DirectoryInfo dirInfo = new DirectoryInfo(folderPath);
                FileInfo[] files = dirInfo.GetFiles();
                foreach (var file in files)
                    file.Delete();

                // Now delete directory
                Directory.Delete(folderPath);

                // Trigger updates
                OnBackupsUpdated();
                return true;
            }
            catch (IOException)
            {
                return false;
            }
        }


        public bool BackupSave(string idSaveDir, string title)
        {
            string direc = "";
            try
            {
                // Generate the Appdata folder where we save our backups
                string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string myPath = appData + @"\" + Constants.APPDATA_FOLDER_NAME;

                if (!Directory.Exists(myPath))
                    Directory.CreateDirectory(myPath);

                //Make a super-wicked-cool-time-based-unique save folder name
                DateTime date = DateTime.Now;
                String timeStr = date.ToString("HH:mm:ss.fff");
                String dateStr = date.ToString("MM/dd/yyyy");
                //remove characters filenames don't like
                timeStr = timeStr.Replace(':', '_');
                dateStr = dateStr.Replace('/', '_');
                String folderName = Constants.FC5_GAME_ID + "_" + dateStr + "_" + timeStr;
                folderName = folderName.Replace(" ", "");

                // Create folder and save path for deletion upon failure
                string backupLocation = myPath + @"\" + title + folderName;
                Directory.CreateDirectory(backupLocation);
                direc = backupLocation;

                // Copy the files to backup location
                string sourceDir = idSaveDir + @"\" + Constants.FC5_GAME_ID;
                DirectoryInfo dirInfo = new DirectoryInfo(sourceDir);
                FileInfo[] files = dirInfo.GetFiles();

                foreach (var file in files)
                    file.CopyTo(backupLocation + @"\" + file.Name, false);

                OnBackupsUpdated();
                return true;
            }
            catch (IOException)
            {
                //delete the failed directory if it was created
                if (direc != "")
                    Directory.Delete(direc);

                return false;
            }

        }


        public string[] GetListOfBackedUpSaves()
        {
            // Use the AppData location to get a list of backed up saves
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string myPath = appData + @"\" + Constants.APPDATA_FOLDER_NAME;
            if (Directory.Exists(myPath))
                return  Directory.GetDirectories(myPath);
            else
                return null;
        }


        // Events
        // -----------------------------
        public void OnBackupsUpdated()
        {
            BackupsUpdatedEvent?.Invoke(this, new EventArgs());
        }

        public void OnBackupLoaded()
        {
            BackupLoadedEvent?.Invoke(this, new EventArgs());
        }
    }
}
