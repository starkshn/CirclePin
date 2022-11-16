using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameScene : BaseScene
{
    private GameObject _target;
    private GameObject p_pinSpawner;
    private GameObject _targetTextUI;

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.GameScene;

        // ===========================================
        // SPAWN
        // Target, PinSpawner, TargetTextUI
        _target = Managers.Resource.Instantiate("Target/Target");
        p_pinSpawner = Managers.Resource.Instantiate("PinSpawner/PinSpawner");
        _targetTextUI = Managers.Resource.Instantiate("UI/Scene/GameScene/TargetTextUI/TargetTextUI");
        // ===========================================


        // ===========================================
        // Call SetUp
        p_pinSpawner.GetComponent<PinSpawner>().SetUp(_target, _targetTextUI);
        _targetTextUI.GetComponent<UI_TargetText>().SetUp(_target);
        
        // ===========================================

        // Banner
        //GameObject adGo = GameObject.Find("@BannerAd");
        //BannerAd ad = adGo.GetComponent<BannerAd>();
        //ad.LoadAd();

        Managers.Stage.SetUp(_target, p_pinSpawner, _targetTextUI);
    }

    public override void Clear()
    {
        Debug.Log("GameScene Clear!");
        
    }
}
