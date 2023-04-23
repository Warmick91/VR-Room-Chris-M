using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSoundsSource : MonoBehaviour
{

    AudioClip[] birdSoundsClips;
    [SerializeField] SphereCollider excludedZone;
    [SerializeField] float birdVolume = 1f;
    //AudioSource birdSoundSource;

    // Start is called before the first frame update
    void Start()
    {
        birdSoundsClips = Resources.LoadAll<AudioClip>("Sounds/Birds Sounds");
        if (birdSoundsClips.Length < 3 || birdSoundsClips == null)
        {
            Debug.Log("Problem loading Birds Sounds");
        }
        else
        {
            Debug.Log("Birds Sounds loaded");
        }

        //birdSoundSource = gameObject.AddComponent<AudioSource>();
        StartCoroutine(PlayBirdSounds());
    }


    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator PlayBirdSounds()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 4f));
            AudioClip clip = birdSoundsClips[Random.Range(0, birdSoundsClips.Length)];
            Vector3 position = GenerateRandomPosition();
            AudioSource.PlayClipAtPoint(clip, position, birdVolume);
        }
    }

    Vector3 GenerateRandomPosition()
    {
        float x = Random.Range(-10f, 20f);
        float y = Random.Range(2.5f, 5.5f);
        float z = Random.Range(-12f, 15f);
        Vector3 position = new Vector3(x, y, z);
        while (excludedZone.bounds.Contains(position))
        {
            x = Random.Range(-10f, 20f);
            y = Random.Range(2.5f, 5.5f);
            z = Random.Range(-12f, 15f);
            position = new Vector3(x, y, z);
        }
        return position;
    }
}
