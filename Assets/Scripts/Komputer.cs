using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Komputer : MonoBehaviour
{
    [SerializeField]
    private short zdrowiePrzeciwnika = 100;

    private short obrazenia;

    private void Obrazenia(short obrazenia)
    {
        this.obrazenia = obrazenia;
    }

    // Update is called once per frame
    private void Update()
    {
        //Debug.Log(zdrowiePrzeciwnika);

        if (zdrowiePrzeciwnika <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "pocisk")
        {
            zdrowiePrzeciwnika -= obrazenia;
            Destroy(collision.gameObject);
        }
    }
}
