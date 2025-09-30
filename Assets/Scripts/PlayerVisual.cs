using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Animator animator;
    private const string IS_RUNING = "IsRaning";
    private const string IS_DEATH = "Death";
    private SpriteRenderer spriteRenderer;
    private FlashBlinck _flashBlinck;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _flashBlinck = GetComponent<FlashBlinck>();
    }

    private void Start()
    {
        Player.Instanse.OnPlayerDeth += Instanse_OnPlayerDeth;

        
    }

    private void Instanse_OnPlayerDeth(object sender, System.EventArgs e)
    {
        animator.SetBool(IS_DEATH, true);
        _flashBlinck.StopBlinck();
    }

    private void Update()
    {
        animator.SetBool(IS_RUNING, Player.Instanse.IsRaning());
        if (Player.Instanse.IsAlive())
        PlayerFacingDirection();
    }
    private void PlayerFacingDirection()
    {
        Vector3 mousePos = GameImput.instance.GetMousePosition();
        Vector3 playerPosition = Player.Instanse.GetPlayerPosition();

        if(mousePos.x  < playerPosition.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
    private void OnDestroy()
    {
        Player.Instanse.OnPlayerDeth -= Instanse_OnPlayerDeth;
    }
}
