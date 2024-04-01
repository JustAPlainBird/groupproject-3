using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Door : MonoBehaviour
{
    // Declare the variables and pass the instances in via the unity editor
    [SerializeField] private QuestionCounter _count;
    [SerializeField] private QuestionController _index;
    [SerializeField] private GameObject _alertWindow;
    [SerializeField] private Button _closeBtn;
   [SerializeField] private Animator _anim;

    // Called when the scene starts
    private void Start()
        {
            _alertWindow.SetActive(false);
            // Listen for a button click 
            _closeBtn.onClick.AddListener(MovePlayer);
        }

    // Called when the player colides with the player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check to see if the object the door collided with has a PlayerMovement component.
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            // If yes, then check to see if the 4 questions have been answered.
            if (_count._questCount == 4)
            {
                // If yes, stop the player running animation and freeze movement, then load the final escape question
                _index._canMove = false;
                _anim.SetBool("IsRunning", false);
                _index._topicIndex = 4;
                _index.DisplayQuestion();
            }
            else if (_count._questCount != 4)
            {
                // Player can't move if window is open.
                _index._canMove = false;
                _anim.SetBool("IsRunning", false);
                // Then print message to go back and complete the questions.
                _alertWindow.SetActive(true);
            }
            
        }
    }
    
    // Allow the player to move again.
    private void MovePlayer()
    {
        _index._canMove = true;
        _alertWindow.SetActive(false);
    }
    
}