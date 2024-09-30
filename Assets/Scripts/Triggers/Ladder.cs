using System;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        EventsManager.Instance.EventGameOver(true);
    }
}
