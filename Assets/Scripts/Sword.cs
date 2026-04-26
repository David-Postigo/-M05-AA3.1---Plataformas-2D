using UnityEngine;

public class Sword : MonoBehaviour
{

    public string tagColision = "enemigo";

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == tagColision)
        {
            Destroy(collision.gameObject);
        }
    }
}
