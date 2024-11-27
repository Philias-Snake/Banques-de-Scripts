using UnityEngine;

public class DestructTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // D�sactive le collider au lieu de le d�truire compl�tement
            Collider2D objectCollider = GetComponent<Collider2D>();
            if (objectCollider != null)
            {
                objectCollider.enabled = false;
            }
        }
    }
}