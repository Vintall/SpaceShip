using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HeightMapImageTaker
{
    // seed { 4 - x, 4 - y, 4 - radius, 2 - sea level (%), ...} 
    //
    public static (Vector3[,], float[,]) TakeMapImage(string seed)
    {
        int noise_x_coord = int.Parse(seed.Substring(0, 4));
        int noise_y_coord = int.Parse(seed.Substring(4, 4));
        int radius = int.Parse(seed.Substring(8, 4));
        int sea_level = int.Parse(seed.Substring(12, 2)); //Percentage

        int map_x_size = (int)(radius * Mathf.PI * 2);
        int map_y_size = (int)(radius * Mathf.PI);
        float[,] result = new float[map_x_size, map_y_size];

        float h;
        float line_on_h;
        float line_on_r = radius * Mathf.PI * 2;
        for (int y = 0; y < map_y_size/2; y++)
        {
            h = (radius - y) * 2 / Mathf.PI;
            line_on_h = Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow(h, 2)) * Mathf.PI * 2;

            for (int x = 0; x < map_x_size; x++)
            {
                //(float)i / (map.GetLength(0) / scale), (float)j / (map.Length / scale / map.GetLength(0))
                result[x, y] = Mathf.PerlinNoise(noise_x_coord + (x * line_on_h / line_on_r) / map_x_size, noise_y_coord + (y)/(map_y_size/2f));
            }
        }
        //PerlinNoise.GetPoint

        return (new Vector3[5, 5], new float[5, 5]);//result;
    }
    public static void TakeMapSquaredImage(ulong seed)
    {

    }
}
