using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerEx
{
    // int <-> GameObject
    GameObject _player;
    HashSet<GameObject> _pins = new HashSet<GameObject>();
    HashSet<GameObject> _textPinIndex = new HashSet<GameObject>();

    CameraController _cameraController;

    public GameObject GetPlayer() { return _player; }

    public void Clear()
    {

    }

    public Define.WorldObject GetWorldObjectType(GameObject go)
    {
        CreatureController cc = go.GetComponent<CreatureController>();

        if (cc == null)
        {
            Debug.Log("GetWorldObjectType Failed!");
            return Define.WorldObject.Unknown;
        }
        return cc.WorldObjectType;
    }

    public GameObject Spawn(Define.WorldObject type, string path, Transform parent = null)
    {
        GameObject go = Managers.Resource.Instantiate(path, parent);

        switch (type)
        {
            case Define.WorldObject.Player:
                {  
                    _player = go;
                    GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
                    _cameraController = Util.GetOrAddComponent<CameraController>(camera);

                    _cameraController.SetPlayer(_player);
                }
                break;
            case Define.WorldObject.Pin:
                {
                    _pins.Add(go);
                }
                break;
            case Define.WorldObject.TextPinIndex:
                {
                    _textPinIndex.Add(go);
                }
                break;


        }
        return go;
    }
    public void Despawn(GameObject go)
    {
        Define.WorldObject type = GetWorldObjectType(go);

        switch (type)
        {
            case Define.WorldObject.Player:
                {
                    if (_player == go)
                        _player = null;
                }
                break;
            default:
                break;
        }

        Managers.Resource.Destroy(go);
    }
}
