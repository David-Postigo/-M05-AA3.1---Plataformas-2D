using UnityEngine;
using TMPro;

public class senal : MonoBehaviour
{
    public TextMeshProUGUI txt;
    void Start()
    {
        txt.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            txt.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            txt.gameObject.SetActive(false);
        }
    }
}