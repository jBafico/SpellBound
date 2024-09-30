using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region UNITY_METHODS

    private void Start()
    {
        EventsManager.Instance.OnBossBeat += OnBossBeat;
    }

    #endregion

    #region LEVEL_MANAGER_METHODS

    private void OnBossBeat()
    {
        GameObject door = GameObject.FindGameObjectWithTag("Door").gameObject;
        Destroy(door);
    }

    #endregion
    
}
