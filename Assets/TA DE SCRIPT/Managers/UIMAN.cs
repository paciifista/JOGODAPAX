using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NavGame.misskiss;
using NavGame.Core;

public class UIMAN : MonoBehaviour
{
    public GameObject errorPanel;
    public Text errorText;
    public float errorTime = 1.5f;
    public Text coinText;
    public GameObject[] cooldownOBJs;
    public Text[] actionCosts;
    Image[] cooldownImages;
    
    void Awake()
    {
        LevelManager.instance.onActionSelect += OnActionSelect;
        LevelManager.instance.onActionCancel += OnActionCancel;
        LevelManager.instance.onActionCooldownUpdate += OnActionCooldownUpdate;
        LevelManager.instance.onResourceUpdate += OnResourceUpdate;   
        LevelManager.instance.onReportableError += OnReportableError;
    }
    
    
    
    void Start()
    {
        InitializeUI();
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
        errorPanel.SetActive(false);

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

    void OnResourceUpdate(int currentAmount)
    {
        coinText.text = "x" + currentAmount; 
    }
    void OnReportableError(string message)
    {
        errorText.text = message;
        errorPanel.SetActive(true);
        StartCoroutine(TurnOffError());
    }
    IEnumerator TurnOffError()
    {
        yield return new WaitForSeconds(errorTime);
        errorPanel.SetActive(false);
    }
}
