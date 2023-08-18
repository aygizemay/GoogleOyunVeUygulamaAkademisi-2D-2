using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{
    [SerializeField] private AudioClip _clickSound;
    private int count = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            count++;
            AudioSource.PlayClipAtPoint(_clickSound, other.transform.position);
            Destroy(other.gameObject);
        }
    }
}

