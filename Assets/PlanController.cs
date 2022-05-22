using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanController : MonoBehaviour
{
    private RectTransform m_selectedObject;
    private bool m_isDragging = false;
    private Vector2 m_lastPosition;

    public RectTransform SelectedObject { get { return m_selectedObject; } }
    public bool IsDragging { get { return m_isDragging; } }

    public void SetSelectedObject(RectTransform _object)
    {
        if (_object == null)
            return;

        m_selectedObject = _object;
        m_lastPosition = Input.mousePosition * 2;

        StartDragging();
    }

    private void StartDragging()
    {
        m_isDragging = true;
    }

    private void StopDragging()
    {
        m_isDragging = false;
        m_selectedObject = null;
    }

    private void Update()
    {
        if (m_isDragging && m_selectedObject != null)
        {
            Vector2 _mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 _screenSize = new Vector2(m_lastPosition.x, m_lastPosition.y);
            Vector2 _sizeDelta = (_mousePosition - _screenSize / 2);
            Vector2 _sizeDeltaPosition = _screenSize / 2 + _sizeDelta / 2;

            m_selectedObject.sizeDelta = _sizeDelta;
            m_selectedObject.SetPositionAndRotation(_sizeDeltaPosition, Quaternion.identity);
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopDragging();
        }
    }
}
