using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DitheringCullOff : MonoBehaviour
{
    Material ditheringObj;
    [SerializeField] Material mat;

    public void Desintegracion()
    {
        ditheringObj = GetComponent<Renderer>().material;
        ditheringObj.DOFloat(5f, "_Cutoff", 3.5f);
    }
}
