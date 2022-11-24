using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_GearPopup : UI_Popup
{
    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Define.UI_GearPopup_Button));

        string[] btns = Enum.GetNames((typeof(Define.UI_GearPopup_Button)));

        #region "Bind Button Event"

        for (int i = 0; i < btns.Length - 1; ++i)
        {
            int btnIdex = (int)Enum.Parse(typeof(Define.UI_GearPopup_Button), btns[i]);

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


        BindEvent(GetButton((int)Define.UI_GearPopup_Button.ResumeButton).gameObject, OnClickedResumeButton, Define.UIEvent.Click);

        BindEvent(GetButton((int)Define.UI_GearPopup_Button.RestartButton).gameObject, OnClickedRestartButton, Define.UIEvent.Click);

        BindEvent(GetButton((int)Define.UI_GearPopup_Button.ExitButton).gameObject, OnClickedExitButton, Define.UIEvent.Click);
    }


    private void OnClickedResumeButton(PointerEventData data)
    {
        Debug.Log("OnClickedResumeButton");

        Managers.UI.OnClickedGearMenuButton.Invoke(false);
        Managers.UI.ClosePopupUI(this);
        Managers.UI._clickedGearButton = false;
        
    }

    private void OnClickedRestartButton(PointerEventData data)
    {
        Debug.Log("OnClickedPauseButton");
        Managers.UI._clickedGearButton = false;
        Managers.Scene.LoadScene(Define.Scene.GameScene);

    }

    private void OnClickedExitButton(PointerEventData data)
    {
        Debug.Log("OnClickedPauseButton");
        Managers.UI._clickedGearButton = false;

        // 현재 실행 환경이 에디터 이면 에디터 플레이모드 종료
#if UINTY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // or      UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
        #endif
    }

}
