using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class CheckCollisions : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private GameObject _popUpWindow;
    [SerializeField] private Text _questionDisplay;
    [SerializeField] private QuestionController _index;
    [SerializeField] private QuestionController _animators;
    [SerializeField] private AudioSource _hitSFX;
    [SerializeField] private Animator _player_Anim;
    
 
    
    // Check to see if the player has collided with any of the questions.
    private void OnTriggerEnter2D(Collider2D collision)
        {
            _hitSFX.Play();
            // Check to see if the object the player collided with has been tagged with 'Mechanics'.
            if (collision.gameObject.CompareTag("Mechanics"))
                {
                    // if yes, load the linked question.
                    _index._topicIndex = 0;
                    _index.DisplayQuestion();
                }
            if (collision.gameObject.CompareTag("Algebra"))
                { 
                    _index._topicIndex = 1;
                    _index.DisplayQuestion();
                }
            if (collision.gameObject.CompareTag("Statistics"))
                { 
                    _index._topicIndex = 2;
                    _index.DisplayQuestion();
                }
            if (collision.gameObject.CompareTag("Operational Research"))
                {
                    _index._topicIndex = 3;
                    _index.DisplayQuestion();
                }
            // Set player animation to idle
            _player_Anim.SetBool("IsRunning", false);


        }
    
         
}

