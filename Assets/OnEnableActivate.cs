using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableActivate : MonoBehaviour
{
    [SerializeField] GameObject objToActivate;
    private void OnEnable()
    {
        objToActivate.SetActive(true);
    }
}
