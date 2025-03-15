using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement playerMovement;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        bool isMoving = playerMovement._movementInput != Vector2.zero;
        animator.SetBool("isMoving", isMoving);
        if (isMoving)
        {
            if (playerMovement._movementInput.x < 0)
                spriteRenderer.flipX = true;
            else if (playerMovement._movementInput.x > 0)
                spriteRenderer.flipX = false;
        }
    }
}
