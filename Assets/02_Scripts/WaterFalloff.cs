using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFalloff : MonoBehaviour
{
    [SerializeField] [Range(-2, .5f)] private float fallOff;
    [SerializeField] private Material water;

    void Update()
    {
        water.SetFloat("_WaterFalloff",fallOff);
    }
}
