using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PerlinNoise
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="noise_seed">Seed of the noise dimention</param>
    /// <param name="octave">Grid size</param>
    /// <param name="x">X coordinate in world</param>
    /// <param name="y">Y coordinate in world</param>
    /// <param name="z">Z coordinate in world</param>
    public static double GetPoint(int noise_seed, int octave, double x, double y, double z) //octave in meters
    {
        Vector3Int position_inside_sheet = new Vector3Int(
            (int)x,
            (int)y,
            (int)z);

        Vector3Int octave_low_position = new Vector3Int(
            position_inside_sheet.x - position_inside_sheet.x % octave,
            position_inside_sheet.y - position_inside_sheet.y % octave,
            position_inside_sheet.z - position_inside_sheet.z % octave);

        Vector3Int[,,] cube_vertices_position = new Vector3Int[2, 2, 2];
        cube_vertices_position[0, 0, 0] = new Vector3Int(
            octave_low_position.x,
            octave_low_position.y,
            octave_low_position.z);

        cube_vertices_position[0, 1, 0] = new Vector3Int(
            cube_vertices_position[0, 0, 0].x, 
            cube_vertices_position[0, 0, 0].y + octave, 
            cube_vertices_position[0, 0, 0].z);

        cube_vertices_position[0, 0, 1] = new Vector3Int(
            cube_vertices_position[0, 0, 0].x, 
            cube_vertices_position[0, 0, 0].y, 
            cube_vertices_position[0, 0, 0].z + octave);

        cube_vertices_position[0, 1, 1] = new Vector3Int(
            cube_vertices_position[0, 0, 0].x, 
            cube_vertices_position[0, 0, 0].y + octave, 
            cube_vertices_position[0, 0, 0].z + octave);


        cube_vertices_position[1, 0, 0] = new Vector3Int(
            cube_vertices_position[0, 0, 0].x + octave,
            cube_vertices_position[0, 0, 0].y,
            cube_vertices_position[0, 0, 0].z);

        cube_vertices_position[1, 1, 0] = new Vector3Int(
            cube_vertices_position[0, 0, 0].x + octave,
            cube_vertices_position[0, 0, 0].y + octave,
            cube_vertices_position[0, 0, 0].z);

        cube_vertices_position[1, 0, 1] = new Vector3Int(
            cube_vertices_position[0, 0, 0].x + octave,
            cube_vertices_position[0, 0, 0].y,
            cube_vertices_position[0, 0, 0].z + octave);

        cube_vertices_position[1, 1, 1] = new Vector3Int(
            cube_vertices_position[0, 0, 0].x + octave,
            cube_vertices_position[0, 0, 0].y + octave,
            cube_vertices_position[0, 0, 0].z + octave);


        Vector4 hash_with_seed;
        int position_randomisation_seed;

        double[,,] vertices = new double[2, 2, 2];
        Vector3 dot_in_vec = new Vector3((float)x, (float)y, (float)z);
        double result = 0;
        for (int i = 0; i < 2; i++)
            for (int j = 0; j < 2; j++)
                for (int k = 0; k < 2; k++)
                {
                    hash_with_seed = new Vector4(
                        cube_vertices_position[i, j, k].x.GetHashCode().GetHashCode().GetHashCode(), 
                        cube_vertices_position[i, j, k].y.GetHashCode().GetHashCode(), 
                        cube_vertices_position[i, j, k].z.GetHashCode(), noise_seed);
                    position_randomisation_seed = hash_with_seed.GetHashCode();
                    Random.InitState(position_randomisation_seed);
                    vertices[i, j, k] = Random.Range(0f, 1f);

                }
        double x_in_normalized_cube = x / (cube_vertices_position[1, 0, 0].x - cube_vertices_position[0, 0, 0].x);
        double y_in_normalized_cube = y / (cube_vertices_position[0, 1, 0].y - cube_vertices_position[0, 0, 0].y);
        double z_in_normalized_cube = z / (cube_vertices_position[0, 0, 1].z - cube_vertices_position[0, 0, 0].z);

        result += vertices[0, 0, 0] * (1 - x_in_normalized_cube) * (1 - y_in_normalized_cube) * (1 - z_in_normalized_cube);
        result += vertices[0, 0, 1] * (1 - x_in_normalized_cube) * (1 - y_in_normalized_cube) * z_in_normalized_cube;
        result += vertices[0, 1, 0] * (1 - x_in_normalized_cube) * y_in_normalized_cube * (1 - z_in_normalized_cube);
        result += vertices[0, 1, 1] * (1 - x_in_normalized_cube) * y_in_normalized_cube * z_in_normalized_cube;
        result += vertices[1, 0, 0] * x_in_normalized_cube * (1 - y_in_normalized_cube) * (1 - z_in_normalized_cube);
        result += vertices[1, 0, 1] * x_in_normalized_cube * (1 - y_in_normalized_cube) * z_in_normalized_cube;
        result += vertices[1, 1, 0] * x_in_normalized_cube * y_in_normalized_cube * (1 - z_in_normalized_cube);
        result += vertices[1, 1, 1] * x_in_normalized_cube * y_in_normalized_cube * z_in_normalized_cube;


        return result;
    }
    public static double GetPoint(int noise_seed, int octave, Vector3 xyz) //octave in meters
    {
        return GetPoint(noise_seed, octave, xyz.x, xyz.y, xyz.z);
    }
}
