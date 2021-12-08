using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region SelializeFields
    [SerializeField] GameObject star_system_prefab;
    [SerializeField] PlanetNameGenerator name_generator;
    #endregion
    #region Variables
    bool is_star_system_done = false;
    static GameController instance;
    Transform star_system;
    [SerializeField] Transform player;  //Remove SerializeField
    
    #endregion
    #region Properties
    public static GameController Instance
    {
        get
        {
            return instance;
        }
    }
    public Transform StarSystem
    {
        get
        {
            return star_system;
        }
    }
    public Transform Player
    {
        get
        {
            return player;
        }
    }
    public PlanetNameGenerator NameGenerator
    {
        get
        {
            return name_generator;
        }
    }
    #endregion
    #region Methods
    private void Awake()
    {
        instance = this;
    }
    public void GenerateStarSystem()
    {
        if (star_system != null)
            Destroy(star_system.gameObject);

        star_system = Instantiate(star_system_prefab).transform;
        star_system.gameObject.
            GetComponent<StarSystem>().
            GenerateStarSystem(UIController.Instance.CreateStarSystemPanel.GetStarMass, 
                               UIController.Instance.CreateStarSystemPanel.GetPlanetsCount);
        
    }
    public void ConfirmStarSystem()
    {
        if (star_system == null)
            return;

        is_star_system_done = true;
        UIController.Instance.ChangeCreateStarSystemState();
    }
    #endregion
}
