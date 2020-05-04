using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NavGame.misskiss;
using NavGame.Core;

public class UIMAN : MonoBehaviour
{
    public GameObject[] cooldownOBJs;
    public Text[] actionCosts;
    Image[] cooldownImages;
    void Start()
    {
        InitializeUI();
        LevelManager.instance.onActionSelect += OnActionSelect;
        LevelManager.instance.onActionCancel += OnActionCancel;
        LevelManager.instance.onActionCooldownUpdate += OnActionCooldownUpdate;
    }
    void InitializeUI()
    {
        cooldownImages = new Image[cooldownOBJs.Length];
        for (int i = 0; i < cooldownOBJs.Length; i++)
        {
            cooldownImages[i] = cooldownOBJs[i].GetComponent<Image>();
            cooldownImages[i].fillAmount = 0f;
        
            actionCosts[i].text = "(" + LevelManager.instance.actions[i].cost + ")";
        }

    }
    void OnActionSelect(int actionIndex)
    {
        cooldownImages[actionIndex].fillAmount = 1f;
    }
    void OnActionCancel(int actionIndex)
    {
        cooldownImages[actionIndex].fillAmount = 0f;
    }

    void OnActionCooldownUpdate(int actionIndex, float coolDown, float waitTime)
    {
        float percent = coolDown / waitTime;
        cooldownImages[actionIndex].fillAmount = percent;
    }
}
