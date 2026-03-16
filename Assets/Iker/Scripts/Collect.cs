using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Collect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="player")
        {
            Destroy(gameObject);
        }
    }


}
