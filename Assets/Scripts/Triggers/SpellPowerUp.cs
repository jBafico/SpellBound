using UnityEngine;

public class SpellPowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            EventsManager.Instance.EventSpellPickup();

            Destroy(gameObject);
        }
    }
}
