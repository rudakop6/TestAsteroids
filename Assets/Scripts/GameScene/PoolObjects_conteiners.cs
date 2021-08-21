using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Что за кривое название класса?
public class PoolObjects_conteiners
{
    public Transform _conteiner {get; private set;}
    public Queue<GameObject> _objects;
    public PoolObjects_conteiners(Transform conteiner)
    {
        _conteiner = conteiner;
        _objects = new Queue<GameObject>();
    }
}
