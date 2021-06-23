using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacjaCelownika : MonoBehaviour
{
    [SerializeField]
    private GameObject centralnyCelownik;
    [SerializeField]
    private GameObject gornyCelownik;
    [SerializeField]
    private GameObject dolnyCelownik;
    [SerializeField]
    private GameObject prawyCelownik;
    [SerializeField]
    private GameObject lewyCelownik;
    
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            WlaczAnimacjeCelownika();
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            WylaczAnimacjeCelownika();
        }
    }

    private void WlaczAnimacjeCelownika()
    {
        centralnyCelownik.GetComponent<Animator>().enabled = true;
        gornyCelownik.GetComponent<Animator>().enabled = true;
        dolnyCelownik.GetComponent<Animator>().enabled = true;
        prawyCelownik.GetComponent<Animator>().enabled = true;
        lewyCelownik.GetComponent<Animator>().enabled = true;
    }

    private void WylaczAnimacjeCelownika()
    {
        centralnyCelownik.GetComponent<Animator>().enabled = false;
        gornyCelownik.GetComponent<Animator>().enabled = false;
        dolnyCelownik.GetComponent<Animator>().enabled = false;
        prawyCelownik.GetComponent<Animator>().enabled = false;
        lewyCelownik.GetComponent<Animator>().enabled = false;
    }
}
