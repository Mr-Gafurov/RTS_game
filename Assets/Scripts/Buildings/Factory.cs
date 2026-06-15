using UnityEngine;

namespace Generals.Buildings
{
    /// <summary>
    /// Завод. Производит технику.
    /// </summary>
    public class Factory : BaseBuilding
    {
        protected override void Start()
        {
            buildingName = "War Factory";
            maxHealth = 1000f;
            cost = 2000;
            energyConsumption = 20f;
            base.Start();
        }
    }
}
