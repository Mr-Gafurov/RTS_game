using UnityEngine;

namespace Generals.Core
{
    [CreateAssetMenu(fileName = "NewMission", menuName = "Generals/Mission")]
    public class MissionData : ScriptableObject
    {
        public string missionId;
        public string title;
        [TextArea] public string description;
        public string sceneName;
        public bool isCompleted;

        [Header("Награды")]
        public int rewardMoney;
        public string unlockTechId; // ID технологии, которая открывается после миссии
    }
}
