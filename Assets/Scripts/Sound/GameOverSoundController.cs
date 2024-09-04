using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameOverSoundController : MonoBehaviour
    {
        #region SOUND_CONTROLLER_PROPERTIES

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _victoryClip; 
        [SerializeField] private AudioClip _defeatClip;
        

        #endregion

        #region UNITY_EVENTS

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        #endregion

        #region SOUND_CONTROLLER_METHODS

        private void OnGameOver(bool isVictory)
        {
            _audioSource.PlayOneShot(isVictory ? _victoryClip : _defeatClip);
        }

        #endregion
    }
