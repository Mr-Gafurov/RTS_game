using UnityEngine;
using System.Collections.Generic;

namespace Generals.Core
{
    public enum MissionObjectiveType
    {
        DestroyAllBuildings,
        DestroySpecificTarget,
        CaptureFlag,
        Survival
    }

    /// <summary>
    /// Контейнер данных для миссии.
    /// </summary>
    [CreateAssetMenu(fileName = "MissionData", menuName = "Generals/MissionData")]
    public class MissionData : ScriptableObject
    {
        public string missionName;
        [TextArea] public string description;
        public Language language;

        public MissionObjectiveType objectiveType;
        public GameObject targetPrefab;

        [Header("Награды")]
        public int rewardMoney;
        public string unlockUnitKey;

        [Header("Настройки карты")]
        public string sceneName;
    }
}
