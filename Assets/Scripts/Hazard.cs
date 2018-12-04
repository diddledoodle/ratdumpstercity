using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered the hazard.");
            PhysicsPlayerCharacter player = collision.GetComponent<PhysicsPlayerCharacter>();

            player.isDead = true;
          
            player.Respawn();

        }
        else
        {
            Debug.Log("Something other than the player entered the hazard.");
        }
        
    }

}
