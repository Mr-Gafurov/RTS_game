using UnityEngine;

namespace Generals.AI
{
    /// <summary>
    /// Анализатор стиля игрока для адаптации ИИ.
    /// </summary>
    public class AITacticalAnalyzer : MonoBehaviour
    {
        [SerializeField] private int playerAggressionScore = 0;

        public void RegisterPlayerAction(string actionType)
        {
            if (actionType == "Attack") playerAggressionScore++;

            if (playerAggressionScore > 10)
            {
                GetComponent<AIController>()?.AdaptToPlayer(AIPersonality.Defensive);
            }
        }
    }
}
