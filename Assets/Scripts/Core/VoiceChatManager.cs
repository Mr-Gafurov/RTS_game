using UnityEngine;

namespace Generals.Core
{
    /// <summary>
    /// Интеграция голосового чата (заглушка для API).
    /// </summary>
    public class VoiceChatManager : MonoBehaviour
    {
        public void ConnectToVoiceChannel(string channelId)
        {
            Debug.Log($"[VoiceChat] Подключение к голосовому каналу: {channelId}");
        }

        public void MuteAll(bool mute)
        {
            Debug.Log($"[VoiceChat] Mute: {mute}");
        }
    }
}
