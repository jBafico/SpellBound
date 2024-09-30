using System;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
        [SerializeField] private CinemachineVirtualCamera _camera;
        private float _startingIntensity;
        private float _timerTotal;
        private float _timer;
        #region UNITY_METHODS

        private void Start()
        {
                EventsManager.Instance.OnTakingDamage += OnTakingDamage;
        }

        private void Update()
        {
                if (_timer > 0)
                {
                        _timer -= Time.deltaTime;
                        _camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = Mathf.Lerp(_startingIntensity, 0f, 1-(_timer / _timerTotal));
                }
        }

        #endregion
        
        #region CAMERA_MANAGER_METHODS

        private void OnTakingDamage(float intensity, float timer)
        {
                _camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = intensity;
                _timer = timer;
                _timerTotal = timer;
                _startingIntensity = intensity;
        }

        #endregion
}
