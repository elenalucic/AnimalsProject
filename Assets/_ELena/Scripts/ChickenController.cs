using System.Collections;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;

    public void StartAnimationSequence()
    {
        StartCoroutine(PlayAnimations());
    }

    private IEnumerator PlayAnimations()
    {
        animator.Play("walk");
        yield return new WaitForSeconds(3f); 

        animator.Play("eat");
        yield return new WaitForSeconds(3f); 

        animator.Play("walk");
        yield return new WaitForSeconds(3f); 

        animator.Play("idle"); 
    }
}
