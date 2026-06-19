using UnityEngine;
using UnityEngine.EventSystems;
using Generals.Core;
using Generals.Buildings;

namespace Generals.Core
{
    /// <summary>
    /// Система размещения зданий тачем.
    /// </summary>
    public class BuildingPlacer : MonoBehaviour
    {
        public static BuildingPlacer Instance { get; private set; }

        [Header("Настройки")]
        public LayerMask groundLayer;
        public Color canPlaceColor = Color.green;
        public Color cannotPlaceColor = Color.red;

        private GameObject _previewInstance;
        private BaseBuilding _currentBuildingData;
        private bool _isPlacing = false;

        private void Awake()
        {
            Instance = this;
        }

        public void StartPlacement(GameObject buildingPrefab)
        {
            if (_isPlacing) CancelPlacement();

            _previewInstance = Instantiate(buildingPrefab);
            _currentBuildingData = _previewInstance.GetComponent<BaseBuilding>();

            // Отключаем основные скрипты на превью
            if (_currentBuildingData != null) _currentBuildingData.enabled = false;

            _isPlacing = true;
        }

        private void Update()
        {
            if (!_isPlacing) return;

            MovePreviewToMouse();

            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                TryPlaceBuilding();
            }

            if (Input.GetMouseButtonDown(1))
            {
                CancelPlacement();
            }
        }

        private void MovePreviewToMouse()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 1000f, groundLayer))
            {
                _previewInstance.transform.position = hit.point;

                bool canPlace = CheckPlacementValidity(hit.point);
                UpdatePreviewColor(canPlace);
            }
        }

        private bool CheckPlacementValidity(Vector3 position)
        {
            // Здесь должна быть логика проверки коллизий (OverlapBox/Sphere)
            // И проверка наличия ресурсов
            return ResourceManager.Instance.Money >= _currentBuildingData.cost;
        }

        private void UpdatePreviewColor(bool canPlace)
        {
            // Логика смены материалов превью
        }

        private void TryPlaceBuilding()
        {
            if (CheckPlacementValidity(_previewInstance.transform.position))
            {
                if (ResourceManager.Instance.SpendMoney(_currentBuildingData.cost))
                {
                    _currentBuildingData.enabled = true;
                    _previewInstance = null;
                    _isPlacing = false;
                    Debug.Log("[BuildingPlacer] Здание успешно размещено.");
                }
            }
        }

        public void CancelPlacement()
        {
            if (_previewInstance != null) Destroy(_previewInstance);
            _isPlacing = false;
        }
    }
}
