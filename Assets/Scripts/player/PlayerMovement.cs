using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public grounddetected ground;
    Rigidbody2D rb;
    private InputSystem_Actions test;

    [Header("Movement")]
    [Tooltip("Place Force (recomended 10+)")]
    public int speed;
    public int jumpforce;

    [Header("Dash")]
    [Tooltip("Place Force (recomended 2000+)")]
    public int force;
    [Tooltip("bool that allows player to dash it has 1 use and recharges when touching ground)")]
    public bool candash;

    public Toggle dashToggle;

    void Start()
    {
        ground = GetComponent<grounddetected>();
        rb = GetComponent<Rigidbody2D>();
        test = new InputSystem_Actions();
        test.Enable();
    }

    void FixedUpdate()
    {
        //basic movement
        Vector2 dir = test.Player.Move.ReadValue<Vector2>();

        dir.y = 0;

        rb.position += dir * speed * Time.fixedDeltaTime;
    }

    private void Update()
    {
        //dash
        //direction capture for the player
        Vector2 dir = test.Player.Move.ReadValue<Vector2>();
        dir.y = 0;

        if (test.Player.Sprint.WasPressedThisFrame() && !ground.isgrounded)
        {
            Dash(dir);
        }

        //crouch
        if (test.Player.Crouch.WasPressedThisFrame())
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        }
        if (test.Player.Crouch.WasReleasedThisFrame())
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        //jump
        if (test.Player.Jump.WasPressedThisFrame() && ground.isgrounded)
        {
            rb.AddForce(Vector2.up * jumpforce);
        }
    }

    void Dash(Vector2 dir)
    {
        // dash towerds the direction
        if (dir != Vector2.zero && candash && dashToggle.isOn)
        {
            candash = false;
            dashToggle.isOn = false;
            rb.constraints |= RigidbodyConstraints2D.FreezePositionY;
            rb.AddForce(dir.normalized * force, ForceMode2D.Impulse);

            // freeze mid air to give sensation of dash
            Invoke(nameof(UnfreezeY), 0.2f);
        }
    }

    void UnfreezeY()
    {
        rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
    }
}
