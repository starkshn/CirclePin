using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ClearPopup : UI_Popup
{
    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Define.UI_MainMenuButton));
    }
}
