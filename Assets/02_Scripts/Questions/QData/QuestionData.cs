using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="QuestionData", menuName ="Question", order =1)]
public class QuestionData : ScriptableObject
{
    public string Pregunta;
    public string RespuestaA;
    public string RespuestaB;
    public int id;
}
