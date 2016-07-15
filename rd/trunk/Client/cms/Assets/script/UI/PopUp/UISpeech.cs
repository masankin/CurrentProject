﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UISpeech : UIBase
{
    public static string ViewName = "UISpeech";

    public static void Open(string speechId, System.Action<float> callBack = null)
    {
        SpeechData info = StaticDataMgr.Instance.GetSpeechData(speechId);
        if (info == null)
        {
            Logger.Log("缺少本地数据配置…………");
            return;
        }
        GameObject go = UIMgr.Instance.OpenUI(UISpeech.ViewName);
        UISpeech speech = go.GetComponent<UISpeech>();
        speech.info = info;
        speech.endEvent = callBack;
        speech.ShowWithData(info);
    }


    public Button btnSkip;
    public Button btnNext;
    public Image imgNextTip;

    public Image imgCampA;
    public Image imgCampB;
    public Text textCampA;
    public Text textCampB;

    public Text textContent;


    private SpeechData info;
    private System.Action<float> endEvent;
    private int index = 0;

    private Image imgCurrent;
    private Text textCurrent;
    private string camp="";
    public string Camp
    {
        get { return info.speechList[index].campType; }
        set 
        {
            if (value!=camp)
            {
                SetCamp(value);
                camp = value;
            }
        }
    }
    void SetCamp(string camp)
    {

        if (camp=="a")
        {
            imgCampA.gameObject.SetActive(true);
            imgCampB.gameObject.SetActive(false);
            imgCurrent = imgCampA;
            textCurrent = textCampA;
        }
        else if(camp=="b")
        {
            imgCampB.gameObject.SetActive(true);
            imgCampA.gameObject.SetActive(false);
            imgCurrent = imgCampB;
            textCurrent = textCampB;
        }
        else
        {
            Logger.Log("error： 配置表阵营填写错误！！");
        }
    }


    void Start()
    {
        EventTriggerListener.Get(btnSkip.gameObject).onClick = OnClickSkip;
        EventTriggerListener.Get(btnNext.gameObject).onClick = OnClickNext;
    }

    public void ShowWithData(SpeechData info)
    {
        if (info.skip != "1")
            btnSkip.gameObject.SetActive(false);
        else
            btnSkip.gameObject.SetActive(true);
        index = 0;
        imgNextTip.gameObject.SetActive(true);
        SetSpeech(index);
    }

    void SetSpeech(int index)
    {
        if (index >= info.speechList.Count) { EndOfSpeech(); return; }
        if (index == (info.speechList.Count - 1)) { imgNextTip.gameObject.SetActive(false); }
        SpeechStaticData data = info.speechList[index];
        Camp = data.campType;
        imgCurrent.sprite = ResourceMgr.Instance.LoadAssetType<Sprite>(data.image);
        textCurrent.text = StaticDataMgr.Instance.GetTextByID(data.name);

        textContent.text = StaticDataMgr.Instance.GetTextByID(data.speakId);

    }

    void OnClickSkip(GameObject go)
    {
        EndOfSpeech();
    }

    void OnClickNext(GameObject go) 
    {
        SetSpeech(++index);
    }

    void EndOfSpeech()
    {
        if (endEvent!=null)
            endEvent(0.0f);
        UIMgr.Instance.CloseUI(this);
    }

}
