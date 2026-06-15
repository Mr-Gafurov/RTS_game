using UnityEngine;
using System;

namespace Generals.Core
{
    /// <summary>
    /// Простая система сохранений через PlayerPrefs (для прототипа).
    /// </summary>
    public static class SaveSystem
    {
        private const string MONEY_KEY = "PlayerMoney";
        private const string LEVEL_KEY = "CurrentLevel";

        public static void SaveGame(float money, int level)
        {
            PlayerPrefs.SetFloat(MONEY_KEY, money);
            PlayerPrefs.SetInt(LEVEL_KEY, level);
            PlayerPrefs.Save();
            Debug.Log("[SaveSystem] Игра сохранена.");
        }

        public static (float money, int level) LoadGame()
        {
            float money = PlayerPrefs.GetFloat(MONEY_KEY, 1000f);
            int level = PlayerPrefs.GetInt(LEVEL_KEY, 1);
            return (money, level);
        }
    }
}
