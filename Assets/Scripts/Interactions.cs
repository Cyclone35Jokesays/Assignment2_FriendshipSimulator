using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{ 
    public Transform playerTrans;
    public Transform friendTrans;
    public Animator anim;
    private bool wavingBack;

    private void Update()
    {
        StartCoroutine(WaveBack());
    }

    private IEnumerator WaveBack()
    {
        wavingBack = true;
        if (Vector3.Distance(playerTrans.position, friendTrans.position) < 100f)
        {
            anim.SetTrigger("IsWavingBack");
        }
        yield return new WaitForSeconds(5);
        wavingBack = false;
    }

}
