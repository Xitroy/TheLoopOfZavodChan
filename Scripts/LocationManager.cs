using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
    public AudioClip audioClipEnter;
    public AudioClip audioClipExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.TryGetComponent(out Player player))
            player.cam.GetComponent<AudioSource>().clip = audioClipEnter;
        player.cam.GetComponent<AudioSource>().Play();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.TryGetComponent(out Player player))
            player.cam.GetComponent<AudioSource>().clip = audioClipExit;
        player.cam.GetComponent<AudioSource>().Play();
    }
}
