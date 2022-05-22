using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

using TMPro;
using FeatherLight.Pro;

public class GridOptionButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("References")]
    [SerializeField] private CanvasGroup m_hoverObject;
    [SerializeField] private TMP_Text m_hoverObjectText;

    [Header("Values")]
    [SerializeField] private float m_textStartSpacing;
    [SerializeField] private float m_textSpacing;
    [SerializeField] private float m_textSpacingSpeed;
    [SerializeField] private float m_hoverAppearingSpeed;

    private bool m_isHover = false;

    public bool IsHighlighted { get { return m_isHover; } }

    public void OnPointerEnter(PointerEventData _Data)
    {
        StartCoroutine(CanvasGroupHelper.Fade(m_hoverObject, true, m_hoverAppearingSpeed));
        StartCoroutine(FadeTextWordSpacing(m_hoverObjectText, m_textSpacing, m_textStartSpacing, m_textSpacingSpeed));
    }

    public void OnPointerExit(PointerEventData _Data)
    {
        StartCoroutine(CanvasGroupHelper.Fade(m_hoverObject, false, m_hoverAppearingSpeed));
        StartCoroutine(FadeTextWordSpacing(m_hoverObjectText, m_textStartSpacing, m_textSpacing, m_textSpacingSpeed));
    }

    private IEnumerator FadeTextWordSpacing(TMP_Text _text, float _wordSpacing, float _startSpacing, float overTime)
    {
        float startTime = Time.time;

        while (Time.time < startTime + overTime)
        {
            _text.characterSpacing = Mathf.Lerp(_startSpacing, _wordSpacing, (Time.time - startTime) / overTime);
            yield return null;
        }

        _text.characterSpacing = _wordSpacing;
    }
}
