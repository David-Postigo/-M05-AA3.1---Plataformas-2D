using UnityEngine;

public class ObjectCollected : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InventarioObject inv = FindObjectOfType<InventarioObject>();

            inv.AddItem(gameObject.tag);

            Destroy(gameObject);
        }
    }
}