using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    #region SerializedFields
    [SerializeField] CreateStarSystemPanel create_star_system_panel;
    #endregion
    #region Variables
    static UIController instance;
    #endregion
    #region Properties
    public static UIController Instance
    {
        get
        {
            return instance;
        }
    }
    public CreateStarSystemPanel CreateStarSystemPanel
    {
        get
        {
            return create_star_system_panel;
        }
    }
    #endregion
    #region Methods
    private void Awake()
    {
        instance = this;
    }
    public void ChangeCreateStarSystemState()
    {
        create_star_system_panel.gameObject.SetActive(!create_star_system_panel.gameObject.activeSelf);
    }
    #endregion
}
