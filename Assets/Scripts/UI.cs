using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI TextState;
    public TextMeshProUGUI TextStateDuration;
    public Button ButtonAutomatic;
    public Button ButtonFilling;
    public Button ButtonPouring;
    public Toggle ToggleAutomatic;

    public void Exit()
    {
        Application.Quit();
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
