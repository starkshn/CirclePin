using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    private CameraController _cameraController;
    private PlayerController _playerController;

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.GameScene;

        // GameScene UI 생성
        Managers.UI.ShowSceneUI<UI_TargetText>("GameScene/TargetTextUI/TargetTextUI");

        // StageController 생성
        Managers.Resource.Instantiate("StageController/StageController");

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
