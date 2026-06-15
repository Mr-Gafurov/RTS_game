using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Generals.UI
{
    using Generals.Core;

    /// <summary>
    /// Главный менеджер HUD в бою.
    /// </summary>
    public class HUDManager : MonoBehaviour
    {
        public TextMeshProUGUI moneyText;
        public Image energyBar;
        public TextMeshProUGUI factionNameText;

        private void Start()
        {
            if (ResourceManager.Instance != null)
            {
                ResourceManager.Instance.OnResourcesChanged += UpdateUI;
            }
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (ResourceManager.Instance != null)
            {
                moneyText.text = $"${ResourceManager.Instance.Money:F0}";
                energyBar.fillAmount = ResourceManager.Instance.EnergyRatio;
            }
        }
    }
}
