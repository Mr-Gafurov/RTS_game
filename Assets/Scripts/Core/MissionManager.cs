using UnityEngine;
using System.Collections.Generic;

namespace Generals.Core
{
    /// <summary>
    /// Менеджер миссий и кампании.
    /// </summary>
    public class MissionManager : MonoBehaviour
    {
        public static MissionManager Instance { get; private set; }

        public List<MissionData> campaignMissions = new List<MissionData>();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void CompleteMission(string missionId)
        {
            MissionData mission = campaignMissions.Find(m => m.missionId == missionId);
            if (mission != null && !mission.isCompleted)
            {
                mission.isCompleted = true;
                Debug.Log($"[MissionManager] Миссия '{mission.title}' успешно завершена!");

                // Выдача наград
                ResourceManager.Instance.AddMoney(mission.rewardMoney);

                // Разблокировка технологий
                if (!string.IsNullOrEmpty(mission.unlockTechId))
                {
                    TechTreeManager.Instance.UnlockTechnology(mission.unlockTechId);
                }
            }
        }

        public void StartMission(string missionId)
        {
            MissionData mission = campaignMissions.Find(m => m.missionId == missionId);
            if (mission != null)
            {
                Debug.Log($"[MissionManager] Запуск миссии: {mission.title}");
                // UnityEngine.SceneManagement.SceneManager.LoadScene(mission.sceneName);
            }
        }
    }
}
