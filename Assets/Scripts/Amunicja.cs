using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Amunicja : MonoBehaviour
{
    [Header("Referencje prefabrykatow")]

    public GameObject magazynek;

    [Header("Referencje lokalizacji modeli czêsci broni")]

    [SerializeField] private Animator animatorMagazynku;
    [SerializeField] private Transform wspolrzedneWyrzutu;

    [Header("Ustawienia")]

    [Tooltip("Okreœl czas do zniszczenia magazynku")]
    [SerializeField] private float czasZniszczenia = 5f;
    [Tooltip("Szybkosc wyrzutu magazynku")]
    [SerializeField] private float mocWyrzutu = 100f;

    private AudioSource dzwiekWymianyMagazynka;

    // Start is called before the first frame update
    private void Start()
    {
        if (!animatorMagazynku) animatorMagazynku = GetComponentInChildren<Animator>();
        if (!dzwiekWymianyMagazynka) dzwiekWymianyMagazynka = GetComponent<AudioSource>();
    }

    [SerializeField]
    private GameObject iloscAmunicjiWEkwipunku, iloscAmunicjiWMagazynku;
    
    private ushort amunicjaWEkwipunku, amunicjaWMagazynku;
    private const ushort pojemnoscMagazynka = 25;
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

        //Naladowanie magazynku nabojami z ekwipunku
        if (Input.GetMouseButtonDown(1))
        {
            if (aktualnaAmunicjaWMagazynku <= 0 && aktualnaAmunicjaWEkwipunku > 0)
            {
                animatorMagazynku.enabled = true;
                animatorMagazynku.SetTrigger("Wymiana");
                dzwiekWymianyMagazynka.Play();
            }

            if (aktualnaAmunicjaWMagazynku <= 0 && aktualnaAmunicjaWEkwipunku >= pojemnoscMagazynka)
            {
                aktualnaAmunicjaWMagazynku += pojemnoscMagazynka;
                aktualnaAmunicjaWEkwipunku -= pojemnoscMagazynka;
            }
            else if (aktualnaAmunicjaWMagazynku <= 0 && aktualnaAmunicjaWEkwipunku < pojemnoscMagazynka && aktualnaAmunicjaWEkwipunku > 0)
            {
                aktualnaAmunicjaWMagazynku += aktualnaAmunicjaWEkwipunku;
                aktualnaAmunicjaWEkwipunku = 0;
            }
        }
    }

    private void ZwolnienieMagazynka()
    {
        if (!wspolrzedneWyrzutu || !magazynek) return;

        GameObject Magazynek = Instantiate(magazynek, wspolrzedneWyrzutu.position, wspolrzedneWyrzutu.rotation);
        Magazynek.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(mocWyrzutu, mocWyrzutu * 3f), (wspolrzedneWyrzutu.position - wspolrzedneWyrzutu.right * 0.3f - wspolrzedneWyrzutu.up * 0.6f), 1f);
        Destroy(Magazynek, czasZniszczenia);
    }
}