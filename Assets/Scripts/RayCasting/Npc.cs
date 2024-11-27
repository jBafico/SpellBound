using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    [SerializeField] private float distance = 5.0f;  

    private bool _showExclamationMark = true;
    private bool _showTutorial = false;

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.right, distance);

        // Check if the ray hits something and is not currently showing the tutorial
        if (!_showTutorial && hitInfo.collider != null && hitInfo.collider.CompareTag("Player"))
        {
            _showTutorial = true;
            if (_showExclamationMark)
            {
                _showExclamationMark = false;
                SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
                Destroy(spriteRenderers[1]);
            }
            
            EventsManager.Instance.EventShowTutorial();
        }

        // Check if the ray does not hit anything and the tutorial is currently showing
        if (_showTutorial && (hitInfo.collider == null || !hitInfo.collider.CompareTag("Player")))
        {
            _showTutorial = false;
            EventsManager.Instance.EventHideTutorial();
        }
    }

   
}
