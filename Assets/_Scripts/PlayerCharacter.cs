using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

    public enum States
    {
        MoveState,
        AttackState,
        RangedAttackState,
        IdleState

    }

    public HealthComponent HP;

    public States CurrentState;

    public float moveSpeed;
    public Rigidbody RB;
    public Camera cam;

    public Animator anim;

    float Horizontal, Verticle;

    bool LeftClick, RightClick;

    public void UpdateKeyInput()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Verticle = Input.GetAxisRaw("Vertical");

        LeftClick = Input.GetMouseButton(0);
        RightClick = Input.GetMouseButton(1);

        if((Horizontal != 0 || Verticle != 0) && (!LeftClick) && CurrentState == States.IdleState)
        {
            CurrentState = States.MoveState;
        }
        else if(LeftClick && CurrentState != States.AttackState)
        {
            anim.SetTrigger("MeleeAttack");
            anim.SetInteger("AttackNum", Random.Range(0, 2));
            CurrentState = States.AttackState;
        }
        else if(RightClick && CurrentState != States.AttackState)
        {
            CurrentState = States.AttackState;
        }


    }


    void DoIdle()
    {
        //RB.velocity = new Vector3(Horizontal * moveSpeed, RB.velocity.y, Verticle * moveSpeed);

    }

    Transform MouseTransform;
    Vector3 MousePos;

    void DoLook()
    {
        RaycastHit hit;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        LayerMask World = 1 << LayerMask.NameToLayer("Default");

        if (Physics.Raycast(ray, out hit, 100000, World))
        {
            //transform.LookAt(hit.point);

            Vector3 forward = (transform.position - hit.point) * -1;
            
            transform.forward = Vector3.MoveTowards(transform.forward, forward.normalized, Time.deltaTime * 15);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y,0);
        }

    }

    void DoMove()
    {
       
        
        RB.velocity = new Vector3(Horizontal * moveSpeed, RB.velocity.y, Verticle * moveSpeed);
        
    }

    public float MaxAttackTime;
    float AttackTime;

    void DoAttack()
    {
        RB.velocity = new Vector3(0, RB.velocity.y, 0);
    }
    void DoRangedAttack()
    {

    }


    // Use this for initialization
    void Start () {
        RB = GetComponent<Rigidbody>();
        CurrentState = States.IdleState;
        AttackTime = MaxAttackTime;
        HP = GetComponent<HealthComponent>();
    }
	
    void updateAnim()
    {
        var localVel = transform.InverseTransformDirection(RB.velocity);

        anim.SetFloat("ForwardSpeed", localVel.z);
        anim.SetFloat("RightSpeed", localVel.x);
        anim = GetComponent<Animator>();
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

    // Update is called once per frame
    void Update () {
        if (!HP.isDead)
        {
            UpdateKeyInput();

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

            DoLook();
            updateAnim();
        }
        else
        {

        }
    }
}
