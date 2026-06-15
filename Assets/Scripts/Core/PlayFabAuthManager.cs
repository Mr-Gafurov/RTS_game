using UnityEngine;
using System;
using System.Collections.Generic;

namespace Generals.Core.Cloud
{
    /// <summary>
    /// Интеграция с PlayFab: Авторизация и профиль игрока.
    /// </summary>
    public class PlayFabAuthManager : MonoBehaviour
    {
        public static PlayFabAuthManager Instance { get; private set; }

        public string playFabTitleId = "YOUR_TITLE_ID";
        public bool isLoggedIn = false;
        public string myPlayFabId;

        private void Awake()
        {
            Instance = this;
        }

        public void LoginWithEmail(string email, string password)
        {
            Debug.Log($"[PlayFab] Попытка входа: {email}");
            // Здесь были бы вызовы PlayFabClientAPI.LoginWithEmailAddress
            SimulateLogin(email);
        }

        public void LoginWithDeviceId()
        {
            Debug.Log("[PlayFab] Вход через Device ID...");
            SimulateLogin("DeviceUser");
        }

        private void SimulateLogin(string username)
        {
            isLoggedIn = true;
            myPlayFabId = "MOCK_ID_" + UnityEngine.Random.Range(1000, 9999);
            Debug.Log($"[PlayFab] Успешный вход! ID: {myPlayFabId}");
        }

        public void SavePlayerData(string key, string value)
        {
            if (!isLoggedIn) return;
            Debug.Log($"[PlayFab] Сохранение данных: {key} = {value}");
            // Вызов PlayFabClientAPI.UpdateUserData
        }
    }
}
