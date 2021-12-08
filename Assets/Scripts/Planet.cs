using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : SpaceObject
{
    #region Variables
    //Planet default mass per sm^3 = 0.005 kg 
    //List<Sattelite> sattelites;
    string planet_name;
    
    #endregion
    #region Properties
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        
    }
    public void FixedUpdate()
    {
        Rocket rocket = GameController.Instance.Player.gameObject.GetComponent<Rocket>();
        rocket.AddForce(gameObject.transform, Time.fixedDeltaTime);
    }
    public void GeneratePlanet(Vector3 pos, float mass, float rotation_speed, float radius, Vector3? start_velocity = null)
    {
        if(start_velocity == null)
            start_velocity = Vector3.zero;

        transform.position = pos;
        planet_name = GameController.Instance.NameGenerator.GenerateName;
        Rb.mass = mass;
        Rb.velocity = (Vector2)start_velocity;

        Debug.Log("Planet " + planet_name + " was generated");

        //Replace to MeshGenerating
        GameObject model = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        model.transform.parent = this.transform;
        model.transform.localPosition = Vector3.zero;
        model.transform.localScale = new Vector3((float)radius, (float)radius, (float)radius);
        //End of replacind



        Rocket rocket = GameController.Instance.Player.GetComponent<Rocket>();
        rocket.transform.position = new Vector3(transform.position.x - radius, transform.position.y, transform.position.z);
        rocket.Rb.velocity = new Vector3(0, 1, 0).normalized * Mathf.Sqrt(rocket.Rb.mass / (rocket.transform.position - transform.position).magnitude);
    }
}
