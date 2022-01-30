using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetSound : MonoBehaviour
{
    [SerializeField] AudioSource magnetSound;
    private MagnetMechanic magnet;

    // Start is called before the first frame update
    void Start()
    {
        magnet = GetComponent<MagnetMechanic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (magnet._state == MagnetMechanic.States.Pull || magnet._state == MagnetMechanic.States.Push)
        {
            if(!magnetSound.isPlaying)
            magnetSound.Play();
        }
    }
}
