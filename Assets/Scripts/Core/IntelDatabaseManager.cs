using UnityEngine;
using System.Collections.Generic;

namespace Generals.Core
{
    /// <summary>
    /// Внутриигровая энциклопедия юнитов и технологий.
    /// </summary>
    public class IntelDatabaseManager : MonoBehaviour
    {
        public List<UnitData> discoveredUnits = new List<UnitData>();

        public void DiscoverUnit(UnitData data)
        {
            if (!discoveredUnits.Contains(data))
            {
                discoveredUnits.Add(data);
                Debug.Log($"[Intel] Получены разведданные о юните: {data.unitName}");
            }
        }

        public void OpenEncyclopedia()
        {
            // Визуализация списка юнитов с их ТТХ
        }
    }
}
