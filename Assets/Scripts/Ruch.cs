using UnityEngine;

public class Ruch : MonoBehaviour
{
    public CharacterController kontrolerPostaci;
    public Transform lokalizacjaGruntu;
    public LayerMask warstwaGruntu;

    public float predkoscRuchu = 12f;
    public float grawitacja = -10f;
    public float odlegloscDoGruntu = 0.4f;
    public float wysokoscSkoku = 2f;

    private float pozycjaKlawiaturyOX; // przesuniecie kontrolera postaci w prawo lub w lewo
    private float pozycjaKlawiaturyOZ; // przesuniecie kontrolera postaci do przodu lub do tylu

    private bool czyNaGruncie;

    private Vector3 predkoscOpadania;
    private Vector3 kierunekRuchu;
    
    // Update is called once per frame
    private void Update()
    {
        // Pobieranie danych wejsciowych z klawiatury dla kontrolera postaci w celu poruszania nim 
        pozycjaKlawiaturyOX = Input.GetAxis("Horizontal");
        pozycjaKlawiaturyOZ = Input.GetAxis("Vertical");

        kierunekRuchu = transform.right * pozycjaKlawiaturyOX + transform.forward * pozycjaKlawiaturyOZ;

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
