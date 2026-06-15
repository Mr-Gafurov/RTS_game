using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Generals.Core.Balance
{
    /// <summary>
    /// Сервис для обновления баланса юнитов в реальном времени без перезапуска клиента.
    /// </summary>
    public class LiveBalanceService : MonoBehaviour
    {
        public string balanceApiUrl = "http://localhost:4000/api/balance/current";
        public float updateInterval = 300f; // 5 минут

        private void Start()
        {
            StartCoroutine(BalanceUpdateRoutine());
        }

        private IEnumerator BalanceUpdateRoutine()
        {
            while (true)
            {
                yield return StartCoroutine(DownloadLatestBalance());
                yield return new WaitForSeconds(updateInterval);
            }
        }

        private IEnumerator DownloadLatestBalance()
        {
            using (UnityWebRequest request = UnityWebRequest.Get(balanceApiUrl))
            {
                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log("[Balance] Последние настройки баланса получены.");
                    ApplyBalance(request.downloadHandler.text);
                }
            }
        }

        private void ApplyBalance(string json)
        {
            // Логика обновления полей в UnitData ScriptableObjects
        }
    }
}
