using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class OnStart : MonoBehaviour
{
    private void OnEnable()
    {
        Image imagen = GetComponent<Image>();

        imagen.DOFade(.4f,5f);
    }
}
