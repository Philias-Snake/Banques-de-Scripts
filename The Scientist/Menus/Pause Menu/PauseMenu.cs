using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // R�f�rence au panneau du menu options
    public GameObject[] HUDElements; // Tableau des �l�ments du HUD � cacher
    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (pauseMenuUI.activeSelf)
            {
                ClosePause();
            }
            else
            {
                OpenPause();
            }
        }

        if (Input.GetKeyUp(KeyCode.Joystick1Button7))
        {
            if (pauseMenuUI.activeSelf)
            {
                ClosePause();
            }
            else
            {
                OpenPause();
            }
        }

    }

    public void OpenPause()
    {
        //Bascule l'�tat de pause
        isPaused = !isPaused;

        // Affichez le menu settings
        pauseMenuUI.SetActive(true);

        // Cachez les �l�ments du HUD
        foreach (GameObject element in HUDElements)
        {
            element.SetActive(false);
        }

        // Met le jeu en pause en arr�tant le temps
        Time.timeScale = 0f;

        // Met � jour l'�tat du jeu
        isPaused = true;
    }

    public void ClosePause()
    {
        // Cachez le menu settings
        pauseMenuUI.SetActive(false);

        // Affichez les �l�ments du HUD
        foreach (GameObject element in HUDElements)
        {
            element.SetActive(true);
        }

        // Reprends le temps du jeu
        Time.timeScale = 1f;

        // Met � jour l'�tat du jeu
        isPaused = false;
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
