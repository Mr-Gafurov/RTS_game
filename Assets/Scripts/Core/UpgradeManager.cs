using UnityEngine;
using System.Collections.Generic;

namespace Generals.Core
{
    /// <summary>
    /// Менеджер глобальных апгрейдов фракции во время матча.
    /// </summary>
    public class UpgradeManager : MonoBehaviour
    {
        public static UpgradeManager Instance { get; private set; }

        private HashSet<string> _activeUpgrades = new HashSet<string>();

        private void Awake()
        {
            Instance = this;
        }

        public void PurchaseUpgrade(string upgradeId, int cost)
        {
            if (ResourceManager.Instance.SpendMoney(cost))
            {
                _activeUpgrades.Add(upgradeId);
                Debug.Log($"[Upgrades] Исследование завершено: {upgradeId}");
                ApplyUpgradeToExistingUnits(upgradeId);
            }
        }

        public bool IsUpgradeActive(string upgradeId)
        {
            return _activeUpgrades.Contains(upgradeId);
        }

        private void ApplyUpgradeToExistingUnits(string upgradeId)
        {
            // Логика поиска всех существующих юнитов и применения бонуса
        }
    }
}
