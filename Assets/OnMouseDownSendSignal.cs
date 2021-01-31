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
    AudioSource audio;

    private void Start()
    {
       // audio = GetComponent<AudioSource>();
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
        if(QuestionManager.canClick)
        {
        Debug.Log(transform.name);
        foreach(Collider cols in col) 
        {
            cols.enabled = false;
        }
       // audio.Play();
        referenceObj.GetComponent<SpriteRenderer>().material = dit;
        qm.AnswerA(tematica.ToString(),referenceObj);
        }
    }
}
