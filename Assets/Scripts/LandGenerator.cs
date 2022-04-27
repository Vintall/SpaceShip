using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandGenerator : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] Vector3 position;
    [SerializeField] Transform player_test;
    [SerializeField] Transform plane_container;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void GenerateLand(string seed)
    {
        
    }
    private void OnDrawGizmos()
    {
        //Sphere
        Gizmos.color = new Color(1f, 0, 0, 0.3f);
        Gizmos.DrawSphere(position, radius);

        Vector3 player_vec = player_test.GetChild(0).transform.position.normalized;

        //vector
        Gizmos.color = new Color(0, 0, 1f, 0.3f);
        Gizmos.DrawLine(position, player_vec * radius);

        
        Vector3 angles = TestAngles(player_vec);

        plane_container.rotation = Quaternion.Euler(0, 0, 0);
        plane_container.Rotate(new Vector3(0, 1, 0), angles.y, Space.Self);
        plane_container.Rotate(new Vector3(0, 0, 1), angles.z, Space.Self);

        Matrix4x4 matrix_y = new Matrix4x4()
        {
            m00 = Mathf.Cos(angles.y*Mathf.Deg2Rad),
            m01 = 0,
            m02 = Mathf.Sin(angles.y * Mathf.Deg2Rad),
            m03 = 0,
            m10 = 0,
            m11 = 1,
            m12 = 0,
            m13 = 0,
            m20 = -Mathf.Sin(angles.y * Mathf.Deg2Rad),
            m21 = 0,
            m22 = Mathf.Cos(angles.y * Mathf.Deg2Rad),
            m23 = 0,
            m30 = 0,
            m31 = 0,
            m32 = 0,
            m33 = 0
        };
        Matrix4x4 matrix_z = new Matrix4x4()
        {
            m00 = Mathf.Cos(angles.z * Mathf.Deg2Rad),
            m01 = -Mathf.Sin(angles.z * Mathf.Deg2Rad),
            m02 = 0,
            m03 = 0,
            m10 = Mathf.Sin(angles.z * Mathf.Deg2Rad),
            m11 = Mathf.Cos(angles.z * Mathf.Deg2Rad),
            m12 = 0,
            m13 = 0,
            m20 = 0,
            m21 = 0,
            m22 = 1,
            m23 = 0,
            m30 = 0,
            m31 = 0,
            m32 = 0,
            m33 = 0
        };



        for (int i = -5; i <= 5; i++) 
            for(int j = -5; j <= 5; j++)
            {
                Vector3 test_vec = new Vector3(0, 0, 0);
                test_vec += new Vector3(10, i, j);

                test_vec = matrix_y * matrix_z * test_vec;
                Gizmos.color = new Color((i + 5) / 11f, (j + 5) / 11f, 0);
                Gizmos.DrawSphere(test_vec, 0.35f);
            }

        var assembly = System.Reflection.Assembly.GetAssembly(typeof(UnityEditor.SceneView));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);

        //Debug.Log("Dot   " + (180 - (Mathf.Acos(Vector3.Dot(new Vector3(player_vec.x, 0, player_vec.z), new Vector3(0, 0, 1))) * Mathf.Rad2Deg + 90)));
        Debug.Log("(  *  ,  " + angles.y + "  ,  " + angles.z + "  )");
        
        Debug.Log("xy from x    " + Vector3.Angle(new Vector3(player_vec.x, player_vec.y, 0).normalized, new Vector3(1, 0, 0)));
        Debug.Log("Player vec" + "   x = " + player_vec.x + "  y = " + player_vec.y + "  z = " + player_vec.z);



    }
    Vector3 TestAngles(Vector3 vec)
    {
        Vector3 result = new Vector3(0, 0, 0);

        if (Mathf.Abs(vec.x) <= 0.00001f) vec.x = 0f;
        if (Mathf.Abs(vec.y) <= 0.00001f) vec.y = 0f;
        if (Mathf.Abs(vec.z) <= 0.00001f) vec.z = 0f;

        if (Vector3.Angle(new Vector3(vec.x, 0, vec.z).normalized, new Vector3(0, 0, 1)) >= 90)
        {
            result.y = Vector3.Angle(new Vector3(vec.x, 0, vec.z).normalized, new Vector3(1, 0, 0));
        }
        else
            result.y = 360 - Vector3.Angle(new Vector3(vec.x, 0, vec.z).normalized, new Vector3(1, 0, 0));

        if (result.y >= 360)
            result.y = result.y % 360;

        if (Vector3.Angle(new Vector3(vec.x, vec.y, vec.z).normalized, new Vector3(0, 1, 0)) > 90)
        {
            if (new Vector3(vec.x, 0, vec.z).magnitude != 0)
                result.z = -Vector3.Angle(
                new Vector3(vec.x, vec.y, vec.z).normalized,
                new Vector3(vec.x, 0, vec.z).normalized);
            else
                result.z = -90;
        }
        else if (Vector3.Angle(new Vector3(vec.x, vec.y, vec.z).normalized, new Vector3(0, 1, 0)) < 90)
        {
            if (new Vector3(vec.x, 0, vec.z).magnitude != 0)
                result.z = Vector3.Angle(
                    new Vector3(vec.x, vec.y, vec.z).normalized,
                    new Vector3(vec.x, 0, vec.z).normalized);
            else
                result.z = 90;
        }
        else
        {
            result.z = 0;
        }

        if (result.z >= 90) result.z = 180 - result.z;
        else if (result.z <= -90) result.z = -180 - result.z;

        return result;
    }
    

    public float VectorMulti(Vector3 a, Vector3 b) => a.x * b.x + a.y * b.y + a.z * b.z;
    public float VectorScalar(Vector3 a, Vector3 b) => VectorMulti(a, b) / (a.magnitude * b.magnitude);
}
