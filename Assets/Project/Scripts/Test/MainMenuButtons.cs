using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void GoToMainScene()
    {
        SceneManager.LoadScene(2);
    }
    
    public void GoToTutorial()
    {
        SceneManager.LoadScene(1);
    }
}
