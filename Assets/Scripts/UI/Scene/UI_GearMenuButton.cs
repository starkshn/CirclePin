using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_GearMenuButton : UI_Scene
{
    // PauseButton == gearIcon
    private RectTransform   _gearIcon = null;
    private RectTransform   _UIPausePopup = null;

    private float           _gearRotation = 180.0f;
    private float           _time = 1.0f;

    public override void Init()
    {
        base.Init();

        #region "Bind Button Event"

        Bind<Button>(typeof(Define.UI_GearMenuButton_Button));

        _gearIcon = GetButton((int)Define.UI_GearMenuButton_Button.GearButton).gameObject.GetComponent<RectTransform>();

        string[] btns = Enum.GetNames((typeof(Define.UI_GearMenuButton_Button)));

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


        BindEvent(GetButton((int)Define.UI_GearMenuButton_Button.GearButton).gameObject, OnClickedPauseButton, Define.UIEvent.Click);
    }
    
    private void OnClickedPauseButton(PointerEventData data)
    {
        Debug.Log("OnClickedPauseButton");

        _gearIcon.RotateTween(Vector3.forward, _gearIcon.rotation.eulerAngles.z + _gearRotation, _time).SetEase(Ease.EaseInOutBack);

        UI_Popup popup = Managers.UI.ShowPopupUI<UI_Popup>("UI_GearPopup");
        // popup.gameObject.GetComponent<RectTransform>().ScaleTween(new Vector3(0.0f, 0.0f, 0.0f), 1.0f);

        Managers.UI.OnClickedGearMenuButton.Invoke(true);
    }

}

