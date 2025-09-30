using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    [SerializeField] private Player playerHealth;
    [SerializeField] private DeathScreen deathScreen;

    private void OnEnable()
    {
        playerHealth.OnPlayerDeth += HandleDeath;
    }

    private void OnDisable()
    {
        playerHealth.OnPlayerDeth -= HandleDeath;
    }

    private void HandleDeath(object sender, System.EventArgs e)
    {
        deathScreen.ShowDeathScreen();
    }
}
