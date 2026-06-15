using UnityEngine;
using UnityEngine.SceneManagement;

namespace Generals.UI
{
    using Generals.Core;

    /// <summary>
    /// Контроллер главного меню.
    /// </summary>
    public class MainMenuController : MonoBehaviour
    {
        public void StartNewGame()
        {
            GameManager.Instance.ChangeState(GameState.Loading);
            SceneManager.LoadScene("BattleScene");
        }

        public void OpenSettings()
        {
            // Логика открытия настроек
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void SelectFaction(int factionIndex)
        {
            // Сохранение выбранной фракции для матча
            Debug.Log($"[MainMenu] Выбрана фракция: {(FactionType)factionIndex}");
        }
    }
}
