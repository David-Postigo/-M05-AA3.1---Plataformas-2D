using UnityEngine;

public class Crouch : MonoBehaviour
{
    grounddetected ground;
    Rigidbody2D rb;
    private InputSystem_Actions test;
    public int force;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        test = new InputSystem_Actions();
        test.Enable();
    }
    void Update()
    {
        if (test.Player.Sprint.WasPressedThisFrame())
        {
            rb.AddForce(Vector2.right * force);
        }
        if(test.Player.Crouch.WasPressedThisFrame())
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        }
    }
}
