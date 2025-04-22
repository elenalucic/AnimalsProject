using UnityEngine;

public class SettingsAnimatorTrigger : MonoBehaviour
{
    public Animator animator;

    

    public void ToggleSettings()
    {
        bool isLandscape = Screen.width > Screen.height;
        animator.SetBool("isHorizontal", isLandscape);

    }
}
