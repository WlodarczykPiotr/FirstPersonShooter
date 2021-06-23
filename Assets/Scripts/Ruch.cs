using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruch : MonoBehaviour
{
    public CharacterController kontrolerPostaci;
    public Transform lokalizacjaGruntu;
    public LayerMask warstwaGruntu;

    [SerializeField]
    private float predkoscRuchu = 6f;
    [SerializeField]
    private float grawitacja = 0f;
    [SerializeField]
    private float odlegloscDoGruntu = 0.4f;
    [SerializeField]
    private float wysokoscSkoku = 2f;

    private float wejscieKlawiaturyOX; // przesuniecie kontrolera postaci w prawo lub w lewo
    private float wejscieKlawiaturyOZ; // przesuniecie kontrolera postaci do przodu lub do tylu

    private bool czyNaGruncie;

    private Vector3 predkoscOpadania;
    private Vector3 kierunekRuchu;
    
    // Update is called once per frame
    private void Update()
    {
        // Pobieranie danych wejsciowych z klawiatury dla kontrolera postaci w celu poruszania nim 
        wejscieKlawiaturyOX = Input.GetAxis("Horizontal");
        wejscieKlawiaturyOZ = Input.GetAxis("Vertical");

        kierunekRuchu = transform.right * wejscieKlawiaturyOX + transform.forward * wejscieKlawiaturyOZ;

        kontrolerPostaci.Move(kierunekRuchu * predkoscRuchu * Time.deltaTime);
        
        predkoscOpadania.y += grawitacja * Time.deltaTime;

        kontrolerPostaci.Move(predkoscOpadania * Time.deltaTime);

        if (lokalizacjaGruntu) czyNaGruncie = Physics.CheckSphere(lokalizacjaGruntu.position, odlegloscDoGruntu, warstwaGruntu);

        if (czyNaGruncie && predkoscOpadania.y < 0)
        {
            predkoscOpadania.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && czyNaGruncie)
        {
            predkoscOpadania.y = (Mathf.Sqrt(wysokoscSkoku * -2f * grawitacja));
        }
    }
}