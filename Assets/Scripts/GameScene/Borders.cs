using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
    [SerializeField] Transform _bulletBorder;
    [SerializeField] Transform _enemyBorder;
    [SerializeField, Range(1, 5)] int _scale;
    [SerializeField, Range(0, 1)] int _distBulletBorders;
    [SerializeField, Range(5, 10)] int _distEnemyBorders;

    private void Start()
    {
        float bottom;
        float top;
        float left;
        float right;

        _bulletBorder.localScale = new Vector3(_scale, _scale, 0f);

        Vector3 zero = ScreenConfig.instance.GetZeroPoint();
        Vector3 zero_north = ScreenConfig.instance.GetDisplacedZeroPoint();

        bottom = zero.y;
        left = zero_north.x;
        top = -zero_north.y;
        right = -zero_north.x;

        CreateBulletBorders(_distBulletBorders, bottom, top, left, right);
        CreateEnemyBorders(_distEnemyBorders, bottom, top, left, right);
    }

    private void CreateBulletBorders(float distance, float bottom, float top, float left, float right)
    {
        float a = _scale / 2;
        _bulletBorder.localScale = new Vector3((left - distance) * 2, _scale, 0f);
        _bulletBorder.localPosition = new Vector3(0f, top + a, 0f);
        Instantiate(_bulletBorder, _bulletBorder.localPosition, _bulletBorder.rotation);
        _bulletBorder.localPosition = new Vector3(0f, bottom - a, 0f);
        Instantiate(_bulletBorder, _bulletBorder.localPosition, _bulletBorder.rotation);

        _bulletBorder.localScale = new Vector3(_scale, (bottom - distance) * 2, 0f);
        _bulletBorder.localPosition = new Vector3(left - a, 0f, 0f);
        Instantiate(_bulletBorder, _bulletBorder.localPosition, _bulletBorder.rotation);
        _bulletBorder.localPosition = new Vector3(right + a, 0f, 0f);
        Instantiate(_bulletBorder, _bulletBorder.localPosition, _bulletBorder.rotation);
    }

    private void CreateEnemyBorders(float distance, float bottom, float top, float left, float right)
    {
        float a = _scale / 2 + distance;
        _enemyBorder.localScale = new Vector3((left - distance) * 2, _scale, 0f);
        _enemyBorder.localPosition = new Vector3(0f, top + a, 0f);
        Instantiate(_enemyBorder, _enemyBorder.localPosition, _enemyBorder.rotation);
        _enemyBorder.localPosition = new Vector3(0f, bottom - a, 0f);
        Instantiate(_enemyBorder, _enemyBorder.localPosition, _enemyBorder.rotation);

        _enemyBorder.localScale = new Vector3(_scale, (bottom - distance) * 2, 0f);
        _enemyBorder.localPosition = new Vector3(left - a, 0f, 0f);
        Instantiate(_enemyBorder, _enemyBorder.localPosition, _enemyBorder.rotation);
        _enemyBorder.localPosition = new Vector3(right + a, 0f, 0f);
        Instantiate(_enemyBorder, _enemyBorder.localPosition, _enemyBorder.rotation);
    }
}
