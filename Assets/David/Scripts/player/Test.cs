using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    grounddetected ground;
    Rigidbody2D rb;
    private InputSystem_Actions test;

    [Header("Movement")]
    [Tooltip("Place Force (recomended 10+)")]
    public int speed;

    [Header("Dash")]
    [Tooltip("Place Force (recomended 2000+)")]
    public int force;
    [Tooltip("bool that allows player to dash it has 1 use and recharges when touching ground)")]
    public bool candash;

    public Toggle dashToggle;

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

    private void Update()
    {
        Vector2 dir = test.Player.Move.ReadValue<Vector2>();
        dir.y = 0;

        if (test.Player.Sprint.WasPressedThisFrame())
        {
            Dash(dir);
        }
    }

    void Dash(Vector2 dir)
    {
        if (dir != Vector2.zero && candash && dashToggle.isOn)
        {
            candash = false;
            dashToggle.isOn = false;
            rb.constraints |= RigidbodyConstraints2D.FreezePositionY;
            rb.AddForce(dir.normalized * force, ForceMode2D.Impulse);

            Invoke(nameof(UnfreezeY), 0.2f);
        }
    }

    void UnfreezeY()
    {
        rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
    }
}