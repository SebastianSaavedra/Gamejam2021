using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDownSendSignal : MonoBehaviour
{
    public enum Tematicas { who, color, existencia, dream, heart, hope, mind, fear, moral, outer };
    public Tematicas tematica;
    [SerializeField] QuestionManager qm;
    public GameObject referenceObj;
    public List<Collider> col;
    [SerializeField] Material dit;
    [SerializeField] AudioClip[] clips;
    [SerializeField] AudioClip[] clicks;
    AudioSource audio;
    [SerializeField] GameObject[] toChange;
    [SerializeField] GameObject currentActive;
    [SerializeField] int fadeout;

    private void Start()
    {
       audio = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        foreach (Collider cols in col)
        {
            cols.enabled = true;
        }
    }
    private void OnMouseDown()
    {
        if (qm.stage==11 && QuestionManager.canClick)
        {
            qm.CallStop();
            referenceObj.GetComponent<SpriteRenderer>().material = dit;
            referenceObj.GetComponent<DitheringCullOff>().Desintegracion();
           switch (referenceObj.GetComponent<IconTheme>().tematica) 
            {
                //who, color, existencia, dream, heart, hope, mind, fear, moral, outer
                case IconTheme.Tematicas.existencia:
                    audio.clip = clips[0];
                    qm.KillSaved(2);
                    break;
                case IconTheme.Tematicas.dream:
                    audio.clip = clips[1];
                    qm.KillSaved(2);
                    break;
                case IconTheme.Tematicas.heart:
                    audio.clip = clips[2];
                    qm.KillSaved(2);
                    break;

                case IconTheme.Tematicas.hope:
                    audio.clip = clips[3];
                    qm.KillSaved(2);
                    break;
                case IconTheme.Tematicas.mind:
                    audio.clip = clips[4];
                    qm.KillSaved(2);
                    break;
                case IconTheme.Tematicas.fear:
                    audio.clip = clips[5];
                    qm.KillSaved(2);
                    break;
                case IconTheme.Tematicas.moral:
                    audio.clip = clips[6];
                    qm.KillSaved(2);
                    break;
                case IconTheme.Tematicas.outer:
                    audio.clip = clips[7];
                    qm.KillSaved(2);
                    break;
            }
            audio.Play();

            Destroy(referenceObj,3);
        }
        else 
        { 
        if(QuestionManager.canClick)
        {
        Debug.Log(transform.name);
        foreach(Collider cols in col) 
        {
            cols.enabled = false;
        }
        audio.clip = clicks[Random.Range(0, clicks.Length)];
        audio.Play();
        referenceObj.GetComponent<SpriteRenderer>().material = dit;
                qm.AnswerA(tematica.ToString(), referenceObj);

                if (referenceObj.GetComponent<FindIcon>()) 
                {
                    if (referenceObj.GetComponent<FindIcon>().iconToFind == "Espada")
                    {
                        toChange[0].SetActive(true);
                    }
                    if (referenceObj.GetComponent<FindIcon>().iconToFind == "Escudo")
                    {
                        toChange[1].SetActive(true);
                    }
                    if (referenceObj.GetComponent<FindIcon>().iconToFind == "Corazon")
                    {
                        toChange[2].SetActive(true);
                    }
                }
                if (referenceObj.GetComponent<ChangeColor>()) 
                {
                    if (referenceObj.GetComponent<ChangeColor>().color == "red")
                    {
                        foreach (GameObject obj in toChange) 
                        {
                            if (obj != null) 
                            {
                        obj.GetComponent<SpriteRenderer>().color = referenceObj.GetComponent<ChangeColor>().color1;
                            }
                        }
                    }
                    if (referenceObj.GetComponent<ChangeColor>().color == "green")
                    {
                        foreach (GameObject obj in toChange)
                        {
                            if (obj != null)
                            {
                                obj.GetComponent<SpriteRenderer>().color = referenceObj.GetComponent<ChangeColor>().color2;
                            }
                        }
                    }
                    if (referenceObj.GetComponent<ChangeColor>().color == "blue")
                    {
                        foreach (GameObject obj in toChange)
                        {
                            if (obj != null)
                            {
                                obj.GetComponent<SpriteRenderer>().color = referenceObj.GetComponent<ChangeColor>().color3;
                            }
                        }
                    }
                }
        }
        }
    }
}
