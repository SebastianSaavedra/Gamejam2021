using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDownSendSignal : MonoBehaviour
{
    public enum Tematicas { nombre, figure, color, felicidad, odio, sabiduria, moral };
    public Tematicas tematica;
    [SerializeField] QuestionManager qm;
    [SerializeField] GameObject referenceObj;
    public List<Collider> col;

    private void Start()
    {
     
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
        qm.AnswerA(tematica.ToString(),referenceObj);
        }
    }
}
