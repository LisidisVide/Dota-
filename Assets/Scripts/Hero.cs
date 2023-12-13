using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [HideInInspector]
    public uint line;
    public int price;

    [SerializeField, Space]
    private float _speed;
    [SerializeField]
    private float _damage;
    [SerializeField]
    private float _cooldown;
    [SerializeField]
    private float _health;
    private bool _isEnemy;
    private Hero _currentEnemy;
    private float duration;

    private Rigidbody2D rb;

    public bool IsEnemy
    {
        get { return _isEnemy; }
    }

    public void Initialize(bool isEnemy, uint line)
    {
        this.line = line;
        rb = GetComponent<Rigidbody2D>();
        _isEnemy = isEnemy;
        if (_isEnemy)
            _speed *= -1;
    }

    private void Update()
    {
        if (_currentEnemy != null)
            Attack();
        else
        {
            if (duration != _cooldown)
                duration = _cooldown;
            rb.velocity = new Vector2(_speed, rb.velocity.y);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Hero enemy) && enemy.IsEnemy != IsEnemy && enemy.line == line)
        {
            _currentEnemy = enemy;
        }
    }


    private void Attack()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        if (duration == 0)
        {
            duration = _cooldown;
            _currentEnemy.GetDamage(_damage);
        }
        else
        {
            duration -= Time.deltaTime;
            if (duration < 0)
                duration = 0;
        }
    }

    public void GetDamage(float damage)
    {
        if (_health > damage)
        {
            _health -= damage;
        }
        else
        {
            _health = 0;
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
