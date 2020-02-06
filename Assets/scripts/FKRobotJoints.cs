using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FKRobotJoints : MonoBehaviour 
{
    public Transform[] Joints;
    public Transform endEffector;

    public Slider S_Slider;    //PositionX min=4 max=12
    public Slider L_Slider;    //PositionY min=-4 max=4
    public Slider U_Slider;    //PositionZ min=4 max=12

    public static double[] theta = new double[3];

    private float a2, a3;

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
        theta[0] = S_Slider.value;
        theta[1] = L_Slider.value;
        theta[2] = U_Slider.value;

        if (!double.IsNaN(theta[0]))
            Joints[0].transform.localEulerAngles = new Vector3(0, (float)theta[0], 0);
        if (!double.IsNaN(theta[2]))
            Joints[2].transform.localEulerAngles = new Vector3((float)theta[2], 0, 0);
        if (!double.IsNaN(theta[1]))
            Joints[1].transform.localEulerAngles = new Vector3((float)theta[1], 0, 0);

        Debug.Log("END EFFECTOR POSITION = " + endEffector.transform.position);
    }
}
