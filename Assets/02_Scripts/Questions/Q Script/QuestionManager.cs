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
    [SerializeField] GameObject hands;
    [Header("BodyParts2D")]
    [SerializeField] SpriteRenderer sprite;
    [Header("Values")]
    [SerializeField] float fadeTime;
    [SerializeField] int questionid;
    [SerializeField] string currentBodyPart;
    [SerializeField] string sentBodyPart;
    [SerializeField] int stage;
    [SerializeField] List<GameObject> answers;
    [SerializeField] List<GameObject> answersInGame;
    [SerializeField] List<GameObject> savedAnswers;
    [SerializeField] List<GameObject> ActivePanels;
    [SerializeField] List<Transform> origin;
    [SerializeField] List<Transform> savedorigin;
    [SerializeField] Transform savedAorigin;
    [SerializeField] GameObject sentObj;
    [Header("Question")]
    [SerializeField] TextMeshProUGUI pregunta;
    [SerializeField] TextMeshProUGUI respuestaA;
    [SerializeField] TextMeshProUGUI respuestaB;
    [SerializeField] List<QuestionData> questions;
    [SerializeField] GameObject objectToWaitFor;
    [Header("Question Feed")]
    [SerializeField] List<QuestionData> nombre_Data;
    [SerializeField] List<QuestionData> figura_Data;
    [SerializeField] List<QuestionData> color_Data;
    [SerializeField] List<QuestionData> felicidad_Data;
    [SerializeField] List<QuestionData> odio_Data;
    [SerializeField] List<QuestionData> sabiduria_Data;
    [SerializeField] List<QuestionData> moral_Data;
    [Header("Saved Sprites")]
    List<GameObject> preguntasRespondidas;
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
        StartCoroutine(OnStartUp());
        StartCoroutine(waitforFirstInput());
       
    }
   public void SelectQuestion() 
    {
        origin.Clear();
        foreach (Transform origins in savedorigin)
        {
           origin.Add(origins);
        }
        //sprite.sprite = questions[questionid].tematicatSprite;
        currentBodyPart = questions[questionid].parts.tematica.ToString();
        Debug.Log(questionid);
        pregunta.text = questions[questionid].Pregunta;
        //respuestaA.text = questions[questionid].RespuestaA;
        //respuestaB.text = questions[questionid].RespuestaB;
      foreach(GameObject answer in questions[questionid].answers) 
        {
            answers.Add(answer);
        }
      for(int x = 0; x < answers.Count; x++) 
        {
            int y = Random.Range(0, origin.Count);
           GameObject obj= Instantiate(answers[x], origin[y].position, origin[y].rotation);
            Debug.Log("Removed " +obj.name);
            obj.transform.parent = hands.transform;
            origin[y].GetComponent<IntermediateScript>().panelReference.gameObject.SetActive(true);
            origin[y].GetComponent<IntermediateScript>().panelReference.referenceObj = obj;
            ActivePanels.Add(origin[y].GetComponent<IntermediateScript>().panelReference.gameObject);
            answersInGame.Add(obj);
            answers.RemoveAt(x);
            origin.RemoveAt(y);
        }
        if (answers.Count == 1) 
        {
            int y = Random.Range(0, origin.Count);
            GameObject obj= Instantiate(answers[0], origin[y].position, origin[y].rotation);
            Debug.Log("Removed " + answers[0].name);
            obj.transform.parent = hands.transform;
            origin[y].GetComponent<IntermediateScript>().panelReference.gameObject.SetActive(true);
            origin[y].GetComponent<IntermediateScript>().panelReference.referenceObj = obj;
            ActivePanels.Add(origin[y].GetComponent<IntermediateScript>().panelReference.gameObject);
            answersInGame.Add(obj);
            answers.RemoveAt(0);
            origin.RemoveAt(y);
        }
    }
    public void AnswerA(string sentBodyPart, GameObject from) 
    {
        sentObj = from;
        savedAnswers.Add(sentObj);
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
        foreach (GameObject answer in answersInGame)
        {
            answer.GetComponent<SpriteRenderer>().DOFade(1, fadeTime);
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

    IEnumerator OnStartUp() 
    {
        yield return new WaitUntil(()=> objectToWaitFor.activeInHierarchy==true);
        StartCoroutine(ShowText());
        yield break;
    }
    
    IEnumerator ShowText() 
    {
        yield return new WaitForSeconds(0.2f);
        SelectQuestion();
        pregunta.DOFade(1,fadeTime);
        //respuestaA.DOFade(1,fadeTime);
        //respuestaB.DOFade(1,fadeTime);
        sprite.DOFade(1, fadeTime);
        foreach(GameObject answer in answersInGame) 
        {
            answer.GetComponent<SpriteRenderer>().DOFade(1, fadeTime);
        }
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
        foreach (GameObject answer in answersInGame)
        {
            answer.GetComponent<SpriteRenderer>().DOFade(0,fadeTime);
        }
        yield return new WaitForSeconds(fadeTime);
        foreach (GameObject answer in answersInGame) 
        {
            if (sentObj != answer) 
            {
            Destroy(answer);
            }
        }
        sentObj.transform.position = savedAorigin.position;
        answersInGame.Clear();
        foreach(GameObject panel in ActivePanels) 
        {
            panel.SetActive(false);
        }
        ActivePanels.Clear();
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
