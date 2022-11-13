using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeEffect : MonoBehaviour
{
    private float _fadeTime = 1.5f; // ���̵� ȿ���� �Ϸ�Ǵ½ð�
    [SerializeField]
    private AnimationCurve _fadeCurve; // ���̵� ȿ���� ����Ǵ� ���� ������ �ƴ� ����� ������ �� ���
    private TextMeshProUGUI _fadeText; // ���̵� ȿ���� ����Ǵ� Text UI

    private float _endAlpha; // ���̵� ȿ�� ����Ϸ� �� Alpha��

    private void Start()
    {
        _fadeText = GetComponent<TextMeshProUGUI>();
        _fadeTime = 1.5f;
        //_endAlpha = _fadeText.color.a;
    }

    public void FadeIn()
    {
        StartCoroutine(Fade(0, _endAlpha));
    }

    private IEnumerator Fade(float start, float end)
    {
        float current = 0;
        float precent = 0;

        while (precent < 1)
        {
            current += Time.deltaTime;
            precent = current / _fadeTime;

            Color color = _fadeText.color;
            color.a = Mathf.Lerp(start, end, _fadeCurve.Evaluate(precent));
            _fadeText.color = color;

            yield return null;
        }
    }
}
