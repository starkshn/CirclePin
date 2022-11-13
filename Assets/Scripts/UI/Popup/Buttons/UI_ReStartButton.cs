using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ReStartButton : UI_Popup
{
    public override void Init()
    {
        base.Init();

        _rectTransform = GetComponent<RectTransform>();

        _rectTransform.Move(new Vector2(0.5f, 0.5f), 0.5f).SetEase(Ease.Spring);

    }
}
