using UnityEngine;

public class SelfDestroiVFX : MonoBehaviour
{
    private ParticleSystem _pr;

    private void Awake()
    {
        _pr = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if(_pr && !_pr.IsAlive())
        {
            DestroySelf();
        }
    }
    private void DestroySelf()
    {
        Destroy(gameObject);
    }

}

