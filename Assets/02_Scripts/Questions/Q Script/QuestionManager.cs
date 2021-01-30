using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class QuestionManager : MonoBehaviour
{
    [Header("BodyParts")]
    [SerializeField] GameObject Head;
    [SerializeField] GameObject body;
    [SerializeField] GameObject legs;
    [Header("Values")]
    [SerializeField] float fadeTime;
    [SerializeField] int questionid;
    [SerializeField] string currentBodyPart;
    [Header("Question")]
    [SerializeField] TextMeshProUGUI pregunta;
    [SerializeField] TextMeshProUGUI respuestaA;
    [SerializeField] TextMeshProUGUI respuestaB;
    [SerializeField] List<QuestionData> questions;
    void Start()
    {
        StartCoroutine(ShowText());
    }

   public void SelectQuestion() 
    {
        questionid = Random.Range(0, questions.Count);
        currentBodyPart = questions[questionid].parts.bodyParts.ToString();
        pregunta.text = questions[questionid].Pregunta;
        respuestaA.text = questions[questionid].RespuestaA;
        respuestaB.text = questions[questionid].RespuestaB;
    }

    public void AnswerA() 
    {
        if (questions[questionid].a) 
        {
        switch (questions[questionid].parts.bodyParts) 
        {
            case QuestionData.Parts.BodyParts.head:
                Head.SetActive(true);
                break;
            case QuestionData.Parts.BodyParts.body:
                body.SetActive(true);
                break;
            case QuestionData.Parts.BodyParts.legs:
                legs.SetActive(true);
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
                    Head.SetActive(true);
                    break;
                case QuestionData.Parts.BodyParts.body:
                    body.SetActive(true);
                    break;
                case QuestionData.Parts.BodyParts.legs:
                    legs.SetActive(true);
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
        yield break;
    }
    IEnumerator HideText()
    {
        pregunta.DOFade(0, fadeTime);
        respuestaA.DOFade(0, fadeTime);
        respuestaB.DOFade(0, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        questions.RemoveAt(questionid);
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(ShowText());
        yield break;
    }



}
