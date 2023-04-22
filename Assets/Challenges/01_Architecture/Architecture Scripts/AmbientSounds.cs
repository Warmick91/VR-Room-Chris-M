using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSounds : MonoBehaviour
{
    GameObject ambientSound;
    // Start is called before the first frame update
    void Start()
    {
        ambientSound = GameObject.Find("Ambient Sounds Source");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
