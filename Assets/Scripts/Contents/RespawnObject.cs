using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RespawnObject : MonoBehaviour
{
    public Define.WorldObject WorldObjectType { get; protected set; } = Define.WorldObject.Unknown;
    private void Start()
    {
        init();
    }

    public abstract void init();
}
