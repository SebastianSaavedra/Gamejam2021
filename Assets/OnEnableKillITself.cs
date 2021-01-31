using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class OnEnableKillITself : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        GetComponent<TextMeshProUGUI>().DOFade(1,3);
        Destroy(gameObject,3.1f);
    }
}
