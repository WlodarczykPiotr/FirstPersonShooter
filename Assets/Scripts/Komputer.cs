using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Komputer : MonoBehaviour
{
    [SerializeField]
    private ushort zdrowiePrzeciwnika = 100;

    private IEnumerator Obrazenia(float[] parametry_0DAMAGE_1DISTANCE)
    {
        if (parametry_0DAMAGE_1DISTANCE[1] < 2.5f) yield return new WaitForSeconds(0.125f);
        else if (parametry_0DAMAGE_1DISTANCE[1] > 2.5f && parametry_0DAMAGE_1DISTANCE[1] < 5f) yield return new WaitForSeconds(0.25f);
        else if (parametry_0DAMAGE_1DISTANCE[1] > 5f && parametry_0DAMAGE_1DISTANCE[1] < 10f) yield return new WaitForSeconds(0.5f);
        else if (parametry_0DAMAGE_1DISTANCE[1] > 10f) yield return new WaitForSeconds(1f);

        zdrowiePrzeciwnika -= (ushort)parametry_0DAMAGE_1DISTANCE[0];
    }

    // Update is called once per frame
    private void Update()
    {
        if (zdrowiePrzeciwnika <= 0)
        {
            Destroy(gameObject);
        }
    }
}
