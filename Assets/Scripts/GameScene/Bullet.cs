using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Bullet : MonoBehaviour, PoolObjects_interface
{
    private Score score;
    public PoolObjects.ObjectInfo.ObjectType Type => type;
    [SerializeField] private PoolObjects.ObjectInfo.ObjectType type;

    [SerializeField, Range(1f, 5)] float _speed;
    [SerializeField] Rigidbody2D rb;

    Action CollisionEnemy;
    Action CollisionEnemyChild;

    public void OnCreate(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
    }
    private void Awake()
    {
        _speed *= 15;//магическое число,должно быть константой в начале класса
        score = FindObjectOfType<Score>();
        CollisionEnemy += score.ChangeScoreEnemy;
        CollisionEnemyChild += score.ChangeScoreChild;
    }

    private void OnDestroy()
    {
        CollisionEnemy -= score.ChangeScoreEnemy;
        CollisionEnemyChild -= score.ChangeScoreChild;
    }

    private void FixedUpdate()
    {
        rb.velocity = -this.transform.up * _speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") && !collision.CompareTag("Bullet"))
        {
            PoolObjects.instance.DestroyObject(gameObject);
            if (collision.CompareTag("Enemy"))
            {
                CollisionEnemy?.Invoke();
            }
            else if (collision.CompareTag("Enemy_children"))
            {
                CollisionEnemyChild?.Invoke();
            }
        }
    }
}



