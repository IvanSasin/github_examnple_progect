using System;
using UnityEngine;

public class Svorld : MonoBehaviour
{
    [SerializeField] private int _damageEntity = 10;
    public event EventHandler OnSvorldSwing;

    private PolygonCollider2D _polygonCollider2D;

    private void Awake()
    {
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
    }
    private void Start()
    {
        AtackColiderTirnOff();
    }

    public void Atack()
    {
        AtackColiderOffOn();
        OnSvorldSwing?.Invoke(this, EventArgs.Empty);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out EnemyEntity enemyEntity))
        {
            enemyEntity.TakeDamage(_damageEntity);
        }
    }
    public void AtackColiderTirnOff()
    {
        _polygonCollider2D.enabled = false;
    }
    private void AtackColiderTirnOn()
    {
        _polygonCollider2D.enabled = true;
    }
    private void AtackColiderOffOn()
    {
        AtackColiderTirnOff();
        AtackColiderTirnOn();
    }
}
