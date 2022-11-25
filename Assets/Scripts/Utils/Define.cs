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
        UI_MainMenu,
        UI_TargetTextUI,

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
        PointerEnter,
        PointerExit,
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

    public enum Animals
    {
        Bear,
        Buffalo,
        Chick,
        Chicken,
        Cow,
        Crocodile,
        Dog,
        Elephant,
        Frog,
        Giraffe,
        Goat,
        Gorilla,
        Hippo,
        Horse,
        Monkey,
        Moose,
        Narwhal,
        Owl,
        Panda,
        Parrot,
        Penguin,
        Pig,
        Rabbit,
        Rhino,
        Sloth,
        Snake,
        Walrus,
        Whale,
        Zebra,

        END
    }


    // =============================
    // UI_MainMenu
    public enum UI_MainMenuText
    {
        Title,
    }
    public enum UI_MainMenuButton
    {
        StartButton,
        LeaderBoardButton,
        ExitButton,

        Count,
    }
    public enum UI_MainMenuImage
    {
        Background,
    }
    // =============================


    // =============================
    // UI_GearMenuButton
    public enum UI_GearMenuButton_Button
    {
        GearButton,

        Count,
    }

    // =============================

    // =============================
    // UI_GearPopup
    public enum UI_GearPopup_Button
    {
        ResumeButton,
        RestartButton,
        ExitButton,
        
        Count,
    }

    // =============================

}
