using UnityEngine;
using System.Collections.Generic;
using System;

namespace Generals.Core
{
    [Serializable]
    public class TutorialStep
    {
        public string instruction;
        public string targetUiElement;
        public bool isCompleted = false;
    }

    /// <summary>
    /// Система интерактивного обучения (Tutorial).
    /// </summary>
    public class TutorialManager : MonoBehaviour
    {
        public static TutorialManager Instance { get; private set; }

        public List<TutorialStep> steps = new List<TutorialStep>();
        public int currentStepIndex = 0;

        private void Awake()
        {
            Instance = this;
        }

        public void StartTutorial()
        {
            currentStepIndex = 0;
            ShowCurrentStep();
        }

        public void CompleteStep(int index)
        {
            if (index == currentStepIndex)
            {
                steps[index].isCompleted = true;
                currentStepIndex++;
                if (currentStepIndex < steps.Count)
                    ShowCurrentStep();
                else
                    EndTutorial();
            }
        }

        private void ShowCurrentStep()
        {
            string msg = steps[currentStepIndex].instruction;
            Debug.Log($"[Tutorial] ШАГ {currentStepIndex + 1}: {msg}");
            Generals.UI.NotificationManager.Instance?.SendNotification(msg);
        }

        private void EndTutorial()
        {
            Debug.Log("[Tutorial] Обучение завершено!");
            UnlockService.Instance?.UnlockContent("TUTORIAL_COMPLETED");
        }
    }
}
