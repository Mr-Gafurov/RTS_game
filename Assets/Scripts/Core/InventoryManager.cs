using UnityEngine;
using System.Collections.Generic;
using System;

namespace Generals.Core
{
    [Serializable]
    public class InventoryItem
    {
        public string id;
        public string itemName;
        public string type; // Skin, Hero, Boost
        public bool isEquipped = false;
    }

    /// <summary>
    /// Менеджер инвентаря игрока.
    /// </summary>
    public class InventoryManager : MonoBehaviour
    {
        public static InventoryManager Instance { get; private set; }

        public List<InventoryItem> items = new List<InventoryItem>();

        private void Awake()
        {
            Instance = this;
        }

        public void AddItem(string id, string name, string type)
        {
            items.Add(new InventoryItem { id = id, itemName = name, type = type });
            Debug.Log($"[Inventory] Добавлен предмет: {name}");
        }

        public void EquipItem(string id)
        {
            foreach (var item in items)
            {
                if (item.id == id) item.isEquipped = true;
                else if (item.type == "Skin") item.isEquipped = false; // Пример для скинов
            }
        }
    }
}
