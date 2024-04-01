using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rullesmenu : MonoBehaviour
{
    [SerializeField] GameObject _controlsMenu;
    [SerializeField] GameObject _rulesMenu;
    // Start is called before the first frame update
    void Start()
    {
        Rulesmenu();
    }

    // Reveals the rules
    public void Rulesmenu()
    {
        _controlsMenu.SetActive(false);
        _rulesMenu.SetActive(true);
    }

    // Reveals the controls
    public void ControlsMenu()
    {
        _rulesMenu.SetActive(false);
        _controlsMenu.SetActive(true);
    }

    // Moves to the next scene
    public void Game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Moves to the previous scene
    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
