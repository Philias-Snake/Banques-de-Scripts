using UnityEngine;

public class NextMain : MonoBehaviour
{
    public GameObject uiElementToActivate; // R�f�rence � l'�l�ment UI � activer                                        

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Next();
        }

        if (Input.GetKeyUp(KeyCode.Joystick1Button0))
        {
            Next();
        }
    }

    public void Next()
    {
        if (uiElementToActivate != null)
        {
            // Activez l'�l�ment UI
            uiElementToActivate.SetActive(true);
        }
    }
}
