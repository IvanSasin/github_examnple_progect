using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private GameObject deathPanel;

    private void Awake()
    {
        if (deathPanel != null)
            deathPanel.SetActive(false); 
    }

    public void ShowDeathScreen()
    {
        deathPanel.SetActive(true);
        Time.timeScale = 1f; 
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}