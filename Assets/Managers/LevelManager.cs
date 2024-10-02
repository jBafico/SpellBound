using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _medkit;
    [SerializeField] private GameObject _destroyedCrate;
    [SerializeField] private GameObject _door;
    
    #region UNITY_METHODS

    private void Start()
    {
        EventsManager.Instance.OnBossBeat += OnBossBeat;
        EventsManager.Instance.OnTutorialFinished += OnTutorialFinished;
        EventsManager.Instance.OnCrateDestroyed += OnCrateDestroyed;
    }

    #endregion

    #region LEVEL_MANAGER_METHODS

    private void OnBossBeat()
    {
        Destroy(_door);
    }

    private void OnTutorialFinished()
    {
        Destroy(GameObject.FindWithTag("Tutorial"));
    }

    private void OnCrateDestroyed(GameObject crate)
    {
        Vector3 cratePosition = crate.transform.position;
        Instantiate(_destroyedCrate, cratePosition, Quaternion.identity);
        Instantiate(_medkit, cratePosition, Quaternion.identity);
        Destroy(crate);
    }

    #endregion
    
}
