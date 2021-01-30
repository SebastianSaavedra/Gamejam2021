﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEvents : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    [SerializeField] List<GameObject> objetos = new List<GameObject>();
    [SerializeField] GameObject panel;

    int clicks;
    bool puedeDarClick = true;
    bool primerEvento = false;
    void Update()
    {
        IsClicked();
    }

    void IsClicked()
    {
        if (puedeDarClick && Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Mouse is pressed down " + puedeDarClick);

            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo,Mathf.Infinity,layer))
            {
                Debug.Log("Object Hit is " + hitInfo.collider.gameObject.name);

                if (!primerEvento)
                {
                    if (clicks != objetos.Count - 1)
                    {
                        clicks++;
                        objetos[clicks].SetActive(true);
                    }
                    else
                    {
                        Debug.Log("Clicks = " + objetos.Count);
                        clicks = 0;
                        StartCoroutine(Espera());
                    }
                }
            }
        }
    }

    IEnumerator Espera()
    {
        puedeDarClick = false;
        primerEvento = true;
        yield return new WaitForSeconds(3.5f);
        panel.SetActive(true);
        yield return new WaitForSeconds(.1f);
        Destroy(this);
        //puedeDarClick = true;
        yield break;
    }
}