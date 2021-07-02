using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZbieranieAmunicji : MonoBehaviour
{
    [SerializeField]
    private ushort iloscAmunicjiWSkrzynce;

    private AudioSource dzwiekZebraniaAmunicji;

    private void Start()
    {
        if (!dzwiekZebraniaAmunicji) dzwiekZebraniaAmunicji = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "gracz")
        {
            if (Amunicja.aktualnaAmunicjaWMagazynku <= 0) Amunicja.aktualnaAmunicjaWMagazynku += iloscAmunicjiWSkrzynce;
            else Amunicja.aktualnaAmunicjaWEkwipunku += iloscAmunicjiWSkrzynce;

            dzwiekZebraniaAmunicji.Play();
            Destroy(this.gameObject, 0.25f);
        }
    }
}