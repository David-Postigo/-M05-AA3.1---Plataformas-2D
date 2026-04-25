using UnityEngine;
using UnityEngine.UI;

public class InventarioObject : MonoBehaviour
{
    public GameObject[] slots;
    public Sprite escudoSprite;
    public Sprite llaveSprite;
    public Sprite botasSprite;
    public Sprite espadaSprite;
    public Sprite pocionSprite;


    public void AddItem(string tag)
    {
        Sprite spriteToAdd = null;

        if (tag == "escudo")
            spriteToAdd = escudoSprite;

        if (tag == "llave")
            spriteToAdd = llaveSprite;

        if (tag == "botas")
            spriteToAdd = botasSprite;

        if (tag == "espada")
            spriteToAdd = espadaSprite;

        if (tag == "pocion")
            spriteToAdd = pocionSprite;

        if (spriteToAdd == null)
            return;

        for (int i = 0; i < slots.Length; i++)
        {
            Image img = slots[i].GetComponent<Image>();

            if (img.sprite == null)
            {
                img.sprite = spriteToAdd;
                img.color = Color.white;
                return;
            }
        }
    }
}