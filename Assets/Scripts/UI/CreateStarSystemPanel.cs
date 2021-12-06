using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStarSystemPanel : MonoBehaviour
{
    #region SerializedFields
    [SerializeField] StarSystemInputPanel input_panel;
    [SerializeField] StarSysterPreviewPanel preview_panel;
    #endregion
    #region Properties
    public StarSystemInputPanel InputPanel
    {
        get
        {
            return input_panel;
        }
    }
    public StarSysterPreviewPanel PreviewPanel
    {
        get
        {
            return preview_panel;
        }
    }
    public float GetStarMass
    {
        get
        {
            return input_panel.StarMass;
        }
    }
    public int GetPlanetsCount
    {
        get
        {
            return input_panel.PlanetsCount;
        }
    }
    #endregion
    #region Methods
    public void GenerateStarSystem()
    {
        GameController.Instance.GenerateStarSystem();
    }
    public void ConfirmStarSystem()
    {
        GameController.Instance.ConfirmStarSystem();
    }
    #endregion
}
