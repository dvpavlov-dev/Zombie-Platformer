using System.Collections.Generic;
using UnityEngine;

public class ZombieDeadController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private List<AudioClip> _deadSounds;
    
    void Start()
    {
        _audioSource.clip = _deadSounds[Random.Range(0, _deadSounds.Count)];
        _audioSource.Play();
        
        Destroy(gameObject,  _audioSource.clip.length);
    }
}
