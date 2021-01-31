using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDownSendSignal : MonoBehaviour
{
    public enum Tematicas { nombre, figure, color, felicidad, odio, sabiduria, moral };
    public Tematicas tematica;
    [SerializeField] QuestionManager qm;
    public GameObject referenceObj;
    public List<Collider> col;
    [SerializeField] Material dit;

    private void Start()
    {
     
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
        referenceObj.GetComponent<SpriteRenderer>().material = dit;
        qm.AnswerA(tematica.ToString(),referenceObj);
        }
    }
}
