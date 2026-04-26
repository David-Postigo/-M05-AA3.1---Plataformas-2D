using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public grounddetected ground;
    Rigidbody2D rb;
    private InputSystem_Actions test;

    [Header("Movement")]
    [Tooltip("Place Force (recomended 10+)")]
    public float speed;
    public float jumpforce;

    [Header("Dash")]
    [Tooltip("Place Force (recomended 20+)")]
    public int force;

    [Tooltip("bool that allows player to dash it has 1 use and recharges when touching ground)")]
    public bool candash;

    public Toggle dashToggle;
    Animator anim;

    private bool isCrouching;
    private bool isDashing;

    private float facing = 1f;

    void Start()
    {
        ground = GetComponent<grounddetected>();
        rb = GetComponent<Rigidbody2D>();
        test = new InputSystem_Actions();
        test.Enable();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // basic movement
        Vector2 dir = test.Player.Move.ReadValue<Vector2>();
        dir.y = 0;

        rb.position += dir * speed * Time.fixedDeltaTime;

        // facing
        if (dir.x > 0)
            facing = 1f;
        else if (dir.x < 0)
            facing = -1f;

        float scaleY = isCrouching ? 0.5f : 1f;
        transform.localScale = new Vector3(facing * scaleY, scaleY, 1f);

        // ANIMACIONES (FIX IMPORTANTE)
        bool isMoving = dir.x != 0 && ground.isgrounded;

        if (isDashing)
        {
            anim.SetBool("Dash", true);
            anim.SetBool("Run", false);
        }
        else
        {
            anim.SetBool("Dash", false);
            anim.SetBool("Run", isMoving);
        }
    }

    private void Update()
    {
        // dash
        if (test.Player.Sprint.WasPressedThisFrame() && !ground.isgrounded)
        {
            Dash();
        }

        // crouch
        if (test.Player.Crouch.WasPressedThisFrame())
        {
            isCrouching = !isCrouching;
            anim.SetBool("Crouch", isCrouching);
        }

        // jump
        if (test.Player.Jump.WasPressedThisFrame() && ground.isgrounded)
        {
            rb.AddForce(Vector2.up * jumpforce);
        }
    }

    void Dash()
    {
        if (candash && dashToggle.isOn)
        {
            candash = false;
            dashToggle.isOn = false;

            isDashing = true;
            anim.SetBool("Dash", true);

            Vector2 dashDir = new Vector2(facing, 0f);

            rb.constraints |= RigidbodyConstraints2D.FreezePositionY;
            rb.AddForce(dashDir * force, ForceMode2D.Impulse);

            Invoke(nameof(EndDash), 0.2f);
            Invoke(nameof(UnfreezeY), 0.2f);
        }
    }

    void EndDash()
    {
        isDashing = false;
        anim.SetBool("Dash", false);
    }

    void UnfreezeY()
    {
        rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
    }
}