using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuCam : MonoBehaviour {

   
    public GameObject Point1, Point2, Point3, Point4;
    public GameObject MovePoint1, MovePoint2, MovePoint3, MovePoint4;
    public float PanSpeed;

    public int Num;
    public void DoOne()
    {
        transform.position = Vector3.MoveTowards(transform.position, MovePoint1.transform.position, PanSpeed * Time.deltaTime);
    }
    public void DoTwo()
    {

        transform.position = Vector3.MoveTowards(transform.position, MovePoint2.transform.position, PanSpeed * Time.deltaTime);
    }
    public void DoThree()
    {

        transform.position = Vector3.MoveTowards(transform.position, MovePoint3.transform.position, PanSpeed * Time.deltaTime);
    }
    public void DoFour()
    {

        transform.position = Vector3.MoveTowards(transform.position, MovePoint4.transform.position, PanSpeed * Time.deltaTime);
    }


    public bool move;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (move)
        {
            switch (Num)
            {
                case 0:
                    DoOne();
                    break;
                case 1:
                    DoTwo();
                    break;
                case 2:
                    DoThree();
                    break;
                case 3:
                    DoFour();
                    break;
            }
        }

    }
}
