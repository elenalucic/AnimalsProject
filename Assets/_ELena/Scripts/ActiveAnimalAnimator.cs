using UnityEngine;

public class ActiveAnimalAnimator : MonoBehaviour
{
    public AnimalDisplay animalDisplay;


    public void PlayActiveAnimalAnimator()
    {
        GameObject currentAnimal = animalDisplay.GetCurrentAnimal();

        if (currentAnimal == null)
        {
            Debug.LogWarning("Nema aktivne životinje!");
            return;
        }

        Animator animator = currentAnimal.GetComponent<Animator>();

        if (animator != null)
        {
            animator.Rebind();   
            animator.Update(0f); 
            animator.SetBool("play", true); 
        }
        else
        {
            Debug.LogWarning("Animator nije pronađen na aktivnoj životinji!");
        }
    }


}
