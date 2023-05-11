using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// This script takes a value and converts it to a hue along the HSV color spectrum.
/// </summary>

public class ConvertValueToHue : MonoBehaviour
{
    [Range(0, 1)] public float saturation = 1.0f;
    [Range(0, 1)] public float value = 0.5f;

    [Serializable] public class ColorChangeEvent : UnityEvent<Color> { }
    public ColorChangeEvent OnColorChange = new ColorChangeEvent();

    public XRDirectInteractor directInteractor;
    public GameObject sliderHandle;

    public void SetHue(float value)
    {
        value = Mathf.Clamp(value, 0, 1);
        Color newColor = Color.HSVToRGB(value, saturation, value);
        OnColorChange.Invoke(newColor);
    }

    private void OnEnable()
    {
        directInteractor.selectExited.AddListener(HandleSelectExit);
    }

    private void OnDisable()
    {
        directInteractor.selectExited.RemoveListener(HandleSelectExit);
    }

    public UnityEvent OnSliderHandRelease;

    private void HandleSelectExit(SelectExitEventArgs args)
    {
        if (args.interactorObject.Equals(sliderHandle))
        {   
            OnSliderHandRelease.Invoke();
            Debug.Log("Handle released");
        }
            
    }

}
