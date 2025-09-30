using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartLevel()
    {
        
        Time.timeScale = 1f;

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
