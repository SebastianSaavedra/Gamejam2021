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
    [SerializeField] Material spriteMaterial;
    [SerializeField] float fadeTime;
    [SerializeField] int questionid;
    [SerializeField] string currentBodyPart;
    [SerializeField] string sentBodyPart;
    public int stage;
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
    //who,color,existencia,dream,heart,hope,mind,fear,moral,outer
    [SerializeField] List<QuestionData> who_Data;
    [SerializeField] List<QuestionData> color_Data;
    [SerializeField] List<QuestionData> existencia_Data;
    [SerializeField] List<QuestionData> dream_Data;
    [SerializeField] List<QuestionData> heart_Data;
    [SerializeField] List<QuestionData> hope_Data;
    [SerializeField] List<QuestionData> mind_Data;
    [SerializeField] List<QuestionData> fear_Data;
    [SerializeField] List<QuestionData> moral_Data;
    [SerializeField] List<QuestionData> outer_Data;
    [Header("Saved Sprites")]
    List<GameObject> preguntasRespondidas;
    [Header("MusicStages")]
    #region music
    [SerializeField] AudioSource stage1;
    [SerializeField] AudioSource stage2;
    [SerializeField] AudioSource stage3;
    [SerializeField] AudioSource stage4;
    [SerializeField] AudioSource stage5;
    [SerializeField] AudioSource stage6;
    [SerializeField] AudioSource stage7;
    [SerializeField] AudioSource stage8;
    [SerializeField] AudioSource stage9;
    [SerializeField] AudioSource stage10;
    #endregion
    [Header("CanClick")]
    public static bool canClick;
    void Start()
    {
        questions.Add(who_Data[Random.Range(0,who_Data.Count)]);
        questions.Add(color_Data[Random.Range(0,color_Data.Count)]);
        questions.Add(existencia_Data[Random.Range(0,existencia_Data.Count)]);
        questions.Add(dream_Data[Random.Range(0,dream_Data.Count)]);
        questions.Add(heart_Data[Random.Range(0,heart_Data.Count)]);
        questions.Add(hope_Data[Random.Range(0,hope_Data.Count)]);
        questions.Add(mind_Data[Random.Range(0,mind_Data.Count)]);
        questions.Add(fear_Data[Random.Range(0,fear_Data.Count)]);
        questions.Add(moral_Data[Random.Range(0,moral_Data.Count)]);
        questions.Add(outer_Data[Random.Range(0,outer_Data.Count)]);
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
        GetComponent<AudioSource>().clip = questions[questionid].audio;
        GetComponent<AudioSource>().Play();
      foreach (GameObject answer in questions[questionid].answers) 
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
        canClick = false;
        sentObj = from;
        savedAnswers.Add(sentObj);
        switch (questions[questionid].parts.tematica) 
        {
            //who,color,existencia,dream,heart,hope,mind,fear,moral,outer
            case QuestionData.Parts.Tematicas.who:
                    sentObj.GetComponent<DitheringCullOff>().Desintegracion();
                break;
            case QuestionData.Parts.Tematicas.color:
                    sentObj.GetComponent<DitheringCullOff>().Desintegracion();                
                break;
            case QuestionData.Parts.Tematicas.existencia:
                    sentObj.GetComponent<DitheringCullOff>().Desintegracion();               
                break;
                case QuestionData.Parts.Tematicas.dream:
                    sentObj.GetComponent<DitheringCullOff>().Desintegracion();
                    break;
                case QuestionData.Parts.Tematicas.heart:
                    sentObj.GetComponent<DitheringCullOff>().Desintegracion();
                    break;
                case QuestionData.Parts.Tematicas.hope:
                    sentObj.GetComponent<DitheringCullOff>().Desintegracion();
                    break;
            case QuestionData.Parts.Tematicas.mind:
                sentObj.GetComponent<DitheringCullOff>().Desintegracion();
                break;
            case QuestionData.Parts.Tematicas.fear:
                sentObj.GetComponent<DitheringCullOff>().Desintegracion();
                break;
            case QuestionData.Parts.Tematicas.moral:
                sentObj.GetComponent<DitheringCullOff>().Desintegracion();
                break;
            case QuestionData.Parts.Tematicas.outer:
                sentObj.GetComponent<DitheringCullOff>().Desintegracion();
                break;
        }
        foreach (GameObject answer in answersInGame)
        {
            answer.GetComponent<SpriteRenderer>().DOFade(1, fadeTime);
        }
        foreach(GameObject panel in ActivePanels) 
        {
            foreach(Collider col in panel.GetComponent<OnMouseDownSendSignal>().col) 
            {
                col.enabled = false;
            }
         
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
            case 6:
                AudioSourceQueue(stage7);
                break;
            case 7:
                AudioSourceQueue(stage8);
                break;
            case 8:
                AudioSourceQueue(stage9);
                break;
            case 9:
                AudioSourceQueue(stage10);
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
        if (stage == 11) 
        {
            StartCoroutine(ShowEndSprites());
        }
        else 
        {
        StartCoroutine(ShowText());
        }
        yield break;
    }
    IEnumerator waitforFirstInput() 
    {
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        stage = 1;
        stage1.Play();
        stage2.Play();
        stage3.Play();
        stage4.Play();
        stage5.Play();
        stage6.Play();
        stage7.Play();
        stage8.Play();
        stage9.Play();
        stage10.Play();
        AudioSourceQueue(stage1);
        yield break;
    }

    IEnumerator ShowEndSprites() 
    {
        origin.Clear();
        canClick = true;
        foreach (Transform origins in savedorigin)
        {
            origin.Add(origins);
        }
        for (int x = 2; x < savedAnswers.Count; x++)
        {
            int y = Random.Range(0, origin.Count);
            savedAnswers[x].transform.position = origin[y].position;
            savedAnswers[x].GetComponent<SpriteRenderer>().material = spriteMaterial;
            origin[y].GetComponent<IntermediateScript>().panelReference.gameObject.SetActive(true);
            origin[y].GetComponent<IntermediateScript>().panelReference.GetComponent<OnMouseDownSendSignal>().referenceObj = savedAnswers[x];
            ActivePanels.Add(origin[y].GetComponent<IntermediateScript>().panelReference.gameObject);
            origin.RemoveAt(y);
        }
        foreach (GameObject answer in savedAnswers)
        {
            answer.GetComponent<SpriteRenderer>().DOFade(0, 0);
            answer.GetComponent<SpriteRenderer>().DOFade(1, fadeTime);
        }
        yield break;
    }
    public void CallStop() 
    {
        StartCoroutine(StopClicks());
    }
    IEnumerator StopClicks() 
    {
        canClick = false;
        yield return new WaitForSeconds(3f);
        canClick = true;
        yield break;
    }
    void AudioSourceQueue(AudioSource audio) 
    {
            audio.DOFade(.2f,15);
    }
}
