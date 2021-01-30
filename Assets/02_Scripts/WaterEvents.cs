using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEvents : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    [SerializeField] List<GameObject> objetos = new List<GameObject>();

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
            Debug.Log("Mouse is pressed down " + puedeDarClick);

            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo,Mathf.Infinity,layer))
            {
                Debug.Log("Object Hit is " + hitInfo.collider.gameObject.name);

                if (!primerEvento && hitInfo.collider.gameObject.name == "Agua")
                {
                    if (clicks != 5)
                    {
                        clicks++;
                        objetos[clicks].SetActive(true);
                    }
                    else
                    {
                        Debug.Log("Clicks = 5");
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
        Destroy(this);
        //puedeDarClick = true;
        yield break;
    }
}
