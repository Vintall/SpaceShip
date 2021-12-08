using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : SpaceObject
{
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void GenerateStar(float mass, float rotation_speed, float radius)
    {
        Rb.mass = mass;

        //Replace to MeshGenerating
        GameObject model = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        model.transform.parent = this.transform;
        model.transform.localPosition = Vector3.zero;
        model.transform.localScale = new Vector3((float)radius, (float)radius, (float)radius);
        //End of replacind
    }
}
