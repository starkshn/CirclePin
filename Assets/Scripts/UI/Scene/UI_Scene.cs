using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Scene : UI_Base
{
	public override void Init()
	{
		Managers.UI.SetCanvas(gameObject, false);

        _gameSceneCanvas = GetComponent<Canvas>();
        _gameSceneCanvasRect = _gameSceneCanvas.GetComponent<RectTransform>();
    }

}
