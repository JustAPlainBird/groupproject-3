using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMovement : MonoBehaviour
{
    [SerializeField] private int _bugSpeed;
    [SerializeField] private GameObject _target;
    private Transform _targetPosition;
    // Start is called before the first frame update
    private void Start()
    {
        // Get the position of the target.
        _targetPosition = _target.GetComponent<Transform>();
       
    }

    // Called every frame
    private void Update()
    {
        // Going from current position towards the player position over specified speed * time (distance).
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition.position, _bugSpeed * Time.deltaTime);
    }
}
