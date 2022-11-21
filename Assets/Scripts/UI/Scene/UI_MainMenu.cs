using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Jobs;
using UnityEngine.UI;

public class UI_MainMenu : UI_Scene
{
    // ============================================
    // For MoveUI Canvas
    // ============================================
    private Canvas          _gameSceneCanvas;
    private RectTransform   _gameSceneCanvasRect;

    public override void Init()
    {
        base.Init();

        _gameSceneCanvas = GetComponent<Canvas>();
        _gameSceneCanvasRect = _gameSceneCanvas.GetComponent<RectTransform>();

        Bind<Button>(typeof(Define.UI_MainMenuButton));
        Bind<Text>(typeof(Define.UI_MainMenuText));
        Bind<Image>(typeof(Define.UI_MainMenuImage));

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

    }

    private void OnPointerEnterButton(PointerEventData data)
    {
        Debug.Log(data);
        Debug.Log(this.gameObject.name);
        //GetButton((int)Define.UI_MainMenuButton.RestartButton).gameObject.GetComponent<RectTransform>().ScaleTween(new Vector3(1.2f, 1.2f, 1.2f), 0.3f);
    }

    private void OnPointerExitButton(PointerEventData data)
    {
        // GetButton((int)Define.UI_MainMenuButton.RestartButton).gameObject.GetComponent<RectTransform>().ScaleTween(new Vector3(1.0f, 1.0f, 1.0f), 0.3f);
    }

    private void OnClickedRestartButton(PointerEventData data)
    {
        Debug.Log("OnClickedRestartButton On RestartBTN");
    }



}
