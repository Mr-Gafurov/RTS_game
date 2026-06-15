using UnityEngine;
using System.Collections.Generic;

namespace Generals.Buildings
{
    using Generals.Units;

    /// <summary>
    /// Командный центр. Главное здание базы.
    /// </summary>
    public class CommandCenter : BaseBuilding
    {
        protected override void Start()
        {
            buildingName = "Command Center";
            maxHealth = 2000f;
            cost = 2000;
            energyConsumption = 0; // Не потребляет, а возможно генерирует
            base.Start();
        }

        // Логика производства строителей или вызова спецспособностей
    }
}
