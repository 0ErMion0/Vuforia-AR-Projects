using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrlW5 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 1, 0, Space.World);
    }
}
