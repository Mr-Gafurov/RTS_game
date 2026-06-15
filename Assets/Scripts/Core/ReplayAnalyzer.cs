using UnityEngine;
using System.Collections;

namespace Generals.Core
{
    /// <summary>
    /// Анализатор матчей с помощью Google Gemini.
    /// </summary>
    public class ReplayAnalyzer : MonoBehaviour
    {
        public void AnalyzeMatch(string replayJson)
        {
            string prompt = $"Проанализируй ход матча в RTS Generals и дай тактический совет игроку на основе этих данных: {replayJson}. Выдели ошибки и предложи лучшую стратегию.";

            GeminiAIIntegration.Instance?.GenerateMissionBriefing(prompt, (analysis) => {
                Debug.Log($"[GeminiAnalysis] Разбор матча: {analysis}");
            });
        }
    }
}
