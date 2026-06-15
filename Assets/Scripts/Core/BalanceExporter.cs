using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace Generals.Core
{
    using Generals.Units;

    /// <summary>
    /// Инструмент для экспорта баланса всех юнитов.
    /// </summary>
    public class BalanceExporter : MonoBehaviour
    {
        public List<UnitData> allUnits;

        [ContextMenu("Export Balance to CSV")]
        public void ExportToCSV()
        {
            string path = Path.Combine(Application.dataPath, "balance_export.csv");
            string content = "UnitName,Faction,HP,Damage,Range,Speed,Cost\n";

            foreach (var unit in allUnits)
            {
                content += $"{unit.unitName},{unit.faction},{unit.maxHealth},{unit.damage},{unit.attackRange},{unit.movementSpeed},{unit.cost}\n";
            }

            File.WriteAllText(path, content);
            Debug.Log($"[BalanceExporter] Данные экспортированы в {path}");
        }
    }
}
