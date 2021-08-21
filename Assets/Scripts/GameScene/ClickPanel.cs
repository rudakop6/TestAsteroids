using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

public class ClickPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    [SerializeField] private Gun _gun;
    Action<bool> _singleShot;
    Action _aroundShot;

    public void OnPointerDown(PointerEventData data)
    {
        if(data.button == 0)
        {
            _singleShot?.Invoke(true);
        }        
    }
    public void OnPointerUp(PointerEventData data)
    {
        if (data.button == PointerEventData.InputButton.Left)
        {
            _singleShot?.Invoke(false);
        }   
    }

    public void OnPointerClick(PointerEventData data)
    {
        if (data.button == PointerEventData.InputButton.Right)
        {
            _aroundShot?.Invoke();
        }
    }
    private void Start()
    {
        _singleShot += _gun.InitializeShoot;
        _aroundShot += _gun.ShootAround;
    }
    private void OnDestroy()
    {
        _singleShot -= _gun.InitializeShoot;
        _aroundShot -= _gun.ShootAround;
    }
}

