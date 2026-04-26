using UnityEngine;

public class UsarObjetos : MonoBehaviour
{
    public Transform slotEquipado;
    public PlayerMovement player;

    private float baseSpeed;
    private float baseJump;

    void Start()
    {
        baseSpeed = player.speed;
        baseJump = player.jumpforce;
    }

    void Update()
    {
        player.speed = baseSpeed;
        player.jumpforce = baseJump;

        if (slotEquipado != null && slotEquipado.childCount > 0)
        {
            Transform child = slotEquipado.GetChild(0);

            Debug.Log("Item equipado: " + child.name + " | Tag: " + child.tag);

            if (child.CompareTag("botas"))
            {
                player.speed = baseSpeed * 1.5f;
                player.jumpforce = baseJump * 1.5f;
            }
        }
    }
}