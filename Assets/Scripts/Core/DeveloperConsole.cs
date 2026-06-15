using UnityEngine;

namespace Generals.Core
{
    /// <summary>
    /// Консоль разработчика для тестирования и отладки.
    /// </summary>
    public class DeveloperConsole : MonoBehaviour
    {
        public bool isEnabled = false;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.BackQuote)) // Тильда
            {
                isEnabled = !isEnabled;
            }
        }

        public void ExecuteCommand(string cmd)
        {
            if (cmd == "money_99999")
            {
                ResourceManager.Instance?.AddMoney(99999);
                Debug.Log("[Dev] Чит-код активирован: Деньги");
            }
            else if (cmd == "instant_build")
            {
                // Логика мгновенной постройки
            }
        }
    }
}
