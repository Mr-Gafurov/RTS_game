using UnityEngine;

namespace Generals.AI
{
    public enum AIStrategyPattern
    {
        TankRush,
        AirSuperiority,
        Ambush,
        Turtle
    }

    /// <summary>
    /// Паттерны поведения ИИ.
    /// </summary>
    public class AIStrategyPatternManager : MonoBehaviour
    {
        public AIStrategyPattern currentPattern;

        public void ApplyPattern(AIStrategyPattern pattern)
        {
            currentPattern = pattern;
            Debug.Log($"[AI] Применен паттерн: {pattern}");

            switch (pattern)
            {
                case AIStrategyPattern.TankRush:
                    // Приоритет на постройку танков и быструю атаку
                    break;
                case AIStrategyPattern.AirSuperiority:
                    // Приоритет на аэродромы и авиацию
                    break;
            }
        }
    }
}
