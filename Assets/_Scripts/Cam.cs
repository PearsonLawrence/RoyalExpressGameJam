using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {

    public PlayerCharacter p1;
    public GameObject StartPoint;
    public float LagSpeed;

    Vector3 Offset;

	// Use this for initialization
	void Start () {
        Offset =   transform.position - p1.transform.position;
        transform.position = StartPoint.transform.position;
        //p1 = GameObject.FindObjectOfType<PlayerCharacter>();
	}
    public float smoothDamp;
    float CurrentXPos;
    float CurrentZPos;
    float XposV, ZposV;
    public bool start;
	// Update is called once per frame
	void LateUpdate () {
        if (start)
        {
            transform.position = StartPoint.transform.position; ;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, p1.transform.position + Offset, Time.deltaTime * LagSpeed);

            //CurrentXPos = Mathf.SmoothDamp(CurrentXPos, transform.position.x, ref XposV, smoothDamp);
            //CurrentZPos = Mathf.SmoothDamp(CurrentZPos, transform.position.z, ref ZposV, smoothDamp);

            //Vector3 newDamp = new Vector3(CurrentXPos, transform.position.y, CurrentZPos);
            //transform.position = newDamp;
        }

    }
}
