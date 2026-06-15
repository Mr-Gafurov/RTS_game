using UnityEngine;

namespace Generals.Core
{
    /// <summary>
    /// Режим наблюдателя для трансляций и турниров.
    /// </summary>
    public class SpectatorManager : MonoBehaviour
    {
        public bool isSpectator = false;

        public void EnableSpectatorMode()
        {
            isSpectator = true;
            // Отключаем туман войны для наблюдателя
            // Даем свободное управление камерой
            Debug.Log("[SpectatorManager] Режим наблюдателя включен.");
        }

        public void SwitchToPlayer(int playerIndex)
        {
            Debug.Log($"[SpectatorManager] Переключение камеры на игрока {playerIndex}");
        }
    }
}
