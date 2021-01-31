using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class QuestionManager : MonoBehaviour
{
    [Header("BodyParts3D")]
    [SerializeField] GameObject head;
    [SerializeField] GameObject body;
    [SerializeField] GameObject legs;
    [Header("BodyParts2D")]
    [SerializeField] SpriteRenderer sprite;
    [Header("Values")]
    [SerializeField] float fadeTime;
    [SerializeField] int questionid;
    [SerializeField] string currentBodyPart;
    [SerializeField] string sentBodyPart;
    [SerializeField] int stage;
    [SerializeField] GameObject sentObj;
    [Header("Question")]
    [SerializeField] TextMeshProUGUI pregunta;
    [SerializeField] TextMeshProUGUI respuestaA;
    [SerializeField] TextMeshProUGUI respuestaB;
    [SerializeField] List<QuestionData> questions;
    [Header("Question Feed")]
    [SerializeField] List<QuestionData> nombre_Data;
    [SerializeField] List<QuestionData> figura_Data;
    [SerializeField] List<QuestionData> color_Data;
    [SerializeField] List<QuestionData> felicidad_Data;
    [SerializeField] List<QuestionData> odio_Data;
    [SerializeField] List<QuestionData> sabiduria_Data;
    [SerializeField] List<QuestionData> moral_Data;
    [SerializeField] DitheringCullOff fadeAnim;
    [Header("Saved Sprites")]

    [Header("MusicStages")]
    [SerializeField] List<AudioSource> stage1;
    [SerializeField] List<AudioSource> stage2;
    [SerializeField] List<AudioSource> stage3;
    [SerializeField] List<AudioSource> stage4;
    [SerializeField] List<AudioSource> stage5;
    [SerializeField] List<AudioSource> stage6;
    [Header("CanClick")]
    public static bool canClick;
    void Start()
    {
        questions.Add(nombre_Data[Random.Range(0,nombre_Data.Count)]);
        questions.Add(figura_Data[Random.Range(0,figura_Data.Count)]);
        questions.Add(color_Data[Random.Range(0,color_Data.Count)]);
        questions.Add(felicidad_Data[Random.Range(0,felicidad_Data.Count)]);
        questions.Add(odio_Data[Random.Range(0,odio_Data.Count)]);
        questions.Add(sabiduria_Data[Random.Range(0,sabiduria_Data.Count)]);
        questions.Add(moral_Data[Random.Range(0,moral_Data.Count)]);
        StartCoroutine(ShowText());
        StartCoroutine(waitforFirstInput());
       
    }
   public void SelectQuestion() 
    {
        sprite.sprite = questions[questionid].tematicatSprite;
        currentBodyPart = questions[questionid].parts.tematica.ToString();
        pregunta.text = questions[questionid].Pregunta;
        respuestaA.text = questions[questionid].RespuestaA;
        respuestaB.text = questions[questionid].RespuestaB;
        questionid =  questionid + 1;
    }
    public void AnswerA(string sentBodyPart, GameObject from) 
    {
        sentObj = from;
        switch (questions[questionid].parts.tematica) 
        {
            case QuestionData.Parts.Tematicas.nombre:
                    sentObj.GetComponent<DitheringCullOff>().Desintegracion();
                break;
            case QuestionData.Parts.Tematicas.figure:
                    sentObj.GetComponent<DitheringCullOff>().Desintegracion();                
                break;
            case QuestionData.Parts.Tematicas.color:
                    sentObj.GetComponent<DitheringCullOff>().Desintegracion();               
                break;
                case QuestionData.Parts.Tematicas.felicidad:
                    sentObj.GetComponent<DitheringCullOff>().Desintegracion();
                    break;
                case QuestionData.Parts.Tematicas.odio:
                    sentObj.GetComponent<DitheringCullOff>().Desintegracion();
                    break;
                case QuestionData.Parts.Tematicas.sabiduria:
                    sentObj.GetComponent<DitheringCullOff>().Desintegracion();
                    break;
            case QuestionData.Parts.Tematicas.moral:
                sentObj.GetComponent<DitheringCullOff>().Desintegracion();
                break;
        }
        switch (stage) 
        {
            case 1:
                AudioSourceQueue(stage2);
                break;
            case 2:
                AudioSourceQueue(stage3);
                break;
            case 3:
                AudioSourceQueue(stage4);
                break;
            case 4:
                AudioSourceQueue(stage5);
                break;
            case 5:
                AudioSourceQueue(stage6);
                break;
        }
        StartCoroutine(HideText());
    }
    //public void AnswerB() 
    //{
    //    if (questions[questionid].b)
    //    {
    //        switch (questions[questionid].parts.tematica)
    //        {
    //            case QuestionData.Parts.Tematicas.head:
    //                break;
    //            case QuestionData.Parts.Tematicas.body:
                  
    //                break;
    //            case QuestionData.Parts.Tematicas.legs:
                 
    //                break;
    //        }
    //    }
    //        StartCoroutine(HideText());
    //}
    
    IEnumerator ShowText() 
    {
        SelectQuestion();
        pregunta.DOFade(1,fadeTime);
        respuestaA.DOFade(1,fadeTime);
        respuestaB.DOFade(1,fadeTime);
        sprite.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        canClick = true;
        yield break;
    }
    IEnumerator HideText()
    {
        canClick = false;
        pregunta.DOFade(0, fadeTime);
        respuestaA.DOFade(0, fadeTime);
        respuestaB.DOFade(0, fadeTime);
        sprite.DOFade(0, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        stage = stage + 1;
        questions.RemoveAt(questionid);
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(ShowText());
        yield break;
    }
    IEnumerator waitforFirstInput() 
    {
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        stage = 1;
        foreach (AudioSource audio in stage1) 
        {
            audio.Play();
        }
        foreach (AudioSource audio in stage2)
        {
            audio.Play();
        }
        foreach (AudioSource audio in stage3)
        {
            audio.Play();
        }
        foreach (AudioSource audio in stage4)
        {
            audio.Play();
        }
        foreach (AudioSource audio in stage5)
        {
            audio.Play();
        }
        foreach (AudioSource audio in stage6)
        {
            audio.Play();
        }
        AudioSourceQueue(stage1);
        yield break;
    }

    void AudioSourceQueue(List<AudioSource> list) 
    {
        foreach(AudioSource audio in list) 
        {
            audio.DOFade(1,20);
        }
    }
}
