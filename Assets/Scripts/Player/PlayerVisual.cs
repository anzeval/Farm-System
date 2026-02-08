using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] PlayerAnimator playerAnimator;
    [SerializeField] PlayerMovement movement;

    void Update()
    {
        Vector2 velocity = movement.Velocity;

        //Flip sprite
        if(velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f,1f);
        } 
        else if (velocity.x > 0)
        {
            transform.localScale = Vector3.one;
        }

        playerAnimator.Run(velocity.magnitude);
    }
}
