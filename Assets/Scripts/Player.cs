using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject friend;
    public Animator anim;
    public ParticleSystem effects;
    // private bool wave;
    //private float waveDuration = 3f;
    //private float acceleration = 10;
    //private float currentTargetSpeed = 1f;

    private void Start()
    {
        anim.GetComponent<Animator>();
    }
    private void Update()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f,Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;

        if (moveInput != new Vector3(0, 0, 0))
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
    
        transform.Translate(moveInput, Space.World);
        if (moveInput != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveInput), 0.05f);
        }
        float distance = Vector3.Distance(transform.position, friend.transform.position);

            if (Input.GetMouseButton(0))
            {
                anim.SetBool("IsWaving", true);
                if (distance <= 3)
                {
                    friend.GetComponent<Animator>().SetTrigger("IsWavingBack");
                    effects.Play();
                }
         
            }
            else
            {
                anim.SetBool("IsWaving", false);
            }
        
        
    }

   
}
/* if (!wave)
 {
     speed = Mathf.MoveTowards(speed, currentTargetSpeed, acceleration * Time.deltaTime);
 }


 if (!wave && Input.GetMouseButtonDown(0))
 {
     speed = 0;
     StartCoroutine(Wave());
 }

 IEnumerator Wave()
 {
     wave = true;
     effects.GetComponent<ParticleSystem>().Play();
     GetComponent<Animator>().SetTrigger("IsWaving");

     if (Vector3.Distance(GetComponent<Transform>().position, friend.GetComponent<Transform>().position) < 100f)
     {
         effects.GetComponent<ParticleSystem>().Play();
         friend.GetComponent<Animator>().SetTrigger("IsWaving");
     }

     yield return new WaitForSeconds(waveDuration);
     wave = false;
 } */
