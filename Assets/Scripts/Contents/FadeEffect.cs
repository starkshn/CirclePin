using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeEffect : MonoBehaviour
{
    private float _fadeTime = 1.5f; // 페이드 효과가 완료되는시간
    [SerializeField]
    private AnimationCurve _fadeCurve; // 페이드 효과가 적용되는 값을 직선이 아닌 곡선으로 설정할 때 사용
    private TextMeshProUGUI _fadeText; // 페이드 효과가 적용되는 Text UI

    private float _endAlpha; // 페이드 효과 재생완료 후 Alpha값

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
