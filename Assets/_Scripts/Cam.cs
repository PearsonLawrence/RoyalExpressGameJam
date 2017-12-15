using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {

    public PlayerCharacter p1;

    public float LagSpeed;

    Vector3 Offset;

	// Use this for initialization
	void Start () {
        Offset =   transform.position - p1.transform.position;
        //p1 = GameObject.FindObjectOfType<PlayerCharacter>();
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = Vector3.MoveTowards(transform.position, p1.transform.position + Offset, LagSpeed * Time.deltaTime);

	}
}
