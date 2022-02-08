using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandGenerator : MonoBehaviour
{
    void Start()
    {
        //GenerateLand(0);
    }
    [SerializeField, Range(1, 100)] int accuracy = 1;
    [SerializeField, Range(1, 100)] float position_x = 1;
    [SerializeField, Range(1, 100)] float position_y = 1;
    [SerializeField, Range(1, 100)] int map_size = 1;
    void Update()
    {
    }
    //float[,] height_data;
    //float[,] temp_data;
    //float[,] wetness_data;
    public void GenerateLand(int seed)
    {
        //height_data = new float[range, range];
        //temp_data = new float[range, range];
        //wetness_data = new float[range, range];

        //for (int i = 0; i < range; i++)
        //    for (int j = 0; j < range; j++)
        //    {
        //        height_data[i, j] = Mathf.PerlinNoise(501 + i / (float)range, j / (float)range);
        //        temp_data[i, j] = Mathf.PerlinNoise(i / (float)range, 5 + j / (float)range);
        //        wetness_data[i, j] = Mathf.PerlinNoise(i / (float)range, 10 + j / (float)range);
        //    }
    }
    private void OnDrawGizmos()
    {
        float gray_shadow;
        int a = 0;
        int b = 5;
        for (int i = a; i < b; i++)
        {
            for (int j = a; j < b; j++)
            {
                gray_shadow = Mathf.PerlinNoise((float)i*20, (float)j*20);
                //Debug.Log(gray_shadow);
                Gizmos.color = new Color(gray_shadow, gray_shadow, gray_shadow);
                Gizmos.DrawCube(
                            new Vector3(i,j,0),
                            new Vector3(1, 1, 1));
            }
        }

        //for (float i = position_x-map_size/2f; i < position_x+map_size/2f; ++i)
        //    for (float j = position_y-map_size/2f; j < position_y+map_size/2f; ++j)
        //    {

        //        for (float n = 0; n < accuracy; ++n)
        //            for (float m = 0; m < accuracy; ++m)
        //            {
        //                gray_shadow = Mathf.PerlinNoise(i + n/accuracy, j + m/accuracy);

        //                Gizmos.color = new Color(gray_shadow, gray_shadow, gray_shadow);

        //                Gizmos.DrawCube(
        //                    new Vector3((i + n - position_x + map_size / 2f),
        //                                (j + m - position_y + map_size / 2f), 0),
        //                    new Vector3(1, 1, 1));

        //                //Gizmos.DrawCube(
        //                //    new Vector3(-0.5f + 1 / (map_size * accuracy / 2f) + (i+n - position_x + map_size / 2f) / (map_size * accuracy), -0.5f + 1f / (map_size * accuracy / 2f) + (j+m - position_y + map_size / 2f) / (map_size * accuracy), 0),
        //                //    new Vector3(1f / (map_size * accuracy), 1f / (map_size * accuracy), 1f / (map_size * accuracy)));

        //                //Gizmos.DrawCube(new Vector3(i / (float)range - 0.5f + 1 / (float)range / 2, j / (float)range - 0.5f + 1 / (float)range / 2, 0),
        //                //    new Vector3(1 / (float)range, 1 / (float)range, 1 / (float)range));
        //            }

                
        //        //Gizmos.color = new Color(gray_shadow, gray_shadow, gray_shadow);
        //        //Gizmos.DrawCube(new Vector3(i / (float)range - 0.5f + 1 / (float)range / 2, j / (float)range - 0.5f + 1 / (float)range / 2, 0),
        //        //    new Vector3(1 / (float)range, 1 / (float)range, 1 / (float)range));

        //        //gray_shadow = temp_data[i, j];
        //        //Gizmos.color = new Color(gray_shadow, 0, 1 - gray_shadow);
        //        //Gizmos.DrawCube(new Vector3(2 + i / (float)range - 0.5f + 1 / (float)range / 2, j / (float)range - 0.5f + 1 / (float)range / 2, 0),
        //        //    new Vector3(1 / (float)range, 1 / (float)range, 1 / (float)range));

        //        //gray_shadow = wetness_data[i, j];
        //        //Gizmos.color = new Color(0, 0, gray_shadow);
        //        //Gizmos.DrawCube(new Vector3(4 + i / (float)range - 0.5f + 1 / (float)range / 2, j / (float)range - 0.5f + 1 / (float)range / 2, 0),
        //        //    new Vector3(1 / (float)range, 1 / (float)range, 1 / (float)range));
        //    }

    }
}
