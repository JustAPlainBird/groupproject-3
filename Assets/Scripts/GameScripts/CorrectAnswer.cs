using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectAnswer : MonoBehaviour
{
    [SerializeField] private GameObject _sprite;
    // If the question has been answered correctly, play the star animation then turn off.
    public void End()
    {
        _sprite.gameObject.SetActive(false);
    }
}
