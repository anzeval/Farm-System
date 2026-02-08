using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void Run (float velocity)
    {
        animator.SetFloat("Speed", velocity);
    }

    public void  UseWateringCan()
    {
        
    }

    public void UseTool()
    {
        
    }
}
