using UnityEngine;
using System.Collections.Generic;

namespace Generals.Core
{
    /// <summary>
    /// Система разблокировки технологий и юнитов.
    /// </summary>
    public class TechManager : MonoBehaviour
    {
        public static TechManager Instance { get; private set; }

        private HashSet<string> _unlockedTechs = new HashSet<string>();

        private void Awake()
        {
            Instance = this;
            LoadUnlockedTechs();
        }

        public void UnlockTech(string techId)
        {
            if (!_unlockedTechs.Contains(techId))
            {
                _unlockedTechs.Add(techId);
                SaveUnlockedTechs();
                Debug.Log($"[TechManager] Новая технология разблокирована: {techId}");
            }
        }

        public bool IsTechUnlocked(string techId)
        {
            return _unlockedTechs.Contains(techId);
        }

        private void SaveUnlockedTechs()
        {
            string data = string.Join(",", _unlockedTechs);
            PlayerPrefs.SetString("UnlockedTechs", data);
        }

        private void LoadUnlockedTechs()
        {
            string data = PlayerPrefs.GetString("UnlockedTechs", "");
            if (!string.IsNullOrEmpty(data))
            {
                _unlockedTechs = new HashSet<string>(data.Split(','));
            }
        }
    }
}
