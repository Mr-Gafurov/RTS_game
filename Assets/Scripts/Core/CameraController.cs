using UnityEngine;

namespace Generals.Core
{
    /// <summary>
    /// Камера с поддержкой мобильных жестов (свайп, щипок).
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        [Header("Настройки перемещения")]
        public float moveSpeed = 0.5f;
        public Vector2 mapBounds = new Vector2(500, 500);

        [Header("Настройки Зума")]
        public float zoomSpeed = 0.1f;
        public float minZoom = 10f;
        public float maxZoom = 60f;

        private Camera _cam;
        private Vector3 _lastPanPosition;
        private int _panFingerId = -1;

        private void Awake()
        {
            _cam = GetComponent<Camera>();
        }

        private void Update()
        {
            if (GameManager.Instance.CurrentState != GameState.Battle) return;

            HandleTouchInput();
        }

        private void HandleTouchInput()
        {
            if (Input.touchCount == 1)
            {
                HandlePan();
            }
            else if (Input.touchCount == 2)
            {
                HandleZoom();
            }
        }

        private void HandlePan()
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _lastPanPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector3 delta = touch.position - (Vector2)_lastPanPosition;
                Vector3 move = new Vector3(-delta.x, 0, -delta.y) * moveSpeed * Time.deltaTime;

                transform.Translate(move, Space.World);

                // Ограничение по границам карты
                Vector3 pos = transform.position;
                pos.x = Mathf.Clamp(pos.x, -mapBounds.x, mapBounds.x);
                pos.z = Mathf.Clamp(pos.z, -mapBounds.y, mapBounds.y);
                transform.position = pos;

                _lastPanPosition = touch.position;
            }
        }

        private void HandleZoom()
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;

            float prevMagnitude = (touch0PrevPos - touch1PrevPos).magnitude;
            float currentMagnitude = (touch0.position - touch1.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            float zoomAmount = difference * zoomSpeed;

            if (_cam.orthographic)
            {
                _cam.orthographicSize = Mathf.Clamp(_cam.orthographicSize - zoomAmount, minZoom, maxZoom);
            }
            else
            {
                _cam.fieldOfView = Mathf.Clamp(_cam.fieldOfView - zoomAmount, minZoom, maxZoom);
            }
        }
    }
}
