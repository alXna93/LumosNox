using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    walk,
    attack,
    stagger,
    idle
}

public class PlayerController : MonoBehaviour {


    public PlayerState currentState;
    public Rigidbody2D theRB;
    public float moveSpeed;
    public Vector3 change;
    public Animator myAnim;
    public FloatValue currentHealth;
    public Signal playerHealthSignal;

    public static PlayerController instance;


    public string areaTransitionName;

    private Vector3 BottomLeftLimit;
    private Vector3 TopRightLimit;

    public bool canMove = true;
    //public bool isAttacking = false;
   

	// Use this for initialization
	void Start () {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
        currentState = PlayerState.walk;
        myAnim.SetFloat("moveX", 0);
        myAnim.SetFloat("moveY", -1);
	}


    // Update is called once per frame
    void Update() {

        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger) 
        {
            StartCoroutine(AttackCo());

        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }

        // Camera following player
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, BottomLeftLimit.x, TopRightLimit.x), Mathf.Clamp(transform.position.y, BottomLeftLimit.y, TopRightLimit.y), transform.position.z);

    }

    private IEnumerator AttackCo()
    {
        myAnim.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        myAnim.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            myAnim.SetFloat("moveX", change.x);
            myAnim.SetFloat("moveY", change.y);
            myAnim.SetBool("moving", true);
        }
        else
        {
            myAnim.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        change.Normalize();
        theRB.MovePosition(transform.position + change * moveSpeed * Time.deltaTime);
    }

    public void Knock(float knockTime, float damage)
    {
        currentHealth.RuntimeValue -= damage;
        playerHealthSignal.Raise();
        if (currentHealth.RuntimeValue > 0)
        {
           
            StartCoroutine(KnockCo(knockTime));
        }
        else
        {
            this.gameObject.SetActive(false);
        }

        
    }

    private IEnumerator KnockCo(float knockTime)
    {
        if (theRB != null)
        {
            yield return new WaitForSeconds(knockTime);
            theRB.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            theRB.velocity = Vector2.zero;
        }
    }




    public void SetBounds(
            Vector3 botLeft, Vector3 topRight) { 

            BottomLeftLimit = botLeft + new Vector3(.5f, 1f, 0f);
            TopRightLimit = topRight + new Vector3(-.5f, -1f, 0f);

        }


}
