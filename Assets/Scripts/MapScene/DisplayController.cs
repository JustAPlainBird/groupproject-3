using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;

public class DisplayController : MonoBehaviour
{
    [SerializeField] private GameObject _displayWindow;
    [SerializeField] private AudioSource _sceneMusic;
    [SerializeField] private AudioSource _btnSFX;
    [SerializeField] private Text _displayText;
    [SerializeField] private Button _eggBtn;
    [SerializeField] private Button _scrollBtn;
    [SerializeField] private Button _coinBtn;
    [SerializeField] private Button _hatBtn;
    [SerializeField] private Button _doorBtn;
    [SerializeField] private Button _exitBtn;
    private string _mechanicsExample = "Mechanics is a branch of physics that deals with behaviour of pyshical bodies. It applies to engineering (design structures, machines and aircraft), sports (improving technique e.g running) and biomechanics (structure and function of living organisms and injury prevention).";
    private string _algebraExample = "Algebra is fundamental in solving equations and understaning patterns. It's used in computer science (coding and cryptography), finance (interest calculations and investment analysis), and physics(modelling systems with equations).";
    private string _statsExample = "Statistics involves collecting, analysing and interpretating data. It's cruial in medicine (clinical trials and data analysis) and is used by the NHS to analyse trends of disease to determine which groups of individuals might be susceptible to certain diseases for example, COVID-19. It's used in business (market research and forecasting), and in sociology(survey analysis) to make informed decisions based on data patterns/trends.";
    private string _orExample = "Operational research expands over several domains, using advanced analytical methods to make better decisions in complex scenarios. It's used in business operations (inventory management and production scheduling) to help minimise costs and maximise efficiency, in transportation and logistics (routes and vechicle assignments and flight schedules), more examples include healthcare management, energy and utilities, government, finance and investment, manufacturing and production and environmental management.";
    private string _cryptoExample = "Cryptography is the art of secure communication. It protects data (encryption of data stored online), is used in shopping (securing e-commerce transactions and blocking interceptions)and in blockchain technology (Bitcoin and Ethereum).";

    // Start is called before the first frame update
    private void Start()
    {
        _displayWindow.SetActive(true);
        _sceneMusic.time = 3;
        _sceneMusic.Play();
        _eggBtn.onClick.AddListener(Mechanics);
        _scrollBtn.onClick.AddListener(Algebra);
        _coinBtn.onClick.AddListener(Statistics);
        _hatBtn.onClick.AddListener(OperationalResearch);
        _doorBtn.onClick.AddListener(Cryptography);
        _exitBtn.onClick.AddListener(ExitGame);
    }

    // Displays the info on mechanics
    private void Mechanics()
    {
        _displayText.text = _mechanicsExample;
    }

    // Displays the info on statistics
    private void Statistics()
    {
        _displayText.text = _statsExample;
    }

    // Displays the info on algebra
    private void Algebra()
    {
        _displayText.text = _algebraExample;
    }

    // Displays the info on operational research
    private void OperationalResearch()
    {
        _displayText.text = _orExample;
    }

    // Displays the info on cryptography
    private void Cryptography()
    {
        _displayText.text = _cryptoExample;
    }

    // Exits the game
    private void ExitGame()
    {
        Application.Quit();
    }

    // Plays the "hit" SFX
    public void PlaySFX()
    {
        _btnSFX.Play();
    }
}
