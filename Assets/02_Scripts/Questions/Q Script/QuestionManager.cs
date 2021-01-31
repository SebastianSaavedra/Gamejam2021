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
    [SerializeField] List<QuestionData> head_Data;
    [SerializeField] List<QuestionData> body_Data;
    [SerializeField] List<QuestionData> legs_Data;
    [SerializeField] List<QuestionData> hands_Data;
    [SerializeField] List<QuestionData> feet_Data;
    [SerializeField] List<QuestionData> arms_Data;
    [SerializeField] DitheringCullOff fadeAnim;
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
        questions.Add(head_Data[Random.Range(0,head_Data.Count)]);
        questions.Add(body_Data[Random.Range(0,body_Data.Count)]);
        questions.Add(legs_Data[Random.Range(0,legs_Data.Count)]);
        questions.Add(hands_Data[Random.Range(0,hands_Data.Count)]);
        questions.Add(feet_Data[Random.Range(0,feet_Data.Count)]);
        questions.Add(arms_Data[Random.Range(0,arms_Data.Count)]);
        StartCoroutine(ShowText());
        StartCoroutine(waitforFirstInput());
       
    }
   public void SelectQuestion() 
    {
        questionid = Random.Range(0, questions.Count);
        sprite.sprite = questions[questionid].bodyPartSprite;
        currentBodyPart = questions[questionid].parts.bodyParts.ToString();
        pregunta.text = questions[questionid].Pregunta;
        respuestaA.text = questions[questionid].RespuestaA;
        respuestaB.text = questions[questionid].RespuestaB;
    }
    public void AnswerA(string sentBodyPart, GameObject from) 
    {
        sentObj = from;
        switch (questions[questionid].parts.bodyParts) 
        {
            case QuestionData.Parts.BodyParts.head:
                    sentObj.GetComponent<DitheringCullOff>().Desintegracion();
                break;
            case QuestionData.Parts.BodyParts.body:
                    sentObj.GetComponent<DitheringCullOff>().Desintegracion();                
                break;
            case QuestionData.Parts.BodyParts.legs:
                    sentObj.GetComponent<DitheringCullOff>().Desintegracion();               
                break;
                case QuestionData.Parts.BodyParts.arms:
                    sentObj.GetComponent<DitheringCullOff>().Desintegracion();
                    break;
                case QuestionData.Parts.BodyParts.hands:
                    sentObj.GetComponent<DitheringCullOff>().Desintegracion();
                    break;
                case QuestionData.Parts.BodyParts.feet:
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
    public void AnswerB() 
    {
        if (questions[questionid].b)
        {
            switch (questions[questionid].parts.bodyParts)
            {
                case QuestionData.Parts.BodyParts.head:
                    break;
                case QuestionData.Parts.BodyParts.body:
                  
                    break;
                case QuestionData.Parts.BodyParts.legs:
                 
                    break;
            }
        }
            StartCoroutine(HideText());
    }
    
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
        AudioSourceQueue(stage1);
        yield break;
    }

    void AudioSourceQueue(List<AudioSource> list) 
    {
        foreach(AudioSource audio in list) 
        {
            audio.DOFade(1,10);
        }
    }
}
