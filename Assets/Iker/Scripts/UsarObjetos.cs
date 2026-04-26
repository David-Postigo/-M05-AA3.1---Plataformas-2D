using UnityEngine;

public class UsarObjetos : MonoBehaviour
{
    public Transform slotEquipado;
    public PlayerMovement player;

    private int speedBase;
    private int jumpBase;

    void Start()
    {
        speedBase = player.speed;
        jumpBase = player.jumpforce;
    }

    void Update()
    {
        player.speed = speedBase;
        player.jumpforce = jumpBase;

        if (slotEquipado != null && slotEquipado.childCount > 0)
        {
            Transform child = slotEquipado.GetChild(0);

            if (child == null) return;

            GameObject item = child.gameObject;

            if (item == null) return;

            if (item.CompareTag("botas"))
            {
                player.speed = (int)(speedBase * 1.5f);
                player.jumpforce = (int)(jumpBase * 1.5f);
            }
        }
    }
}