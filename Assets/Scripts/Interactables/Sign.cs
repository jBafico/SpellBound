using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Sign : MonoBehaviour
{
    #region UNITY_METHODS

    private void Start()
    {
        gameObject.SetActive(false);
    }

    #endregion
    
    
    #region SIGN_METHODS

    public void ShowTutorial()
    {
        gameObject.SetActive(true);
    }
    
    public void HideTutorial()
    {
        gameObject.SetActive(false);
    }

    #endregion
}