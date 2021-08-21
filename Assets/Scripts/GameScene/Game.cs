using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class Game : MonoBehaviour
{
    [SerializeField] private PoolObjects.ObjectInfo.ObjectType EnemyType;
    [SerializeField, Range(0.1f, 100f)] private float _spawnSpeed;
    private float _spawnProgress;
    private SideOfScreen _sideOfScreen;

    private Vector3 enemy_scale = new Vector3(1f, 1f, 0f);
    private Vector3 enemy_rotation;
    private Vector3 enemy_position;
    private Vector3 zero, zero_north;
    private float z_position = 1, distantFromBorder = 5f;// вынести в разные строчки
    private void Start()
    {      
        zero = ScreenConfig.instance.GetZeroPoint();
        zero_north = ScreenConfig.instance.GetDisplacedZeroPoint();
    }
    private void Update()
    {
        _spawnProgress += _spawnSpeed * Time.deltaTime; //если _spawnSpeed == 100 то 100 раз в секнуду частота
        while (_spawnProgress >= 1f)//магическое число
        {
            _spawnProgress -= 1f;
            Enemies_transform();
                  
            var enemy = PoolObjects.instance.GetObject(EnemyType);
            enemy.transform.localScale = enemy_scale;
            enemy.GetComponent<Enemy>().OnCreate(enemy_position, Quaternion.Euler(enemy_rotation));
        }      
    }
    private void Enemies_transform()
    {
        int direction = 0;//Random.Range(0, 4);      
        switch ((SideOfScreen)direction)
        {
            case SideOfScreen.Top:
                enemy_position.x = Mathf.Round(Random.Range(-zero.x, zero.x));
                if (enemy_position.x % 2 == 0)
                    enemy_position.x += 1;
                enemy_position.y = -zero_north.y + enemy_scale.y + distantFromBorder;
                enemy_position.z = z_position;
                enemy_rotation = new Vector3(0f, 0f, Random.Range(-80f, 80f));//0 
                break;
            case SideOfScreen.Left:
                enemy_position.x = zero.x - enemy_scale.x - distantFromBorder;
                enemy_position.y = Mathf.Round(Random.Range(-zero.y, zero.y));
                if (enemy_position.y % 2 == 0)
                    enemy_position.y += 1;
                enemy_position.z = z_position;
                enemy_rotation = new Vector3(0f, 0f, Random.Range(10f, 170f));//90 
                break;
            case SideOfScreen.Bottom:
                enemy_position.x = Mathf.Round(Random.Range(-zero.x, zero.x));
                if (enemy_position.x % 2 == 0)
                    enemy_position.x += 1;
                enemy_position.y = zero.y - enemy_scale.y - distantFromBorder;
                enemy_position.z = z_position; 
                enemy_rotation = new Vector3(0f, 0f, Random.Range(100f, 260f));//180 
                break;
            case SideOfScreen.Right:
                enemy_position.x = -zero.x + enemy_scale.x + distantFromBorder;
                enemy_position.y = Mathf.Round(Random.Range(-zero.y, zero.y));
                if (enemy_position.y % 2 == 0)
                    enemy_position.y += 1;
                enemy_position.z = z_position;
                enemy_rotation = new Vector3(0f, 0f, Random.Range(190f, 350f));//270 
                break;
        }
    }
}

