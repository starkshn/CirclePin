using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class routine : MonoBehaviour
{
    public void GameClear()
    {
        StartCoroutine(GameClearCo());
    }

    public IEnumerator GameClearCo()
    {
        Debug.Log("�ڷ�ƾ �ȿ� ����");
        yield return new WaitForSeconds(3.0f);

        //if (IsGameOver == true)
        //{
        //    yield break;
        //}

        //// Get Component
        //_targetRotator.RotateFast();
        //_targetController.RotateFast();

        //_camera.backgroundColor = _clearBackGroundColor;
        Debug.Log("�ڷ�ƾ End");
    }
}
