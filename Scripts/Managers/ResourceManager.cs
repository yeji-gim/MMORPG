using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   
public class ResourceManager 
{
   public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {

        // 1. orginal�� �̹� ��� ������ �ٷ� ���
        GameObject prefab = Load<GameObject>($"Prefab/{path}");
        if(prefab == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }
        // 2. Ȥ�� Ǯ���� �ְ� ������?
        GameObject go = Object.Instantiate(prefab, parent);
        int index = go.name.IndexOf("(Clone)");
        if (index > 0)
            go.name = go.name.Substring(0, index);
        go.name = prefab.name;
        return go;
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        // ���࿡ Ǯ���� �ʿ��� ���̶�� -> Ǯ�� �Ŵ������� ��Ź

        Object.Destroy(go);
    }
}

