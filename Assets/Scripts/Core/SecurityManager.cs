using UnityEngine;

namespace Generals.Core
{
    /// <summary>
    /// Менеджер безопасности. Проверка целостности и обнаружение читов.
    /// </summary>
    public class SecurityManager : MonoBehaviour
    {
        public void CheckIntegrity()
        {
            // Проверка хеша файлов данных
            Debug.Log("[SecurityManager] Проверка целостности данных...");
        }

        public void ReportViolation(string reason)
        {
            Debug.LogError($"[SecurityManager] Нарушение безопасности: {reason}");
            // Отправка отчета на бэкенд
        }
    }
}
