using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{ 
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.GameScene;

        // GameScene UI 생성
        Managers.UI.ShowSceneUI<UI_TargetText>("GameScene/TargetTextUI/TargetTextUI");

        // Banner
        //GameObject adGo = GameObject.Find("@BannerAd");
        //BannerAd ad = adGo.GetComponent<BannerAd>();
        //ad.LoadAd();
    }

    public override void Clear()
    {
        Debug.Log("GameScene Clear!");
        
    }
}
