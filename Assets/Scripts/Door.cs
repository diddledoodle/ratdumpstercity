using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField]
    private string scenetoLoad;

    private bool isPlayerInTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }
    private void nTriggerExit2D(Collider2D collision)
    {
        isPlayerInTrigger = false;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Activate") && isPlayerInTrigger)
        {
            Debug.Log("Player activated door!");
            SceneManager.LoadScene(scenetoLoad);
        }
    }
}