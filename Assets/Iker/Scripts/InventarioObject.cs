using UnityEngine;
using UnityEngine.UI;

public class InventarioObject : MonoBehaviour
{
    public GameObject[] slots;

    public Sprite escudoSprite;
    public Sprite llaveSprite;
    public Sprite botasSprite;
    public Sprite pocionSprite;

    public GameObject itemPrefab;

    public void AddItem(string tag)
    {
        Debug.Log("Añadiendo item: " + tag);

        for (int i = 0; i < slots.Length; i++)
        {
            Transform slot = slots[i].transform;

            if (slot.childCount == 0)
            {
                GameObject newItem = Instantiate(itemPrefab, slot);

                newItem.tag = tag;

                Image img = newItem.GetComponent<Image>();

                if (img == null)
                {
                    Debug.LogError("El prefab no tiene Image");
                    return;
                }

                if (tag == "escudo")
                    img.sprite = escudoSprite;
                else if (tag == "llave")
                    img.sprite = llaveSprite;
                else if (tag == "botas")
                    img.sprite = botasSprite;
                else if (tag == "pocion")
                    img.sprite = pocionSprite;
                else
                {
                    Debug.LogWarning("Tag no reconocido: " + tag);
                }

                img.enabled = true;

                return;
            }
        }

        Debug.LogWarning("Inventario lleno");
    }
}