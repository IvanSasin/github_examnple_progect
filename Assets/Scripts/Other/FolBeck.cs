using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FolBeck : MonoBehaviour
{
    [SerializeField] private float _knovBackForse = 3f;
    [SerializeField] private float _knovBackMovingTimeMax = 0.3f;

    private float _knovBackMovingTime;

    private Rigidbody2D _rb;

    public bool IsGetingKnocBeck { get; private set; }
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _knovBackMovingTime -= Time.deltaTime;
        if (_knovBackMovingTime < 0) 
        
            StopKnockBackMovent(); 
        
            
    }
    public void GetKnocketBeck(Transform damageSource)
    {
        IsGetingKnocBeck = true;
        _knovBackMovingTime = _knovBackMovingTimeMax;
        Vector2 diference = (transform.position - damageSource.position).normalized * _knovBackForse / _rb.mass;
        _rb.AddForce(diference, ForceMode2D.Impulse);
    }

    public void StopKnockBackMovent()
    {
        _rb.linearVelocity = Vector2.zero;
        IsGetingKnocBeck = false;
    }

}
