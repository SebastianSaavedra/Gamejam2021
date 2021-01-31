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
    public AudioClip audio;
    [System.Serializable]
    public class Parts 
    {
    public enum Tematicas {who,color,existencia,dream,heart,hope,mind,fear,moral,outer};
    public  Tematicas tematica;
    }
}
