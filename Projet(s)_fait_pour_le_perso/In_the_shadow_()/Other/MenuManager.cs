using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // r�f�rence au nom de la sc�ne demander.
    public string sceneName;

    // commande permettant d'aller sur la sc�ne demander.
    public void PlayButton()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OpenMenu(GameObject open)
    {
        open.SetActive(true);
    }

    public void CloseMenu(GameObject close)
    { 
        close.SetActive(false);
    }

    // commande permettant de quitter le jeu.
    public void Quit()
    {
        Application.Quit();
    }
}