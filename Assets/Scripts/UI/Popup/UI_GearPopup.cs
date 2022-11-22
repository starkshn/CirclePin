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

        Bind<Button>(typeof(Define.UI_GearMenuButton_Button));

        string[] btns = Enum.GetNames((typeof(Define.UI_GearMenuButton_Button)));

        #region "Bind Button Event"


        for (int i = 0; i < btns.Length - 1; ++i)
        {
            int btnIdex = (int)Enum.Parse(typeof(Define.UI_GearMenuButton_Button), btns[i]);

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
        Debug.Log("OnClickedPauseButton");

       
    }

    private void OnClickedRestartButton(PointerEventData data)
    {
        Debug.Log("OnClickedPauseButton");


    }

    private void OnClickedExitButton(PointerEventData data)
    {
        Debug.Log("OnClickedPauseButton");


    }

}
