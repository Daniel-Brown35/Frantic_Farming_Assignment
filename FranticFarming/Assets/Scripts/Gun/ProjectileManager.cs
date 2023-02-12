using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{

    private AudioSource audioSource;
    public AudioClip splatSound;
    public float despawnDelay;
    private float despawnTimer;

    private void Start()
    {
        audioSource = GameObject.Find("SoundSystem").GetComponent<AudioSource>();
    }

    private void Update()
    {
        despawnTimer += Time.deltaTime;

        if (despawnTimer >= despawnDelay)
        {
            Destroy(gameObject);
        }
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
