using Platinio;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager
{
    public Action<bool> OnClickedGearMenuButton;

    int _order = 10;

    Stack<UI_Popup>     _popupStack   = new Stack<UI_Popup>();
    Queue<UI_Scene>     _sceneList    = new Queue<UI_Scene>();

    UI_Scene            _sceneUI = null;

    // Gear Button
    public bool        _clickedGearButton = false;

    // Animals
    UI_Scene[] _animalsSpritesObj = new UI_Scene[(int)Define.Animals.END - 1];
    

    public GameObject Root
    {
        get
        {
			GameObject root = GameObject.Find("@UI_Root");
			if (root == null)
				root = new GameObject { name = "@UI_Root" };
            return root;
		}
    }

    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }


    // for AnimalUI (수정함)
	public T MakeSubItem<T>(Transform parent = null, string name = null) where T : UI_Base
	{
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/SubItem/{name}");
        if (parent != null)
            go.transform.SetParent(parent);

        return Util.GetOrAddComponent<T>(go);
    }
    

    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
	{
		if (string.IsNullOrEmpty(name))
			name = typeof(T).Name;

		GameObject go = Managers.Resource.Instantiate($"UI/Scene/{name}");
		T sceneUI = Util.GetOrAddComponent<T>(go);
        _sceneUI = sceneUI;

		go.transform.SetParent(Root.transform);

        _sceneList.Enqueue(sceneUI);

        return sceneUI;
	}

	public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}");
        T popup = Util.GetOrAddComponent<T>(go);
        _popupStack.Push(popup);

        go.transform.SetParent(Root.transform);

		return popup;
    }

  

    // for scene Change
    public void CloseAllSceneUI()
    {
        if (_sceneList.Count == 0)
            return;

        while (_sceneList.Count == 0)
        {
            GameObject ui = _sceneList.Dequeue().gameObject;
            Managers.Resource.Destroy(ui);   
        }
    }

    public void ClosePopupUI(UI_Popup popup)
    {
		if (_popupStack.Count == 0)
			return;

        if (_popupStack.Peek() != popup)
        {
            Debug.Log("Close Popup Failed!");
            return;
        }

        ClosePopupUI();
    }

    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
            return;

        UI_Popup popup = _popupStack.Pop();
        Managers.Resource.Destroy(popup.gameObject);
        popup = null;
        _order--;
    }

    public void CloseAllPopupUI()
    {
        while (_popupStack.Count > 0)
            ClosePopupUI();
    }

    public void Clear()
    {
        CloseAllPopupUI();
        _sceneUI = null;
    }

    public void SetAnimalPopupUI(int idx, UI_Scene go)
    {
        _animalsSpritesObj[idx] = go;
    }
    public UI_Scene GetAnimalPopupUI(int idx)
    {
        if ((int)Define.Animals.END <= idx)
        {
            Debug.Log("Animal Index 초과!");
            return null;
        }
        return _animalsSpritesObj[idx];
    }

}
