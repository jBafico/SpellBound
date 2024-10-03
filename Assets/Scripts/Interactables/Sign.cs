using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Sign : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _popUpBox;
    
    #region UNITY_METHODS

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)) OnInteract();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")) _popUpBox.SetActive(false);
    }

    #endregion
    
    #region IINTERACTABLE_METHODS

    public void OnInteract()
    {
        _popUpBox.SetActive(true);
    }

    #endregion
}
