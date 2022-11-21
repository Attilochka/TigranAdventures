using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunForPlayer : MonoBehaviour
{
    public Animator anime;
    public float offset;
    public GameObject Bullet;
    public Transform ShotPoint;

    public float TimeBtwShots;
    public float StartTimeBtwShot;

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);

        if(anime.GetBool("take") == true && TimeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anime.SetBool("gun", true);
                var BulletObj = Instantiate(Bullet, ShotPoint.position, transform.rotation);
                TimeBtwShots = StartTimeBtwShot;
                
            }
        }
        else
        {
            TimeBtwShots -= Time.deltaTime;
            anime.SetBool("gun", false);
        }
        
    }
}
