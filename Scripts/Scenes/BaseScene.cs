using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour
{
    Define.Scene _sceneType = Define.Scene.Unknown;
    public Define.Scene SceneType { get; protected set; } = Define.Scene.Unknown;
    void Start()
    {

    }
    protected virtual void Init()
    {
        Object obj = GameObject.FindObjectOfType(typeof(EventSystem));
        if (obj == null)
            Manager.Resource.Instantiate("UI/EventSystem").name = "@EventSystem";
    }
    public abstract void Clear();
}

