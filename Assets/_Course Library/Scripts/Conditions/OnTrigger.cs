using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Calls functionality when a trigger occurs
/// </summary>
public class OnTrigger : MonoBehaviour
{
    public string requiredTag = string.Empty;

    [Serializable] public class TriggerEvent : UnityEvent<Collider> { }

    // When the object enters a collision
    public TriggerEvent OnEnter = new TriggerEvent();

    // When the object exits a collision
    public TriggerEvent OnExit = new TriggerEvent();

    // Add a reference to the ToggleParticle script
    public ToggleParticle lighterToggleParticle;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LighterFlame"))
        {
            // Also checks if the lighter is on
            if (CanTrigger(other.gameObject) && lighterToggleParticle.isPlaying)
                OnEnter?.Invoke(other);
                Debug.Log("The candle has been lit");
        }
        else
        {
            if (CanTrigger(other.gameObject))
                OnEnter?.Invoke(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (CanTrigger(other.gameObject))
            OnExit?.Invoke(other);
    }

    private bool CanTrigger(GameObject otherGameObject)
    {
        if (requiredTag != string.Empty)
        {
            return otherGameObject.CompareTag(requiredTag);
        }
        else
        {
            return true;
        }
    }

    private void OnValidate()
    {
        if (TryGetComponent(out Collider collider))
            collider.isTrigger = true;
    }
}
