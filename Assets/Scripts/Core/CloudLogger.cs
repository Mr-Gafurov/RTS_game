using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

namespace Generals.Core
{
    /// <summary>
    /// Отправка критических логов на сервер админки.
    /// </summary>
    public class CloudLogger : MonoBehaviour
    {
        public string adminApiUrl = "http://localhost:4000/api/admin/logs";

        public void LogToServer(string message, string level = "INFO")
        {
            StartCoroutine(SendLog(message, level));
        }

        private IEnumerator SendLog(string message, string level)
        {
            string json = "{\"message\": \"" + message + "\", \"level\": \"" + level + "\"}";
            using (UnityWebRequest request = new UnityWebRequest(adminApiUrl, "POST"))
            {
                byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");
                yield return request.SendWebRequest();
            }
        }
    }
}
