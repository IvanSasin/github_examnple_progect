using UnityEngine;

public class FlashBlinck : MonoBehaviour
{
    [SerializeField] private MonoBehaviour _damageBliObgect;
    [SerializeField] private Material _blinckMatirial;
    [SerializeField] private float _duration = 0.2f;

    private float _blinckTime;
    private Material _defoltMatirial;
    private SpriteRenderer _spriteRenderer;
    private bool _isBlinck;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defoltMatirial = _spriteRenderer.material;

        _isBlinck = true;

        
    }

    private void Start()
    {
        if (_damageBliObgect is Player)
        {
            (_damageBliObgect as Player).OnFlashBlinck += DamageBliObgect_OnFlashBlinck;
        }
    }

    private void DamageBliObgect_OnFlashBlinck(object sender , System.EventArgs e)
    {
        SetBliackMaterial();
    }

    private void Update()
    {
        if (_isBlinck)
        {
            _blinckTime -= Time.deltaTime;
            if( _blinckTime < 0)
            {
                SetDefoltMatirial();
            }
        }
    }

    private void SetBliackMaterial()
    {
        _blinckTime = _duration;
        _spriteRenderer.material = _blinckMatirial;
    }

    private void SetDefoltMatirial()
    {
        _spriteRenderer.material = _defoltMatirial;
    }

    public void StopBlinck()
    {
        SetDefoltMatirial();
        _isBlinck = false;
    }

    private void OnDestroy()
    {
        if (_damageBliObgect is Player)
        {
            (_damageBliObgect as Player).OnFlashBlinck -= DamageBliObgect_OnFlashBlinck;
        }
    }
}
