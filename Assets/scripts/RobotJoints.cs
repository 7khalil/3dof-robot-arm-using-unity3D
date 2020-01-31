using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotJoints : MonoBehaviour {
	
    public float speed = 5.0f;

    private float pivot0Slider = 0.0f;
    private float pivot1Slider = 0.0f;
    private float pivot2Slider = 0.0f;
    
    public GameObject pivot1, pivot2;


     void OnGUI()
    {
        pivot0Slider = GUI.HorizontalSlider(new Rect (25, 25, 100, 30), pivot0Slider, -5.0f, 5.0f);
        pivot1Slider = GUI.HorizontalSlider(new Rect (25, 50, 100, 30), pivot1Slider, -5.0f, 5.0f);
        pivot2Slider = GUI.HorizontalSlider(new Rect (25, 75, 100, 30), pivot2Slider, -5.0f, 5.0f);
    }

    void Update () {

        transform.Rotate(0, pivot0Slider*speed*Time.deltaTime, 0);
        pivot1.transform.Rotate(pivot1Slider*speed*Time.deltaTime, 0, 0);
        pivot2.transform.Rotate(pivot2Slider*speed*Time.deltaTime, 0, 0);

        if (Input.GetMouseButtonUp(0)){
                pivot0Slider = 0;
                pivot1Slider = 0;
                pivot2Slider = 0;
        }
    }
}
