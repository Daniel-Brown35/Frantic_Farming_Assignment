using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{

    private AudioSource audioSource;
    public AudioClip splatSound;

    private void Start()
    {
        audioSource = GameObject.Find("SoundSystem").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground" || collision.gameObject.tag == "Animal")
        {
            audioSource.PlayOneShot(splatSound);
            Destroy(gameObject);
        }
    }
}
