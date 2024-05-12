using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.IO;

public class QuizManager : MonoBehaviour
{
    public TMP_Text questionText;
    public TMP_Text scoreText;
    public TMP_Text answerResultText; // Text to display whether the answer is correct or incorrect
    public Button[] answerButtons;

    private List<QuestionData> questionsData = new List<QuestionData>(); // List to store questions and answers data
    private int currentQuestionIndex = 0;
    private int score = 0;

    void Start()
    {
        string csvFileName = PlayerPrefs.GetString("CSVFileName");
        if (!string.IsNullOrEmpty(csvFileName))
        {
            LoadQuestionsData(csvFileName); // Load questions data from CSV file
            scoreText.text = "Score: " + score.ToString(); // Initialize score text
            ShowQuestion();
            AddButtonListeners();
        }
        else
        {
            Debug.LogError("CSV file name not provided!");
        }
    }

    void LoadQuestionsData(string fileName)
    {
        TextAsset csvFile = Resources.Load<TextAsset>(fileName); // Load CSV file from Resources folder
        if (csvFile != null)
        {
            string[] data = csvFile.text.Split('\n'); // Split CSV file by new line

            for (int i = 1; i < data.Length; i++) // Start from index 1 to skip header row
            {
                string[] row = data[i].Split(','); // Split each row by comma

                if (row.Length >= 6) // Ensure row has at least 6 elements
                {
                    QuestionData question = new QuestionData();
                    question.question = row[0];
                    question.answers = new string[] { row[1], row[2], row[3], row[4] };
                    question.correctAnswer = row[5].Trim(); // Remove any whitespace
                    questionsData.Add(question);
                }
            }
        }
        else
        {
            Debug.LogError("Failed to load CSV file: " + fileName);
        }
    }

    void ShowQuestion()
    {
        questionText.text = questionsData[currentQuestionIndex].question;
        // Set answer text for each button
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TMP_Text>().text = questionsData[currentQuestionIndex].answers[i];
        }
    }

    void AddButtonListeners()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            int index = i; // Capture the current value of i for the listener
            answerButtons[i].onClick.AddListener(() => OnButtonClick(index));
        }
    }

    void OnButtonClick(int buttonIndex)
    {
        string chosenAnswer = ((char)(buttonIndex + 97)).ToString(); // Convert index to letter (a, b, c, d)
        Debug.Log("Chosen answer: " + chosenAnswer);
        Debug.Log("Correct answer: " + questionsData[currentQuestionIndex].correctAnswer);

        bool isCorrect = chosenAnswer.ToLower() == questionsData[currentQuestionIndex].correctAnswer.ToLower();

        // Save the question result in PlayerPrefs
        PlayerPrefs.SetString("UserAnswer" + (currentQuestionIndex + 1), chosenAnswer);
        PlayerPrefs.SetString("CorrectAnswer" + (currentQuestionIndex + 1), questionsData[currentQuestionIndex].correctAnswer);
        PlayerPrefs.SetInt("Question" + (currentQuestionIndex + 1), isCorrect ? 1 : 0);

        if (isCorrect)
        {
            score++;
            answerResultText.text = "Correct!";
        }
        else
        {
            answerResultText.text = "Incorrect!";
        }

        Debug.Log("Current score: " + score);
        scoreText.text = "Score: " + score.ToString(); // Update score text

        currentQuestionIndex++;
        if (currentQuestionIndex < questionsData.Count)
        {
            ShowQuestion();
        }
        else
        {
            // Save final score to PlayerPrefs
            PlayerPrefs.SetInt("FinalScore", score);

            SceneManager.LoadScene("ExitScreen"); // Load the exit scene
        }
    }

    [System.Serializable]
    public class QuestionData
    {
        public string question;
        public string[] answers;
        public string correctAnswer;
    }
}
