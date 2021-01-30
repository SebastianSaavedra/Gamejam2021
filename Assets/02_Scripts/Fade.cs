using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    void Start()
    {
        Image imgFade = GetComponent<Image>();
        imgFade.DOFade(0,5f);
        Destroy(gameObject,5.1f);
    }
}
