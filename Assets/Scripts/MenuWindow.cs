using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using FeatherLight.Pro;

public class MenuWindow : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CanvasGroup m_shadowCanvasGroup;
    [SerializeField] private RectTransform m_windowTransform;

    [Header("References")]
    [SerializeField] private float m_shadowWindowFadeTime;
    [SerializeField] private float m_slideInWindowTime;

    public void SetActive(bool _Value)
    {
        StartCoroutine(CanvasGroupHelper.Fade(m_shadowCanvasGroup, _Value, m_shadowWindowFadeTime));

        Vector3 _startPos = new Vector3((_Value) ? -325f : 325f, m_windowTransform.position.y, m_windowTransform.position.z);
        Vector3 _targetPos = new Vector3((_Value) ? 325f : -325f, m_windowTransform.position.y, m_windowTransform.position.z);
        StartCoroutine(FadePos(m_windowTransform, _startPos, _targetPos, m_slideInWindowTime));
    }

    private IEnumerator FadePos(Transform _object, Vector3 _start, Vector3 _target, float overTime)
    {
        float startTime = Time.time;

        while (Time.time < startTime + overTime)
        {
            _object.position = Vector3.Lerp(_start, _target, (Time.time - startTime) / overTime);
            yield return null;
        }

        _object.position = _target;
    }
}
