using UnityEngine;
using System.Collections;

namespace Generals.Core
{
    /// <summary>
    /// Генератор миссий на основе ИИ Gemini.
    /// </summary>
    public class GeminiMissionGenerator : MonoBehaviour
    {
        public void GenerateDailyMission(int playerLevel)
        {
            string context = $"Игрок имеет уровень {playerLevel}. Сгенерируй условия уникальной ежедневной миссии: цель, враг, ландшафт и награда.";

            GeminiAIIntegration.Instance?.GenerateMissionBriefing(context, (missionData) => {
                Debug.Log($"[GeminiMission] Сгенерирована миссия: {missionData}");
                // Создание ScriptableObject MissionData на лету
            });
        }
    }
}
