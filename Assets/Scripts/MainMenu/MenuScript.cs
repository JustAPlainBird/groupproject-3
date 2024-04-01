using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuScript : MonoBehaviour
{

    public AudioMixer _audioMixer;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private GameObject _credits;
    [SerializeField] private AudioSource _testSFX;
    [SerializeField] private AudioSource _menuMusic;

    // Called when the scene starts
    private void Start()
    {
        _menuMusic.time = 3;
        _menuMusic.Play();
        _settingsMenu.SetActive(false);
        _credits.SetActive(false);
        _mainMenu.SetActive(true);
    }
    
    // Moves to the next scene
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Moves to the previous scene
    public void PreviousScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
    // Closes the game
    public void Quit()
    {
        Application.Quit();
    }

    // Opens the settings menu
    public void settingsMenu()
    {
        _mainMenu.SetActive(false);
        _settingsMenu.SetActive(true);
    }

    // Opens the main menu
    public void MainMenu()
    { 
        _settingsMenu.SetActive(false);
        _credits.SetActive(false);
        _mainMenu.SetActive(true);
    }

    // Opens the Credits screen
    public void Credits()
    {
        _mainMenu.SetActive(false);
        _credits.SetActive(true);
    }

    // Sets the value of the "master volume" mixer to the slider's value 
    public void MasterVolume(float input)
    {
        _audioMixer.SetFloat("MasterVolume", input);
    }

    // Sets the value of the "music volume" mixer to the slider's value
    public void MusicVolume(float input)
    {
        _audioMixer.SetFloat("MusicVolume", input);
    }

    // Sets the value of the "SFX volume" mixer to the slider's value
    public void SFXVolume(float input)
    {
        _audioMixer.SetFloat("SFXVolume", input);
    }

    // Plays a SFX so the player can test the volume they've set
     public void TestSFX()
    {
        _testSFX.Play();
    }
}
