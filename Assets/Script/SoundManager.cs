using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audios;
    private AudioSource controladorAudio;

    private void Awake()
    {
        controladorAudio = GetComponent<AudioSource>();
    }

    public void SelecionAudio(int indice, float volumen)
    {
        controladorAudio.PlayOneShot(audios[indice], volumen);
    }
}
