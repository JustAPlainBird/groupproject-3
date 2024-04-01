using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionCounter : MonoBehaviour
{
    // Add the UI text area for the coin counter in the script from the editor.
    [SerializeField] private TMP_Text  _questionCounter;
    // A counter for the number of questions that havce been answered.
    public int _questCount { get ; private set ;}

    // Caled when the scene starts
    private void Awake()
        {
            _questCount = 0;
            DisplayCount();
        }

    // Update is called once per frame
    private void Update()
        {
            // Max display is 4/4. Don't count the door correct answer.
            if (_questCount != 5)
            {
               DisplayCount();
            }
            
        }
    // Displays the number of correct answers out of 4
    private void DisplayCount()
        {
            _questionCounter.text =  _questCount.ToString() + " / " + "4";
        }
    // increases the number of correct answers to disply. Doesnt allow the number displayed to be greater than 4
    public void UpdateCount()
        {
            if (_questCount < 4)
            {
                _questCount++;
                _questionCounter.text = _questCount.ToString() + " / 4";
            }
        }
}