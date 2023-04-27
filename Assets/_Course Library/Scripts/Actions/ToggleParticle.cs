using UnityEngine;

/// <summary>
/// Toggles particle system
/// </summary>
[RequireComponent(typeof(ParticleSystem))]
public class ToggleParticle : MonoBehaviour
{
    private ParticleSystem currentParticleSystem = null;
    private MonoBehaviour currentOwner = null;
    public bool isPlaying = false;

    private void Awake()
    {
        currentParticleSystem = GetComponent<ParticleSystem>();
    }

    public void Play()
    {
        currentParticleSystem.Play();
        isPlaying = true;
    }

    public void Stop()
    {
        currentParticleSystem.Stop();
        isPlaying = false;
    }

    public void PlayWithExclusivity(MonoBehaviour owner)
    {
        if (currentOwner == null)
        {
            currentOwner = this;
            Play();
            isPlaying = true;
        }
    }

    public void StopWithExclusivity(MonoBehaviour owner)
    {
        if (currentOwner == this)
        {
            currentOwner = null;
            Stop();
            isPlaying = false;
        }
    }

    private void OnValidate()
    {
        if (currentParticleSystem)
        {
            ParticleSystem.MainModule main = currentParticleSystem.main;
            main.playOnAwake = false;
        }
    }
}
