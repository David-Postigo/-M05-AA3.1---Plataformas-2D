using UnityEngine;

public class jump : MonoBehaviour
{
    Rigidbody2D rb;
    private InputSystem_Actions test;
    public int force;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        test = new InputSystem_Actions();
        test.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if(test.Player.Jump.WasPressedThisFrame())
        {
            rb.AddForce(Vector2.up * force);
        }
    }
}
