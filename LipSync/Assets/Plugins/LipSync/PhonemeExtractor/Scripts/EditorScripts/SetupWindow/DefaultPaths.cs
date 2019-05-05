﻿using UnityEngine;
using System.IO;

namespace PhonemeExtractor.SetupWindow
{
    public class DefaultPaths
    {
        public static string defaultPluginPath
        {
            get => Path.Combine(Application.dataPath, "Plugins", "LipSync", "PhonemeExtractor", "PhonemeExtractor.jar");
        }
        public static string defaultAcousticModelPath
        {
            get => Path.Combine(Application.dataPath, "Plugins", "LipSync", "PhonemeExtractor", "RecognizerData", "AcousticModel");
        }
        public static string defaultDictionaryPath
        {
            get => Path.Combine(Application.dataPath, "Plugins", "LipSync", "PhonemeExtractor", "RecognizerData", "cmudict-en-us.dict");
        }
        public static string defaultTempFolderPath
        {
            get => Path.Combine(Application.dataPath, "Plugins", "LipSync", "PhonemeExtractor", "Temp");
        }
    }
}