using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(AnemiAI))]
public class EnemyEntity : MonoBehaviour
{
    [SerializeField] Enemy_S0 _enemy_S0;
    public event EventHandler OnTakeHit;
    public event EventHandler OnDeth;
    private int _carentHelf;
    private  PolygonCollider2D _polygonCollider2D;
    private BoxCollider2D _boxCollider2D;
    private AnemiAI _anemiAI;

    private void Awake()
    {
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _anemiAI = GetComponent<AnemiAI>();
    }
    private void Start()
    {
        _carentHelf = _enemy_S0.AemiHelf;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.TryGetComponent(out Player player))
        {
            player.TakeDamage(transform, _enemy_S0.AnemiDamage);
        }
    }

    


    public void TakeDamage(int damage)
    {
        _carentHelf -= damage;
        OnTakeHit?.Invoke(this, EventArgs.Empty);
        DetectivDead();
    }

    public void PoligonColiderTurnOff()
    {
        _polygonCollider2D.enabled = false;
    }
    public void PoligonColiderTurnOn()
    {
        _polygonCollider2D.enabled = true;
    }

    private void DetectivDead()
    {
        if (_carentHelf <= 0)
        {
            _boxCollider2D.enabled = false;
            _polygonCollider2D.enabled = false;
            _anemiAI.SetDeatStait();
            OnDeth?.Invoke(this, EventArgs.Empty);
        }
        
    }

    
}
