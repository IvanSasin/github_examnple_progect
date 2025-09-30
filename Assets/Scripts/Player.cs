using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;



public class Player : MonoBehaviour
{



    public static Player Instanse { get; private set; }
    public event EventHandler OnPlayerDeth;
    public event EventHandler OnFlashBlinck;
    [SerializeField] private float _muvingSpid = 5f;
    [SerializeField] public float _maxHp = 100;
    [SerializeField] private float _damageReecoveryTime = 0.5f;
    [SerializeField] private int _dashSpid = 4;
    [SerializeField] private float _dashTime = 0.2f;
    [SerializeField] private TrailRenderer _trailRenderer;
    [SerializeField] private float _dashColDayn = 0.3f;




    private Rigidbody2D _rb;
    private FolBeck _folBeck;
    private Chest currentChest;
    private GameImput _gameInput;



    private float _minSpid = 0.1f;

    Vector2 ImputVector;

    private bool Run = false;

    public float _currentHp;
    private bool _canTakeDamage;
    private bool _isAlive;
    private float _instSpid;
    private bool _isDeash;

    private void Awake()
    {
        Instanse = this;
        _rb = GetComponent<Rigidbody2D>();
        _folBeck = GetComponent<FolBeck>();
        _gameInput = FindObjectOfType<GameImput>();
    }
    private void Start()
    {
        _canTakeDamage = true;
        _isAlive = true;
        _currentHp = _maxHp;
        _instSpid = _muvingSpid;
        GameImput.instance.OnPlayerAtack += GameImput_OnPlayerAtack;
        GameImput.instance.OnPlayerDash += GameImput_OnPlayerDash;


    }
    public void GameImput_OnPlayerDash(object sender, System.EventArgs e)
    {
        Dash();
    }
    private void OnEnable()
    {
        if (_gameInput != null)
        {
            _gameInput.OnPlayerDash += GameImput_OnPlayerDash;
            _gameInput.OnPlayerAtack += GameImput_OnPlayerAtack;
        }
    }
    private void Dash()
    {
        if (!_isDeash)
        {
            StartCoroutine(DeshRotTime());
        }

    }

    private IEnumerator DeshRotTime()
    {
        _isDeash = true;
        _muvingSpid *= _dashSpid;
        _trailRenderer.emitting = true;
        yield return new WaitForSeconds(_dashTime);

        _trailRenderer.emitting = false;
        _muvingSpid = _instSpid;
        yield return new WaitForSeconds(_dashColDayn);
        _isDeash = false;

    }


    private void OnDisable()
    {
        if (GameImput.instance != null)
        {
            GameImput.instance.OnPlayerDash -= GameImput_OnPlayerDash;

        }
    }

    public void Heal(int amount)
    {
        _currentHp += amount;
        _currentHp = Mathf.Min(_currentHp, _maxHp);

    }

    public void GameImput_OnPlayerAtack(object sender, System.EventArgs e)
    {
        Weapon.Instanse.GetAcktiveWeapon().Atack();
    }
    private void Update()
    {
        ImputVector = GameImput.instance.GetMoventVector();
    }
    public bool IsAlive() => _isAlive;







    private void FixedUpdate()
    {
        if (_folBeck.IsGetingKnocBeck)
            return;
        HendeleMuvment();
    }

    public void TakeDamage(Transform damageSourse, int damage)
    {
        if (_canTakeDamage && _isAlive)
        {
            _canTakeDamage = false;
            _currentHp = Mathf.Max(0, _currentHp -= damage);
            _folBeck.GetKnocketBeck(damageSourse);

            OnFlashBlinck?.Invoke(this, EventArgs.Empty);

            StartCoroutine(DamageRecoveryRoutine());
        }
        DetectiveDead();
    }
    private void DetectiveDead()
    {
        if (_currentHp <= 0 && _isAlive)
        {

            _isAlive = false;
            _folBeck.StopKnockBackMovent();
            GameImput.instance.DisableMovent();
            OnPlayerDeth?.Invoke(this, EventArgs.Empty);

        }

    }

    private IEnumerator DamageRecoveryRoutine()
    {
        yield return new WaitForSeconds(_damageReecoveryTime);
        _canTakeDamage = true;
    }

    private void HendeleMuvment()
    {

        ImputVector = ImputVector.normalized;
        _rb.MovePosition(_rb.position + ImputVector * (_muvingSpid * Time.fixedDeltaTime));

        if (Mathf.Abs(ImputVector.x) > _minSpid || Mathf.Abs(ImputVector.y) > _minSpid)
        {
            Run = true;

        }
        else
        {
            Run = false;
        }

    }
    public bool IsRaning()
    {
        return Run;
    }

    public Vector3 GetPlayerPosition()
    {
        Vector3 playerPosition = Camera.main.WorldToScreenPoint(transform.position);
        return playerPosition;
    }




    private void OnDestroy()
    {
        GameImput.instance.OnPlayerAtack -= GameImput_OnPlayerAtack;
        if (_gameInput != null)
        {
            _gameInput.OnPlayerDash -= GameImput_OnPlayerDash;
            _gameInput.OnPlayerAtack -= GameImput_OnPlayerAtack;
        }









    }
}

