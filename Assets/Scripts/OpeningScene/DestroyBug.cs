using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBug : MonoBehaviour
{
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // If the "bug" reaches the endpoint it is destroyed
   private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Target"))
        {
            // Will destroy the bug on collision with leaves. 
            Destroy(gameObject);
        }
    }
}
