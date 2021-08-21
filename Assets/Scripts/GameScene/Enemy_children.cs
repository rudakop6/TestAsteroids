using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_children : MonoBehaviour, PoolObjects_interface
{
    public PoolObjects.ObjectInfo.ObjectType Type => type;
    [SerializeField] private PoolObjects.ObjectInfo.ObjectType type;

    [SerializeField] Rigidbody2D rb;
    [SerializeField, Range(1f, 5f)] int _speed;

    public void OnCreate(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
    }
    private void Awake()
    {
        _speed *= 2;
    }
    private void FixedUpdate()
    {
        rb.velocity = -this.transform.up * _speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet") || collision.CompareTag("EnemyBorder") || collision.CompareTag("Player") || collision.CompareTag("Enemy"))
            PoolObjects.instance.DestroyObject(gameObject);
    }
}
