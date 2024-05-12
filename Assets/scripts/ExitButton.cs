using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    private void Start()
    {
        // Assuming you have a reference to the Button component
        Button exitButton = GetComponent<Button>();
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    public void OnExitButtonClicked()
    {
        Application.Quit(); // Quit the application
    }
}
