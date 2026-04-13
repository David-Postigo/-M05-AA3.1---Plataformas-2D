using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class triggerevent : MonoBehaviour
{
    public string tag;
    public UnityEvent<GameObject> onTriggerEnter;
    public UnityEvent<GameObject> onTriggerExit;
    public UnityEvent<GameObject> onTriggerStay;
    public UnityEvent<string> prueba;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        prueba.Invoke(collision.gameObject.name);
        if (collision.CompareTag(tag))
        {
            onTriggerEnter.Invoke(collision.gameObject);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(tag))
        {
            onTriggerExit.Invoke(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(tag))
        {
            onTriggerStay.Invoke(collision.gameObject);
        }
    }
}
