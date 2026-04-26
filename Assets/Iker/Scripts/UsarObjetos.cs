using UnityEngine;

public class UsarObjetos : MonoBehaviour
{
    public Transform slotEquipado;
    public PlayerMovement player;
    public PlayerManager playerManager;

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

        playerManager.shieldactive = false;

        if (slotEquipado.childCount > 0)
        {
            GameObject item = slotEquipado.GetChild(0).gameObject;

            if (item.CompareTag("botas"))
            {
                player.speed = baseSpeed * 1.5f;
                player.jumpforce = baseJump * 1.5f;
            }

            if (item.CompareTag("escudo"))
            {
                playerManager.shieldactive = true;
            }
        }
    }
}