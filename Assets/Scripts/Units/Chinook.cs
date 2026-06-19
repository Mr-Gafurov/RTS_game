using UnityEngine;
using System.Collections.Generic;

using Generals.Core;
namespace Generals.Units.USA
{
    /// <summary>
    /// Вертолет Чинук. Собирает ресурсы и перевозит пехоту.
    /// </summary>
    public class Chinook : BaseUnit
    {
        [Header("Транспорт")]
        public int capacity = 5;
        public List<GameObject> passengers = new List<GameObject>();

        protected override void Start()
        {
            unitName = "Chinook Transport";
            faction = FactionType.USA;
            maxHealth = 200f;
            movementSpeed = 10f;
            cost = 1200;
            base.Start();
        }

        public void LoadInfantry(GameObject unit)
        {
            if (passengers.Count < capacity)
            {
                passengers.Add(unit);
                unit.SetActive(false);
                Debug.Log("[Chinook] Пехота погружена.");
            }
        }

        public void UnloadAll()
        {
            foreach (var unit in passengers)
            {
                unit.transform.position = transform.position;
                unit.SetActive(true);
            }
            passengers.Clear();
            Debug.Log("[Chinook] Все выгружены.");
        }
    }
}
