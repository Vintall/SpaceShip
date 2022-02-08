using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structs
{
    public class OrbitEllipse
    {
        #region Gravitational constant G, but it's by division
        //Revert G from double to int . . . 10^(11)/6.67408. U need to divide by this, instead multiply
        readonly public static System.Numerics.BigInteger G = System.Numerics.BigInteger.Parse("14983338528");
        #endregion

        List<OrbitalVector2> points;
        List<OrbitLine> lines;
        (int, double) pos_on_line; // (num of line, pos on line ( 0 ... 1 ))

        public List<OrbitalVector2> Points
        {
            get
            {
                return points;
            }
        }

        public OrbitEllipse()
        {
            points = new List<OrbitalVector2>();
            lines = new List<OrbitLine>();
        }

        public void CalculateOrbit(System.Numerics.BigInteger influence_space_object_mass,
                                   System.Numerics.BigInteger current_space_object_mass,
                                   OrbitalVector2 influence_space_object_pos,
                                   OrbitalVector2 start_pos, 
                                   OrbitalVector2 start_velocity)
        {
            bool while_switcher = true;
            points.Add(start_pos);

            OrbitalVector2 current_point = new OrbitalVector2(start_pos);

            int time_scaler = 1;

            OrbitalVector2 current_vector = new OrbitalVector2(start_velocity.x / time_scaler, start_velocity.y / time_scaler);
            OrbitalVector2 prev_point_vector = current_vector;


            Vector2 influence_space_object_vector;

            System.Numerics.BigInteger current_distance;
            System.Numerics.BigInteger force;
            System.Numerics.BigInteger multi_mass;

            float max_angle = 1;
            int iter_left = 0;
            //1 iteration == 1 second
            while (points.Count < 360 && iter_left < 100000)  
            {
                iter_left++;
                float fuck_it = OrbitalVector2.VectorAngle(current_vector, prev_point_vector);
                if (OrbitalVector2.VectorAngle(current_vector, prev_point_vector) >= max_angle)
                {
                    prev_point_vector = current_vector;
                    points.Add(current_point);
                }

                influence_space_object_vector = (influence_space_object_pos - current_point).normalized;

                current_distance = OrbitalVector2.Distance(current_point, influence_space_object_pos);

                multi_mass = influence_space_object_mass * current_space_object_mass;
                force = multi_mass / (G * current_distance * current_distance);

                force /= time_scaler;

                System.Numerics.BigInteger new_veloc = OrbitalVector2.Sqrt(force * current_distance / current_space_object_mass);
                OrbitalVector2 new_vec = new OrbitalVector2((new System.Numerics.BigInteger(int.Parse(new_veloc.ToString()) * influence_space_object_vector.x)),
                                                            (new System.Numerics.BigInteger(int.Parse(new_veloc.ToString()) * influence_space_object_vector.y)));

                current_vector += new OrbitalVector2(new_vec.x, new_vec.y);



                current_point = current_point + current_vector;
            }
            Debug.Log("Iterations used: " + iter_left);
        }
    }
    public class OrbitalVector2
    {
        public System.Numerics.BigInteger x;
        public System.Numerics.BigInteger y;

        /// <summary>
        /// result = Pow(x)+Pow(y)    without SQRT
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static System.Numerics.BigInteger SqrtDistance(OrbitalVector2 a, OrbitalVector2 b)
        {
            return System.Numerics.BigInteger.Pow(a.x - b.x, 2) + System.Numerics.BigInteger.Pow(a.y - b.y, 2);
        }
        public static System.Numerics.BigInteger Distance(OrbitalVector2 a, OrbitalVector2 b)
        {
            return Sqrt(System.Numerics.BigInteger.Pow(a.x - b.x, 2) + System.Numerics.BigInteger.Pow(a.y - b.y, 2));
        }
        public static System.Numerics.BigInteger Sqrt(System.Numerics.BigInteger n)
        {
            if (n == 0) return 0;
            if (n > 0)
            {
                int bitLength = Convert.ToInt32(Math.Ceiling(System.Numerics.BigInteger.Log(n, 2)));
                System.Numerics.BigInteger root = System.Numerics.BigInteger.One << (bitLength / 2);

                while (!isSqrt(n, root))
                {
                    root += n / root;
                    root /= 2;
                }

                return root;
            }

            throw new ArithmeticException("NaN");
        }
        public Vector2 normalized
        {
            get
            {
                return new Vector2(((float)(x * 10000 / magnitude)) / 10000, ((float)(y * 10000 / magnitude)) / 10000);
            }
        }
        public System.Numerics.BigInteger magnitude
        {
            get
            {
                return Sqrt(System.Numerics.BigInteger.Pow(x, 2) + System.Numerics.BigInteger.Pow(y, 2));
            }
        }
        private static Boolean isSqrt(System.Numerics.BigInteger n, System.Numerics.BigInteger root)
        {
            System.Numerics.BigInteger lowerBound = root * root;
            System.Numerics.BigInteger upperBound = (root + 1) * (root + 1);

            return (n >= lowerBound && n < upperBound);
        }


        public static OrbitalVector2 operator *(System.Numerics.BigInteger multiplier, OrbitalVector2 vec)
        { 
            return new OrbitalVector2(vec.x * multiplier, vec.y * multiplier); 
        }
        public static OrbitalVector2 operator *(OrbitalVector2 vec, System.Numerics.BigInteger multiplier)
        { 
            return new OrbitalVector2(vec.x * multiplier, vec.y * multiplier);
        }
        public static OrbitalVector2 operator +(OrbitalVector2 vec1, OrbitalVector2 vec2)
        {
            return new OrbitalVector2(vec1.x + vec2.x, vec1.y + vec2.y);
        }
        public static OrbitalVector2 operator -(OrbitalVector2 vec1, OrbitalVector2 vec2)
        {
            return new OrbitalVector2(vec1.x - vec2.x, vec1.y - vec2.y);
        }
        public static float VectorAngle(OrbitalVector2 vec1, OrbitalVector2 vec2)
        {
            if (vec1.magnitude * vec2.magnitude == 0)
                return 0;

            float angle = Mathf.Acos(float.Parse(((vec1.x * vec2.x + vec1.y * vec2.y) * 10000 / (vec1.magnitude * vec2.magnitude)).ToString()) / 10000);
            return angle * Mathf.Rad2Deg;
        }
        public OrbitalVector2(string x, string y)
        {
            this.x = System.Numerics.BigInteger.Parse(x);
            this.y = System.Numerics.BigInteger.Parse(y);
        }
        public OrbitalVector2(Vector2 temp)
        {
            this.x = new System.Numerics.BigInteger(temp.x);
            this.y = new System.Numerics.BigInteger(temp.y);
        }
        public OrbitalVector2(OrbitalVector2 temp)
        {
            x = temp.x;
            y = temp.y;
        }
        public OrbitalVector2(System.Numerics.BigInteger x, System.Numerics.BigInteger y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public class OrbitLine
    {
        int point_a_index;
        int point_b_index;
        OrbitalVector2 speed;

        public OrbitLine()
        {
            
        }
    }
}
