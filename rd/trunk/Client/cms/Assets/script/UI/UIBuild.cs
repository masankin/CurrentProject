﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIBuild : UIBase,PopupListIndextDelegate
{
    public static string ViewName = "UIBuild";

    public Button m_PatButton;
    public Button m_ItemButton;
	public	Button	instanceButton;

    public Button m_QuestButton;
    public Button m_SpeechButton;
    public InputField m_SpeechInput;

    public PopupList m_LangPopup;

	public Text levelText;
	public Text coinText;
	public Text nameText;


    // Use this for initialization
    void Start()
    {
        EventTriggerListener.Get(m_PatButton.gameObject).onClick = PatButtonClick;
        EventTriggerListener.Get(m_ItemButton.gameObject).onClick = ItemButtonClick;
        EventTriggerListener.Get(instanceButton.gameObject).onClick = OnInstanceButtonClick;
        EventTriggerListener.Get(m_QuestButton.gameObject).onClick = OnQuestButtonClick;
        EventTriggerListener.Get(m_SpeechButton.gameObject).onClick = OnSpeechButtonClick;

        m_LangPopup.Initialize<PopupListIndextDelegate>(this);
        m_LangPopup.AddItem((int)Language.Chinese, StaticDataMgr.Instance.GetTextByID("ui_chinese"));
        m_LangPopup.AddItem((int)Language.English, StaticDataMgr.Instance.GetTextByID("ui_english"));
        m_LangPopup.SetSelection((int)LanguageMgr.Instance.Lang);

        //levelText.text = GameDataMgr.Instance.PlayerDataAttr.level.ToString ();
        //coinText.text = GameDataMgr.Instance.PlayerDataAttr.coin.ToString ();
        //nameText.text = GameDataMgr.Instance.PlayerDataAttr.nickName;
		BindListener ();
    }

	void OnDestroy()
	{
		UnBindListener ();
	}

	void BindListener()
	{
		GameEventMgr.Instance.AddListener<int> (GameEventList.LevelChanged, OnLevelChanged);
		GameEventMgr.Instance.AddListener<long> (GameEventList.CoinChanged, OnCoinChanged);

		GameEventMgr.Instance.AddListener<ProtocolMessage> (PB.code.MONSTER_CATCH_S.GetHashCode().ToString(),OnCachMonsterFinished);
	}

	void UnBindListener()
	{
		GameEventMgr.Instance.RemoveListener<int> (GameEventList.LevelChanged, OnLevelChanged);
		GameEventMgr.Instance.RemoveListener<long> (GameEventList.CoinChanged, OnCoinChanged);

		GameEventMgr.Instance.RemoveListener<ProtocolMessage> (PB.code.MONSTER_CATCH_S.GetHashCode().ToString(),OnCachMonsterFinished);
	}

	void OnLevelChanged(int level)
	{
		levelText.text = level.ToString ();
		nameText.text = GameDataMgr.Instance.PlayerDataAttr.nickName;
	}

	void OnCoinChanged(long coin)
	{
		coinText.text = coin.ToString ();
	}

    void ItemButtonClick(GameObject go)
    {
        UIMgr.Instance.OpenUI(UIBag.ViewName);
    }

    void PatButtonClick(GameObject go)
    {
        UIMgr.Instance.OpenUI(UIPetList.ViewName);
    }

	void OnInstanceButtonClick(GameObject go)
	{
		//PB.HSMonsterCatch mcache = new PB.HSMonsterCatch ();
	//	mcache.cfgId = "Unit_Demo_qingniao";// Unit_Demo_jiuweihu  Unit_Demo_qingniao.

	//	GameApp.Instance.netManager.SendMessage (ProtocolMessage.Create (PB.code.MONSTER_CATCH_C.GetHashCode(), mcache));

		UIMgr.Instance.OpenUI (UIInstance.ViewName);
	}

    void OnQuestButtonClick(GameObject go)
    {
        UIMgr.Instance.OpenUI(UIQuest.ViewName);
    }

    void OnSpeechButtonClick(GameObject go)
    {
        //UISpeech.Open(m_SpeechInput.text);
        //AudioSystemMgr.Instance.PlaySound(go,SoundType.Click);
        PB.HSMonsterCatch mcache = new PB.HSMonsterCatch();

        mcache.cfgId = m_SpeechInput.text.ToString();// Unit_Demo_jiuweihu  Unit_Demo_qingniao.
        UnitData monster = StaticDataMgr.Instance.GetUnitRowData(mcache.cfgId);
        if (monster == null) return;
        ArrayList spellArrayList = MiniJsonExtensions.arrayListFromJson(monster.spellIDList);
        for (int i = 0; i < spellArrayList.Count; ++i)
        {
            string spellID = spellArrayList[i] as string;
            mcache.skill.Add(new PB.HSSkill() { skillId = spellID, level = 2 });
        }	

        GameApp.Instance.netManager.SendMessage(ProtocolMessage.Create(PB.code.MONSTER_CATCH_C.GetHashCode(), mcache));
    }

	void OnCachMonsterFinished(ProtocolMessage msg)
    {
        if (msg == null)
            return;
        PB.HSMonsterCatchRet result = msg.GetProtocolBody<PB.HSMonsterCatchRet>();
        if (result!=null&&result.status==1)
        {
            GameObject go = new GameObject("tips");
            go.transform.parent = m_SpeechButton.transform;
            go.transform.localPosition = new Vector3(50, 50, -10);
            Text tex = go.AddComponent<Text>();
            tex.text = "获取成功";

            Destroy(go, 5.0f);
        }
        
	}

    public void OnPopupListChanged(int index)
    {
        Language lang = (Language)index;
        if (lang != LanguageMgr.Instance.Lang)
        {
            LanguageMgr.Instance.Lang = lang;
            m_LangPopup.RefrshItem((int)Language.Chinese, StaticDataMgr.Instance.GetTextByID("ui_chinese"));
            m_LangPopup.RefrshItem((int)Language.English, StaticDataMgr.Instance.GetTextByID("ui_english"));
            //GameMain.Instance.ChangeModule<LoginModule>();
        }
    }
}
