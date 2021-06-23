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
            RaycastHit strzal;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out strzal))
            {
                odlegloscDoCelu = strzal.distance;

                if (odlegloscDoCelu < maksymalnyDystansDoAtaku)
                {
                    float[] parametry_0DAMAGE_1DISTANCE = new float[2];
                    parametry_0DAMAGE_1DISTANCE[0] = poziomUszkodzen;
                    parametry_0DAMAGE_1DISTANCE[1] = odlegloscDoCelu;

                    strzal.transform.SendMessage("Obrazenia", parametry_0DAMAGE_1DISTANCE, SendMessageOptions.DontRequireReceiver);
                }

            }
        }
    }
}
