using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LoginScene : UI_Scene
{
    //// For MoveUI Canvas
    //private Canvas          _loginSceneCanvas;
    //private RectTransform   _loginSceneCanvasRect;

    //// LoginScene Animation
    //private Action<bool>    LogoTextEvent;
    //private Action<bool>    LogoEvent;

    //// Default 해상도 비율
    //float fixedAspectRatio = 9f / 16f;

    //// 현재 해상도 비율
    //float curAspectRatio = (float)Screen.width / (float)Screen.height;

    //public override void Init()
    //{
    //    Screen.SetResolution(900, 1600, true);

    //    base.Init();

    //    LogoTextEvent -= LoginSceneBrandAnim;
    //    LogoTextEvent += LoginSceneBrandAnim;

    //    _loginSceneCanvas = GetComponent<Canvas>();
    //    _loginSceneCanvasRect = _loginSceneCanvas.GetComponent<RectTransform>();

    //    Bind<Button>(typeof(Define.LoginScene_UI_Buttons));
    //    Bind<Text>(typeof(Define.LoginScene_UI_Texts));
    //    Bind<Image>(typeof(Define.LoginScene_UI_Images));
    //    Bind<GameObject>(typeof(Define.LoginScene_UI_GameObjects));

    //    GetText((int)Define.LoginScene_UI_Texts.TeamNameText).gameObject.BindEventBool(LoginSceneBrandAnim);
    //    GetText((int)Define.LoginScene_UI_Texts.TeamNameText).gameObject.SetActive(false);

    //    //GetButton((int)Define.LoginScene_UI_Buttons.IDButton).gameObject.SetActive(false);
    //    //GetButton((int)Define.LoginScene_UI_Buttons.PWDButton).gameObject.SetActive(false);

    //    LogoTextEvent.Invoke(true);
    //}

    //private CanvasGroup GetCanvasGroup(GameObject ui)
    //{
    //    return ui.GetOrAddComponent<CanvasGroup>();
    //}

    //private void LoginSceneBrandAnim(bool action)
    //{
    //    if (action)
    //    {
    //        // TeamNameText Scale
    //        GetText((int)Define.LoginScene_UI_Texts.TeamNameText).gameObject.SetActive(true);
    //        GetText((int)Define.LoginScene_UI_Texts.TeamNameText).gameObject.ScaleTween(new Vector3(1, 1, 1), 1.5f).SetEase(Ease.EaseInOutBack);

    //        // Brand위로 올리고 slogan text띄우기
    //        StartCoroutine(LoginSceneSloganAnim());
    //    }
    //}

    //IEnumerator LoginSceneSloganAnim()
    //{
    //    yield return new WaitForSeconds(1.2f);

    //    GetText((int)Define.LoginScene_UI_Texts.TeamNameText).gameObject.GetComponent<RectTransform>().MoveUI(new Vector2(0.5f, 0.6f), _loginSceneCanvasRect, 1.0f).SetEase(Ease.Spring);

    //    GetText((int)Define.LoginScene_UI_Texts.SloganText).gameObject.ScaleTween(new Vector3(1, 1, 1), 1.5f).SetEase(Ease.EaseInOutExpo);

    //    StartCoroutine(LoginSceneFadeTextAnim());
    //}

    //IEnumerator LoginSceneFadeTextAnim()
    //{
    //    yield return new WaitForSeconds(1.5f);

    //    CanvasGroup teamTextCG = GetCanvasGroup(GetText((int)Define.LoginScene_UI_Texts.TeamNameText).gameObject);
    //    teamTextCG.Fade(0.0f, 1.3f).SetEase(Ease.Spring);

    //    CanvasGroup sloganTextCG = GetCanvasGroup(GetText((int)Define.LoginScene_UI_Texts.SloganText).gameObject);
    //    sloganTextCG.Fade(0.0f, 1.3f).SetEase(Ease.Spring);

    //    yield return new WaitForSeconds(0.5f);

    //    for (int i = 0; i < (int)Define.LoginScene_UI_Texts.END - 1; ++i)
    //    {
    //        GetText(i).gameObject.SetActive(false);
    //    }

    //    Managers.Scene.LoadScene(Define.Scene.GameScene);
    //}
}
