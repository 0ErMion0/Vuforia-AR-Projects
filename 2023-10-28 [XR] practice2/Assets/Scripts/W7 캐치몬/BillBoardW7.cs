using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoardW7 : MonoBehaviour
{
    public Transform camTr;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(camTr.transform, Vector3.up);
        //transform.Rotate(0, 180, 0);
    }
}
