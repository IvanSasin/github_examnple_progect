using UnityEngine;
using UnityEngine.SceneManagement;

public class NevLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            NextLvl();
    }
    public void NextLvl()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
