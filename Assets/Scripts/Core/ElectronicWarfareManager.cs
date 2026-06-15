using UnityEngine;

namespace Generals.Core
{
    /// <summary>
    /// Система РЭБ (Радиоэлектронная борьба).
    /// </summary>
    public class ElectronicWarfareManager : MonoBehaviour
    {
        public bool isRadarJammed = false;

        public void JamRadar(float duration)
        {
            isRadarJammed = true;
            Debug.Log("[EW] Радары противника заглушены!");
            Invoke("EndJamming", duration);
        }

        private void EndJamming()
        {
            isRadarJammed = false;
            Debug.Log("[EW] Работа радаров восстановлена.");
        }

        public void DeployDecoy(Vector3 position)
        {
            Debug.Log($"[EW] Развернута ложная цель в позиции {position}");
            // Создание объекта, который отображается на мини-карте противника как юнит
        }
    }
}
