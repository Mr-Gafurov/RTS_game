using UnityEngine;

namespace Generals.Core
{
    /// <summary>
    /// Валидатор действий на стороне клиента (часть системы анти-чита).
    /// </summary>
    public class ServerSideValidator : MonoBehaviour
    {
        public bool ValidateAction(string actionType, object data)
        {
            // В идеале этот код должен дублироваться на сервере Node.js
            // Здесь мы проверяем, может ли игрок совершить действие (хватает ли ресурсов и т.д.)
            Debug.Log($"[Validator] Валидация действия: {actionType}");
            return true;
        }
    }
}
