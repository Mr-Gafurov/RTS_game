using UnityEngine;
using System.Collections.Generic;

namespace Generals.Core
{
    /// <summary>
    /// Данные региона на глобальной карте.
    /// </summary>
    [CreateAssetMenu(fileName = "RegionData", menuName = "Generals/RegionData")]
    public class RegionData : ScriptableObject
    {
        public string regionId;
        public string regionName;
        public FactionType currentOwner;
        public int strategicValue;
        public string missionScene;
        public List<string> adjacentRegions;
    }
}
