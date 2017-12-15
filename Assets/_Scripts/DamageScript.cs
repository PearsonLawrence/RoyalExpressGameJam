using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour {

    public string TagName;

    public float DamageAmount;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(TagName))
        {
            other.GetComponent<HealthComponent>().CurrentHealth -= DamageAmount;
        }
    }
}
