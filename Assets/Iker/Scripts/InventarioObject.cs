using UnityEngine;
using UnityEngine.UI;

public class InventarioObject : MonoBehaviour
{
    public GameObject[] slots;

    public Sprite escudoSprite;
    public Sprite llaveSprite;
    public Sprite botasSprite;

    public GameObject itemPrefab;

    public void AddItem(string tag)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            Transform slot = slots[i].transform;

            if (slot.childCount == 0)
            {
                GameObject newItem = Instantiate(itemPrefab, slot);

                newItem.tag = tag;

                Image img = newItem.GetComponent<Image>();

                if (tag == "escudo")
                    img.sprite = escudoSprite;
                else if (tag == "llave")
                    img.sprite = llaveSprite;
                else if (tag == "botas")
                    img.sprite = botasSprite;

                return;
            }
        }
    }
}