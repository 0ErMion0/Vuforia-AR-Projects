using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoardW61 : MonoBehaviour
{
    public Transform Camtr;


    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camtr.transform);
        transform.Rotate(0, 180, 0);
    }
}
