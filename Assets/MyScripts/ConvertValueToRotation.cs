using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class ConvertValueToRotation : MonoBehaviour
{
    [Range(0, 360)] public float rotation = 0f;
    [Serializable] public class RotationChangeEvent : UnityEvent<float> { }
    public RotationChangeEvent OnRotationChange = new RotationChangeEvent();

    public XRDirectInteractor directInteractor;
    public GameObject sliderHandle;

    public void SetRotation(float value)
    {
        value = Mathf.Clamp(value, 0, 360);
        OnRotationChange.Invoke(value);
    }

    private void OnEnable()
    {
        directInteractor.selectExited.AddListener(HandleSelectExit);
    }

    private void OnDisable()
    {
        directInteractor.selectExited.RemoveListener(HandleSelectExit);
    }

    public UnityEvent OnSliderHandRelease = new UnityEvent();

    private void HandleSelectExit(SelectExitEventArgs args)
    {
        if(args.interactorObject.Equals(sliderHandle))
        {
            OnSliderHandRelease.Invoke();
        }
    }

    public void GetRotationValue()
    {
        Debug.Log("Rotation value: " + rotation);
    }
}
