using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Popup : UI_Base
{
    protected RectTransform _rectTransform;

    public override void Init()
    {
        Managers.UI.SetCanvas(gameObject, true);

        _gameSceneCanvas = GetComponent<Canvas>();
        _gameSceneCanvasRect = _gameSceneCanvas.GetComponent<RectTransform>();
        //CanvasScaler cs = GetComponent<CanvasScaler>();
        //cs.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        //cs.referenceResolution = new Vector2(1080,1920);
    }

    public virtual void ClosePopupUI()
    {
        Managers.UI.ClosePopupUI(this);
    }
}
