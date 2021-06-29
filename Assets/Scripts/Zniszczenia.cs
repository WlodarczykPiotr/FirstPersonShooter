using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zniszczenia : MonoBehaviour
{
    [SerializeField]
    private ushort poziomUszkodzen = 10;
    [SerializeField]
    private float odlegloscDoCelu;
    [SerializeField]
    private float maksymalnyDystansDoAtaku = 15f;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Amunicja.aktualnaAmunicja <= 0) return;

            RaycastHit strzal;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out strzal))
            {
                odlegloscDoCelu = strzal.distance;

                if (odlegloscDoCelu < maksymalnyDystansDoAtaku)
                {
                    ushort obrazenia = poziomUszkodzen;
                    strzal.transform.SendMessage("Obrazenia", obrazenia, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}