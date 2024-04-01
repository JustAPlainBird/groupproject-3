using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Destroys the game object that calls it
    private void Correct()
    {
        Destroy(gameObject);
    }
}
