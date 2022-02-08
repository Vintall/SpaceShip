using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarSystemInputPanel : MonoBehaviour
{
    #region SerializedFields
    [SerializeField] Text star_mass_input;
    [SerializeField] Text count_of_planets_input;
    #endregion
    #region Variables
    int planets_count;
    string star_mass;
    #endregion
    #region Properties
    public int PlanetsCount
    {
        get
        {
            return planets_count;
        }
    }
    public string StarMass
    {
        get
        {
            return star_mass;
        }
    }
    #endregion
    #region Methods
    public void OnStarMassChanged()
    {
        star_mass = star_mass_input.text;
    }
    public void OnPlanetsCountChanged()
    {
        planets_count = int.Parse(count_of_planets_input.text);
    }
    #endregion
    
}
