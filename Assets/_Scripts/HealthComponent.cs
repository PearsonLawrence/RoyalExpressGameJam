using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour {

    public float CurrentHealth;
    public float MaxHealth;

    public Animator anim;

    public ParticleSystem DamagePS;
    public ParticleSystem Heal;
    public ParticleSystem DeathPS;
    // Use this for initialization
    void Start () {
        CurrentHealth = MaxHealth;
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

	    if(CurrentHealth <= 0 && isDead == false)
        {
           
            Die();
        }
	}

    public bool isDead;

    public void Die()
    {
        ParticleSystem PS = Instantiate(DeathPS, transform.position + new Vector3(0,.5f,0), DeathPS.transform.rotation);

        Destroy(PS, 1);
        if (anim != null)
        { 
            anim.SetInteger("DieNum", Random.Range(0, 2));
             anim.SetTrigger("Die");
        }
        else
        {
            Destroy(gameObject);
        }
        isDead = true;
    }

    public void TakeDamage(float Dmg)
    {
        DamagePS.Play() ;
        CurrentHealth -= Dmg;
    }
}
