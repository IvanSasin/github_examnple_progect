using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class DestroiPlants : MonoBehaviour
{

    public event EventHandler OnDestructibleTakeDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Svorld>())
        {
            OnDestructibleTakeDamage?.Invoke(this,EventArgs.Empty);
            
            Destroy(gameObject);

            
        }
            
        
    }
}
