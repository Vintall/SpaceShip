using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : SpaceObject
{
    [SerializeField] RocketBody body;
    float main_engine_power = 0;

    public float MainEnginePower
    {
        get
        {
            return main_engine_power;
        }
        set
        {
            if (value <= 1 && value >= 0)
                main_engine_power = value;
            else
                main_engine_power = 0;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForceAtPosition(body.Engine.transform.forward * main_engine_power * body.Engine.engine_force * Time.fixedDeltaTime, body.Engine.transform.position, ForceMode2D.Impulse);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
