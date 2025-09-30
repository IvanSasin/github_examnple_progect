using UnityEngine;
using UnityEngine.SceneManagement;

public class MeinMenu : MonoBehaviour
{
    public void PlayeGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        Debug.Log("Вийшли");
        Application.Quit();
    }
}
