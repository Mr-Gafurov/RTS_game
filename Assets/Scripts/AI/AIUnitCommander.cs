using UnityEngine;
using System.Collections.Generic;
using Generals.Units;

namespace Generals.AI
{
    /// <summary>
    /// Контроллер юнитов ИИ (атака/защита).
    /// </summary>
    public class AIUnitCommander : MonoBehaviour
    {
        public List<BaseUnit> myUnits = new List<BaseUnit>();
        public Transform enemyBase;

        public void CommandUnits()
        {
            if (myUnits.Count >= 5) // Собираем ударный кулак
            {
                AttackEnemyBase();
            }
        }

        private void AttackEnemyBase()
        {
            if (enemyBase == null) return;

            foreach (var unit in myUnits)
            {
                if (unit != null)
                {
                    // Логика движения к базе противника через UnitMovement
                    Debug.Log($"[AI] Юнит {unit.unitName} атакует базу противника!");
                }
            }
        }

        public void RegisterUnit(BaseUnit unit)
        {
            if (!myUnits.Contains(unit)) myUnits.Add(unit);
        }
    }
}
