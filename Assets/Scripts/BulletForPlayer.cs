using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForPlayer : MonoBehaviour
{
    public float Speed;
    public float LifeTime;
    public float Distance;
    public int Damage;
    public LayerMask WhatIsSolid;
    

    private void Update()
    {
        RaycastHit2D HitIfno = Physics2D.Raycast(transform.position, transform.up, Distance, WhatIsSolid);
        if (HitIfno.collider != null)
        {
            if (HitIfno.collider.CompareTag("Enemy"))
            {
                HitIfno.collider.GetComponent<AIEnemy>().TakeDamage(Damage);
            }
            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
        LifeTime -= Time.deltaTime;
        if (LifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

}
