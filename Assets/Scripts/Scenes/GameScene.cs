using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameScene : BaseScene
{
    private GameObject _target;
    private GameObject p_pinSpawner;
    private GameObject _targetTextUI;
    private GameObject _stageController;

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.GameScene;

        Managers.UI.ShowSceneUI<UI_PauseButton>("UI_PauseButton");

        // ===========================================
        // SPAWN
        // Target, PinSpawner, TargetTextUI
        _target = Managers.Resource.Instantiate("Target/Target");
        p_pinSpawner = Managers.Resource.Instantiate("PinSpawner/PinSpawner");
        _targetTextUI = Managers.Resource.Instantiate("UI/Scene/GameScene/TargetTextUI/TargetTextUI");
        _stageController = Managers.Resource.Instantiate("StageController/@StageController");
        // ===========================================

        // ===========================================
        // Call SetUp
        p_pinSpawner.GetComponent<PinSpawner>().SetUp(_target, _targetTextUI, _stageController);
        _targetTextUI.GetComponent<UI_TargetText>().SetUp(_target);
        _stageController.GetComponent<StageController>().SetUp(_target, p_pinSpawner, _targetTextUI);
        // ===========================================

        // Banner
        //GameObject adGo = GameObject.Find("@BannerAd");
        //BannerAd ad = adGo.GetComponent<BannerAd>();
        //ad.LoadAd();
        //_stageManager.GetComponent<StageManager>().SetUp(_target, p_pinSpawner, _targetTextUI);
    }

    public override void Clear()
    {
        Debug.Log("GameScene Clear!");
        
    }
}
