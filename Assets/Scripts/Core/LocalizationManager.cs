using UnityEngine;
using System.Collections.Generic;
using System;

namespace Generals.Core
{
    public enum Language
    {
        Russian,
        English,
        Chinese
    }

    /// <summary>
    /// Менеджер локализации.
    /// </summary>
    public class LocalizationManager : MonoBehaviour
    {
        public static LocalizationManager Instance { get; private set; }

        public Language currentLanguage = Language.Russian;

        private Dictionary<string, Dictionary<Language, string>> _dictionary = new Dictionary<string, Dictionary<Language, string>>()
        {
            ["BUILD_BARRACKS"] = new Dictionary<Language, string> {
                [Language.Russian] = "Построить казарму",
                [Language.English] = "Build Barracks",
                [Language.Chinese] = "建造兵营"
            },
            ["NOT_ENOUGH_MONEY"] = new Dictionary<Language, string> {
                [Language.Russian] = "Недостаточно средств",
                [Language.English] = "Insufficient funds",
                [Language.Chinese] = "资金不足"
            }
        };

        private void Awake()
        {
            Instance = this;
        }

        public string GetText(string key)
        {
            if (_dictionary.ContainsKey(key))
                return _dictionary[key][currentLanguage];
            return key;
        }
    }
}
