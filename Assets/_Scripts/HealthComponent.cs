using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour {

    public float CurrentHealth;
    public float MaxHealth;

    public ParticleSystem DamagePS;
    public ParticleSystem Heal;
	// Use this for initialization
	void Start () {
        CurrentHealth = MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {

	    if(CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
	}
}
