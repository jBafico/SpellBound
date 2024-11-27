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
    }
    
    public void OnHideTutorial()
    {
        gameObject.SetActive(false);
    }

    #endregion
}
