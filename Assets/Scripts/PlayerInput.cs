using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    float rotation_force_multiplier;
    float main_engine_force_multiplier;
    private void Update()
    {
        rotation_force_multiplier = Input.GetAxis("Horizontal");
        main_engine_force_multiplier = Input.GetAxis("Vertical");

        GetComponent<Rocket>().MainEnginePower = main_engine_force_multiplier;

    }
}
