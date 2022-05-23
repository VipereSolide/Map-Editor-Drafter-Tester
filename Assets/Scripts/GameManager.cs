using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using SW.MapEditorUtility;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Draft m_Project;
    
    public void QuitApplication()
    {
        Application.Quit();
    }
}
