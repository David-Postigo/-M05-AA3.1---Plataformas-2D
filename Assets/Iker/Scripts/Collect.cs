using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Collect : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="objeto")
        {
            Destroy(gameObject);
        }
    }


}
