using UnityEngine;
using System.Collections.Generic;
using System;

namespace Generals.Core.Story
{
    [Serializable]
    public class DialogueLine
    {
        public string speakerName;
        public string text;
        public Sprite portrait;
    }

    /// <summary>
    /// Система диалогов кампании.
    /// </summary>
    public class DialogueSystem : MonoBehaviour
    {
        public static DialogueSystem Instance { get; private set; }

        public event Action OnDialogueEnd;

        private void Awake()
        {
            Instance = this;
        }

        public void PlayDialogue(List<DialogueLine> lines)
        {
            Debug.Log("[Dialogue] Запуск цепочки диалогов...");
            // Логика последовательного отображения в UI
        }

        public void PlayGeminiGeneratedDialogue(string speaker, string context)
        {
            // Запрос к ИИ для создания динамической фразы
            GeminiAIIntegration.Instance?.GenerateGeneralComment(speaker, context, (text) => {
                Debug.Log($"[Dialogue] {speaker}: {text}");
            });
        }
    }
}
