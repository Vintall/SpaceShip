using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    //Planet default mass per sm^3 = 0.005 kg 
    string planet_name;
    float mass;
    float rotation_speed;
    float radius;
    float star_mass;
    Rigidbody2D rb;


    public float Mass
    {
        get
        {
            return mass;
        }
    }
    public Rigidbody2D Rb
    {
        get
        {
            return rb;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        
    }
    public void FixedUpdate()
    {
        
    }

    public void GeneratePlanet(string name, float star_mass, float rotation_speed, float radius)
    {
        planet_name = name;

        this.star_mass = star_mass;
        this.mass = star_mass;
        rb.mass = mass;

        this.radius = radius;
        this.rotation_speed = rotation_speed;
        Debug.Log("Planet " + name + " was generated");
        GameObject model = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        model.transform.parent = this.transform;
        model.transform.localPosition = Vector3.zero;

        rb.velocity = new Vector3(0, 1, 0).normalized * Mathf.Sqrt(mass / radius);
    }

}
