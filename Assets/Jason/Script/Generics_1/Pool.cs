using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=6ED4Qo0Yi6o
public static class Pool<T> where T : Component
{
    public static Queue<T> objectQueue = new Queue<T>();
    public static GameObject prefeb;
    public static void SetPrefeb(GameObject prefeb)
    {
        Pool<T>.prefeb = prefeb;
    }
    /// <summary>
    /// 放回 queue中
    /// </summary>
    /// <param name="obj"></param>
    public static void ReturnObjectToPool(T obj)
    {
        objectQueue.Enqueue(obj);
        obj.gameObject.SetActive(false);
    }
    /// <summary>
    ///若有物件取出 若無則生成物件
    /// </summary>
    /// <returns></returns>
    public static T GetObjFromPool() 
    {
        if (objectQueue.Count > 0)
        {
            T Objget = objectQueue.Dequeue();
            Objget.gameObject.SetActive(true);
            return Objget; //return後不會往下
        }
        return GameObject.Instantiate(prefeb).GetComponent<T>();

    }

}
