using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public enum InteractionType {
        Click,
        Hold,
        Minigame
    }

    float holdTime;

    public InteractionType interactionType;

    public abstract string GetDescription();
    public abstract void Interact();

    public void IncreaseHoldTime() => holdTime += Time.deltaTime;
    public void ResetHoldTime() => holdTime = 0f;

    public float GetHoldTime() => holdTime;


    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
