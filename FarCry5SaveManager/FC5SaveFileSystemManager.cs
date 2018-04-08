using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FarCry5SaveManager
{
    public class FC5SaveFileSystemManager
    {
        public event EventHandler BackupsUpdatedEvent;

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
                return Directory.GetDirectories(SaveGamesFolderPath);
            }
        }

        // Public methods
        //---------------------------------
        public string GetFileInformation(string filePath)
        {
            // If bothexist return both info
            if (DirectoryContainsSaves(filePath))
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
                // if neither exists the save isn't safe
                return Constants.FILES_NOT_FOUND;
            }
            
        }


        public bool DirectoryContainsSaves(string filePath)
        {
            // Check for saves 1 and 2
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

        public bool BackupSave(string idSaveDir)
        {
            string direc = "";
            try
            {
                string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string myPath = appData + @"\" + Constants.APPDATA_FOLDER_NAME;

                if (!Directory.Exists(myPath))
                    Directory.CreateDirectory(myPath);

                DateTime date = DateTime.Now;
                String timeStr = date.ToString("HH:mm:ss.fff");
                String dateStr = date.ToString("MM/dd/yyyy");
                //remove characters filenames don't like
                timeStr = timeStr.Replace(':', '_');
                dateStr = dateStr.Replace('/', '_');
                String folderName = Constants.FC5_GAME_ID + "_" + dateStr + "_" + timeStr;
                folderName = folderName.Replace(" ", "");

                // Create folder and save path for deletion upon failure
                string backupLocation = myPath + @"\" + folderName;
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
    }
}
