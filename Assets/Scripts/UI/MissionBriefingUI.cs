using UnityEngine;
using TMPro;
using System.Collections.Generic;

namespace Generals.UI
{
    using Generals.Core;

    /// <summary>
    /// Экран брифинга перед началом миссии.
    /// </summary>
    public class MissionBriefingUI : MonoBehaviour
    {
        public TextMeshProUGUI titleText;
        public TextMeshProUGUI descriptionText;
        public GameObject briefingPanel;

        public void ShowBriefing(MissionData data)
        {
            titleText.text = data.missionName;
            descriptionText.text = data.description;
            briefingPanel.SetActive(true);

            // Если текст пустой, пробуем запросить у Gemini
            if (string.IsNullOrEmpty(data.description))
            {
                GeminiAIIntegration.Instance?.GenerateMissionBriefing(data.missionName, (result) => {
                    descriptionText.text = result;
                });
            }
        }

        public void OnStartButtonClick()
        {
            briefingPanel.SetActive(false);
            GameManager.Instance?.StartMatch();
        }
    }
}
