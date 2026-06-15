using UnityEngine;
using UnityEngine.UI;

namespace Generals.UI
{
    /// <summary>
    /// Контроллер интерактивной мини-карты.
    /// </summary>
    public class MinimapController : MonoBehaviour
    {
        public RectTransform minimapRect;
        public Camera mainCamera;
        public float terrainSize = 512f;

        public void OnMinimapClick()
        {
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(minimapRect, Input.mousePosition, null, out localPoint);

            // Перевод координат мини-карты в мировые координаты
            float x = (localPoint.x / minimapRect.rect.width) * terrainSize;
            float z = (localPoint.y / minimapRect.rect.height) * terrainSize;

            Vector3 newCameraPos = new Vector3(x, mainCamera.transform.position.y, z);
            mainCamera.transform.position = newCameraPos;
        }

        public void PlacePing(Vector2 minimapPos, string pingType)
        {
            Debug.Log($"[Minimap] Пинг '{pingType}' в координатах {minimapPos}");
            // Отправка пинга союзникам через NetworkManager
        }
    }
}
