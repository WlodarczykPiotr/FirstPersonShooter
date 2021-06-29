using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZbieranieAmunicji : MonoBehaviour
{
    private AudioSource dzwiekZebraniaAmunicji;

    private void Start()
    {
        if (!dzwiekZebraniaAmunicji) dzwiekZebraniaAmunicji = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "gracz")
        {
            Amunicja.aktualnaAmunicja += 10;
            dzwiekZebraniaAmunicji.Play();
            Destroy(this.gameObject, 0.25f);
        }
    }
}