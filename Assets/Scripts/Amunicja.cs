using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Amunicja : MonoBehaviour
{
    [SerializeField]
    private byte lokalnaAmunicja;
    [SerializeField]
    private GameObject iloscAmunicji;

    public static byte aktualnaAmunicja;

    // Update is called once per frame
    private void Update()
    {
        if (lokalnaAmunicja != aktualnaAmunicja)
        {
            lokalnaAmunicja = aktualnaAmunicja;
            iloscAmunicji.GetComponent<Text>().text = "" + lokalnaAmunicja;
        }
    }
}