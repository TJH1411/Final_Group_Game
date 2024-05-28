using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 Instance;
    public List<int> numberList;
    public List<int> targetTotals; // List of possible target totals

    private AppleScript1[] selectedApples = new AppleScript1[2]; // Array to store the selected apples
    private int targetTotal; // Current target total that user needs to achieve
    public TextMeshProUGUI resultText1; // TextMeshProUGUI component that displays the result
    public TextMeshProUGUI questionText; // TextMeshProUGUI component to display the question

    private int correctAnswersCount = 0; // Counter for correct answers
    public int requiredCorrectAnswers = 4; // Number of correct answers needed to transition to the next scene
    public string nextSceneName = "NextScene"; // Name of the next scene to load

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        numberList = new List<int> { 1, 2, 2, 4, 5, 7, 6, 8, 9 };
        targetTotals = new List<int> { 3, 4, 5, 7 }; // Add your possible target totals here
    }

    private void Start()
    {
        SelectRandomTargetTotal(); // Select a random target total at the start
        UpdateQuestionText(); // Update the question text at the start
    }

    // Function to add selected apples to the array
    public void SelectApple(AppleScript1 apple)
    {
        for (int i = 0; i < selectedApples.Length; i++)
        {
            if (selectedApples[i] == null)
            {
                selectedApples[i] = apple;
                apple.GetComponent<MeshRenderer>().material.color = Color.yellow;
                break;
            }
        }

        if (selectedApples[1] != null)
        {
            CheckTotal();
        }
    }

    private void CheckTotal()
    {
        int total = selectedApples[0].appleNumber - selectedApples[1].appleNumber; // Assuming you want the sum

        if (total == targetTotal)
        {
            resultText1.text = "Correct! The total is " + total;
            correctAnswersCount++; // Increment the correct answers counter

            if (correctAnswersCount >= requiredCorrectAnswers)
            {
                TransitionToNextScene(); // Transition to the next scene if the required number of correct answers is reached
            }
            else
            {
                ResetSelectedApples(); // Reset apples after checking
                SelectRandomTargetTotal(); // Select a new random target total for the next round
                UpdateQuestionText(); // Update the question text for the new target total
            }
        }
        else
        {
            resultText1.text = "Incorrect! The total is " + total;
            ResetSelectedApples(); // Reset apples after checking
        }
    }

    // Reset selected apples
    private void ResetSelectedApples()
    {
        foreach (AppleScript1 apple in selectedApples)
        {
            if (apple != null)
            {
                apple.GetComponent<MeshRenderer>().material.color = Color.white; // Reset color to white
            }
        }

        selectedApples = new AppleScript1[2];
    }

    // Select a random target total from the list
    private void SelectRandomTargetTotal()
    {
        if (targetTotals.Count > 0)
        {
            int index = Random.Range(0, targetTotals.Count);
            targetTotal = targetTotals[index];
            Debug.Log("New target total: " + targetTotal);
        }
        else
        {
            Debug.LogWarning("No target totals available to select.");
        }
    }

    // Update the question text with the current target total with a typing effect
    private void UpdateQuestionText()
    {
        string message = "Select the apples so that the total is " + targetTotal;
        StartCoroutine(TypeText(message));
    }

    // Coroutine to type out the text character by character
    private IEnumerator TypeText(string message)
    {
        questionText.text = "";
        foreach (char letter in message.ToCharArray())
        {
            questionText.text += letter;
            yield return new WaitForSeconds(0.05f); // Adjust the speed of typing here
        }
    }

    // Transition to the next scene
    private void TransitionToNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
