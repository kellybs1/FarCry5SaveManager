/*
    Class: Constants
    Purpose: Contains constant values relevant to the FarCry5SaveManager project
    Controlling class: None, class is static
    */

namespace FarCry5SaveManager
{
    public static class Constants
    {
        public struct Errors
        {
            public static string NO_SAVES_FOUND = "No saves found";
            public static string NO_BACKED_UP_SAVES_FOUND = "No backed up saves found";
            public static string FILE_NOT_FOUND = "File not found";
            public static string FILES_NOT_FOUND = "Both save files not found";
        }

        public enum Storefront
        {
            UPlay,
            Steam
        }

        public struct GameIDs
        {
            public static string FC5_UPLAY_GAME_ID = "1803";
            public static string FC5_STEAM_GAME_ID = "856";
        }


        public struct SystemFolderPaths
        {
            public static string APPDATA_FOLDER_NAME = @"GoofyIdiotSoft\.farcry5savemanager";
            public static string DEFAULT_SAVEGAME_LOCATION = @"C:\Program Files (x86)\Ubisoft\Ubisoft Game Launcher\savegames";
        }


        public struct DefaultSaveFileNames
        {
            public static string FC5_FIRST_SAVE_NAME = "1.save";
            public static string FC5_SECOND_SAVE_NAME = "2.save";
        }


    }
}
