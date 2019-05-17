using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D theRB;
    public float moveSpeed;

    public Animator myAnim;

    public static PlayerController instance;

    public string areaTransitionName;

    private Vector3 BottomLeftLimit;
    private Vector3 TopRightLimit;

    public bool canMove = true;
    public bool isAttacking = false;
   


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
		
	}
	
      
	// Update is called once per frame
	void Update () {
        // Set moving velocity
        if (canMove)
        {
            theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
           
        }
        else
        {
            theRB.velocity = Vector2.zero;
        }

        myAnim.SetFloat("moveX", theRB.velocity.x);
        myAnim.SetFloat("moveY", theRB.velocity.y);

        // Moving animation
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            if (canMove)
            {
                myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
                myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
            }
        }

        // Attacking animation
        if (Input.GetButtonDown("attack") && isAttacking != true)
        {
            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                myAnim.SetTrigger("AttackingRight");
            }
            else if(Input.GetAxisRaw("Horizontal") == -1)
            {
                myAnim.SetTrigger("AttackingLeft");
            }
         
        }

       
        // Camera follwing player
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, BottomLeftLimit.x, TopRightLimit.x), Mathf.Clamp(transform.position.y, BottomLeftLimit.y, TopRightLimit.y), transform.position.z);

    }



        public void SetBounds(
            Vector3 botLeft, Vector3 topRight) { 

            BottomLeftLimit = botLeft + new Vector3(.5f, 1f, 0f);
            TopRightLimit = topRight + new Vector3(-.5f, -1f, 0f);

        }


}
