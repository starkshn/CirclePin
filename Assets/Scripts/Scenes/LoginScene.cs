using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.LoginScene;

        // Managers.UI.ShowSceneUI<UI_LoginScene>("UI_LoginScene");

        // Banner
        //GameObject go = GameObject.Find("@BannerAd");
        //BannerAd ad = go.GetComponent<BannerAd>();
        //ad.ExitAd();
    }

    private void Update()
    { 
        if (Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Click 'Q' -> Go To GameScene!");
            Managers.Scene.LoadScene(Define.Scene.GameScene);
        }
    }

    public override void Clear()
    {
        // Managers.Sound.StopBgm("Bgm/GhostChaser");
    }
}
