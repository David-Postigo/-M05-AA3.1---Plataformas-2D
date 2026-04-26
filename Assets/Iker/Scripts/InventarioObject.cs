using UnityEngine;
using UnityEngine.UI;

public class InventarioObject : MonoBehaviour
{
    public GameObject[] slots;

    public Sprite escudoSprite;
    public Sprite llaveSprite;
    public Sprite pocionSprite;
    public Sprite botasSprite;

    public GameObject itemPrefab;

    public void AddItem(string tag)
    {
        Sprite spriteToAdd = null;

        if (tag == "escudo")
            spriteToAdd = escudoSprite;

        if (tag == "llave")
            spriteToAdd = llaveSprite;

        if (tag == "llave")
            spriteToAdd = llaveSprite;

        if (tag == "llave")
            spriteToAdd = llaveSprite;

        if (spriteToAdd == null)
            return;

        for (int i = 0; i < slots.Length; i++)
        {
            // si el slot está vacío
            if (slots[i].transform.childCount == 0)
            {
                GameObject item = Instantiate(itemPrefab, slots[i].transform);

                item.GetComponent<RectTransform>().localPosition = Vector3.zero;

                Image img = item.GetComponent<Image>();
                img.sprite = spriteToAdd;

                return;
            }
        }
    }
}