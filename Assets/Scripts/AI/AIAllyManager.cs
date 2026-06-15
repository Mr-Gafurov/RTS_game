using UnityEngine;
using System.Collections.Generic;

namespace Generals.AI
{
    /// <summary>
    /// Координатор действий союзного ИИ.
    /// </summary>
    public class AIAllyManager : MonoBehaviour
    {
        public void RequestSupport(Vector3 position)
        {
            Debug.Log($"[AllyAI] Получен запрос поддержки в точке {position}. Высылаю войска.");
            // Приказ союзному контроллеру направить юнитов
        }

        public void TransferResources(float amount)
        {
            if (Generals.Core.ResourceManager.Instance.SpendMoney(amount))
            {
                Debug.Log($"[AllyAI] Передано {amount} ресурсов союзнику.");
            }
        }
    }
}
