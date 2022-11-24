using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        if (typeof(T) == typeof(GameObject))
        {
            string name = path;
            int index = name.LastIndexOf('/');
            if (index >= 0)
                name = name.Substring(index + 1);

            GameObject go = Managers.Pool.GetOriginal(name);
            if (go != null)
                return go as T;
        }

        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject original = Load<GameObject>($"Prefabs/{path}"); // 오리지날이고

        if (original == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        if (original.GetComponent<Poolable>() != null)
            return Managers.Pool.Pop(original, parent).gameObject;

        GameObject go = Object.Instantiate(original, parent);
        go.name = original.name; // 카피한거임
        return go;
    }

    // Animal UI전용
    public GameObject Instantiate(string path, RectTransform parent = null, Canvas canvas = null)
    {
        GameObject original = Load<GameObject>($"Prefabs/{path}"); // 오리지날이고

        if (original == null)
        {
            Debug.Log($"Failed to load Animal Image UI prefab : {path}");
            return null;
        }

        if (original.GetComponent<Poolable>() != null)
            return Managers.Pool.Pop(original, parent).gameObject;

        GameObject go = Object.Instantiate(original, parent);
        go.name = original.name; // 카피한거임
        return go;
    }

    // =========================================================
    // Pin위치 설정을 위한 Instantiate 오버라이트 함수
    // =========================================================
    public GameObject Instantiate(string path, Vector3 pos ,Transform parent = null)
    {
        GameObject original = Load<GameObject>($"Prefabs/{path}"); // 오리지날이고

        if (original == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        if (original.GetComponent<Poolable>() != null)
        {
            GameObject pin = Managers.Pool.Pop(original, parent).gameObject;
            pin.transform.position = pos;
            return pin;
        }

        GameObject go = Object.Instantiate(original, parent);
        go.name = original.name; // 카피한거임
        return go;
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        Poolable poolable = go.GetComponent<Poolable>();
        if (poolable != null)
        {
            Managers.Pool.Push(poolable);
            return;
        }

        Object.Destroy(go);
    }

    public void Destroy(GameObject go, float time)
    {
        if (go == null)
            return;

        Poolable poolable = go.GetComponent<Poolable>();
        if (poolable != null)
        {
            Managers.Pool.Push(poolable);
            return;
        }

        Object.Destroy(go, time);
    }
}
