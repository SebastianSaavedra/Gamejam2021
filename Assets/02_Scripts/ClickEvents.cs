using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ClickEvents : MonoBehaviour
{
    //[SerializeField] LayerMask layer;
    //[SerializeField] List<GameObject> objetos = new List<GameObject>();
    //[SerializeField] GameObject panel;
    [SerializeField] AudioClip[] clips;
    [SerializeField] GameObject[] tm;
    AudioSource audio;
    [SerializeField] GameObject you;

    int clicks;
    bool puedeDarClick = true;
    //bool primerEvento = false;

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
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity/*, layer*/))
            {
                Debug.Log("Object Hit is " + hitInfo.collider.gameObject.name);

                //if (!primerEvento)
                //{
                //    if (clicks != objetos.Count)
                //    {

                clicks++;
                audio.clip = clips[clicks-1];
                tm[clicks - 1].SetActive(true);
                audio.volume = audio.volume + .1f;
                audio.Play();
                //objetos[clicks - 1].SetActive(true);
                if (clicks == 5) 
                {
                    GetComponent<QuestionManager>().stage1.DOFade(0, 15);
                    GetComponent<QuestionManager>().stage2.DOFade(0, 15);
                    GetComponent<QuestionManager>().stage3.DOFade(0, 15);
                    GetComponent<QuestionManager>().stage4.DOFade(0, 15);
                    GetComponent<QuestionManager>().stage5.DOFade(0, 15);
                    GetComponent<QuestionManager>().stage6.DOFade(0, 15);
                    GetComponent<QuestionManager>().stage7.DOFade(0, 15);
                    GetComponent<QuestionManager>().stage8.DOFade(0, 15);
                    GetComponent<QuestionManager>().stage9.DOFade(0, 15);
                    GetComponent<QuestionManager>().stage10.DOFade(0, 15);
                    you.GetComponent<Ending>().Dissolve();
                }
                Debug.Log("Clicks = " + clicks);
                StartCoroutine(timer());

                //if (clicks == objetos.Count)
                //{
                //    clicks = 0;
                //    StartCoroutine(Espera());
                //}
                //    }
                //}
            }
        }
    }

    IEnumerator timer()
    {
        puedeDarClick = false;
        yield return new WaitForSeconds(3f);
        puedeDarClick = true;
        yield break;
    }

    //IEnumerator Espera()
    //{
    //    puedeDarClick = false;
    //    primerEvento = true;
    //    yield return new WaitForSeconds(3.5f);
    //    //foreach (GameObject item in objetos)
    //    //{
    //    //    item.GetComponent<Renderer>().material = ditherMaterial;
    //    //}
    //    panel.SetActive(true);
    //    yield return new WaitForSeconds(.1f);
    //    Destroy(this);
    //    //puedeDarClick = true;
    //    yield break;
    //}
}
