using UnityEngine;

namespace Generals.Core
{
    /// <summary>
    /// Логика размещения зданий игроком.
    /// </summary>
    public class BuildingPlacer : MonoBehaviour
    {
        public GameObject currentGhost;
        public bool isPlacing = false;

        public void StartPlacing(GameObject buildingPrefab)
        {
            isPlacing = true;
            currentGhost = Instantiate(buildingPrefab);
            // Отключаем на скрипте Ghost все лишнее (логику, коллайдеры)
        }

        private void Update()
        {
            if (!isPlacing || currentGhost == null) return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Или touch position
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                currentGhost.transform.position = hit.point;

                bool canPlace = CheckPlacementLegality(hit.point);
                UpdateGhostVisual(canPlace);

                if (Input.GetMouseButtonDown(0) && canPlace)
                {
                    FinalizePlacement();
                }
            }
        }

        private bool CheckPlacementLegality(Vector3 pos)
        {
            // Проверка пересечений и типа поверхности
            return true;
        }

        private void UpdateGhostVisual(bool legal)
        {
            // Меняем цвет на красный или зеленый
        }

        private void FinalizePlacement()
        {
            isPlacing = false;
            // Активируем здание
            Debug.Log("[BuildingPlacer] Здание размещено!");
        }
    }
}
