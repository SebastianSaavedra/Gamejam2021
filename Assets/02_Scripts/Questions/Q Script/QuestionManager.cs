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
        questionid = Random.Range(0,questions.Count);      
        pregunta.text = questions[questionid].Pregunta;
        respuestaA.text = questions[questionid].RespuestaA;
        respuestaB.text = questions[questionid].RespuestaB;
        questions.RemoveAt(questionid);
    }

    public void AnswerA() 
    {
        StartCoroutine(HideText());
        switch (questions[questionid].id) 
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }
    public void AnswerB() 
    {
        StartCoroutine(HideText());
        switch (questions[questionid].id)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
        }
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
        StartCoroutine(ShowText());
        yield break;
    }



}
