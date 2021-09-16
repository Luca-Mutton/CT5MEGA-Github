using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVector2
{
    public float x;
    public float y;

    public MyVector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    //adds 2 vectors together
    public static MyVector2 VectorAdd(MyVector2 A, MyVector2 B)
    {
        MyVector2 rv = new MyVector2(0, 0);

        rv.x = A.x + B.x;
        rv.y = A.y + B.y;

        return rv;
    }

    public static MyVector2 operator +(MyVector2 lhs, MyVector2 rhs)
    {
        return VectorAdd(lhs, rhs);
    }

    //subtracts 2 vectors together
    public static MyVector2 VectorSubtract(MyVector2 A, MyVector2 B)
    {
        MyVector2 rv = new MyVector2(0, 0);

        rv.x = A.x - B.x;
        rv.y = A.y - B.y;

        return rv;
    }
    public static MyVector2 operator -(MyVector2 lhs, MyVector2 rhs)
    {
        return VectorSubtract(lhs, rhs);
    }

    //finds the length of a vector
    public static float VectorLength(MyVector2 A)
    {
        float rv;

        rv = Mathf.Sqrt(A.x * A.x + A.y * A.y);

        return rv;
    }

    public static float LengthSq(Vector3 A)
    {
        float rv;
        rv = A.x * A.x + A.y * A.y + A.z * A.z;
        return rv;
    }

    public static float Length(Vector3 A)
    {
        float rv;

        rv = Mathf.Sqrt(A.x * A.x + A.y * A.y + A.z * A.z);

        return rv;
    }

    public static Vector3 MultiplyVector(Vector3 Vec1, float scalar)
    {
        Vector3 rv = new Vector3(0, 0);

        //SCALE THE VECTOR
        rv.x = Vec1.x * scalar;
        rv.y = Vec1.y * scalar;

        return Vector3.zero;
    }

    public static Vector3 DivideVector(Vector3 Vec1, float divisor)
    {
        Vector3 rv = new Vector3(0, 0);

        //DIVIDE THER VECTOR
        rv.x = Vec1.x / divisor;
        rv.y = Vec1.y / divisor;

        return Vector3.zero;
    }

    //normalizes vectors
    public static Vector3 VectorNormalized(Vector3 A)
    {
        Vector3 rv = new Vector3(0, 0);
        rv.x = A.x;
        rv.y = A.y;
        rv.z = A.z;

        rv = rv / Length(rv);

        return rv;
    }

    //vector dot product
    public static float DotProduct(Vector3 Vec1, Vector3 Vec2, bool ShouldNormalize = true)
    {
        float rv;

        Vector3 A = new Vector3(Vec1.x, Vec1.y);
        Vector3 B = new Vector3(Vec1.x, Vec2.y);

        if (ShouldNormalize)
        {
            A = VectorNormalized(A);
            B = VectorNormalized(B);
        }

        rv = A.x * B.x + A.y * B.y;

        return rv;
    }

    //converts 2d vector to radians
    public static float VectorToRadians(Vector2 V)
    {
        float rv = 0.0f;
        rv = Mathf.Atan(V.y / V.x);
        rv = Mathf.Atan2(V.y, V.x);

        return rv;
    }

    //converts radian angles to 2d vector
    public static Vector2 RadiansToVector(float angle)
    {
        Vector2 rv = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        rv.x = Mathf.Cos(angle);
        rv.y = Mathf.Sin(angle);

        return rv;
    }

    //vector cross product
    public static Vector3 VectorCrossProduct(Vector3 A, Vector3 B)
    {
        Vector3 C = new Vector3();

        C.x = A.y * B.z - A.z * B.y;
        C.y = A.z * B.x - A.x * B.z;
        C.z = A.x * B.y - A.y * B.x;

        return C;
    }

    //converts euler angles to 3D Directional vector
    public static Vector3 EulerAnglesToDirection(Vector3 EulerAngles)
    {
        Vector3 rv = new Vector3();
        EulerAngles = EulerAngles * Mathf.PI / 180;

        rv.z = Mathf.Cos(EulerAngles.y) * Mathf.Cos(EulerAngles.x); //rv.z = Mathf.Cos(EulerAngles.y) * Mathf.Cos(EulerAngles.x);
        rv.y = Mathf.Sin(EulerAngles.x);
        rv.x = Mathf.Cos(EulerAngles.x) * Mathf.Sin(EulerAngles.y); //rv.x = Mathf.Cos(EulerAngles.x) * Mathf.Sin(EulerAngles.y);
        return rv;
    }

    public static Vector3 VecLerp(Vector3 A, Vector3 B, float t)
    {
        return A * (1.0f - t) + B * t;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Matrix4by4
{
    public float[,] values;

    //makes one column for 4x4 matrix
    public Matrix4by4(Vector4 column1, Vector4 column2, Vector4 column3, Vector4 column4)
    {
        values = new float[4, 4];

        //column1
        values[0, 0] = column1.x;
        values[1, 0] = column1.y;
        values[2, 0] = column1.z;
        values[3, 0] = column1.w;

        //column2
        values[0, 1] = column2.x;
        values[1, 1] = column2.y;
        values[2, 1] = column2.z;
        values[3, 1] = column2.w;

        //column3
        values[0, 2] = column3.x;
        values[1, 2] = column3.y;
        values[2, 2] = column3.z;
        values[3, 2] = column3.w;

        //column4
        values[0, 3] = column4.x;
        values[1, 3] = column4.y;
        values[2, 3] = column4.z;
        values[3, 3] = column4.w;
    }

    //makes one column for 4x4 matrix
    public Matrix4by4(Vector3 column1, Vector3 column2, Vector3 column3, Vector3 column4)
    {
        values = new float[4, 4];

        //column1
        values[0, 0] = column1.x;
        values[1, 0] = column1.y;
        values[2, 0] = column1.z;
        values[3, 0] = 0;

        //column2
        values[0, 1] = column2.x;
        values[1, 1] = column2.y;
        values[2, 1] = column2.z;
        values[3, 1] = 0;

        //column3
        values[0, 2] = column3.x;
        values[1, 2] = column3.y;
        values[2, 2] = column3.z;
        values[3, 2] = 0;

        //column4
        values[0, 3] = column4.x;
        values[1, 3] = column4.y;
        values[2, 3] = column4.z;
        values[3, 3] = 1;
    }

    public static Matrix4by4 Identity
    {
        get
        {
            return new Matrix4by4(
                new Vector4(1, 0, 0, 0),
                new Vector4(0, 1, 0, 0),
                new Vector4(0, 0, 1, 0),
                new Vector4(0, 0, 0, 1));
        }
    }
    
    //matrix multiplication for two 4x4 matrices
    public static Matrix4by4 operator *(Matrix4by4 lhs, Matrix4by4 rhs)
    {
        
        // lhs = matrix 1
        // rhs = matrix 2
        Matrix4by4 rv = Identity;
        //lhs row 1 x rhs columns
        rv.values[0, 0] = lhs.values[0, 0] * rhs.values[0, 0] + lhs.values[0, 1] * rhs.values[1, 0] + lhs.values[0, 2] * rhs.values[2, 0] + lhs.values[0, 3] * rhs.values[3, 0]; // lhs row 1 into rhs column1
        rv.values[0, 1] = lhs.values[0, 0] * rhs.values[0, 1] + lhs.values[0, 1] * rhs.values[1, 1] + lhs.values[0, 2] * rhs.values[2, 1] + lhs.values[0, 3] * rhs.values[3, 1]; // lhs row 1 into rhs column2
        rv.values[0, 2] = lhs.values[0, 0] * rhs.values[0, 2] + lhs.values[0, 1] * rhs.values[1, 2] + lhs.values[0, 2] * rhs.values[2, 2] + lhs.values[0, 3] * rhs.values[3, 2]; // lhs row 1 into rhs column3
        rv.values[0, 3] = lhs.values[0, 0] * rhs.values[0, 3] + lhs.values[0, 1] * rhs.values[1, 3] + lhs.values[0, 2] * rhs.values[2, 3] + lhs.values[0, 3] * rhs.values[3, 3]; // lhs row 1 into rhs column4

        //lhs row 2 x rhs columns
        rv.values[1, 0] = lhs.values[1, 0] * rhs.values[0, 0] + lhs.values[1, 1] * rhs.values[1, 0] + lhs.values[1, 2] * rhs.values[2, 0] + lhs.values[1, 3] * rhs.values[3, 0]; // lhs row 2 into rhs column1
        rv.values[1, 1] = lhs.values[1, 0] * rhs.values[0, 1] + lhs.values[1, 1] * rhs.values[1, 1] + lhs.values[1, 2] * rhs.values[2, 1] + lhs.values[1, 3] * rhs.values[3, 1]; // lhs row 2 into rhs column2
        rv.values[1, 2] = lhs.values[1, 0] * rhs.values[0, 2] + lhs.values[1, 1] * rhs.values[1, 2] + lhs.values[1, 2] * rhs.values[2, 2] + lhs.values[1, 3] * rhs.values[3, 2]; // lhs row 2 into rhs column3
        rv.values[1, 3] = lhs.values[1, 0] * rhs.values[0, 3] + lhs.values[1, 1] * rhs.values[1, 3] + lhs.values[1, 2] * rhs.values[2, 3] + lhs.values[1, 3] * rhs.values[3, 3]; // lhs row 2 into rhs column4

        //lhs row 3 x rhs columns
        rv.values[2, 0] = lhs.values[2, 0] * rhs.values[0, 0] + lhs.values[2, 1] * rhs.values[1, 0] + lhs.values[2, 2] * rhs.values[2, 0] + lhs.values[2, 3] * rhs.values[3, 0]; // lhs row 3 into rhs column1
        rv.values[2, 1] = lhs.values[2, 0] * rhs.values[0, 1] + lhs.values[2, 1] * rhs.values[1, 1] + lhs.values[2, 2] * rhs.values[2, 1] + lhs.values[2, 3] * rhs.values[3, 1]; // lhs row 3 into rhs column2
        rv.values[2, 2] = lhs.values[2, 0] * rhs.values[0, 2] + lhs.values[2, 1] * rhs.values[1, 2] + lhs.values[2, 2] * rhs.values[2, 2] + lhs.values[2, 3] * rhs.values[3, 2]; // lhs row 3 into rhs column3
        rv.values[2, 3] = lhs.values[2, 0] * rhs.values[0, 3] + lhs.values[2, 1] * rhs.values[1, 3] + lhs.values[2, 2] * rhs.values[2, 3] + lhs.values[2, 3] * rhs.values[3, 3]; // lhs row 3 into rhs column4

        //lhs row 4 x rhs columns
        rv.values[3, 0] = lhs.values[3, 0] * rhs.values[0, 0] + lhs.values[3, 1] * rhs.values[1, 0] + lhs.values[3, 2] * rhs.values[2, 0] + lhs.values[3, 3] * rhs.values[3, 0]; // lhs row 4 into rhs column1
        rv.values[3, 1] = lhs.values[3, 0] * rhs.values[0, 1] + lhs.values[3, 1] * rhs.values[1, 1] + lhs.values[3, 2] * rhs.values[2, 1] + lhs.values[3, 3] * rhs.values[3, 1]; // lhs row 4 into rhs column2
        rv.values[3, 2] = lhs.values[3, 0] * rhs.values[0, 2] + lhs.values[3, 1] * rhs.values[1, 2] + lhs.values[3, 2] * rhs.values[2, 2] + lhs.values[3, 3] * rhs.values[3, 2]; // lhs row 4 into rhs column3
        rv.values[3, 3] = lhs.values[3, 0] * rhs.values[0, 3] + lhs.values[3, 1] * rhs.values[1, 3] + lhs.values[3, 2] * rhs.values[2, 3] + lhs.values[3, 3] * rhs.values[3, 3]; // lhs row 4 into rhs column4
        return rv;
    }

    //multiplies a 4x4 matrix and a 4x1 matrix together
    public static Vector4 operator *(Matrix4by4 lhs, Vector4 vector)
    {
        vector.w = 1;
        Vector4 rv = new Vector4();

        rv.x = lhs.values[0, 0] * vector.x + lhs.values[0, 1] * vector.y + lhs.values[0, 2] * vector.z + lhs.values[0, 3] * vector.w;
        rv.y = lhs.values[1, 0] * vector.x + lhs.values[1, 1] * vector.y + lhs.values[1, 2] * vector.z + lhs.values[1, 3] * vector.w;
        rv.z = lhs.values[2, 0] * vector.x + lhs.values[2, 1] * vector.y + lhs.values[2, 2] * vector.z + lhs.values[2, 3] * vector.w;
        rv.w = lhs.values[3, 0] * vector.x + lhs.values[3, 1] * vector.y + lhs.values[3, 2] * vector.z + lhs.values[3, 3] * vector.w;
        return rv;
    }
}

//Quaternion
public class Quat
{

    public float w, x, y, z;

    public Quat(float Angle, Vector3 Axis)
    {
        float halfAngle = Angle / 2;
        w = Mathf.Cos(halfAngle);
        x = Axis.x * Mathf.Sin(halfAngle);
        y = Axis.y * Mathf.Sin(halfAngle);
        z = Axis.z * Mathf.Sin(halfAngle);
    }

    public Quat(Vector3 Vector)
    {
        SetAxis(Vector);
    }

    public Quat()
    {

    }

    //multiplies two quaternions together
    public static Quat operator *(Quat lhs, Quat rhs)
    {
        float w = rhs.w * lhs.w - MyVector2.DotProduct(rhs.GetAxis(), lhs.GetAxis());
        Vector3 v = lhs.GetAxis() * rhs.w + rhs.GetAxis() * lhs.w + MyVector2.VectorCrossProduct(lhs.GetAxis(), rhs.GetAxis());

        Quat result = new Quat();
        result.w = w;
        result.SetAxis(v);

        return result;
    }

    //get axises from the engine 
    public Vector3 GetAxis()
    {
        Vector3 rv = new Vector3(x, y, z);

        return rv;
    }

    //set axises for the vectors
    public void SetAxis(Vector3 Vec)
    {
        x = Vec.x;
        y = Vec.y;
        z = Vec.z;
    }

    public Quat Inverse()
    {
        Quat rv = new Quat();
        rv.w = w;

        rv.SetAxis(-GetAxis());

        return rv;
    }

    public Vector4 GetAxisAngle()
{
    Vector4 value = new Vector4();

    //Inverse cosine to get our half angle back
    float halfAngle = Mathf.Acos(w);
    value.w = halfAngle * 2; //This is our full angle

   // simple calculations to get our normal axis back using the half-angle
    value.x = x / Mathf.Sin(halfAngle);
    value.y = y / Mathf.Sin(halfAngle);
    value.z = z / Mathf.Sin(halfAngle);

    return value;
}

    //SLERP method
    public static Quat SLERP(Quat q, Quat r, float t)
    {
    t = Mathf.Clamp(t, 0.0f, 1.0f);

    Quat d = r * q.Inverse();
    Vector4 AxisAngle = d.GetAxisAngle();
    Quat dT = new Quat(AxisAngle.w * t, new Vector3(AxisAngle.x, AxisAngle.y, AxisAngle.z));

    return dT * q;
    }

    //converts Quaternion to Rotation Matrix
    public Matrix4by4 QuatToRotMatrix()
    {
        Matrix4by4 Matrix = Matrix4by4.Identity;

        float xx = x * x;
        float xy = x * y;
        float xz = x * z;
        float xw = x * w;

        float yy = y * y;
        float yz = y * z;
        float yw = y * w;

        float zz = z * z;
        float zw = z * w;

        Matrix.values[0, 0] = 1 - 2 * (yy + zz);
        Matrix.values[0, 1] = 2 * (xy - zw);
        Matrix.values[0, 2] = 2 * (xz + yw);

        Matrix.values[1, 0] = 2 * (xy + zw);
        Matrix.values[1, 1] = 1 - 2 * (xx + zz);
        Matrix.values[1, 2] = 2 * (yz - xw);

        Matrix.values[2, 0] = 2 * (xz - yw);
        Matrix.values[2, 1] = 2 * (xw + yz);
        Matrix.values[2, 2] = 1 - 2 * (xx + yy);

        Matrix.values[0, 3] = Matrix.values[1, 3] = Matrix.values[2, 3] = Matrix.values[3, 0] = Matrix.values[3, 1] = Matrix.values[3, 2] = 0;
        Matrix.values[3, 3] = 1;

        return Matrix;
    }

}

//Geometry and Collision detection
public class BoundingCircle
{
    public Vector3 CentrePoint;
    public float Radius;

    public BoundingCircle(Vector3 CentrePoint, float Radius)
    {
        this.CentrePoint = CentrePoint;
        this.Radius = Radius;
    }

    public bool Intersects(BoundingCircle otherCircle)
    {
        //Create a vector representing the direction and length to the other circle
        Vector3 VectorToOther = otherCircle.CentrePoint - CentrePoint;

        //Calculate our combined radii squared
        float CombinedRadiusSq = (otherCircle.Radius + Radius);
        CombinedRadiusSq *= CombinedRadiusSq;

        //return the boolean statement below, if true they intersect!
        return MyVector2.LengthSq(VectorToOther) <= CombinedRadiusSq;
    }

    //A is the segment start,
    //B is the segment end;
    //C is the other point
    public static float SqDistanceFromPointToSegment(Vector3 A, Vector3 B, Vector3 C)
    {
        float value = MyVector2.LengthSq(C - A) - MyVector2.DotProduct(C - A, B - A) * MyVector2.DotProduct(C - A, B - A) / MyVector2.LengthSq(B - A);

        return value;
    }
}

public class BoundingCapsule
{
    public Vector3 A; //start point
    public Vector3 B; //end point
    public float Radius;


    public BoundingCapsule(Vector3 A, Vector3 B, float Radius)
    {
        this.A = A;
        this.B = B;
        this.Radius = Radius;
    }

    public bool Intersects(BoundingCircle otherCircle)
    {
        //Square the sum of both radii
        float CombinedRadiusSq = (Radius + otherCircle.Radius) * (Radius + otherCircle.Radius);

        //check if the square distance is smaller than the return result
        // true = objects are intersecting
        // false = not intersecting
        return BoundingCircle.SqDistanceFromPointToSegment(A, B, otherCircle.CentrePoint) <= CombinedRadiusSq;
    }
}

