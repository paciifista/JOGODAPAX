using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMAN : MonoBehaviour
{
    public GameObject[] cooldownOBJs;
    Image[] cooldownImages; 
    void Start()
    {
        InitializeUI();
    }
    void InitializeUI()
    {
        cooldownImages = new Image [cooldownOBJs.Length];
        for (int i = 0; i < cooldownOBJs.Length; i++)
        {
            cooldownImages[i] = cooldownOBJs[i].GetComponent<Image>();
            cooldownImages[i].fillAmount = 0f;
        }

    }
}
