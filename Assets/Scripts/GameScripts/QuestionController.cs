using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class QuestionController : MonoBehaviour
{
    // Declare the variables and pass the instances in via the unity editor
    [SerializeField] private GameObject _popUpWindow;
    [SerializeField] private GameObject _hintWindow;
    [SerializeField] private GameObject _starAnswer;
    [SerializeField] private AudioSource _correctSFX;
    [SerializeField] private AudioSource _wrongSFX;
    [SerializeField] private AudioSource _fanfareSFX;
    [SerializeField] private Text _questionDisplay;
    [SerializeField] private Text _hintDisplay;
    [SerializeField] private Button _OKbtn;
    [SerializeField] private Button _closeBtn;
    [SerializeField] private Button _hintBtn;
    [SerializeField] private  TMP_InputField _playerInput;
    [SerializeField] private QuestionCounter _count;
    [SerializeField] private Rigidbody2D _player;
    [SerializeField] private Animator _anim_OR;
    [SerializeField] private Animator _anim_Stat;
    [SerializeField] private Animator _anim_Mech;
    [SerializeField] private Animator _anim_Alg;
    [SerializeField] private Animator _anim_Player;
    private string _userInput;

    // Getters/Setters set restrictions on setting and getting a variable value.
    public string _correctInput {private get; set;}
    // E.g. _isCorrect has a public get value, and a private set value.
    public bool _isCorrect {get; private set;}
    public int _topicIndex {private get; set;}
    public bool _canMove {get; set;}

    

    private string[] _questions = {
            "A stone is launched from a catapult in the castle grounds so that its velocity v ms^-1 at time, t seconds is given by:V = 3t^2-6t-6. At time t=0, the stones displacement is 1m. Find the displacement at t = 10",
            "Hidden in a castle you find a bag of rubies, and sapphires sat on a podium. To open leave with them you need to find something of the same weight to replace the bag. The weight is given as, 3x^2 - 6x + w = 0 ;w is positive and has equal roots. Find the value of w.",
            "You're counting your coins after a raid. Of total coins, 10% are gold, 30% sliver and the rest are copper. \n6% of the total coins are fake. 9% of the the gold coins are fake and so are 3% of the sliver coins. \nFind the percentage of the copper coins that are fake.",
            "While trying decide which path to take you meet five numbered trolls ( 1, 2, 4, 5, 7). Knowing 4 of them tell lies and only 1 tells the truth you must work out which one to ask for directions. You are given the following to find the numbers of the lying trolls; 2x^2+y-y^2=8, 2x-y=3",
            "To open the door to the dungeon you need say the password. Luckily you already have the encoded password, 7 6 3 3 1 4 1 5 3 2 , it's the numbers you found from solving the questions! You can decipher the password using the following key; W = 4, E = 6, L = 3, H = 7, D = 2, R = 5 and O = 1.",
        };
    private string[] _answers =  {
            "641",
            "3",
            "7",
            "1257",
            "hello world",
        };
    private string[] _topic = {
            "Mechanics",
            "Algebra",
            "Statistics",
            "Operational Research",
            "Door"
        };
        private string[] _hints = {
            "Mechanics Hint : Integrate the equation and sub in t = 0",
            "Algebra Hint : The discriminate b^2-4ac must be equal to 0",
            "Statistics Hint : Draw a venn diagram",
            "Operational Research Hint : Rearrange equation 2 and substitute it into equation 1.",
            "Door Hint : Sorry you don't get a hint for this question!"
        };
        
    
    // Called when the scene starts
    private void Awake()
    {
        // Set init variable values
        _topicIndex = -1;
        _isCorrect = false;
        _canMove = true;
        _anim_Player.SetBool("IsRunning", false);
        _popUpWindow.SetActive(false);
        _hintBtn.gameObject.SetActive(false);
        _hintWindow.SetActive(false);
        _starAnswer.SetActive(false);
    }

    // Listen for button clicks.
    private void Start()
    {
        _OKbtn.onClick.AddListener(SubmitAnswer);
        _closeBtn.onClick.AddListener(PlayerMove);
    }

    // Displays the correct question
    public void DisplayQuestion()
    {
        _hintWindow.SetActive(false);
        _hintBtn.gameObject.SetActive(false);
        _canMove = false;
        _popUpWindow.SetActive(true);
        _questionDisplay.text = _questions[_topicIndex];
        _playerInput.text = "";
    }
    // Takes the input the user makes and compares it to the correct answer for that question and acts accordingly
    private void SubmitAnswer()
    {
        _userInput = _playerInput.text.ToString();
        _correctInput = _answers[_topicIndex];
        if (_userInput == _correctInput)
        {
            _isCorrect = true;
            CorrectAnswer(_topicIndex);
        }
        else
        {
            _isCorrect = false;
            _wrongSFX.Play();
            if (_playerInput.text.ToString() != "")
            {   
                _playerInput.text = "";
                EnableHint();
            }
        }
    }
    // Check to see if the answer matches the player input.
    private void CorrectAnswer(int i)
    {
        if (_isCorrect)
        {
            // If yes, play the SFX, animation, close window and allow player to move.
            _count.UpdateCount();
            _starAnswer.SetActive(true);
            _correctSFX.Play();
            _popUpWindow.SetActive(false);
            _canMove = true;
            // Destroy the relevant question sprite
            switch(_topicIndex)
            {
                case 0:
                    _anim_Mech.SetBool("Correct", true);
                    break;
                case 1:
                    _anim_Alg.SetBool("Correct", true);
                    break;
                case 2:
                    _anim_Stat.SetBool("Correct", true);
                    break;
                case 3:
                    _anim_OR.SetBool("Correct", true);
                    break;
                case 4:
                    _fanfareSFX.Play();
                    _anim_Player.SetBool("hasFinished", false);
                    break;

            }
            
        }
    }

    // Show the hint btn.
    private void EnableHint()
    {
        _hintBtn.gameObject.SetActive(true);
    }
    // If hint btn clicked, show the hint.
    public void ShowHint()
    {
        _hintWindow.SetActive(true);
        _hintDisplay.text = _hints[_topicIndex];

    }
    // Close window and allow player to move.
    public void PlayerMove()
    {
        _popUpWindow.SetActive(false);
        _canMove = true;
    }
}
