using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Managers : MonoBehaviour
{
    static Managers s_instance; // 유일성이 보장된다
    static Managers Instance { get { Init(); return s_instance; } } // 유일한 매니저를 갖고온다

    DataManager     _data = new DataManager();
    PoolManager     _pool = new PoolManager();
    ResourceManager _resource = new ResourceManager();
    SceneManagerEx  _scene = new SceneManagerEx();
    SoundManager    _sound = new SoundManager();
    UIManager       _ui = new UIManager();
    GameManagerEx   _game = new GameManagerEx();
    StageManager    _stage = new StageManager();   

    // AdManager _ad = new AdManager();

    public static DataManager Data { get { return Instance._data; } }
    public static GameManagerEx Game { get { return Instance._game; } }
    public static PoolManager Pool { get { return Instance._pool; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static SceneManagerEx Scene { get { return Instance._scene; } }
    public static SoundManager Sound { get { return Instance._sound; } }
    public static UIManager UI { get { return Instance._ui; } }
    public static StageManager Stage { get { return Instance._stage; } }
    // public static AdManager Ad { get { return Instance._ad; } }

    void Start()
    {
        Init();
	}

    void Update()
    {
       
    }

    static void Init()
    {
        if (s_instance == null)
        {
			GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();

            }

            GameObject s = GameObject.Find("@StageManager");

            if (s == null)
            {
                s = new GameObject { name = "@StageManager" };
                s.GetOrAddComponent<StageManager>();
                s.transform.SetParent(go.transform);
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();

            s_instance._data.Init();
            s_instance._pool.Init();
            s_instance._sound.Init();
            s_instance._stage.Init();

            // GameObject ad = GameObject.Find("@BaanerAd");

            //if (ad == null)
            //{
            //    ad = new GameObject { name = "@BannerAd" };
            //    ad.AddComponent<BannerAd>();
            //    DontDestroyOnLoad(ad);
            //}
        }		
	}

    public static void Clear()
    {
        Sound.Clear();
        Scene.Clear();
        UI.Clear();
        Pool.Clear();
        Game.Clear();
        Stage.Clear();
    }
}
