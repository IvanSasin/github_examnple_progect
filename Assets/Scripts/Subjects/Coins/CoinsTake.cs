using UnityEngine;

public class CoinsTake : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            DataConteiner.coinse++;
            Destroy(gameObject);
        }
    }

}
