using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanController : MonoBehaviour
{
    public static PlanController Instance;

    [SerializeField] private float m_cellSize = 31.5f;
    [SerializeField] private float m_cellPositionSize = 31.5f;

    private RectTransform m_selectedObject;
    private bool m_isDragging = false;
    private Vector2 m_lastPosition;

    public RectTransform SelectedObject { get { return m_selectedObject; } }
    public bool IsDragging { get { return m_isDragging; } }

    private void Awake()
    {
        Instance = this;
    }

    public void SetSelectedObject(RectTransform _object)
    {
        if (_object == null)
            return;

        m_selectedObject = _object;

        Vector2 _mousePosition = new Vector2(
            Mathf.Round(Input.mousePosition.x / m_cellPositionSize) * m_cellPositionSize,
            Mathf.Round(Input.mousePosition.y / m_cellPositionSize) * m_cellPositionSize
        );

        m_lastPosition = _mousePosition * 2;

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
            Vector2 _mousePosition = new Vector2(
                Mathf.Round(Input.mousePosition.x / m_cellSize) * m_cellSize,
                Mathf.Round(Input.mousePosition.y / m_cellSize) * m_cellSize
            );

            // -480 != -475.5

            Vector2 _screenSize = new Vector2(m_lastPosition.x, m_lastPosition.y);
            Vector2 _sizeDelta = (_mousePosition - _screenSize / 2);
            Vector2 _sizeDeltaPosition = _screenSize / 2 + _sizeDelta / 2;
            float _roundedCell = m_cellSize / 2;

            m_selectedObject.SetPositionAndRotation(_sizeDeltaPosition + new Vector2(-1f,-4), Quaternion.identity);
            m_selectedObject.sizeDelta = _sizeDelta;
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopDragging();
        }
    }
}
