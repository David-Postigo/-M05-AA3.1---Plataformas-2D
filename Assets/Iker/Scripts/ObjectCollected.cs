using UnityEngine;

public class ObjectCollected : MonoBehaviour
{
    private InventarioObject inventario;

    void Start()
    {
        inventario = FindObjectOfType<InventarioObject>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (CompareTag("botas"))
            {
                inventario.AddItem("botas");
            }

            if (CompareTag("escudo"))
            {
                inventario.AddItem("escudo");
            }

            if (CompareTag("llave"))
            {
                inventario.AddItem("llave");
            }

            Destroy(gameObject);
        }
    }
}