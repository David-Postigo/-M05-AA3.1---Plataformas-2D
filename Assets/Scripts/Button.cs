using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");

    }
    public void Exit()
    {
        Application.Quit();
    }
}
