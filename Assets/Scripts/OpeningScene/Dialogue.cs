using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject _playerWindow;
    [SerializeField] private AudioSource _sceneMusic;
    [SerializeField] private AudioSource _teleportSFX;
    [SerializeField] private Text _playerText;
    [SerializeField] private GameObject _teacherWindow;
    [SerializeField] private Text _teacherText;
    [SerializeField] private Button _nextBtn;
    [SerializeField] private Button _OKBtn;
    [SerializeField] private Animator Player_anim;
    private string [] _playersConvo = {"Welcome brave adventurer to Castle Conundrum.", "Castle conundrum?","Here you must face your worst fears to be able to escape...MATHS problems!", "NO!...please, anything but maths!", "Good Luck!",  "AHHHHHHHH!..."};
    private int i;
    private float _letterPause;
    private float _speakerPause;
    private string _lineSpeaking;
    private string _speakingLine;
    private bool _teacherTalking;
    
    // First step of initialisation
    private void Awake()
    {
        i = 0;
        _letterPause = 0.1f;
        _speakerPause = 2f;
        _sceneMusic.time = 4;
        _sceneMusic.Play();
        ShowDialogueWindow();
    }

    // Second step of initialisation
    private void Start()
    {
        _teacherTalking = true;
        _nextBtn.onClick.AddListener(NextButton);
        _nextBtn.gameObject.SetActive(false);
        _OKBtn.gameObject.SetActive(false);
        StartCoroutine(CoroutineDisplayDialogue());
    }

    // Called every frame
    private void Update()
    {
        if (i == _playersConvo.Length)
        {
            _nextBtn.gameObject.SetActive(true);
        }
    }

    // Stops the Dialogue, Plays the teleport animation and enables the button to progress
    public void NextButton()
    {   
        StopAllCoroutines();
        Player_anim.SetBool("Finnished_talking", true);
        _teleportSFX.Play();
        Invoke("ShowBtn", 1);
    }

    // Shows the Dialogue boxes
    private void ShowDialogueWindow()
    {
        _playerWindow.SetActive(true);
        _teacherWindow.SetActive(true);
    }

    // Reveals the button to go to the next scene
    private void ShowBtn()
    {
        _nextBtn.gameObject.SetActive(false);
        _OKBtn.gameObject.SetActive(true);
    }

    // Allows the "Teacher" and the "Student" to talk at the same time from the same script
    private IEnumerator CoroutineDisplayDialogue()
    {
        _speakingLine = _playersConvo[i];
        for (int j = 0; j < _speakingLine.Length; j++)
        {
            
            if (_teacherTalking)
            {
                _teacherText.text += _speakingLine[j];
                _playerText.text = "";
            }
            else
            {
                _playerText.text += _speakingLine[j];
                _teacherText.text = "";
            }
            yield return new WaitForSeconds(_letterPause);
        }
        i++;
        _teacherTalking = !_teacherTalking;
        yield return new WaitForSeconds(_speakerPause);
        StartCoroutine(CoroutineDisplayDialogue());
    }
    
}
