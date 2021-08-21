using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField, Range(1f, 4f)] private int _moveSpeed;
    [SerializeField] Transform _gameField;

    Vector3 mousePosition;
    private float _moveSpeedPlayer;
    private float move_border_x_min, 
                  move_border_x_max, 
                  move_border_y_min, 
                  move_border_y_max;

    private void Start()
    {
        _moveSpeedPlayer = (float)_moveSpeed /  10;

        Vector3 value = new Vector3(transform.localScale.x, transform.localScale.y, 0f);
        Vector3 valueX = new Vector3(transform.localScale.x, transform.localScale.y - _gameField.localPosition.y * 2, 0f);

        move_border_x_min = Camera.main.ScreenToWorldPoint(value).x;
        move_border_x_max = -Camera.main.ScreenToWorldPoint(value).x;
        move_border_y_min = Camera.main.ScreenToWorldPoint(value).y;
        move_border_y_max = -Camera.main.ScreenToWorldPoint(valueX).y;
    }


    private void MovePlayer(Vector2 value)
    {
        Vector3 move;
        float MoveSpeed = _moveSpeedPlayer;
        move.x = transform.position.x + value.x * MoveSpeed;
        move.y = transform.position.y + value.y * MoveSpeed;
        move.z = transform.position.z;

        move.x = Mathf.Clamp(move.x, move_border_x_min, move_border_x_max);
        move.y = Mathf.Clamp(move.y, move_border_y_min, move_border_y_max);
        transform.position = move;
    }
    private void RotatePlayer()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = mousePosition - transform.position;
        difference.Normalize();
        float rotation_y = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_y);
    }
    void FixedUpdate()
    {
        //поищи чужой код, возможно лучше можно сделать
        bool flag = false;
        Vector2 value = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            flag = true;
            value.y = 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            flag = true;
            value.x = -1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            flag = true;
            value.y = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            flag = true;
            value.x = 1f;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            value.y = 0;
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            value.x = 0;
        }
        if (flag)
        {
            MovePlayer(value);
        }
        RotatePlayer();

    }
}



