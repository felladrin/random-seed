using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {
    public AudioClip music;
    private AudioSource source;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        source = gameObject.AddComponent<AudioSource>();
        source.loop = true;
    }
    
    void Start()
    {
        source.clip = music;
        source.Play();
    }
}
