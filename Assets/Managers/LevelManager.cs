using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region UNITY_METHODS

    private void Start()
    {
        EventsManager.Instance.OnBossBeat += OnBossBeat;
        EventsManager.Instance.onTutorialFinished += OnTutorialFinished;
    }

    #endregion

    #region LEVEL_MANAGER_METHODS

    private void OnBossBeat()
    {
        GameObject door = GameObject.FindGameObjectWithTag("Door").gameObject;
        Destroy(door);
    }

    private void OnTutorialFinished()
    {
        Destroy(GameObject.FindWithTag("Tutorial"));
    }

    #endregion
    
}
