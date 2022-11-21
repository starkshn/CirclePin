using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_PausePopup : UI_Popup
{
    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Define.UI_PausePopup_Button));

        string[] btns = Enum.GetNames((typeof(Define.UI_PausePopup_Button)));
        // string[] imgs = Enum.GetNames((typeof(Define.UI_Pause_Images)));

        #region "Bind Button Event"

        for (int i = 0; i < btns.Length - 1; ++i)
        {
            int btnIdex = (int)Enum.Parse(typeof(Define.UI_PausePopup_Button), btns[i]);

            int a = 10;

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

        BindEvent(GetButton((int)Define.UI_PausePopup_Button.ResumeButton).gameObject, OnClickedResumeButton, Define.UIEvent.Click);

        BindEvent(GetButton((int)Define.UI_PausePopup_Button.RestartButton).gameObject, OnClickedRestartButton, Define.UIEvent.Click);

        BindEvent(GetButton((int)Define.UI_PausePopup_Button.ExitButton).gameObject, OnClickedExitButton, Define.UIEvent.Click);
    }

    private void OnClickedResumeButton(PointerEventData data)
    {
        Debug.Log("OnClickedResumeButton");
        Managers.UI.ClosePopupUI(this);
        
    }

    private void OnClickedRestartButton(PointerEventData data)
    {
        Debug.Log("OnClickedRestartButton");

    }

    private void OnClickedExitButton(PointerEventData data)
    {
        Debug.Log("OnClickedExitButton");
        // 현재 실행 환경이 에디터 이면 에디터 플레이모드 종료
#if UINTY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // or UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
