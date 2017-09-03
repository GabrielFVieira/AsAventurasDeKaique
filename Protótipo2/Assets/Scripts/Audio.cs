using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Audio : MonoBehaviour
{
    public Slider sound;
    public AudioSource song;
    public MenuManager menuManager;
    public void Start()
    {
        menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
        song = GameObject.Find("MenuManager").GetComponent<AudioSource>();

        sound.value = menuManager.SoundState;

    }

    public void Update()
    {
        menuManager.SoundState = song.volume;
        song.volume = sound.value;
    }
}