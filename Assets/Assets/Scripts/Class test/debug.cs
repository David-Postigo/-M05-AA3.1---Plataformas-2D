using UnityEngine;

public class debug : MonoBehaviour
{
    public void write()
    {
        Debug.Log("Test" + Time.frameCount);
    }
    public void Write(string Text)
    {
        Debug.Log(Text + Time.frameCount);
    }
}
