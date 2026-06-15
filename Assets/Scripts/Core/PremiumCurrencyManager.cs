using UnityEngine;

namespace Generals.Core
{
    /// <summary>
    /// Управление премиум валютой.
    /// </summary>
    public class PremiumCurrencyManager : MonoBehaviour
    {
        public static PremiumCurrencyManager Instance { get; private set; }

        [SerializeField] private int _gems = 0;
        public int Gems => _gems;

        private void Awake()
        {
            Instance = this;
        }

        public void AddGems(int amount)
        {
            _gems += amount;
            Debug.Log($"[Premium] Получено {amount} гемов. Всего: {_gems}");
        }

        public bool SpendGems(int amount)
        {
            if (_gems >= amount)
            {
                _gems -= amount;
                return true;
            }
            return false;
        }
    }
}
