using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class YouAreDeadScreen : MonoBehaviour
{
    public RubyBleu rubyBleu;

    public TextMeshProUGUI rubyBleuText;

    public void Update()
    {
        rubyBleuText.text = rubyBleu.rubyCount + "";
        rubyBleuText.color = Color.blue;

    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");

        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
