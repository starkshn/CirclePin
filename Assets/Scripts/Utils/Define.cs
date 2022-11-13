using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum Scene
    {
        Unknown,
        LoginScene,
        Lobby,
        GameScene,
    }
    
    public enum UI
    {
        UI_None,
        UI_LoginScene,
        UI_GameScene,
    }

    public enum CreatureState
    {
        None,
        Idle,
        Walk,
        Moving,
        Rotate,
        Dead,
    }

    public enum WorldObject
    { 
        Player,
        Pin,
        Target,
        TextPinIndexCanvas,
        TextPinIndex,
        Unknown,
    }
    

    public enum Sound
    {
        Bgm,
        Effect,

        MaxCount,
    }

    public enum UIEvent
    {
        Click,
        Drag,
        Touch,
    }
    public enum CameraMode
    {
        QuarterView,
    }

    public enum UI_TargetText
    {
        INDEX_UI_TEXT,
        TARGET_INDEX_UI_TEXT,
    }


 
    //public enum GameScene_UI_Buttons
    //{
    //    StartButton,
    //    ReStartButton,
    //    GameOverButton, // 텍스트 처럼 활용
    //    ScoreButton,    // 텍스트 처럼 활용
    //    AdButton,       // 보상형 광고 버튼

    //    END
    //}
    //public enum GameScene_UI_Texts
    //{
    //    ScoreText,
    //    CurrentScoreText,
    //    BestScoreText,

    //    END
    //}
    //public enum GameScene_UI_Images
    //{
       
    //}
    //public enum GameScene_UI_GameObjects
    //{

    //}

    //public enum GameScene_UI_Panel
    //{

    //}
   
}
