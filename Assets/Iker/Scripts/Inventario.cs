using UnityEngine;

public class Inventario : MonoBehaviour
{
    public GameObject inventario;
    public PlayerMovement playerMovement;

    public bool isActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isActive = !isActive;
            inventario.SetActive(isActive);

            playerMovement.enabled = !isActive;
        }
    }
}