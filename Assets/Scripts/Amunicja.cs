using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Amunicja : MonoBehaviour
{

    [SerializeField]
    private GameObject iloscAmunicjiWEkwipunku, iloscAmunicjiWMagazynku;

    private ushort amunicjaWEkwipunku, amunicjaWMagazynku, pojemnoscMagazynka = 25;
    public static ushort aktualnaAmunicjaWEkwipunku, aktualnaAmunicjaWMagazynku;

    // Update is called once per frame
    private void Update()
    {
        if (amunicjaWMagazynku != aktualnaAmunicjaWMagazynku)
        {
            amunicjaWMagazynku = aktualnaAmunicjaWMagazynku;
            iloscAmunicjiWMagazynku.GetComponent<Text>().text = amunicjaWMagazynku.ToString();
        }

        if (amunicjaWEkwipunku != aktualnaAmunicjaWEkwipunku)
        {
            amunicjaWEkwipunku = aktualnaAmunicjaWEkwipunku;
            iloscAmunicjiWEkwipunku.GetComponent<Text>().text = amunicjaWEkwipunku.ToString();
        }

        if (aktualnaAmunicjaWMagazynku <= 0 && aktualnaAmunicjaWEkwipunku >= pojemnoscMagazynka)
        {
            aktualnaAmunicjaWMagazynku += pojemnoscMagazynka;
            aktualnaAmunicjaWEkwipunku -= pojemnoscMagazynka;
        }
    }
}