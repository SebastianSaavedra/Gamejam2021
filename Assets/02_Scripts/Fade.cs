using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] GameObject parent;
    void Start()
    {
        Image imgFade = GetComponent<Image>();
        imgFade.DOFade(0,5f);
        Destroy(parent,5.1f);
    }
}
