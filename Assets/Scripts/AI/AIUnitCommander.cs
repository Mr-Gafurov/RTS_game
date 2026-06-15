using UnityEngine;

namespace Generals.AI
{
    /// <summary>
    /// Управление юнитами ИИ (атака, защита).
    /// </summary>
    public class AIUnitCommander : MonoBehaviour
    {
        public void EvaluateTacticalSituation()
        {
            // Логика: если собрана группа из 5+ юнитов - в атаку!
            Debug.Log("[AIUnitCommander] Оценка тактической ситуации...");
        }
    }
}
