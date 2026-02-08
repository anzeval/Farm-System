using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    PlayerInputHandler playerInput;
    Rigidbody2D rb;
    Vector2 direction;

    public Vector2 Velocity {get; private set;}

    void Awake()
    {
        playerInput = GetComponent<PlayerInputHandler>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        direction = playerInput.MoveDirection;
        rb.linearVelocity = direction.normalized * moveSpeed;
        Velocity = rb.linearVelocity;
    }
}
