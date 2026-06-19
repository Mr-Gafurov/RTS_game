using UnityEngine;

using Generals.Core;
namespace Generals.Combat
{
    using Generals.Units;

    /// <summary>
    /// Кибер-атака: Вирус, захватывающий вражеские дроны.
    /// </summary>
    public class CyberVirus : MonoBehaviour
    {
        public float duration = 15f;

        public void InjectVirus(BaseUnit target)
        {
            if (target.unitName.Contains("Drone"))
            {
                Debug.Log($"[Cyber] Вирус внедрен в {target.unitName}!");
                // Временная смена фракции юнита
                FactionType originalFaction = target.faction;
                target.faction = FactionType.USA; // Пример: переходит к нам

                // Таймер возврата
            }
        }
    }
}
