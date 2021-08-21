using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjects : MonoBehaviour
{
    public static PoolObjects instance;
    
    [Serializable]
    public struct ObjectInfo
    {
        public enum ObjectType
        {
            Bullets,
            Enemy,
            Enemy_children,
        }

        public ObjectType Type;
        public GameObject Prefab;
        public int StartCount;
    }
    [SerializeField] 
    private List<ObjectInfo> objectInfo;
    private Dictionary<ObjectInfo.ObjectType, PoolObjects_conteiners> pools;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        InitPool();
    }
    private void InitPool()
    {
        pools = new Dictionary<ObjectInfo.ObjectType, PoolObjects_conteiners>();
        var empty = new GameObject();
        foreach(var obj in objectInfo)
        {
            var conteiner = Instantiate(empty, transform, false);
            conteiner.name = obj.Type.ToString();
            pools[obj.Type] = new PoolObjects_conteiners(conteiner.transform);
            for(int i = 0; i < obj.StartCount; i++)
            {
                var create = InstantiateObject(obj.Type, conteiner.transform);
                pools[obj.Type]._objects.Enqueue(create);    
            }
        }
        Destroy(empty);
    }
    private GameObject InstantiateObject(ObjectInfo.ObjectType type, Transform parent)
    {
        var create = Instantiate(objectInfo.Find(x=>x.Type == type).Prefab, parent);
        create.SetActive(false);
        return create;
    }

    public GameObject GetObject(ObjectInfo.ObjectType type)
    {
        var obj = pools[type]._objects.Count > 0 ?
            pools[type]._objects.Dequeue() : InstantiateObject(type, pools[type]._conteiner);
        obj.SetActive(true);
        return obj;
    }    

    public void DestroyObject(GameObject obj)
    {
        pools[obj.GetComponent<PoolObjects_interface>().Type]._objects.Enqueue(obj);
        obj.transform.localPosition = Vector3.zero;
        obj.SetActive(false);
    }
}
