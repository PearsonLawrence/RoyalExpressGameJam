using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDetectionRadius : MonoBehaviour {

    public AICharacter Self;

	// Use this for initialization
	void Start () {
        //Self = GetComponent<AICharacter>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Self.Player = other.GetComponent<PlayerCharacter>();
            Self.SeePlayer = true;
        }
    }
}
