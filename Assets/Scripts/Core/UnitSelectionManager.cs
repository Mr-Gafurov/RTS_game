using UnityEngine;
using System.Collections.Generic;
using System;

namespace Generals.Core
{
    /// <summary>
    /// Менеджер выбора юнитов (тап, рамка).
    /// </summary>
    public class UnitSelectionManager : MonoBehaviour
    {
        public static UnitSelectionManager Instance { get; private set; }

        private List<GameObject> _selectedUnits = new List<GameObject>();
        public List<GameObject> SelectedUnits => _selectedUnits;

        public event Action OnSelectionChanged;

        private void Awake()
        {
            Instance = this;
        }

        public void SelectUnit(GameObject unit, bool additive = false)
        {
            if (!additive)
                DeselectAll();

            if (!_selectedUnits.Contains(unit))
            {
                _selectedUnits.Add(unit);
                // Тут можно вызвать визуальный эффект выбора
                unit.SendMessage("OnSelect", SendMessageOptions.DontRequireReceiver);
            }

            OnSelectionChanged?.Invoke();
        }

        public void DeselectAll()
        {
            foreach (var unit in _selectedUnits)
            {
                if (unit != null)
                    unit.SendMessage("OnDeselect", SendMessageOptions.DontRequireReceiver);
            }
            _selectedUnits.Clear();
            OnSelectionChanged?.Invoke();
        }

        // Логика выделения рамкой будет реализована через Input в CameraController или отдельный скрипт UI
    }
}
