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
    [SerializeField] private float m_slideLeftValue = -325f;
    [SerializeField] private bool m_useTargetPosition;
    [SerializeField] private Vector3 m_beforePosition;
    [SerializeField] private Vector3 m_afterPosition;

    [Space()]

    [SerializeField] private float m_shadowWindowFadeTime;
    [SerializeField] private float m_slideInWindowTime;

    private bool m_isActive = false;

    public bool IsActive { get { return m_isActive; } }

    public void SetActive(bool _Value)
    {
        m_isActive = _Value;
        UpdateState();
    }

    public void Toggle()
    {
        m_isActive = !m_isActive;
        UpdateState();
    }

    private void UpdateState()
    {
        if (m_shadowCanvasGroup != null) StartCoroutine(CanvasGroupHelper.Fade(m_shadowCanvasGroup, m_isActive, m_shadowWindowFadeTime));

        if (!m_useTargetPosition)
        {
            Vector3 _startPos = new Vector3((m_isActive) ? m_slideLeftValue : -m_slideLeftValue, m_windowTransform.position.y, m_windowTransform.position.z);
            Vector3 _targetPos = new Vector3((m_isActive) ? -m_slideLeftValue : m_slideLeftValue, m_windowTransform.position.y, m_windowTransform.position.z);
            StartCoroutine(FadePos(m_windowTransform, _startPos, _targetPos, m_slideInWindowTime));
        }
        else
        {
            StartCoroutine(FadePos(m_windowTransform, (m_isActive) ? m_beforePosition : m_afterPosition, (m_isActive) ? m_afterPosition : m_beforePosition, m_slideInWindowTime));
        }
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
