using UnityEngine;

public class Komputer : MonoBehaviour
{
    [SerializeField]
    private ushort zdrowiePrzeciwnika = 100;

    private void Obrazenia(ushort poziomUszkodzen)
    {
        zdrowiePrzeciwnika -= poziomUszkodzen;
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
