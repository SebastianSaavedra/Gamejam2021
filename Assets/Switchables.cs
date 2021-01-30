using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchables : MonoBehaviour
{
    public enum Poder {Saltar,Caminar,Vision,Oir};
    [SerializeField] Poder poder;
    [SerializeField] string pressedKey;
    [SerializeField] GameObject vision;
    void Start()
    {
        poder = Poder.Caminar;
    }

    // Update is called once per frame
    void Update()
    {     
        pressedKey=Input.inputString;
        SwitchPower(Input.inputString);
        Powers();
    }

    void SwitchPower(string input)
    {
        Debug.Log("FRAME 1?");
        switch (pressedKey)
        {
            case "1":
            poder = Poder.Saltar;
                break;
            case "2":
                poder = Poder.Caminar;
                break;
            case "3":
                poder = Poder.Vision;
                break;
            case "4":
                poder = Poder.Oir;
                break;
        }
    }

    void Powers() 
    {
        switch (poder) 
        {
            case Poder.Saltar:
                CPMovement.canMove = false;
                vision.SetActive(false);
                break;
            case Poder.Caminar:
                CPMovement.canMove = true;
                vision.SetActive(true);
                break;
            case Poder.Vision:
                CPMovement.canMove = false;
                vision.SetActive(false);
                break;
            case Poder.Oir:
                CPMovement.canMove = false;
                vision.SetActive(false);
                break;
        }
    }
}
