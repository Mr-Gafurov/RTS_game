using UnityEngine;

namespace Generals.Units
{
    public enum UnitStance
    {
        Aggressive, // Атакует любого в поле зрения
        Defensive,  // Атакует только в ответ, возвращается на позицию
        HoldFire,   // Не атакует совсем
        Passive     // Не атакует, даже если бьют
    }

    /// <summary>
    /// Управление режимами поведения юнита.
    /// </summary>
    public class UnitStanceManager : MonoBehaviour
    {
        public UnitStance currentStance = UnitStance.Defensive;

        public void SetStance(UnitStance newStance)
        {
            currentStance = newStance;
            Debug.Log($"[Stance] {gameObject.name} теперь в режиме: {newStance}");
        }
    }
}
