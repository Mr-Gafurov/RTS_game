using UnityEngine;
using System.Collections.Generic;

namespace Generals.Core
{
    /// <summary>
    /// Менеджер тумана войны. Использует текстуру для хранения данных о видимости.
    /// </summary>
    public class FogOfWarManager : MonoBehaviour
    {
        public static FogOfWarManager Instance { get; private set; }

        public Texture2D fogTexture;
        public int textureSize = 512;
        public float worldSize = 512f;

        private Color32[] _pixels;

        private void Awake()
        {
            Instance = this;
            InitializeFog();
        }

        private void InitializeFog()
        {
            fogTexture = new Texture2D(textureSize, textureSize, TextureFormat.RGBA32, false);
            _pixels = new Color32[textureSize * textureSize];

            // Заполняем черным (невидимо)
            for (int i = 0; i < _pixels.Length; i++)
                _pixels[i] = new Color32(0, 0, 0, 255);

            fogTexture.SetPixels32(_pixels);
            fogTexture.Apply();
        }

        public void RevealArea(Vector3 position, float radius)
        {
            int centerX = Mathf.RoundToInt((position.x / worldSize + 0.5f) * textureSize);
            int centerY = Mathf.RoundToInt((position.z / worldSize + 0.5f) * textureSize);
            int pixelRadius = Mathf.RoundToInt((radius / worldSize) * textureSize);

            for (int x = centerX - pixelRadius; x <= centerX + pixelRadius; x++)
            {
                for (int y = centerY - pixelRadius; y <= centerY + pixelRadius; y++)
                {
                    if (x >= 0 && x < textureSize && y >= 0 && y < textureSize)
                    {
                        float dist = Vector2.Distance(new Vector2(x, y), new Vector2(centerX, centerY));
                        if (dist <= pixelRadius)
                        {
                            _pixels[y * textureSize + x] = new Color32(255, 255, 255, 0); // Прозрачно
                        }
                    }
                }
            }

            fogTexture.SetPixels32(_pixels);
            fogTexture.Apply();
        }
    }
}
