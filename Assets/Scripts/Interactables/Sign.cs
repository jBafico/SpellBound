using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Sign : MonoBehaviour
{
    #region UNITY_METHODS

    private void Start()
    {
        EventsManager.Instance.OnShowTutorial += OnShowTutorial;
        EventsManager.Instance.OnHideTutorial += OnHideTutorial;
        gameObject.SetActive(false);
    }

    #endregion
    
    
    #region SIGN_METHODS

    public void OnShowTutorial()
    {
        gameObject.SetActive(true);
        Debug.Log("Tutorial shown: _showTutorial = true, _showExclamationMark = false");
    }
    
    public void OnHideTutorial()
    {
        gameObject.SetActive(false);
        Debug.Log("Tutorial hidden: _showTutorial = false, _showExclamationMark = true");
    }

    #endregion
}
