using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPart : MonoBehaviour
{
    #region Variables
    float mass;
    float durability;
    #endregion
    #region Properties
    public float Mass
    {
        get
        {
            return mass;
        }
        set
        {
            mass = value;
        }
    }
    public float Durability
    {
        get
        {
            return durability;
        }
        set
        {
            durability = value;
        }
    }
    #endregion

}
