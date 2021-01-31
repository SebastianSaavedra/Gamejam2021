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
    public Sprite tematicatSprite;
    public Parts parts;
    public List<GameObject> answers;
    [System.Serializable]
    public class Parts 
    {
    public enum Tematicas {nombre,figure,color,felicidad,odio,sabiduria,moral};
    public  Tematicas tematica;
    }
}
