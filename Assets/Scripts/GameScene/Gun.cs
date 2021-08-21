using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _rateOfFire;
    [SerializeField] private PoolObjects.ObjectInfo.ObjectType bulletType;

    private bool flag = false;
    private void Shoot()
    {
        var bullet = PoolObjects.instance.GetObject(bulletType);
        bullet.GetComponent<Bullet>().OnCreate(transform.position, transform.rotation);
    }

    public void ShootAround()
    {
        Vector3 bullet_position = new Vector3(this.transform.position.x, this.transform.position.y, 1f);
        Vector3 bullet_rotation = Vector3.zero;
        float z = this.transform.eulerAngles.z;


        for (int i = 0; i < 3; i++)//магическое число
        {
            if (i == 0)
            {
                bullet_rotation.z = z;
            }
            else
            {
                bullet_rotation.z = z - 20 * i;//магическое число
                var bullet1 = PoolObjects.instance.GetObject(bulletType);//а тут нужно поменять возращаемый тип на Bullet и пусть только 
                //с GameObject работает только он.Тогда GetComponent не понадобится 
                bullet1.GetComponent<Bullet>().OnCreate(bullet_position, Quaternion.Euler(bullet_rotation));

                bullet_rotation.z = z + 20 * i;//магическое число
            }

            var bullet = PoolObjects.instance.GetObject(bulletType);
            bullet.GetComponent<Bullet>().OnCreate(bullet_position, Quaternion.Euler(bullet_rotation));

        }
    }


    private void Start()
    {      
        StartCoroutine(Shooting());//ну я бы в корутине это не делал. Я бы к кнопке событие привязал бы.Зачем ее крутить каждые 0.1 сек?
        //не уверен что это неправильно,но я по-другому делаю
    }

    IEnumerator Shooting()
    {
        while(true)
        {
            if (flag)
            {
                Shoot();
                yield return new WaitForSeconds(0.1f);
            }    
            else
            {
                yield return new WaitForEndOfFrame();
            }
        }      
    }

    public void InitializeShoot(bool value)
    {
        flag = value;
    }
}
