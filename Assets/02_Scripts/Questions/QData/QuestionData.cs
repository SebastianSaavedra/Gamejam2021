using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="QuestionData", menuName ="Question", order =1)]
public class QuestionData : ScriptableObject
{
    public string Pregunta;
    public string RespuestaA;
    public string RespuestaB;
    [Header("Respuesta Correcta")]
    public bool a;
    public bool b;
    public Sprite bodyPartSprite;
    public Parts parts;
    public Sprite option1;
    public Sprite option2;
    public Sprite option3;
    public Sprite option4;
    [System.Serializable]
    public class Parts 
    {
    public enum BodyParts {head,body,legs,hands,feet,arms};
    public  BodyParts bodyParts;
    }
}
