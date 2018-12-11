using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{
    PhysicsPlayerCharacter player;

    AudioSource audioSource;
    SpriteRenderer spriteRenderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.GetComponent<PhysicsPlayerCharacter>();
            spriteRenderer = player.GetComponent<SpriteRenderer>();
            audioSource = player.GetComponent<AudioSource>();

            Debug.Log("Player entered the hazard.");

            audioSource.Play();

            player.canDoInput = false;
            player.GetComponent<Rigidbody2D>().velocity = new Vector3 (0,0,0);
            player.transform.localScale = new Vector3(player.transform.localScale.x, -1, player.transform.localScale.z);
            
            StartCoroutine(pauseenumerator());
        }
        else
        {
            Debug.Log("Something other than the player entered the hazard.");
        }
    }

    IEnumerator pauseenumerator()
    {
        yield return new WaitForSeconds(0.7f);

        player.Respawn();
    }
}
