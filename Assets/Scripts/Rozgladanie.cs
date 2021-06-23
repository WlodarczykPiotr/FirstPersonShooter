using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rozgladanie : MonoBehaviour
{
    private float wejscieMyszyOX; // obrot kontrolera postaci w prawo lub w lewo
    private float wejscieMyszyOY; // obrot kontrolera postaci do gory lub w dol
    private float rotacjaX = 0f;

    public float czuloscMyszy = 100f;

    public Transform lokalizacjaGracza;
    
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        // Pobieranie danych wejsciowych z myszy dla kontrolera postaci w celu obracania go
        wejscieMyszyOX = Input.GetAxis("Mouse X") * czuloscMyszy * Time.deltaTime;
        wejscieMyszyOY = Input.GetAxis("Mouse Y") * czuloscMyszy * Time.deltaTime;

        rotacjaX -= wejscieMyszyOY;
        rotacjaX = Mathf.Clamp(rotacjaX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotacjaX, 0f, 0f);

        lokalizacjaGracza.Rotate(Vector3.up * wejscieMyszyOX);
    }
}