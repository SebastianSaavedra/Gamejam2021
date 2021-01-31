using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class WaterEvents : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    [SerializeField] List<GameObject> objetos = new List<GameObject>();
    [SerializeField] GameObject panel;
    [SerializeField] GameObject canvasPanelesOscuros;
    [SerializeField] AudioClip[] clips;
     AudioSource audio;

    //[Header("Material")]
    //[SerializeField] Material ditherMaterial;

    int clicks;
    bool puedeDarClick = true;
    bool primerEvento = false;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = clips[0];
        audio.volume = 0.1f;
        audio.Play();
    }
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
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity, layer))
            {
                Debug.Log("Object Hit is " + hitInfo.collider.gameObject.name);

                if (!primerEvento)
                {
                    if (clicks != objetos.Count)
                    {
                        audio.clip = clips[clicks + 1];
                        audio.volume = audio.volume + .1f;
                        audio.Play();
                        objetos[clicks].GetComponent<Image>().DOFade(0f, 3f);
                        clicks++;
                        //objetos[clicks - 1].SetActive(true);
                        Debug.Log("Clicks = " + clicks);
                        if (clicks == objetos.Count)
                        {
                            clicks = 0;
                            StartCoroutine(Espera());
                        }
                    }
                }
            }
            StartCoroutine(timer());
        }
    }
    IEnumerator timer()
    {
        puedeDarClick = false;
        yield return new WaitForSeconds(3f);
        puedeDarClick = true;
        yield break;
    }

    IEnumerator Espera()
    {
        puedeDarClick = false;
        primerEvento = true;
        yield return new WaitForSeconds(3.5f);
        foreach (GameObject item in objetos)
        {
            item.SetActive(false);
        }
        panel.SetActive(true);
        canvasPanelesOscuros.SetActive(false);
        yield return new WaitForSeconds(.1f);
        Destroy(this);
        //puedeDarClick = true;
        yield break;
    }
}
