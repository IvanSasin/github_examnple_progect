using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class SlaimVisual : MonoBehaviour
{
    [SerializeField] private AnemiAI _anemiAI;
    [SerializeField] private EnemyEntity _enemyEntity;
    private Animator _animator;
    private const string ISRUNING = "IsRan";
    private const string HIT = "Hit";
    private const string DETH = "IsDie";
    private const string CHASING_SPID = "ChasingSpid";
    private const string ATTACK = "Atack";

    SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _animator.SetBool(ISRUNING, _anemiAI.isRaning());
        _animator.SetFloat(CHASING_SPID, _anemiAI.GetAnimationSpeed() );
    }
    private void Start()
    {
        _anemiAI.onEnemiAtack += _anemiAI_onEnemiAtack;
        _enemyEntity.OnTakeHit += _enemyEntity_OnTakeHit;
        _enemyEntity.OnDeth += _enemyEntity_OnDeth;
    }

    private void _enemyEntity_OnDeth(object sender, System.EventArgs e)
    {
        _animator.SetTrigger(DETH);
        _spriteRenderer.sortingOrder = -1;
    }

    private void _enemyEntity_OnTakeHit(object sender, System.EventArgs e)
    {
        _animator.SetBool(HIT, true);
    }

    
    public void SlimeAtackTurnOff()
    {
        _enemyEntity.PoligonColiderTurnOff();
    }
    public void SlimeAtackTurnOn()
    {
        _enemyEntity.PoligonColiderTurnOn();
    }
    private void _anemiAI_onEnemiAtack(object sender, System.EventArgs e)
    {
        _animator.SetTrigger(ATTACK);
    }
    private void OnDestroy()
    {
        _anemiAI.onEnemiAtack -= _anemiAI_onEnemiAtack;
        _enemyEntity.OnTakeHit -= _enemyEntity_OnTakeHit;
        
    }

}
