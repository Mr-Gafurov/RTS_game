using UnityEngine;
using Generals.Units;

using Generals.Core;
namespace Generals.Units.China
{
    /// <summary>
    /// Танк Оверлорд (Китай). Огромный танк с возможностью установки модулей.
    /// </summary>
    public class Overlord : BaseUnit
    {
        public enum OverlordModule
        {
            None,
            PropagandaTower,
            GatlingCannon,
            Bunker
        }

        [Header("Модули")]
        public OverlordModule currentModule = OverlordModule.None;

        protected override void Start()
        {
            unitName = "Overlord Tank";
            faction = FactionType.China;
            maxHealth = 500f;
            movementSpeed = 3f;
            cost = 2000;
            base.Start();
        }

        public void InstallModule(OverlordModule module)
        {
            currentModule = module;
            Debug.Log($"[Overlord] Установлен модуль: {module}");
            // Логика изменения характеристик или активации доп. оружия
        }
    }
}
