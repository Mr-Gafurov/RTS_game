using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

namespace Generals.Core
{
    /// <summary>
    /// Интеграция с Google Gemini для генерации динамического контента (диалоги, брифинги).
    /// </summary>
    public class GeminiAIIntegration : MonoBehaviour
    {
        public static GeminiAIIntegration Instance { get; private set; }

        [Header("Настройки API")]
        [SerializeField] private string _apiKey = "YOUR_GEMINI_API_KEY";
        [SerializeField] private string _apiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-pro:generateContent";

        private void Awake()
        {
            Instance = this;
        }

        /// <summary>
        /// Запрос на генерацию текста брифинга для миссии.
        /// </summary>
        public void GenerateMissionBriefing(string missionContext, Action<string> onComplete)
        {
            string prompt = $"Ты — военный советник в игре Generals: Mobile Command. Напиши краткий и атмосферный боевой брифинг для следующей ситуации: {missionContext}. Тон должен быть серьезным и профессиональным.";
            StartCoroutine(SendGeminiRequest(prompt, onComplete));
        }

        /// <summary>
        /// Генерация динамической насмешки или комментария генерала во время боя.
        /// </summary>
        public void GenerateGeneralComment(string faction, string situation, Action<string> onComplete)
        {
            string prompt = $"Напиши короткую фразу (не более 10 слов) от лица генерала фракции {faction} в ответ на ситуацию: {situation}.";
            StartCoroutine(SendGeminiRequest(prompt, onComplete));
        }

        private IEnumerator SendGeminiRequest(string prompt, Action<string> onComplete)
        {
            // Формируем JSON для Gemini API
            string jsonData = "{\"contents\": [{\"parts\": [{\"text\": \"" + prompt + "\"}]}]}";

            using (UnityWebRequest request = new UnityWebRequest($"{_apiUrl}?key={_apiKey}", "POST"))
            {
                byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");

                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    // В реальном проекте здесь нужен парсинг JSON ответа Gemini
                    string responseText = request.downloadHandler.text;
                    Debug.Log($"[GeminiAI] Ответ получен: {responseText}");
                    onComplete?.Invoke(responseText);
                }
                else
                {
                    Debug.LogError($"[GeminiAI] Ошибка запроса: {request.error}");
                    onComplete?.Invoke("Связь с командным центром прервана...");
                }
            }
        }
    }
}
