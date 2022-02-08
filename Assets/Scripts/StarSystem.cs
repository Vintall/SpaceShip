using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSystem : MonoBehaviour
{
    #region Prefab
    [SerializeField] GameObject planet_prefab;
    [SerializeField] GameObject star_prefab;
    #endregion
    
    List <Transform> planets = new List<Transform>();
    List<Transform> stars = new List<Transform>();

    private void Awake()
    {

    }
    void PlanetOrbitalMovement()
    {
        foreach (Transform star in stars)
        {
            foreach (Transform t in planets)
            {
                Planet planet = t.GetComponent<Planet>();
                planet.AddForce(star, Time.fixedDeltaTime);
            }
        }
    }
    void RocketOrbitalMovement()
    {
        foreach (Transform star in stars)
        {
            Rocket rocket = GameController.Instance.Player.gameObject.GetComponent<Rocket>();
            rocket.AddForce(star, Time.fixedDeltaTime);
        }
    }
    private void FixedUpdate()
    {
        PlanetOrbitalMovement();
        RocketOrbitalMovement();
    }
    Structs.OrbitEllipse orbitEllipse  = null;
    public void GenerateStarSystem(string star_mass_string, int count_of_planet)
    {
        System.Numerics.BigInteger star_mass = System.Numerics.BigInteger.Parse("1988500000000000000000000000000"); //кг
        System.Numerics.BigInteger planet_mass = System.Numerics.BigInteger.Parse("5972370000000000000000000"); //кг
        System.Numerics.BigInteger distance = System.Numerics.BigInteger.Parse("150000000000"); //метров


        //System.Numerics.BigInteger star_mass = System.Numerics.BigInteger.Parse(  "198850000000000000"); //кг
        //System.Numerics.BigInteger planet_mass = System.Numerics.BigInteger.Parse("5972370000000"); //кг
        //System.Numerics.BigInteger distance = System.Numerics.BigInteger.Parse("1500"); //метров

        //System.Numerics.BigInteger star_mass = System.Numerics.BigInteger.Parse("597237500000000"); //кг
        //System.Numerics.BigInteger planet_mass = System.Numerics.BigInteger.Parse("597237500000000"); //кг
        //System.Numerics.BigInteger distance = System.Numerics.BigInteger.Parse("1500"); //метров

        //float[] radiuses = new float[1];

        //radiuses[0] = Mathf.Sqrt(star_mass / (4 * Mathf.PI));

        //Planet planet = Instantiate(planet_prefab, transform).GetComponent<Planet>();
        //planet.GeneratePlanet(new Vector3(0, 0, 0),
        //                      2808116000000000, Random.Range(-30f, 30f),
        //                      6370);
        orbitEllipse = new Structs.OrbitEllipse();
        //planets.Add(planet.transform);
        orbitEllipse.CalculateOrbit(star_mass,
                                    planet_mass,
                                    new Structs.OrbitalVector2(0, 0),
                                    new Structs.OrbitalVector2(-distance, 0),
                                    new Structs.OrbitalVector2(0, System.Numerics.BigInteger.Parse("100000000")));


        System.Numerics.BigInteger buff = orbitEllipse.Points[0].magnitude;
        for (int i = 0; i < orbitEllipse.Points.Count; i++)
        {
            orbitEllipse.Points[i] = new Structs.OrbitalVector2(orbitEllipse.Points[i].x * 50 / buff, orbitEllipse.Points[i].y * 50 / buff);
        }

        //float[] radiuses = new float[count_of_planet];
        //float[] orbit_radiuses = new float[count_of_planet];

        //Star star_obj = Instantiate(star_prefab, transform).GetComponent<Star>();
        //float star_radius = Mathf.Sqrt(star_mass / (4 * Mathf.PI));

        //star_obj.GenerateStar(star_mass, 0f, star_radius);
        //stars.Add(star_obj.transform);


        //for (int i = 0; i < count_of_planet; i++)
        //{
        //    radiuses[i] = Mathf.Sqrt(star_mass * 0.1f / (4 * Mathf.PI));
        //}

        //for (int i = 0; i < count_of_planet; i++)
        //{
        //    if (i == 0)
        //        orbit_radiuses[i] = Random.Range(star_radius * 5, star_radius * 20);
        //    else
        //        orbit_radiuses[i] = orbit_radiuses[i - 1] + Random.Range(star_radius * 5, star_radius * 20);

        //    Planet planet = Instantiate(planet_prefab, transform).GetComponent<Planet>();
        //    planet.GeneratePlanet(new Vector3(orbit_radiuses[i], 0, 0),
        //                          star_mass * 0.1f, Random.Range(-30f, 30f),
        //                          radiuses[i],
        //                          new Vector3(0, 1, 0).normalized * Mathf.Sqrt(star_mass * 0.1f / orbit_radiuses[i]));

        //    planets.Add(planet.transform);
        //}
    }
    private void OnDrawGizmos()
    {
        if(orbitEllipse != null)
        {
            Gizmos.color = Color.red;
            for(int i = 0; i< orbitEllipse.Points.Count; i++)
            {
                Gizmos.DrawSphere(new Vector3(float.Parse(orbitEllipse.Points[i].x.ToString()), float.Parse(orbitEllipse.Points[i].y.ToString()), 0), 5);
            }
        }
    }
}
