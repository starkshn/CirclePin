using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Popup : UI_Base
{
    protected RectTransform _rectTransform;

    public override void Init()
    {
        Managers.UI.SetCanvas(gameObject, true);

        _gameSceneCanvas = GetComponent<Canvas>();
        _gameSceneCanvasRect = _gameSceneCanvas.GetComponent<RectTransform>();
    }

    public virtual void ClosePopupUI()
    {
        Managers.UI.ClosePopupUI(this);
    }
}
