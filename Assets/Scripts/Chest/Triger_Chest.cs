using System;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour
{
    public event EventHandler OnPlayerInteract;
    public Animator anim;
    private const string IS_OPEN = "Open";
    private bool _isChast = false;
    [SerializeField] public GameImput gameImput;

    [Header("Loot Settings")]
    public GameObject[] lootPrefabs; 
    public Transform spawnPoint;     
    public float spawnDelay = 0.5f;  
    public int lootCount = 3;        
    private bool _isOpen = false;

    private void Awake()
    {
        
        anim = GetComponent<Animator>();
        
    }
    public void OpenChest()
    {
        StartCoroutine(SpawnLoot());
    }

    private IEnumerator SpawnLoot()
    {
        yield return new WaitForSeconds(spawnDelay);

        for (int i = 0; i < lootCount; i++)
        {
            GameObject loot = lootPrefabs[UnityEngine.Random.Range(0, lootPrefabs.Length)];
            GameObject obj = Instantiate(loot, spawnPoint.position, Quaternion.identity);

            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 forceDir = UnityEngine.Random.insideUnitCircle.normalized;
                float power = UnityEngine.Random.Range(2f, 4f);
                rb.AddForce(forceDir * power, ForceMode2D.Impulse);
                rb.linearDamping = 2f;
                rb.angularDamping = 2f;
            }

            yield return new WaitForSeconds(0.2f);
        }
    }  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !_isOpen)
        {
            _isOpen = true;               
            anim.SetBool("Open", true);   
            StartCoroutine(SpawnLoot());  
        }
    }
    

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            _isChast = true;
            
        }
    }
}