using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDownSendSignal : MonoBehaviour
{
    public enum BodyPart { head, body, legs, hands, feet, arms };
    public BodyPart bodypart;
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
        qm.AnswerA(bodypart.ToString(),referenceObj);
        }
    }
}
