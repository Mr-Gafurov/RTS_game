using UnityEngine;
using System.Collections.Generic;

namespace Generals.Core
{
    /// <summary>
    /// Уровни технологий РЭБ.
    /// </summary>
    public enum EWLevel
    {
        None = 0,
        RadarJamming = 1,    // Глушение радара (Fog of War)
        BuildingDisruption = 2, // Ослепление зданий (башни не стреляют)
        UAVInterference = 3,  // Глушение БПЛА/Полетов
        CyberHacking = 4      // Перехват управления (Hacking)
    }

    /// <summary>
    /// Система РЭБ (Радиоэлектронная борьба) с прогрессией уровней.
    /// </summary>
    public class ElectronicWarfareManager : MonoBehaviour
    {
        public static ElectronicWarfareManager Instance { get; private set; }

        [Header("Текущий уровень РЭБ")]
        public EWLevel currentLevel = EWLevel.None;

        [Header("Состояние систем")]
        public bool isRadarJammed = false;
        public List<GameObject> jammedBuildings = new List<GameObject>();

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        /// <summary>
        /// Попытка активации РЭБ эффекта.
        /// </summary>
        public void ActivateEW(EWLevel level, float duration)
        {
            if (level > currentLevel)
            {
                Debug.LogWarning($"[EW] Уровень {level} еще не разблокирован! Текущий: {currentLevel}");
                return;
            }

            switch (level)
            {
                case EWLevel.RadarJamming:
                    StartCoroutine(JamRadarRoutine(duration));
                    break;
                case EWLevel.BuildingDisruption:
                    StartCoroutine(JamBuildingsRoutine(duration));
                    break;
                case EWLevel.UAVInterference:
                    StartCoroutine(JamUAVsRoutine(duration));
                    break;
                case EWLevel.CyberHacking:
                    ExecuteHacking();
                    break;
            }
        }

        private System.Collections.IEnumerator JamRadarRoutine(float duration)
        {
            isRadarJammed = true;
            Debug.Log("[EW] РЛС противника ослеплены!");
            yield return new WaitForSeconds(duration);
            isRadarJammed = false;
            Debug.Log("[EW] РЛС противника восстановили работу.");
        }

        private System.Collections.IEnumerator JamBuildingsRoutine(float duration)
        {
            Debug.Log("[EW] Энергосистемы оборонительных зданий перегружены!");
            // Логика отключения башен
            yield return new WaitForSeconds(duration);
            Debug.Log("[EW] Здания противника перезагружены.");
        }

        private System.Collections.IEnumerator JamUAVsRoutine(float duration)
        {
            Debug.Log("[EW] Частоты управления БПЛА заглушены!");
            yield return new WaitForSeconds(duration);
            Debug.Log("[EW] Связь с БПЛА восстановлена.");
        }

        private void ExecuteHacking()
        {
            Debug.Log("[EW] Произведен кибер-взлом системы управления!");
            // Логика перехвата юнита
        }

        /// <summary>
        /// Метод для улучшения уровня РЭБ (вызывается из TechTreeManager).
        /// </summary>
        public void UpgradeLevel()
        {
            if ((int)currentLevel < 4)
            {
                currentLevel++;
                Debug.Log($"[EW] Технология РЭБ улучшена до уровня: {currentLevel}");
            }
        }
    }
}
