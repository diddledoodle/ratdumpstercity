using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 100;

    private void Update()
    {
        UpdateRotation();
    }
    private void UpdateRotation()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entering the checkpoint.");
            PhysicsPlayerCharacter player = collision.GetComponent<PhysicsPlayerCharacter>();
            player.SetCurrentCheckpoint(this);

        }

    }
}
