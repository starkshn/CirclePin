using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class TextPinIndex : CreatureController
{
    protected override void Init()
    {
        _objectType = Define.WorldObject.TextPinIndex;
        
    }
}
