using UnityEngine;
using System;
using System.Collections.Generic;

namespace Generals.Core
{
    [Serializable]
    public class TechNode
    {
        public string id;
        public string techName;
        public string description;
        public int currentLevel;
        public int maxLevel;
        public int costPerLevel;
        public bool isUnlocked;
    }

    /// <summary>
    /// Глобальный менеджер технологий и прокачки.
    /// </summary>
    public class TechTreeManager : MonoBehaviour
    {
        public static TechTreeManager Instance { get; private set; }

        [Header("Дерево технологий")]
        public List<TechNode> technologies = new List<TechNode>();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                InitializeTechTree();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void InitializeTechTree()
        {
            technologies.Add(new TechNode {
                id = "ew_system",
                techName = "РЭБ (EW System)",
                description = "Система радиоэлектронной борьбы",
                currentLevel = 0,
                maxLevel = 4,
                costPerLevel = 500,
                isUnlocked = true
            });

            technologies.Add(new TechNode {
                id = "uav_tech",
                techName = "Дроны (UAV)",
                description = "Технология разведывательных и ударных БПЛА",
                currentLevel = 0,
                maxLevel = 3,
                costPerLevel = 300,
                isUnlocked = false
            });
        }

        public void UpgradeTechnology(string techId)
        {
            TechNode node = technologies.Find(t => t.id == techId);
            if (node != null && node.currentLevel < node.maxLevel)
            {
                // Проверка ресурсов игрока через ResourceManager
                if (ResourceManager.Instance.SpendMoney(node.costPerLevel))
                {
                    node.currentLevel++;
                    ApplyTechEffects(node);
                    Debug.Log($"[TechTree] Технология {node.techName} улучшена до уровня {node.currentLevel}");
                }
            }
        }

        private void ApplyTechEffects(TechNode node)
        {
            if (node.id == "ew_system")
            {
                ElectronicWarfareManager.Instance.currentLevel = (EWLevel)node.currentLevel;
            }
            // Другие эффекты...
        }

        public void UnlockTechnology(string techId)
        {
            TechNode node = technologies.Find(t => t.id == techId);
            if (node != null)
            {
                node.isUnlocked = true;
                Debug.Log($"[TechTree] Технология {node.techName} разблокирована!");
            }
        }
    }
}
