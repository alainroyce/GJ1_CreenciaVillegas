using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 2f;
    public Transform interactionTransform;
    public Transform player;

    public virtual void Interact()
    {
        // This method is meant to be overwritten
        Debug.Log("Interacted with " + transform.name);
    }

    void OnDrawGizmosSelected()
    {
        if (interactionTransform != null)
            interactionTransform = transform;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}