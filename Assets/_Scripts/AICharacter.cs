using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICharacter : MonoBehaviour {
    
    public enum States
    {
        MoveState,
        AttackState,
        RangedAttackState,
        IdleState

    }

    public States CurrentState;

    public float moveSpeed;
    public float Acceleration;
    public Rigidbody RB;
    public NavMeshAgent Agent;
    


    public Animator anim;

    float Horizontal, Verticle;

    bool LeftClick, RightClick;
    
    void DoIdle()
    {
        //RB.velocity = new Vector3(Horizontal * moveSpeed, RB.velocity.y, Verticle * moveSpeed);

    }

    public PlayerCharacter Player;

    Transform MouseTransform;
    Vector3 MousePos;

    void DoLook()
    {
       

    }

    void DoMove()
    {
        Agent.isStopped = false;
    }

    public float MaxAttackTime;
    float AttackTime;

    void DoAttack()
    {
        Agent.isStopped = true;
    }
    void DoRangedAttack()
    {

    }

    public HealthComponent HP;
    // Use this for initialization
    void Start()
    {
        HP = GetComponent<HealthComponent>();
        anim = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
        Agent.acceleration = Acceleration;
        Agent.speed = moveSpeed;

        RB = GetComponent<Rigidbody>();
        CurrentState = States.IdleState;
        AttackTime = MaxAttackTime;
    }

    void updateAnim()
    {
        var localVel = transform.InverseTransformDirection(Agent.velocity);

        anim.SetFloat("ForwardSpeed", localVel.z);
        anim.SetFloat("RightSpeed", localVel.x);
      
    }

    public GameObject HitBox;

    public void DamageEvent()
    {
        HitBox.SetActive(true);
    }
    public void EndDamage()
    {
        HitBox.SetActive(false);
    }

    public void EndAttack()
    {
        CurrentState = States.IdleState;
    }

    public bool SeePlayer = false;

    public float StoppingDistance = 3;

    public void UpdateWatchPlayer()
    {
        if(SeePlayer)
        {

            if(Agent.remainingDistance <= StoppingDistance && CurrentState != States.AttackState)
            {
                anim.SetTrigger("MeleeAttack");
                anim.SetInteger("AttackNum", Random.Range(0, 2));

                CurrentState = States.AttackState;
            }
            else if(Agent.remainingDistance > StoppingDistance && CurrentState != States.AttackState)
            {
                CurrentState = States.MoveState;
                Agent.isStopped = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!HP.isDead)
        {
            if(Player !=null)
                Agent.destination = Player.transform.position;

            switch (CurrentState)
            {
                case States.IdleState:
                    DoIdle();
                    break;
                case States.MoveState:
                    DoMove();
                    break;
                case States.RangedAttackState:
                    DoRangedAttack();
                    break;
                case States.AttackState:
                    DoAttack();
                    break;

            }
            UpdateWatchPlayer();
            updateAnim();
        }
        else
        {
            Agent.isStopped = true;
        }
    }
}
