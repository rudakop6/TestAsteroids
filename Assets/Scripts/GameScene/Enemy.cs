//using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, PoolObjects_interface
{
    public PoolObjects.ObjectInfo.ObjectType Type => enemyType;
    [SerializeField] private PoolObjects.ObjectInfo.ObjectType enemyType;
    [SerializeField] private PoolObjects.ObjectInfo.ObjectType enemyChildType;

    [SerializeField] Rigidbody2D rb;
    [SerializeField, Range(1f, 5f)] int _speed;

    private Vector3 enemy_children_scale = new Vector3(0.5f, 0.5f, 0f);

    public void OnCreate(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
    }
    public void Awake()
    {
        _speed *= 5;//магическое число
    }

    public void FixedUpdate()
    {
        rb.velocity = -this.transform.up * _speed;
    }
    
    private void Crashing()
    {
       
        Vector3 children_position;
        Vector3 children_rotation;

        children_position = new Vector3(0f, 0f, 1f);
        children_rotation = Vector3.zero;

        float z = this.transform.eulerAngles.z;
        
        
        for(int i = 0; i < 8; i++)//магическое число
        {           
            children_position.x = this.transform.position.x;
            children_position.y = this.transform.position.y;
            children_rotation.z = z + 45 * i;

            var enemy_child1 = PoolObjects.instance.GetObject(enemyChildType);
            enemy_child1.transform.localScale = enemy_children_scale;
            enemy_child1.GetComponent<Enemy_children>().OnCreate(children_position, Quaternion.Euler(children_rotation));
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Crashing();
            PoolObjects.instance.DestroyObject(this.gameObject);
        }
        else if (!collision.CompareTag("BulletBorder") && !collision.CompareTag("Enemy"))
        {
            PoolObjects.instance.DestroyObject(this.gameObject);
        }
    }
}
