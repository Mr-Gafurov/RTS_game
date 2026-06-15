using UnityEngine;

namespace Generals.Units.China
{
    /// <summary>
    /// Хакер (Китай). Может воровать деньги из интернета или отключать здания.
    /// </summary>
    public class Hacker : BaseUnit
    {
        public float moneyPerSecond = 5f;

        protected override void Start()
        {
            unitName = "Black Lotus / Hacker";
            faction = FactionType.China;
            maxHealth = 50f;
            movementSpeed = 4f;
            cost = 625;
            base.Start();
        }

        public void StartHacking()
        {
            // Логика взлома
            Debug.Log("[Hacker] Взлом начат...");
        }
    }
}
