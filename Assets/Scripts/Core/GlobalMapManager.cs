using UnityEngine;
using System.Collections.Generic;

namespace Generals.Core
{
    /// <summary>
    /// Менеджер глобальной карты и захвата мира.
    /// </summary>
    public class GlobalMapManager : MonoBehaviour
    {
        public static GlobalMapManager Instance { get; private set; }

        public List<RegionData> worldRegions = new List<RegionData>();

        private void Awake()
        {
            Instance = this;
        }

        public void CaptureRegion(string regionId, FactionType newOwner)
        {
            var region = worldRegions.Find(r => r.regionId == regionId);
            if (region != null)
            {
                region.currentOwner = newOwner;
                Debug.Log($"[GlobalMap] Регион {region.regionName} захвачен фракцией {newOwner}!");
                // Обновление UI карты
            }
        }
    }
}
