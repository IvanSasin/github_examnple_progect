using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameImput : MonoBehaviour
{
    private Player_Imput_Action playerImputAction;

    public static GameImput instance { get; private set; }

    public event EventHandler OnPlayerAtack;
    public event EventHandler OnPlayerDash;
    /*public event EventHandler OnPlayerInteract;*/


    private void Awake()
    {
        instance = this;
        playerImputAction = new Player_Imput_Action();
        playerImputAction.Enable();
        playerImputAction.Combat.Atack.started += GameImput_OnPlayerAtack;
        playerImputAction.Player.Dash.performed += PlayerDash;
        /*playerImputAction.Player.Open.performed += PlayerInteract;*/
        DontDestroyOnLoad(gameObject);

    }

    private void PlayerDash(InputAction.CallbackContext obj)
    {
        OnPlayerDash?.Invoke(this, EventArgs.Empty);
    }

    private void GameImput_OnPlayerAtack (InputAction.CallbackContext obj)
    {
        
         OnPlayerAtack?.Invoke(this, EventArgs.Empty);
        
        
    }
    /*public void PlayerInteract(InputAction.CallbackContext obj)
    {
        OnPlayerInteract?.Invoke(this, EventArgs.Empty);
        Debug.Log("1");
        
    }*/


    public Vector2 GetMoventVector()
    {
        Vector2 inputVector = playerImputAction.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }

    public Vector3 GetMousePosition()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        return mousePos;
    }

   public void DisableMovent()
    {
        playerImputAction.Disable();
    }

    
}
