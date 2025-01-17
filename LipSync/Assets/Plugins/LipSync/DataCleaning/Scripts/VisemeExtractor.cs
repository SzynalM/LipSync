﻿using System.Collections.Generic;
using UnityEngine;

namespace VisemeExtraction
{
    public class VisemeExtractor
    {
        private string[] phonemesInWord;
        private string phonemes = "";
        private string timings = "";

        private Dictionary<string, Viseme> phonemeToVisemeDictionary;

        public List<ScriptableObject> ExtractVisemes(string[] text)
        {
            try
            {
                List<ScriptableObject> visemes = new List<ScriptableObject>();

                for (int i = 0; i < text.Length; i++)
                {
                    text[i] = text[i].Substring(1);
                    phonemes = text[i].Split(')')[0].Trim();
                    timings = text[i].Split(')')[1].Trim();
                    phonemesInWord = phonemes.Split(' ');
                    for (int j = 0; j < phonemesInWord.Length; j++)
                    {
                        phonemeToVisemeDictionary = CreateDictionary();
                        if (phonemeToVisemeDictionary.ContainsKey(phonemesInWord[j]))
                        {
                            Viseme currentViseme = phonemeToVisemeDictionary[phonemesInWord[j]];
                            GetVisemeTimings(currentViseme, int.Parse(timings.Split(':')[0]), int.Parse(timings.Split(':')[1]), phonemesInWord.Length, j);
                            visemes.Add(currentViseme);
                        }
                    }
                }
                DataCleaning.LoadingBarViewer.Instance.SetNextPhase();
                return visemes;
            }
            catch (System.Exception e)
            {
                Debug.Log("Viseme extration failed\n" + e);
                return null;
            }
        }

        private void GetVisemeTimings(Viseme viseme, int startTime, int endTime, int amountOfPhonemesInWord, int index)
        {
            int interval = endTime - startTime;
            int visemeDuration = Mathf.RoundToInt(interval / amountOfPhonemesInWord);
            viseme.startTime = startTime + visemeDuration * index;
            viseme.endTime = startTime + visemeDuration * (index + 1);
        }

        private Dictionary<string, Viseme> CreateDictionary()
        {
            return new Dictionary<string, Viseme>(){
                    {"AA", ScriptableObject.CreateInstance<Viseme_AA>().Init(0.5f, 0.6f)},
                    {"AE", ScriptableObject.CreateInstance<Viseme_AA>().Init(0.4f, 0.6f) },
                    {"AH", ScriptableObject.CreateInstance<Viseme_AA>().Init(.6f, 0.6f) },
                    {"AO", ScriptableObject.CreateInstance<Viseme_OO>().Init(.8f, 0.9f) },
                    {"B", ScriptableObject.CreateInstance<Viseme_BM>().Init(0.25f, 1) },
                    {"CH", ScriptableObject.CreateInstance<Viseme_CH>().Init(1, 0.85f) },
                    {"D", ScriptableObject.CreateInstance<Viseme_IH>().Init(0.3f, 0.85f) },
                    {"DH", ScriptableObject.CreateInstance<Viseme_Mixed>().Init(ScriptableObject.CreateInstance<Viseme_FV>().Init(0.5f, 1), ScriptableObject.CreateInstance<Viseme_AA>().Init(0.12f, 1)) },
                    {"EH", ScriptableObject.CreateInstance<Viseme_EE>().Init(0.7f, 0.8f) },
                    {"F", ScriptableObject.CreateInstance<Viseme_FV>().Init(0.3f, 1) },
                    {"G", ScriptableObject.CreateInstance<Viseme_EE>().Init(0.30f, 1) },
                    {"HH", ScriptableObject.CreateInstance<Viseme_AA>().Init(0.15f, 0.85f) }, //insignificant
                    {"IH", ScriptableObject.CreateInstance<Viseme_EE>().Init(0.55f, 0.8f) },
                    {"IY", ScriptableObject.CreateInstance<Viseme_IH>().Init(0.5f, 1) },
                    {"JH", ScriptableObject.CreateInstance<Viseme_CH>().Init(1, 1) },
                    {"K", ScriptableObject.CreateInstance<Viseme_AA>().Init(0.15f, 0.85f) }, //insignificant
                    {"L", ScriptableObject.CreateInstance<Viseme_Mixed>().Init(ScriptableObject.CreateInstance<Viseme_OO>().Init(0.22f, 0.8f), ScriptableObject.CreateInstance<Viseme_EE>().Init(0.3f, 0.8f)) },
                    {"M", ScriptableObject.CreateInstance<Viseme_BM>().Init(0.6f, 1) },
                    {"N", ScriptableObject.CreateInstance<Viseme_AA>().Init(0.15f, 0.85f) }, //insignificant
                    {"NG", ScriptableObject.CreateInstance<Viseme_EE>().Init(0.3f, 0.85f)  }, //insignificant
                    {"P",  ScriptableObject.CreateInstance<Viseme_BM>().Init(0.3f, 1)},
                    {"R", ScriptableObject.CreateInstance<Viseme_R>().Init(0.3f, 0.8f) },
                    {"S", ScriptableObject.CreateInstance<Viseme_R>().Init(0.2f, 0.8f) },
                    {"SH", ScriptableObject.CreateInstance<Viseme_CH>().Init(0.64f, 0.8f) },
                    {"SIL", ScriptableObject.CreateInstance<Viseme_Silence>()},
                    {"T", ScriptableObject.CreateInstance<Viseme_EE>().Init(0.3f, 1) }, //insignificant
                    {"TH", ScriptableObject.CreateInstance<Viseme_R>().Init(0.3f, 1) }, //insignificant
                    {"UH", ScriptableObject.CreateInstance<Viseme_UU>().Init(1, 1) },
                    {"UW", ScriptableObject.CreateInstance<Viseme_Mixed>().Init(ScriptableObject.CreateInstance<Viseme_AA>().Init(0.15f, 0.8f), ScriptableObject.CreateInstance<Viseme_UU>().Init(0.8f, 0.8f)) },
                    {"V", ScriptableObject.CreateInstance<Viseme_FV>().Init(0.75f, 1) },
                    {"W", ScriptableObject.CreateInstance<Viseme_UU>().Init(0.5f, 1) },
                    {"Y", ScriptableObject.CreateInstance<Viseme_EE>().Init(0.3f, 0.7f) },
                    {"Z", ScriptableObject.CreateInstance<Viseme_EE>().Init(0.2f, 0.7f) },
                    {"ZH", ScriptableObject.CreateInstance<Viseme_Mixed>().Init(ScriptableObject.CreateInstance<Viseme_EE>().Init(0.4f, 0.9f), ScriptableObject.CreateInstance<Viseme_CH>().Init(0.53f, 0.9f)) }
                };
        }
    }
}