using UnityEngine;
using System.Collections.Generic;

namespace Generals.Core.Cloud
{
    /// <summary>
    /// Управление экономикой и инвентарем через PlayFab.
    /// </summary>
    public class PlayFabEconomyManager : MonoBehaviour
    {
        public void GetInventory()
        {
            Debug.Log("[PlayFab] Запрос инвентаря игрока...");
            // Вызов PlayFabClientAPI.GetUserInventory
        }

        public void PurchaseItem(string itemId, int price, string currencyCode)
        {
            Debug.Log($"[PlayFab] Покупка предмета {itemId} за {price} {currencyCode}");
            // Вызов PlayFabClientAPI.PurchaseItem
        }

        public void GrantReward(string catalogItemId)
        {
            // Используется для выдачи наград за миссии через облако
            Debug.Log($"[PlayFab] Награда выдана: {catalogItemId}");
        }
    }
}
