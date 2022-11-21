using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_PauseButton : UI_Scene
{
    public override void Init()
    {
        base.Init();

        #region "Bind Button Event"

        Bind<Button>(typeof(Define.UI_PauseButton_Button));

        string[] btns = Enum.GetNames((typeof(Define.UI_PauseButton_Button)));

        for (int i = 0; i < btns.Length - 1; ++i)
        {
            int btnIdex = (int)Enum.Parse(typeof(Define.UI_PauseButton_Button), btns[i]);

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


        BindEvent(GetButton((int)Define.UI_PauseButton_Button.PauseButton).gameObject, OnClickedPauseButton, Define.UIEvent.Click);
    }
    
    private void OnClickedPauseButton(PointerEventData data)
    {
        Debug.Log("OnClickedPauseButton");

        Managers.UI.ShowPopupUI<UI_Popup>("UI_PausePopup");
    }

}

