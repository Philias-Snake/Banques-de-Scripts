using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // R�f�rence au panneau du menu options
    public GameObject[] HUDElements; // Tableau des �l�ments du HUD � cacher

    private bool isPaused = false; // Variable pour suivre l'�tat du jeu (en pause ou non)

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

        Time.timeScale = 0f;
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

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
