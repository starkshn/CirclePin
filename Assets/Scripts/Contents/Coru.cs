using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coru : MonoBehaviour
{
    GameObject _target;
    GameObject _targetTextUI;

    public void StartCo(GameObject targetTextUI, GameObject target)
    {
        StartCoroutine(GameClear());

        _targetTextUI = targetTextUI;
        _target = target;
    }

    public IEnumerator GameClear()
    {
        Debug.Log("코루틴 안에 들어옴");
        yield return new WaitForSeconds(0.1f);

        if (GetComponent<StageManager>().IsGameOver == true)
        {
            yield break;
        }

        // Get Component
        _targetTextUI.GetComponent<Rotator>().RotateFast();

        _target.GetComponent<TargetController>().RotateFast();

        // _camera.backgroundColor = _clearBackGroundColor;
    }


}
