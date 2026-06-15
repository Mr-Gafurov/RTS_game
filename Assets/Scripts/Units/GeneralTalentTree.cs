using UnityEngine;
using System.Collections.Generic;
using System;

namespace Generals.Units
{
    [Serializable]
    public class Talent
    {
        public string id;
        public string name;
        public int requiredLevel;
        public bool isUnlocked = false;
        public float multiplier = 1.1f;
    }

    /// <summary>
    /// Дерево талантов для Героя-Генерала.
    /// </summary>
    public class GeneralTalentTree : MonoBehaviour
    {
        private GeneralHero _hero;

        [Header("Таланты")]
        public List<Talent> damageTalents = new List<Talent>();
        public List<Talent> speedTalents = new List<Talent>();

        private void Awake()
        {
            _hero = GetComponent<GeneralHero>();
        }

        public void TryUnlockTalent(string talentId)
        {
            var talent = damageTalents.Find(t => t.id == talentId) ?? speedTalents.Find(t => t.id == talentId);

            if (talent != null && _hero.level >= talent.requiredLevel && !talent.isUnlocked)
            {
                talent.isUnlocked = true;
                ApplyTalent(talent);
                Debug.Log($"[TalentTree] Разблокирован талант: {talent.name}");
            }
        }

        private void ApplyTalent(Talent talent)
        {
            // Логика применения бонуса к статам героя или всей фракции
        }
    }
}
