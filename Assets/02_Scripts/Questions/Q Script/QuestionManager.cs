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
    void Start()
    {    
        questions.Add(head_Data[Random.Range(0,head_Data.Count)]);
        questions.Add(body_Data[Random.Range(0,body_Data.Count)]);
        questions.Add(legs_Data[Random.Range(0,legs_Data.Count)]);
        questions.Add(hands_Data[Random.Range(0,hands_Data.Count)]);
        questions.Add(feet_Data[Random.Range(0,feet_Data.Count)]);
        questions.Add(arms_Data[Random.Range(0,arms_Data.Count)]);
        StartCoroutine(ShowText());
       
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
        if (currentBodyPart == sentBodyPart) //prev questions[questionid].a
        {
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
        yield break;
    }
    IEnumerator HideText()
    {
        pregunta.DOFade(0, fadeTime);
        respuestaA.DOFade(0, fadeTime);
        respuestaB.DOFade(0, fadeTime);
        sprite.DOFade(0, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        questions.RemoveAt(questionid);
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(ShowText());
        yield break;
    }


}
