using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using System;
using System.Collections;
using System.Collections.Generic;

using FeatherLight.Pro;

public class DraftComponent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private bool m_interractable = true;
    
    [Space()]
    [SerializeField] private CanvasGroup m_group;
    [SerializeField] private float m_groupFadeSpeed;

    [Space()]
    [SerializeField] private Image m_lockImage;
    [SerializeField] private Sprite m_interractableSprite;
    [SerializeField] private Sprite m_uninterractableSprite;

    private bool m_isHighlighted = false;
    private bool m_pointerDown = false;

    public bool Interractable
    {
        get { return m_interractable; }
    }

    public void ToggleInterractable()
    {
        m_interractable = !m_interractable;

        m_lockImage.sprite = (m_interractable) ? m_interractableSprite : m_uninterractableSprite;
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (!m_interractable)
            return;

        m_pointerDown = true;

        PlanController.Instance.SetSelectedObject(GetComponent<RectTransform>());
        
        if (m_group.alpha == 1)
            StartCoroutine(CanvasGroupHelper.Fade(m_group, false, m_groupFadeSpeed));
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (m_group.alpha == 0 && !m_isHighlighted)
            StartCoroutine(CanvasGroupHelper.Fade(m_group, true, m_groupFadeSpeed));

        m_pointerDown = false;
    }

    public void OnPointerEnter(PointerEventData data)
    {
        m_isHighlighted = true;

        if (m_group.alpha == 0 && !m_pointerDown)
            StartCoroutine(CanvasGroupHelper.Fade(m_group, true, m_groupFadeSpeed));
    }

    public void OnPointerExit(PointerEventData data)
    {
        m_isHighlighted = false;
        
        if (m_group.alpha == 1 && !m_interractable)
            StartCoroutine(CanvasGroupHelper.Fade(m_group, false, m_groupFadeSpeed));
    }
}