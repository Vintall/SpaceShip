using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObject : MonoBehaviour
{
    protected Rigidbody2D rb;

    public Rigidbody2D Rb
    {
        get
        {
            return rb;
        }
    }
    public float Mass
    {
        get
        {
            return rb.mass;
        }
    }

    public void AddForce(Transform gravity_object, float multiplier)
    {
        Vector3 vec = gravity_object.position - gameObject.transform.position;
        SpaceObject space_obj = gravity_object.gameObject.GetComponent<SpaceObject>();

        if (vec.magnitude == 0)
            return;

        Vector3 force = vec.normalized * multiplier * Mass * space_obj.Mass / Mathf.Pow(vec.magnitude, 2);
        Rb.AddForce(force, ForceMode2D.Impulse);
    }
    public void AddForce(Transform gravity_object)
    {
        Vector3 vec = gravity_object.position - transform.position;
        Star star_obj = gravity_object.GetComponent<Star>();
        Vector2 force = vec.normalized * Mass * star_obj.Rb.mass / Mathf.Pow(vec.magnitude, 2);
        Rb.AddForce(force, ForceMode2D.Impulse);
    }
    public void AddForce(Vector2 force)
    {
        Rb.AddForce(force, ForceMode2D.Impulse);
    }
}
