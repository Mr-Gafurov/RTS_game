using UnityEngine;
using UnityEngine.UI;

namespace Generals.UI
{
    using Generals.Core;

    /// <summary>
    /// Меню настроек.
    /// </summary>
    public class SettingsUI : MonoBehaviour
    {
        public Slider musicVolumeSlider;
        public Slider sfxVolumeSlider;

        public void OnMusicVolumeChanged(float value)
        {
            PlayerPrefs.SetFloat("MusicVolume", value);
            // Обновление AudioManager
        }

        public void OnSFXVolumeChanged(float value)
        {
            PlayerPrefs.SetFloat("SFXVolume", value);
        }

        public void ChangeLanguage(int langIndex)
        {
            LocalizationManager.Instance.currentLanguage = (Language)langIndex;
            Debug.Log($"[Settings] Язык изменен на: {(Language)langIndex}");
        }
    }
}
