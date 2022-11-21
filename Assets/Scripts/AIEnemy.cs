using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class AIEnemy : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public int Patrol;
    public Transform PointForEnemy;
    bool MovingRight;
    Transform Player;
    public float DistanceStopping;
    public int health;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;  
    }

    
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (Vector2.Distance(transform.position, PointForEnemy.position) < Patrol)
        {
            Chill();
        }
        if (Vector2.Distance(transform.position, Player.position) < DistanceStopping)
        {
            Angry();
        }
        if (Vector2.Distance(transform.position, Player.position) > DistanceStopping)
        {
            GoBack();
        }
    }

    void Chill()
    {
        if (transform.position.x > PointForEnemy.position.x + Patrol)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);     
        }
        else if(transform.position.x < PointForEnemy.position.x - Patrol)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
    }

    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position, speed * Time.deltaTime);
    }

    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, PointForEnemy.position, speed * Time.deltaTime);
    }

    public void TakeDamage(int Damage)
    {
        health -= Damage;
    }

}

