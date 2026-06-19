using UnityEngine;
using UnityEngine.UI;
using Generals.Units;

namespace Generals.UI
{
    /// <summary>
    /// Контроллер мини-карты.
    /// </summary>
    public class MiniMap : MonoBehaviour
    {
        public RawImage mapDisplay;
        public RectTransform iconContainer;
        public GameObject unitIconPrefab;

        [Header("Настройки")]
        public float worldSize = 512f;

        private void Update()
        {
            // В реальной игре здесь будет логика обновления иконок юнитов
            // Проекция координат Vector3 в RectTransform координаты
        }

        public Vector2 WorldToMap(Vector3 worldPos)
        {
            float x = (worldPos.x / worldSize) * mapDisplay.rectTransform.rect.width;
            float y = (worldPos.z / worldSize) * mapDisplay.rectTransform.rect.height;
            return new Vector2(x, y);
        }
    }
}
