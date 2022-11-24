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

        //Managers.UI.ShowSceneUI<UI_LoginBackGround>("UI_LoginBackGround");
        Managers.UI.ShowSceneUI<UI_MainMenu>("UI_MainMenu");

        // Banner
        //GameObject go = GameObject.Find("@BannerAd");
        //BannerAd ad = go.GetComponent<BannerAd>();
        //ad.ExitAd();
    }

    public override void Clear()
    {
        // Managers.Sound.StopBgm("Bgm/GhostChaser");
        Debug.Log("LoginScene Clear");
        Managers.UI.CloseAllSceneUI();        
    }
}
