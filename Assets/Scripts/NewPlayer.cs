using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : MonoBehaviour
{
    public float speed;
    public float roatateSpeed;
    float acceleration = 10;
    float maxSpeed = 3;
    float rotateY;
    public Animator anim;
    public event Action wave;
    private bool waving;
    float waveDuration = 1f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionZ = Input.GetAxisRaw("Vertical");

        if (!waving)
        {
            speed = Mathf.MoveTowards(speed, maxSpeed * directionZ, acceleration * Time.deltaTime);
            rotateY += directionX * roatateSpeed * Time.deltaTime;
        }
        if (!waving && Input.GetKeyDown(KeyCode.Mouse0))
        {

            StartCoroutine(Waveing());
        }
        transform.position += transform.forward * speed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0, rotateY, 0);
    }

    private IEnumerator Waveing()
    {
        wave?.Invoke();

        waving = true;

        yield return new WaitForSeconds(waveDuration);

        waving = false;
    }
}
