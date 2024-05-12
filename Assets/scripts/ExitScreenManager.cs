using UnityEngine;
using TMPro;

public class ExitSceneManager : MonoBehaviour
{
    public TMP_Text finalScoreText;
    public TMP_Text questionResultsText;

    void Start()
    {
        // Retrieve final score from PlayerPrefs
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        finalScoreText.text = "Final Score: " + finalScore.ToString();

        // Retrieve question results from PlayerPrefs
        string questionResults = "Question Results:\n";
        int numQuestions = PlayerPrefs.GetInt("NumQuestions", 0);
        for (int i = 0; i < numQuestions; i++)
        {
            string userAnswer = PlayerPrefs.GetString("UserAnswer" + (i + 1));
            string correctAnswer = PlayerPrefs.GetString("CorrectAnswer" + (i + 1));
            string result = userAnswer.ToLower() == correctAnswer.ToLower() ? "Correct" : "Incorrect";
            questionResults += "Question " + (i + 1) + ": Chosen Answer - " + userAnswer + ", Correct Answer - " + correctAnswer + ", Result - " + result + "\n";
        }
        questionResultsText.text = questionResults;
    }
}
