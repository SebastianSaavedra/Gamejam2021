using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ending : MonoBehaviour
{
    Material awaMat;
    //bool theEnd = false;
    //int clicks;

    //List<GameObject> dialogos = new List<GameObject>();
    

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Dissolve();
    //    }
    //}

    //private void OnMouseDown()
    //{
    //    if (!theEnd)
    //    {
    //        return;
    //    }

    //    else
    //    {
    //        Debug.Log("Llego al Endgame y ha clickeado: " + clicks + " veces");
    //        //dialogos[clicks - 1].SetActive(true);
    //    }
    //}

    public void Dissolve()
    {
        awaMat = GetComponent<Renderer>().material;
        awaMat.DOFloat(5f, "_Distortion", 100f);
    }
}
