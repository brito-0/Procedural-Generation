using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("controlls")]
    [SerializeField] private bool mouse;
    [Header("attributes")]
    [SerializeField] private float speed = 3f;
    [Header("attack")]
    [SerializeField] private float wDamage = 1f;
    [SerializeField] private Transform weapon;
    [SerializeField] private float range = .2f;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private float aRate = 1.5f;
    private float aTime = 0f;
    private Rigidbody2D rBody;
    private float maxHealth = 3f;
    public float health;
    private Vector2 move;
    private bool isDead = false;
    private Vector3 attackDir;
    private float attackAngle;

    private Quaternion slideDir;
    private float slideSpeed;

    private Text healthDisplay;

    // -----------------------------

    private State state;

    private enum State
    {
        Normal, 
        Dodge,
    }


    private void Awake()
    {
        state = State.Normal;
    }

    // -----------------------------


    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        maxHealth = 50;
        health = maxHealth;
        //healthDisplay = GameObject.Find("healthDisplay").GetComponent<Text>();
        healthDisplay = GameObject.FindWithTag("HealthText").GetComponent<Text>();

        healthDisplay.text = "health: " + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state) {
            case State.Normal:

                move.x = Input.GetAxisRaw("Horizontal");
                move.y = Input.GetAxisRaw("Vertical");
                Rotate();

                if (Time.time >= aTime)
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        Attack();
                        aTime = Time.time + 1f / aRate;
                    }
                }

                if (Input.GetButtonDown("Jump"))
                {
                    Dodge();
                }


                break;

            case State.Dodge:

                DodgeRoll();
                
                break;


    }
    }

    private void FixedUpdate()
    {
        rBody.MovePosition(rBody.position + move * speed * Time.fixedDeltaTime);
    }

    // rotates the player
    private void Rotate()
    {
        if (move.x > 0 && move.y > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, -45);
        }
        else if (move.x < 0 && move.y < 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 135);
        }
        else if (move.x > 0 && move.y < 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, -135);
        }
        else if (move.x < 0 && move.y > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 45);
        }
        else if (move.y > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if (move.y < 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 180);
        }
        else if (move.x > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, -90);
        }
        else if (move.x < 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 90);
        }
    }

    // makes the player take damage
    public void Damage(float dam)
    {
        if (state == State.Normal)
        {
            health -= dam;
            if (health <= 0)
            {
                health = 0;
                Death();
            }
            healthDisplay.text = "health: " + ((int)health).ToString();
        }
    }

    // kills the player
    private void Death()
    {
        isDead = true;
        Destroy(gameObject);
    }

    // player attacks an enemy
    private void Attack()
    {
        if (!mouse)
        {
            Collider2D[] hit = Physics2D.OverlapCircleAll(weapon.position, range, enemyLayers);

            foreach (Collider2D ene in hit)
            {
                Debug.Log("player hit");
                ene.GetComponent<Enemy>().Damage(wDamage);
            }
        }
        else
        {
            attackDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            attackAngle = (Mathf.Atan2(attackDir.y, attackDir.x) * Mathf.Rad2Deg) - 90;
            transform.rotation = Quaternion.AngleAxis(attackAngle, Vector3.forward);

            Collider2D[] hit = Physics2D.OverlapCircleAll(weapon.position, range, enemyLayers);

            foreach (Collider2D ene in hit)
            {
                Debug.Log("player hit");
                ene.GetComponent<Enemy>().Damage(wDamage);
            }
        }
    }

    public float getHealth() 
    {
        return health;
    }

    public float getMaxHealth() 
    {
        return maxHealth;
    }

    private void Dodge()
    {
        // add dodge mechanic

        state = State.Dodge;
        slideDir = transform.rotation.normalized;
        slideSpeed = 4f;

    }

    private void DodgeRoll()
    {

        // find a way to work with rigid body

        //rBody.MovePosition(rBody.position + move * slideSpeed * Time.deltaTime);

        //transform.position += transform.position * slideSpeed * Time.deltaTime;

        //rBody.MovePosition(rBody.position + move * abcde);

        slideSpeed -= slideSpeed * 5f * Time.deltaTime;

        if (slideSpeed < 1f)
        {
            state = State.Normal;
        }
    }

    // draws attack area on the scene
    private void OnDrawGizmosSelected()
    {
        if (weapon == null) { return; }
        Gizmos.DrawWireSphere(weapon.position, range);
    }

    private void OnLevelWasLoaded(int level)
    {
        //healthDisplay = GameObject.Find("healthDisplay").GetComponent<Text>();
        healthDisplay = GameObject.FindWithTag("HealthText").GetComponent<Text>();

        healthDisplay.text = "health: " + health.ToString();
    }
}
