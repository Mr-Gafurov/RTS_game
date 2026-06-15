using UnityEngine;

namespace Generals.Combat
{
    /// <summary>
    /// Гиперзвуковая ракета. Очень быстрая, мощная, игнорирует стандартную ПВО.
    /// </summary>
    public class HypersonicMissile : Projectile
    {
        public float acceleration = 20f;
        public bool isStealth = true;

        protected void Update()
        {
            // Ускорение в полете
            speed += acceleration * Time.deltaTime;
            base.Update();
        }

        // Переопределение попадания для нанесения критического урона зданиям
    }
}
