using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        // RUN
        animator.SetBool("run", move != 0);

        // CROUCH
        animator.SetBool("crouch", Input.GetKey(KeyCode.S));

        // DASH
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetTrigger("dash");
        }
    }
}