using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{

    public Transform playerTransform;
    public Transform friendTransform;
    public Animator anim;
    private bool wavingBack;

    void Update()
    {
        StartCoroutine(WaveBack());
    }

    private IEnumerator WaveBack()
    {
        wavingBack = true;
        if (Vector3.Distance(playerTransform.position, friendTransform.position) < 100f)
        {
            anim.SetTrigger("IsWavingBack");
        }
        yield return new WaitForSeconds(3);
        wavingBack = false;
    }

}
