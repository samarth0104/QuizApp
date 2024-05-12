using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PracticalButton : MonoBehaviour
{
    public string csvFileName; // Specify the CSV file name in the Inspector

    void Start()
    {
        Button button = GetComponent<Button>(); // Get the Button component
        button.onClick.AddListener(OnPlayButtonClicked); // Add a listener to the button click event
    }

    void OnPlayButtonClicked()
    {
        PlayerPrefs.SetString("CSVFileName", csvFileName); // Set the CSV file name
        SceneManager.LoadScene("QuizApp"); // Load the QuizApp scene
    }
}
