using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBody : RocketPart
{
    [SerializeField] Engine engine;
    [SerializeField] LandingStrut strut;

    public Engine Engine
    {
        get
        {
            return engine;
        }
    }
    public LandingStrut Strut
    {
        get
        {
            return strut;
        }
    }
}
