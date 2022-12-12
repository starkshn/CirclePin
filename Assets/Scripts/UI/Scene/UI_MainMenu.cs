using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Jobs;
using UnityEngine.UI;

public class UI_MainMenu : UI_Scene
{
    public override void Init()
    {
        base.Init();

        _gameSceneCanvas = GetComponent<Canvas>();
        _gameSceneCanvasRect = _gameSceneCanvas.GetComponent<RectTransform>();

        Bind<Button>(typeof(Define.UI_MainMenuButton));
        Bind<Text>(typeof(Define.UI_MainMenuText));

        #region "Bind Button Event"

        string[] btns = Enum.GetNames((typeof(Define.UI_MainMenuButton)));

        for (int i = 0; i < btns.Length - 1; ++i)
        {
            int btnIdex = (int)Enum.Parse(typeof(Define.UI_MainMenuButton), btns[i]);

            BindEvent
            (
                GetButton(btnIdex).gameObject,
                (PointerEventData data) => { GetButton(btnIdex).gameObject.GetComponent<RectTransform>().ScaleTween(new Vector3(1.2f, 1.2f, 1.2f), 0.3f); },
                Define.UIEvent.PointerEnter
            );

            BindEvent
            (
                GetButton(btnIdex).gameObject,
                (PointerEventData data) => { GetButton(btnIdex).gameObject.GetComponent<RectTransform>().ScaleTween(new Vector3(1.0f, 1.0f, 1.0f), 0.3f); },
                Define.UIEvent.PointerExit
            );
        }
        #endregion

        BindEvent(GetButton((int)Define.UI_MainMenuButton.StartButton).gameObject, OnClickedStartButton, Define.UIEvent.Click);
        BindEvent(GetButton((int)Define.UI_MainMenuButton.LeaderBoardButton).gameObject, OnClickedLeaderBoardButton, Define.UIEvent.Click);
        BindEvent(GetButton((int)Define.UI_MainMenuButton.ExitButton).gameObject, OnClickedExitButton, Define.UIEvent.Click);

    }

    private void OnClickedStartButton(PointerEventData data)
    {
        Debug.Log("OnClickedStartButton");

        Managers.Scene.LoadScene(Define.Scene.GameScene);
    }

    private void OnClickedLeaderBoardButton(PointerEventData data)
    {
        Debug.Log("OnClickedLeaderBoardButton");
    }

    private void OnClickedExitButton(PointerEventData data)
    {
        // 현재 실행 환경이 에디터 이면 에디터 플레이모드 종료
        #if UINTY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // or UnityEditor.EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
