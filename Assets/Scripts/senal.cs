using UnityEngine;
using TMPro; // si usas TextMeshPro

public class senal : MonoBehaviour
{
    public GameObject textoUI; // arrastras el texto desde el Canvas

    void Start()
    {
        textoUI.SetActive(false); // oculto al inicio
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textoUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textoUI.SetActive(false);
        }
    }
}