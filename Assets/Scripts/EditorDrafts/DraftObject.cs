using System;

using UnityEngine;

namespace SW.MapEditorUtility
{
    [Serializable]
    public class DraftObject
    {
        #region Declarations

        // We will focus on rectangles for now, and then add the triangle support.
        [SerializeField] private DraftObjects m_draftType = DraftObjects.Rect;
        [SerializeField, Tooltip("In order: posX, posY, width, height")] private Vector4 m_draftDimensions = new Vector4();
        
        // The user will select the corresponding height for each colors. The color ID will be used to
        // Determine the draft object's height.
        [SerializeField] private int m_draftColorID = 0;

        #endregion
        #region Public Getters

        public DraftObjects DraftType
        {
            get { return m_draftType; }
        }

        public Vector4 DraftDimensions
        {
            get { return m_draftDimensions; }
        }

        public int DraftColorID
        {
            get { return m_draftColorID; }
        }

        #endregion
        #region Constructor(s)

        public DraftObject(DraftObjects _DraftType, Vector4 _DraftDimensions, int _ColorID)
        {
            m_draftColorID = _ColorID;
            m_draftDimensions = _DraftDimensions;
            m_draftType = _DraftType;
        }

        public DraftObject(DraftObjects _DraftType, float _PosX, float _PosY, float _Width, float _Height, int _ColorID)
        {
            m_draftColorID = _ColorID;
            m_draftDimensions = new Vector4(_PosX, _PosY, _Width, _Height);
            m_draftType = _DraftType;
        }

        public DraftObject(DraftObjects _DraftType, Vector4 _DraftDimensions)
        {
            m_draftColorID = 0;
            m_draftDimensions = _DraftDimensions;
            m_draftType = _DraftType;
        }

        public DraftObject(DraftObjects _DraftType, float _PosX, float _PosY, float _Width, float _Height)
        {
            m_draftDimensions = new Vector4(_PosX, _PosY, _Width, _Height);
            m_draftType = _DraftType;
        }

        #endregion
    }

    public enum DraftObjects
    {
        Rect,
        Triangle
    }
}