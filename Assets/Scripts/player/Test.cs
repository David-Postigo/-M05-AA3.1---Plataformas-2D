using UnityEngine;

public class Test : MonoBehaviour
{
    Rigidbody2D rb;
    private InputSystem_Actions test;
    public int speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        test = new InputSystem_Actions();
        test.Enable();
    }

    void FixedUpdate()
    {
        Vector2 dir = test.Player.Move.ReadValue<Vector2>();

        dir.y = 0;

        rb.position += dir * speed * Time.fixedDeltaTime;
    }
}