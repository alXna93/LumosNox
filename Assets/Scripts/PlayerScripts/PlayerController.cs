using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum PlayerState
{
    walk,
    attack,
    stagger,
    idle
    
}

public class PlayerController : MonoBehaviour {

    //Player variables
    public PlayerState currentState;
    public Rigidbody2D theRB;
    public float moveSpeed;
    public Vector3 change;
    public Animator myAnim;
    public FloatValue currentHealth;
    public Signal playerHealthSignal;
    

    public static PlayerController instance;

    private sfxManager sfxMan;

    public string areaTransitionName;

    private Vector3 BottomLeftLimit;
    private Vector3 TopRightLimit;

    public bool canMove = true;
    public float waitToReload;

   






    // Use this for initialization
    void Start () {

        //Set instance to player character
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            if (instance != this)
            {
                Destroy(gameObject); //Destroy instance if there is more than one
            }
        }

        DontDestroyOnLoad(gameObject); //Dont destroy player character when loading into new level
        currentState = PlayerState.walk; //Set players initial state
        sfxMan = FindObjectOfType<sfxManager>();
       
        myAnim.SetFloat("moveX", 0); // X value for animator
        myAnim.SetFloat("moveY", -1); // Y value for animator
    }


    // Update is called once per frame
    void Update() {

        //Change player direction based on player input
        change = Vector3.zero; 
        change.x = Input.GetAxisRaw("Horizontal"); 
        change.y = Input.GetAxisRaw("Vertical");

        //Check if player is attacking and if they are change player state and run coroutine
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger) 
        {
            StartCoroutine(AttackCo());

        }
        //If the player isnt attacking, update animation and move player
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }

        // Camera following player
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, BottomLeftLimit.x, TopRightLimit.x), Mathf.Clamp(transform.position.y, BottomLeftLimit.y, TopRightLimit.y), transform.position.z);

       
    }

    private IEnumerator AttackCo() //Attacking coroutine
    {
        myAnim.SetBool("attacking", true); //Set animation for attacking
        currentState = PlayerState.attack; //Set updated player state
        sfxMan.playerAttack.Play(); //Play attacking sound effect
        yield return null;
        myAnim.SetBool("attacking", false); //Player stopped attacking
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk; //Return to walk state
    }

    void UpdateAnimationAndMove() //Update the animator depending on direction
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            change.x = Mathf.Round(change.x);
            change.y = Mathf.Round(change.y);
            myAnim.SetFloat("moveX", change.x);
            myAnim.SetFloat("moveY", change.y);
            myAnim.SetBool("moving", true);
        }
        else
        {
            myAnim.SetBool("moving", false);
        }

      
    }

    void MoveCharacter() //Move player in given direction
    {
        change.Normalize();
        theRB.MovePosition(transform.position + change * moveSpeed * Time.deltaTime);
    }

    public void Knock(float knockTime, float damage) 
    {

        //Set player health by reducing it by the knockback damage dealth by enemy

        currentHealth.RuntimeValue -= damage;
        playerHealthSignal.Raise();
        if (currentHealth.RuntimeValue > 0)
        {
           
            StartCoroutine(KnockCo(knockTime)); //start knockback coroutine
        }
        else
        {
            
            StartCoroutine(PlayerDead());
            


        }

        
    }

    private IEnumerator KnockCo(float knockTime) //Coroutine for player rigidbody after knockback
    {
        if (theRB != null)
        {
            yield return new WaitForSeconds(knockTime);
            theRB.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            theRB.velocity = Vector2.zero;
        }
    }

    private IEnumerator PlayerDead()
    {
        sfxMan.playerDeath.Play(); //Play attacking sound effect
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("gameOver");
        

    }


    public void SetBounds( //Bounds for player in level
            Vector3 botLeft, Vector3 topRight) { 

            BottomLeftLimit = botLeft + new Vector3(.5f, 1f, 0f);
            TopRightLimit = topRight + new Vector3(-.5f, -1f, 0f);

        }


}