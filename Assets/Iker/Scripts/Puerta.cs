using UnityEngine;

public class Puerta : MonoBehaviour
{
    public UsarObjetos usarObjetos;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            if (usarObjetos.tieneLlave)
            {
                Debug.Log("Puerta abierta");
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Necesitas una llave");
            }
        }
    }
}