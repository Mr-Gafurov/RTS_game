using UnityEngine;
using System.Collections.Generic;
using System;

namespace Generals.Core
{
    [Serializable]
    public class MissionTrigger
    {
        public string id;
        public string conditionType; // TriggerEnter, UnitDied, TimePassed
        public GameObject target;
        public bool isTriggered = false;

        public event Action OnActivate;

        public void Activate()
        {
            if (isTriggered) return;
            isTriggered = true;
            OnActivate?.Invoke();
        }
    }

    /// <summary>
    /// Расширенный менеджер миссий для обработки сценариев (триггеры, подкрепления).
    /// </summary>
    public class MissionScenarioManager : MonoBehaviour
    {
        public List<MissionTrigger> triggers = new List<MissionTrigger>();

        private void Update()
        {
            // Проверка условий триггеров в реальном времени
        }

        public void SpawnReinforcements(GameObject prefab, Vector3 position, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Instantiate(prefab, position + UnityEngine.Random.insideUnitSphere * 5f, Quaternion.identity);
            }
            Debug.Log($"[Scenario] Вызваны подкрепления: {prefab.name} x{count}");
        }

        public void StartCutscene(string cutsceneId)
        {
            Debug.Log($"[Scenario] Начало кат-сцены: {cutsceneId}");
            // Отключаем ввод игрока, перемещаем камеру
        }
    }
}
