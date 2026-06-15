using UnityEngine;
using System.Collections.Generic;

namespace Generals.Core
{
    /// <summary>
    /// Менеджер звуков.
    /// </summary>
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        [Header("Настройки")]
        public AudioSource musicSource;
        public AudioSource sfxSource;

        private void Awake()
        {
            Instance = this;
        }

        public void PlayMusic(AudioClip clip)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }

        public void PlaySFX(AudioClip clip, Vector3 position)
        {
            AudioSource.PlayClipAtPoint(clip, position);
        }

        public void PlayUnitVoice(AudioClip clip)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}
