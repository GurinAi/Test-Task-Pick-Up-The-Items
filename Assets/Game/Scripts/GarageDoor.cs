using UnityEngine;

public class GarageDoor : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetInteger("DOOR_STATE", 1);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetInteger("DOOR_STATE", -1);
        }
    }
}
