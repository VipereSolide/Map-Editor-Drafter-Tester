using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using FeatherLight.Pro;

public class RadialSelector : MonoBehaviour
{
    [SerializeField] private Transform m_selector;
    [SerializeField] private CanvasGroup m_selectorCanvasGroup;
    [SerializeField] private float m_selectorMoveSpeed;
    [SerializeField] private Transform m_container;

    private int _index;

    public void SetIndex(int _Index)
    {
        _index = _Index;

        if (_index >= m_container.childCount)
            _index = m_container.childCount - 1;

        if (_index <= -1)
            _index = 0;

        UpdateSelector();
    }

    public void UpdateSelector()
    {
        StartCoroutine(CanvasGroupHelper.Fade(m_selectorCanvasGroup, false, m_selectorMoveSpeed));
        m_selector.transform.position = m_container.GetChild(_index).position;
        StartCoroutine(CanvasGroupHelper.Fade(m_selectorCanvasGroup, true, m_selectorMoveSpeed));
    }
}