﻿namespace PhonemeExtractor.SetupWindow
{
    public class CurrentPaths
    {
        public string PluginPath { get; set; }
        public string AcousticModelPath { get; set; }
        public string DictionaryPath { get; set; }
        public string TempFolderPath { get; set; }
        public string DialogueDataSavingPath { get; set; }

        public CurrentPaths(string pluginPath, string acousticModelPath, string dictionaryPath, string tempFolderPath, string dialogueDataSavingPath)
        {
            PluginPath = pluginPath;
            AcousticModelPath = acousticModelPath;
            DictionaryPath = dictionaryPath;
            TempFolderPath = tempFolderPath;
            DialogueDataSavingPath = dialogueDataSavingPath;
        }
    }
}