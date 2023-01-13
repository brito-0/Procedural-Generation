using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //[SerializeField] private Transform player;
    [Header("attributes")]
    [SerializeField] private float maxHealth = 5f;
    [SerializeField] private float speed = 2f;
    [Header("attack")]
    [SerializeField] private Transform weapon;
    [SerializeField] private float wDamage = .5f;
    [SerializeField] private float range = .2f;
    [SerializeField] private float Frange = 4.3f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float aRate = 1.5f;
    private float aTime = 0f;
    private int fTime;
    private Collider2D playerFollow;
    private Rigidbody2D rBody;
    private float health;
    private Vector3 oPos;
    private Quaternion oRot;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        oPos = transform.position;
        oRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D near = Physics2D.OverlapCircle(transform.position, Frange, playerLayer);
        if (near != null) 
        { 
            fTime = 500;
            playerFollow = near;
        }
        if (near != null || fTime > 0) {
            Follow(playerFollow);
        } else if (transform.position != oPos)
        {
            Vector3 dir = oPos - transform.position;
            float angle = Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            transform.position = Vector3.MoveTowards(transform.position, oPos, (speed * .8f) * Time.deltaTime);

            if (transform.position == oPos)
            {
                transform.rotation = oRot;
            }
        }
        Collider2D att = Physics2D.OverlapCircle(weapon.position, range, playerLayer);
        if (att != null)
        {
            if (Time.time >= aTime)
            {
                Attack(att);
                aTime = Time.time + 1f / aRate;
            }
        }
    }

    private void FixedUpdate()
    {
        if (fTime > 0) { fTime--; }
    }

    public void Damage(float dam)
    {
        health -= dam;
        if (health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        isDead = true;
        Destroy(gameObject);
    }
    
    // enemy follows the player
    private void Follow(Collider2D abc)
    {
        Vector3 dir = abc.transform.position - transform.position;
        float angle = Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.position = Vector2.MoveTowards(transform.position, abc.transform.position, speed * Time.deltaTime);
    }

    // enemy attacks the player
    private void Attack(Collider2D hit)
    {
        //Collider2D hit = Physics2D.OverlapCircle(weapon.position, range, playerLayer);

        Debug.Log("enemy hit");
        hit.GetComponent<Player>().Damage(wDamage);
    }

    // draws attack and follow area on the scene
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Frange);
        if (weapon == null) { return; }
        Gizmos.DrawWireSphere(weapon.position, range);
    }
}
