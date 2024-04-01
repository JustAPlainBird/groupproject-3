
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    // Variables needed for the player to move.
    // [SerializeField] allows you to declare the variable value from the Unity scene editor
    // It's the same as making it public instead of private. 
    [SerializeField] private QuestionController _info;
    private int _playerSpeed = 5;
    private float dirx;
    private Rigidbody2D _rigidbody;
    private Vector2 _userInput;
    // These variables are used to make the movement of the player a lot smoother.
    private Vector2 _smootherMovementTransition;
    private Vector2 _smootherMovementVelocity;
    private Animator _anim;
    private SpriteRenderer _spriterenderer;

    
   
    // Runs on the game awake.
    private void Awake()
    {
        // Finds the rigid body component attached to the game object (Player)
        // And will save it in the variable.
        _rigidbody = GetComponent<Rigidbody2D>();
        // Can't move while 'teleporting'
        _rigidbody.bodyType = RigidbodyType2D.Static;
        // sets init vals for the animtor
        _anim = GetComponent<Animator>();
        _anim.SetBool("IsRunning", false);
        _spriterenderer = GetComponent<SpriteRenderer>();

    }
    
    // Allows the player to move once the starting animation has played
    public void StartGame()
    {
        // Can now move after finishing 'teleporting'
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        // Sets the player animation to idle after finishing teleporting anim
        _anim.SetBool("hasFinished", true);
    }

    // Called every frame
    private void FixedUpdate()
    {
        // If the player can move (not in a question screen)
        if (_info._canMove)
            {
                // Move player
                PlayerMove();
                // Run relevent animation (e.g. idle or running)
                UpdateAnim();
            }
    }

    /// <summary>
    /// The OnMove uses the Input System extension to get the movement from default inputs e.g arrow keys or WASD keys. inputValue is what keys are being pressed. Saves the user input as vector values (x,y).
    /// </summary>
    /// <param name="inputValue"></param>
    private void OnMove(InputValue inputValue) 
    {
        //Vector2 has 2 params one for X and Y.
        _userInput = inputValue.Get<Vector2>();
    }

    /// <summary>
    /// Moves the player direction using the user input. Moves the player at the speed assigned. Smoothes the movement of the player.
    /// </summary>
    private void PlayerMove()
    {
        _smootherMovementTransition = Vector2.SmoothDamp(_smootherMovementTransition, _userInput, ref _smootherMovementVelocity, 0.1f);
        _rigidbody.velocity = _smootherMovementTransition * _playerSpeed;
        
    }
    
    /// <summary>
    /// Changes the player animation based on keyboard input.
    /// </summary>
    private void UpdateAnim()
    {
        
        if (_rigidbody.velocity.x < -0.1f)
        {
            _anim.SetBool("IsRunning", true);
            _spriterenderer.flipX = false;
        }
        else if (_rigidbody.velocity.x > 0.1f)
        {
            _anim.SetBool("IsRunning", true);
            _spriterenderer.flipX = true;
        }
        else if (_rigidbody.velocity.y < -0.1f)
        {
            _anim.SetBool("IsRunning", true);
        }
        else if (_rigidbody.velocity.y > 0.1f)
        {
            _anim.SetBool("IsRunning", true);
        }
        else
        {
            _anim.SetBool("IsRunning", false);
        }
    } 

    /// <summary>
    /// Move to the next scene.
    /// </summary>
    private void EndGameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void GameStartCheck()
    {
        _anim.SetBool("hasStarted", true);
    }

}
