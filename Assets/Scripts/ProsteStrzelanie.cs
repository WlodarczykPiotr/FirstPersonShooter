using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProsteStrzelanie : MonoBehaviour
{
    [Header("Referencje prefabrykatow")]

    public GameObject trzonekPocisku;
    public GameObject obudowaPocisku;
    public GameObject efektyCzasteczkowe;

    [Header("Referencje lokalizacji modeli częsci broni")]

    [SerializeField] private Animator animatorBroni;
    [SerializeField] private Transform wspolrzedneLufy;
    [SerializeField] private Transform wspolrzedneOdrzutu;

    private AudioSource dzwiekWystrzalu;
    
    [Header("Ustawienia")]

    [Tooltip("Określ czas do zniszczenia modelu obudowy pocisku")]
    [SerializeField] private float czasZniszczenia = 5f;

    [Tooltip("Predkosc pocisku")]
    [SerializeField] private float mocWystrzalu = 500f;

    [Tooltip("Szybkosc wyrzutu modelu obudowy pocisku")]
    [SerializeField] private float mocWyrzutu = 100f;
    
    private void Start()
    {
        if (!wspolrzedneLufy) wspolrzedneLufy = GetComponent<Transform>();
        if (!animatorBroni) animatorBroni = GetComponentInChildren<Animator>();
        if (!dzwiekWystrzalu) dzwiekWystrzalu = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Amunicja.aktualnaAmunicjaWMagazynku <= 0) return;

            animatorBroni.enabled = true;
            animatorBroni.SetTrigger("Fire");
            dzwiekWystrzalu.Play();
            Amunicja.aktualnaAmunicjaWMagazynku--;
        }
    }

    // Ta funkcja tworzy zachwanie pocisku
    private void Strzal()
    {
        if (!efektyCzasteczkowe || !wspolrzedneLufy) return;
        
        // Utworzenie instancji błysku wystrzału
        Instantiate(efektyCzasteczkowe, wspolrzedneLufy.position, wspolrzedneLufy.rotation);
        
        if (!trzonekPocisku) return;

        // Utworzenie instacji trzonka pocisku
        GameObject trzonekOdPocisku = Instantiate(trzonekPocisku, wspolrzedneLufy.position, wspolrzedneLufy.rotation);

        // Nadanie pociskowi mocy wystrzalu
        trzonekOdPocisku.GetComponent<Rigidbody>().AddForce(wspolrzedneLufy.forward * mocWystrzalu);
    }

    // Ta funkcja tworzy obudowe w szczelinie wyrzutowej
    private void ZwolnienieObudowy()
    {
        if (!wspolrzedneOdrzutu || !obudowaPocisku) return;

        // Utworzenie instacji obudowy pocisku
        GameObject obudowaOdPocisku = Instantiate(obudowaPocisku, wspolrzedneOdrzutu.position, wspolrzedneOdrzutu.rotation);

        //Dodanie siły do obudowy, aby ją wypchnać
        obudowaOdPocisku.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(mocWyrzutu, mocWyrzutu * 3f), (wspolrzedneOdrzutu.position - wspolrzedneOdrzutu.right * 0.3f - wspolrzedneOdrzutu.up * 0.6f), 1f);
        
        // Dodanie momentu obrotowego, aby obudowa pocisku obracała sie w losowym kierunku
        obudowaOdPocisku.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Force);
        
        //Zniszczenie obudowy pocisku po X sekundach
        Destroy(obudowaOdPocisku, czasZniszczenia);
    }
}