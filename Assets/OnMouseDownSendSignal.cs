using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDownSendSignal : MonoBehaviour
{
    public enum BodyPart { head, body, legs, hands, feet, arms };
    public BodyPart bodypart;
    [SerializeField] QuestionManager qm;
    [SerializeField] GameObject referenceObj;


    private void OnMouseDown()
    {
        Debug.Log("T");
        qm.AnswerA(bodypart.ToString(),referenceObj);
    }
}
