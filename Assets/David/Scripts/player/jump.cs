using UnityEngine;

public class jump : MonoBehaviour
{
    grounddetected ground;
    Rigidbody2D rb;
    private InputSystem_Actions test;
    public int force;
    void Start()
    {
        ground = GetComponent<grounddetected>();
        rb = GetComponent<Rigidbody2D>();
        test = new InputSystem_Actions();
        test.Enable();
    }
    void Update()
    {
        if(test.Player.Jump.WasPressedThisFrame() && ground.isgrounded)
        {
            rb.AddForce(Vector2.up * force);
        }
    }
}
