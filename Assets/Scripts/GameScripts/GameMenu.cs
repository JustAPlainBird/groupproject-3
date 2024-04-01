using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _rulesMenu;
    [SerializeField] private GameObject _controlsText;
    [SerializeField] private GameObject _rulesText;
    [SerializeField] private GameObject _menuButton;

    // When the game starts it hides the menu
    private void Start()
    {
        _menuButton.SetActive(true);
        _menu.SetActive(false);
        _rulesMenu.SetActive(false);
    }

    // Reveals the menu when the button is pressed
    public void ActiveateMenu()
    {
        _menu.SetActive(true);
        _menuButton.SetActive(false);
    }

    // If the rules/ controls is not currently shown it shows them, if they are already shown it closes.
    public void RulesMenu()
    {
        if (_rulesMenu.activeInHierarchy == false)
        {
            _rulesMenu.SetActive(true);
        }
        else 
        {
            _rulesMenu.SetActive(false);
        }
    }

    // Shows the rules
    public void RulesText()
    {
        _controlsText.SetActive(false);
        _rulesText.SetActive(true);
    }

    // Shows the controls
    public void ControlsText()
    {
        _rulesText.SetActive(false);
        _controlsText.SetActive(true);
    }

    // Restarts the game scene
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Jump to the menu scene
    public void Menu()
    {
        Application.LoadLevel(0);
    }
    
    // Closes the game
    public void Quit()
    {
        Application.Quit();
    }
}
