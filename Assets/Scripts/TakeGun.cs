using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TakeGun : MonoBehaviour
{
    public Animator anime;

    void Start(){
        Debug.Log("IM WORK too");
    }
    void Update()
    {
        Console.WriteLine("WORK");
        if(Input.GetKeyDown(KeyCode.F) && anime.GetBool("take") == false)
        {
            Debug.Log("F work");
            anime.SetBool("take", true);
        }
        else if(anime.GetBool("take") == true && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("NOOOOOOO");
            anime.SetBool("take", false);
        }

    }
}
