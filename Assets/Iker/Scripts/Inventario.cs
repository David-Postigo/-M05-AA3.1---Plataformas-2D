using UnityEngine;

public class Inventario : MonoBehaviour
{
    public GameObject inventario;
    bool isActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isActive = !isActive;
            inventario.SetActive(isActive);
        }
    }
}