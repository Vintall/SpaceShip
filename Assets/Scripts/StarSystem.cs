using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSystem : MonoBehaviour
{
    [SerializeField] GameObject planet_prefab;
    PlanetNameGenerator name_generator;

    List <Transform> planets = new List<Transform>();

    int count_of_planet;
    float[] radiuses;
    float[] orbit_radiuses;
    float star_mass;


    private void Awake()
    {
        name_generator = GetComponent<PlanetNameGenerator>();
    }
    private void FixedUpdate()
    {
        foreach(Transform t in planets)
        {
            Planet planet = t.GetComponent<Planet>();
            Vector2 force = -t.transform.position.normalized * Time.fixedDeltaTime * planet.Mass * star_mass / (t.transform.position.magnitude * t.transform.position.magnitude);
            t.GetComponent<Planet>().Rb.AddForce(force, ForceMode2D.Impulse);
        }
    }
    public void GenerateStarSystem(float star_mass, int count_of_planet)
    {
        this.star_mass = star_mass;
        this.count_of_planet = count_of_planet;

        radiuses = new float[count_of_planet];
        orbit_radiuses = new float[count_of_planet];

        for (int i = 0; i < count_of_planet; i++)
        {
            radiuses[i] = Random.Range(50, 150);
        }

        for (int i = 0; i < count_of_planet; i++)
        {
            if (i == 0) 
                orbit_radiuses[i] = Random.Range(200, 500);
            else
                orbit_radiuses[i] = orbit_radiuses[i - 1] + Random.Range(200, 500);

            GameObject cur = Instantiate(planet_prefab, this.transform);
            cur.GetComponent<Transform>().position = new Vector3(orbit_radiuses[i], 0, 0);
            cur.GetComponent<Planet>().GeneratePlanet(name_generator.GenerateName, star_mass, Random.Range(-30f, 30f), orbit_radiuses[i]);
            planets.Add(cur.transform);
        }
    }
}
