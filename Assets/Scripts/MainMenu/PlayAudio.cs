using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    [SerializeField] new AudioSource audio = new AudioSource();

    private void Start()
    {
        audio.Play();
    }
}
