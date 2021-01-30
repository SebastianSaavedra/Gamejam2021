using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DitheringCullOff : MonoBehaviour
{
    Material ditheringObj;

    private void Start()
    {
        ditheringObj = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Desintegracion();
        }
    }

    void Desintegracion()
    {
        ditheringObj.DOFloat(5f, "_Cutoff", 3.5f);
    }
}
