using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class CloseDialogue : MonoBehaviour
{
    [SerializeField] private GameObject _playerWindow;
    [SerializeField] private AudioSource _sceneMusic;
    [SerializeField] private AudioSource _teleportSFX;
    [SerializeField] private Text _playerText;
    [SerializeField] private GameObject _teacherWindow;
    [SerializeField] private Text _teacherText;
    [SerializeField] private Button _OKBtn;
    [SerializeField] private Button _nextBtn;
    [SerializeField] private Animator Player_anim;
    private string [] _playersConvo = {"Congratulations! Now do you understand, maths is an essential part of life?", "I guess? But when am I going use it?","The castle was just the beginning.", "Wait? I can use maths outside of the castle?","Of course! Maths is everywhere, explore the map to discover more.", "Oh no, not again! AHHHHHHH!..."};
    private float _letterPause;
    private float _speakerPause;
    private string _lineSpeaking;
    private string _speakingLine;
    private bool _teacherTalking;
    private int i;
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
        _OKBtn.onClick.AddListener(OKButton);
        _OKBtn.gameObject.SetActive(false);
        StartCoroutine(CoroutineDisplayDialogue());
    }

    // Called every Frame
    private void Update()
    {
        if (i == _playersConvo.Length)
        {
            _OKBtn.gameObject.SetActive(true);
        }
    }
    // Stops the dialogue, calls the telemport animation and activates the button to go to the next scene
    public void OKButton()
    {   
        StopAllCoroutines();
        Player_anim.SetBool("Finnished_talking", true);
        _teleportSFX.Play();
        Invoke("ShowBtn", 1);
    }
    // Activates the button to go to the next scene
    private void ShowBtn()
    {
       _nextBtn.gameObject.SetActive(true);
        _OKBtn.gameObject.SetActive(false);
    }
    // Shows the Dialogue boxes
    private void ShowDialogueWindow()
    {
        _playerWindow.SetActive(true);
        _teacherWindow.SetActive(true);
    }
    // Starts the coroutine, allowing the "teacher" and "Student" to talk at the same time and from teh same dialogue script
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
