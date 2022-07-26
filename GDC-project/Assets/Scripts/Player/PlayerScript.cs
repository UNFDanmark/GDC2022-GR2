using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5f;
    public float defaultGravity = -13f;
    public float startJumpForce = 600f;
    public float jumpModifier = 1.25f;
    public float startAttackSpeed = 5f;
    public float attackGravityMultiplier = 3f;
    public float weakJump = 4f;
    public float starBottomBounceback = -5f;
    Vector3 previousVel;
    Vector3 previousPos;
    float screenHeight;
    float screenWidth;
    public float gameOverDelay = 2.0f;
    public AudioClip attackSFX;
    public AudioClip deathSFX;
    public float volume;
    public bool holdToAttack = true;

    bool firstJump = true;
    bool starHit = false;
    bool isAttacking = false;
    bool isDead = false;

    public GameObject highscoreSaver;
    public List<GameObject> stillframes;

    PointsManager pm;
    Rigidbody rb;
    SceneHandler sceneHandler;


    void Start()
    {
        sceneHandler = FindObjectOfType<SceneHandler>();
        rb = GetComponent<Rigidbody>();
        pm = FindObjectOfType<PointsManager>();

        Physics.gravity = new Vector3(0, defaultGravity, 0);

        screenHeight = 2f * Camera.main.orthographicSize;
        screenWidth = screenHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        //Save current speed and position
        previousVel = rb.velocity;
        previousPos = transform.position;

        //Move and attack
        if (!isDead)
        {
            MoveHandler();
            AttackHandler();
        }
        HandleVisuals();
    }

    void MoveHandler()
    {
        float moveInput = Input.GetAxis("Horizontal");
        float xVelocity = speed * moveInput * Time.deltaTime;

        transform.Translate(new Vector3(xVelocity, 0, 0));

        float xPos = Mathf.Clamp(transform.position.x, -screenWidth/2, screenWidth/2);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);

        bool wantsToJump = Input.GetButtonDown("Jump");

        if (firstJump && wantsToJump && !starHit)
        {
            rb.AddForce(Vector3.up * startJumpForce);
            firstJump = false;
        }
    }

    void AttackHandler()
    {
        if (Input.GetKeyDown("s"))
        {
            rb.velocity = new Vector3(rb.velocity.x, -startAttackSpeed, rb.velocity.z); //Sets the vertical speed to attack speed
            isAttacking = true;
            Physics.gravity = new Vector3(0, attackGravityMultiplier * defaultGravity, 0);
            AudioSource.PlayClipAtPoint(attackSFX, Camera.main.transform.position, volume);
        }
        else if (Input.GetKeyUp("s") && holdToAttack)
        {
            CancelAttack();
        }
    }

    void HandleVisuals()
    {
        if(isAttacking)
        {
            stillframes[0].SetActive(false); //normal or rising
            stillframes[1].SetActive(true); //attacking
            stillframes[2].SetActive(false); //falling
        }
        else if(rb.velocity.y < 0)
        {
            stillframes[0].SetActive(false);
            stillframes[1].SetActive(false);
            stillframes[2].SetActive(true);
        }
        else
        {
            stillframes[0].SetActive(true);
            stillframes[1].SetActive(false);
            stillframes[2].SetActive(false);
        }
    }

    void CancelAttack()
    {
        Physics.gravity = new Vector3(0, defaultGravity, 0);
        isAttacking = false;
    }

    public void Die()
    {
        isDead = true;
        GameObject.FindWithTag("Soundguy").GetComponent<AudioSource>().Stop();
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);
        //pm.SetTextsAsNull();
        GameObject scoreSaver = Instantiate(highscoreSaver);
        scoreSaver.GetComponent<HighscoreSaver>().score = pm.GetScore();
        scoreSaver.GetComponent<HighscoreSaver>().highscore = pm.GetHighscore();
        Invoke("GameOver", gameOverDelay);
    }

    void GameOver()
    {
        sceneHandler.LoadSceneIndex(2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "StarTop")
        {
            if (isAttacking)
            {
                transform.position = previousPos;
                rb.velocity = new Vector3(previousVel.x, Mathf.Max(-previousVel.y * jumpModifier, weakJump), previousVel.z);
                other.transform.parent.gameObject.GetComponent<Star>().DestroyStar(true);
                pm.IncreaseScore(1);
            }
            else
            {
                transform.position = previousPos;
                rb.velocity = new Vector3(previousVel.x, weakJump, previousVel.z);
            }
            CancelAttack();
            starHit = true;
        }
        else if (other.gameObject.tag == "StarBottom")
        {
            rb.velocity = new Vector3(rb.velocity.x, starBottomBounceback, rb.velocity.z);
            CancelAttack();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isAttacking = false;
            if (!starHit)
            {
                firstJump = true;
            }
            else
            {
                Die();
            }

            //rb.velocity = new Vector3(rb.velocity.x, 30f, rb.velocity.z);
        }
    }
}