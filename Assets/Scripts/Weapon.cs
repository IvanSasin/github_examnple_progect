using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static Weapon Instanse {  get; private set; }
    [SerializeField] private Svorld svorld;
    private void Awake()
    {
        Instanse = this;
    }
    private void Update()
    {
        if (Player.Instanse.IsAlive())
            FolovMousePosition();
    }
    public Svorld GetAcktiveWeapon()
    {
        return svorld;
    }
    private void FolovMousePosition()
    {
        Vector3 mousePos = GameImput.instance.GetMousePosition();
        Vector3 playerPosition = Player.Instanse.GetPlayerPosition();

        if (mousePos.x < playerPosition.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
