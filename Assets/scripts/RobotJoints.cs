using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotJoints : MonoBehaviour 
{
    public Transform[] Joints;
    public Transform endEffector;

    public Slider S_Slider;    //PositionX min=4 max=12
    public Slider L_Slider;    //PositionY min=-4 max=4
    public Slider U_Slider;    //PositionZ min=4 max=12

    public static double[] theta = new double[3];

    private float a2, a3;
    private float D;

    public float px, py, pz;

    void Start()
    {
        theta[0] = theta[1] = theta[2] = 0.0;
        a2 = 4.0f;
        a3 = 4.0f;

        px = 7f; py = 0f; pz = 7f;
    }

    void Update()
    {    
        pz = S_Slider.value;
        py = L_Slider.value;
        px = U_Slider.value;

        px = px + 0.01f;

        D = Mathf.Pow(px, 2) + Mathf.Pow(py, 2) + Mathf.Pow(pz, 2) - (Mathf.Pow(a2, 2) + Mathf.Pow(a3, 2));

        theta[0] = Mathf.Atan2(pz, px);

        theta[2] = Mathf.Acos(D/(2*a2*a3));

        theta[1] = Mathf.Atan2(py, Mathf.Sqrt(Mathf.Pow(px, 2) + Mathf.Pow(pz, 2))) - Mathf.Atan2(a3*Mathf.Sin((float)theta[2]), a2+a3*Mathf.Cos((float)theta[2]));

        if (!double.IsNaN(theta[0]))
            Joints[0].transform.localEulerAngles = new Vector3(0, (float)theta[0] * Mathf.Rad2Deg + 180, 0);
        if (!double.IsNaN(theta[2]))
            Joints[2].transform.localEulerAngles = new Vector3((float)theta[2] * Mathf.Rad2Deg, 0, 0);
        if (!double.IsNaN(theta[1]))
            Joints[1].transform.localEulerAngles = new Vector3((float)theta[1] * Mathf.Rad2Deg - 90, 0, 0);

        Debug.Log("END EFFECTOR POSITION = " + endEffector.transform.position);
    }
}

