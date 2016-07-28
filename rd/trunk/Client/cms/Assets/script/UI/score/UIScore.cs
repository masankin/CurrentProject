﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class UIScore : UIBase 
{
    public static string ViewName = "UIScore";

    public GameObject mPlayerInfoRoot;
    public Text mPlayerLvl;
    public UIProgressbar mPlayerProgress;
    public Text mPlayerGainExp;
    public Text mPlayerGainGold;
    public GameObject mPlayerLvlUp;
    public Sprite mVictorySprite;
    public Sprite mFailedSprite;
    public GameObject mScoreBack;
    
    //internal use only
    public RectTransform mCenterPos;
    public RectTransform mTopPos;

    public Button mRetryBtn;
    public Button mNextLevelBtn;
    public Button mConfirmBtn;
    public Text mRetryText;
    public Text mNextLevelText;
    public Text mConfirmText;

    public RectTransform mMonsterExpList;
    public RectTransform mItemGainList;

    public GameObject mBackground;
    public GameObject mLineMonsterItem;

    private UIGainPet mGainPetUI;
    private GameObject mEndBattleUI;

    private bool mIsSuccess;
    private PB.HSRewardInfo mInstanceSettleResult;
    private Dictionary<long, UIMonsterIconExp> mUIMonsterExpList = new Dictionary<long, UIMonsterIconExp>();
    private bool mSkipEnable = false;
    private Tweener mBattleTitleTw;

    //---------------------------------------------------------------------------------------------
    void Start()
    {
        EventTriggerListener.Get(mRetryBtn.gameObject).onClick = OnRetry;
        EventTriggerListener.Get(mNextLevelBtn.gameObject).onClick = OnNextLevel;
        EventTriggerListener.Get(mConfirmBtn.gameObject).onClick = OnConfirm;
        EventTriggerListener.Get(mScoreBack.gameObject).onClick = SkipScoreAni;
    }
    //---------------------------------------------------------------------------------------------
    void OnEnable()
    {
    }
    //---------------------------------------------------------------------------------------------
    void OnDisable()
    {
    }
    //---------------------------------------------------------------------------------------------
    void OnRetry(GameObject go)
    {
        BattleController.Instance.UnLoadBattleScene(2);
    }
    //---------------------------------------------------------------------------------------------
    void OnNextLevel(GameObject go)
    {
        BattleController.Instance.UnLoadBattleScene(1);
    }
    //---------------------------------------------------------------------------------------------
    void OnConfirm(GameObject go)
    {
        BattleController.Instance.UnLoadBattleScene(0);
    }
    //---------------------------------------------------------------------------------------------
    void SkipScoreAni(GameObject go)
    {
        if (mSkipEnable == true)
        {
            mSkipEnable = false;
            if (mBattleTitleTw != null)
            {
                mBattleTitleTw.Complete();
            }
            mPlayerProgress.SkipAnimation();

            var itor = mUIMonsterExpList.GetEnumerator();
            while (itor.MoveNext())
            {
                itor.Current.Value.SkipAnimation();
            }
        }
    }
    //---------------------------------------------------------------------------------------------
    void Awake()
    {
        gameObject.SetActive(false);
    }
    //---------------------------------------------------------------------------------------------
    public override void Init()
    {
        base.Init();

        mSkipEnable = false;
        mUIMonsterExpList.Clear();
        mPlayerInfoRoot.SetActive(false);
        mMonsterExpList.gameObject.SetActive(false);
        mItemGainList.gameObject.SetActive(false);
        mRetryBtn.gameObject.SetActive(false);
        mNextLevelBtn.gameObject.SetActive(false);
        mConfirmBtn.gameObject.SetActive(false);
        mBackground.SetActive(false);
        mLineMonsterItem.SetActive(false);
        mRetryText.text = StaticDataMgr.Instance.GetTextByID("ui_battle_again");
        mNextLevelText.text = StaticDataMgr.Instance.GetTextByID("ui_battle_next");
        mConfirmText.text = StaticDataMgr.Instance.GetTextByID("ui_queding");
    }
    //---------------------------------------------------------------------------------------------
    public override void Clean()
    {
        base.Clean();
        mUIMonsterExpList.Clear();
        mBattleTitleTw = null;
        ResourceMgr.Instance.DestroyAsset(mEndBattleUI);
    }
    //---------------------------------------------------------------------------------------------
    public void ShowScoreUI(bool success)
    {
        mIsSuccess = success;
        gameObject.SetActive(true);
        if (mInstanceSettleResult != null)
        {
            int count = mInstanceSettleResult.RewardItems.Count;
            for (int i = 0; i < count; ++i)
            {
                PB.RewardItem item = mInstanceSettleResult.RewardItems[i];
                if (item.type == (int)PB.itemType.MONSTER)
                {
                    UnitData unitRowData = StaticDataMgr.Instance.GetUnitRowData(item.itemId);
                    if (unitRowData != null && unitRowData.grade >= 3)
                    {
                        AddGainMonster(item.itemId, item.level, item.stage);
                        return;
                    }

                    break;
                }
            }
        }

        ShowEndBattleUI();
    }
    //---------------------------------------------------------------------------------------------
    private void AddGainMonster(string monsterID, int level, int stage)
    {
        mGainPetUI = UIMgr.Instance.OpenUI_(UIGainPet.ViewName) as UIGainPet;
        mGainPetUI.transform.SetParent(transform, false);
        mGainPetUI.ShowGainPet(monsterID);
        mGainPetUI.SetConfirmCallback(ConfirmGainPet);
        //add monster icon
        MonsterIcon icon = MonsterIcon.CreateIcon();
        icon.transform.SetParent(mItemGainList.transform, false);
        icon.SetMonsterStaticId(monsterID);
        icon.SetLevel(level);
        icon.SetStage(stage);
    }
    //---------------------------------------------------------------------------------------------
    private void ConfirmGainPet(GameObject go)
    {
        UIMgr.Instance.DestroyUI(mGainPetUI);
        ShowEndBattleUI();
    }
    //---------------------------------------------------------------------------------------------
    private void ShowEndBattleUI()
    {
        SetScoreInternal();
        mEndBattleUI = ResourceMgr.Instance.LoadAsset("endBattle");
        mEndBattleUI.transform.SetParent(transform, false);
        mEndBattleUI.transform.localPosition = mCenterPos.localPosition;
        Image endImage = mEndBattleUI.GetComponent<Image>();
        if (mIsSuccess)
        {
            endImage.sprite = mVictorySprite;
        }
        else
        {
            endImage.sprite = mFailedSprite;
        }
        endImage.SetNativeSize();
        mBattleTitleTw = mEndBattleUI.transform.DOLocalMove(mTopPos.localPosition, BattleConst.scoreTitleUpTime);
        mBattleTitleTw.OnComplete(ShowStar);
        mBattleTitleTw.SetDelay(BattleConst.scoreTitleStayTime);

        mSkipEnable = true;
    }
    //---------------------------------------------------------------------------------------------
    public void SetScoreInfo(PB.HSRewardInfo scoreInfo)
    {
        mInstanceSettleResult = scoreInfo;
    }
    //---------------------------------------------------------------------------------------------
    private void ShowStar()
    {
        //Logger.LogFormat("get star {0}", mInstanceSettleResult.starCount);
        ShowScoreInfo();
    }
    //---------------------------------------------------------------------------------------------
    private void SetScoreInternal()
    {
        PlayerData mainPlayer = GameDataMgr.Instance.PlayerDataAttr;
        PlayerLevelAttr originalAttr = StaticDataMgr.Instance.GetPlayerLevelAttr(mainPlayer.level);

        //success
        if (mInstanceSettleResult != null)
        {
            //show player info;
            SetInitPlayerInfo(originalAttr, mainPlayer);
            PB.SynPlayerAttr playerAttr = mInstanceSettleResult.playerAttr;
            List<PB.RewardItem> rewardItemList = mInstanceSettleResult.RewardItems;
            int count = rewardItemList.Count;
            for (int i = 0; i < count; ++i)
            {
                PB.RewardItem item = rewardItemList[i];
                if (item.type == (int)PB.itemType.PLAYER_ATTR)
                {
                    if ((int)PB.changeType.CHANGE_COIN == int.Parse(item.itemId))
                    {
                        mPlayerGainGold.text = "+" + item.count.ToString();
                        //GameDataMgr.Instance.mainPlayer.coin += item.count;
                        //GameEventMgr.Instance.FireEvent<long>(GameEventList.CoinChanged, playerAttr.coin);
                    }
                    else if ((int)PB.changeType.CHANGE_PLAYER_EXP == int.Parse(item.itemId))
                    {
                        mPlayerGainExp.text = "+" + item.count.ToString();
                    }
                }
            }
            if (playerAttr.level > 0)
            {
                PlayerLevelAttr curAttr = StaticDataMgr.Instance.GetPlayerLevelAttr(playerAttr.level);
                mPlayerProgress.SetLoopCount(playerAttr.level - mainPlayer.level);
                mPlayerProgress.SetCurrrentRatio(mainPlayer.exp / (float)originalAttr.exp);
                if (playerAttr.level >= GameConfig.MaxPlayerLevel)
                {
                    mPlayerLvl.text = "MAX LVL";
                    mPlayerProgress.SetTargetRatio(0.0f);
                }
                else
                {
                    mPlayerLvl.text = "LVL " + playerAttr.level.ToString();
                    mPlayerProgress.SetTargetRatio(playerAttr.exp / (float)curAttr.exp);
                }
                mPlayerLvlUp.SetActive(mainPlayer.level != playerAttr.level);
                //TODO:Sysnc player info here?
                if (mainPlayer.level != playerAttr.level)
                {
                    mainPlayer.level = playerAttr.level;
                    GameEventMgr.Instance.FireEvent<int>(GameEventList.LevelChanged, mainPlayer.level);
                }
                mainPlayer.exp = playerAttr.exp;
            }
            else
            {

            }

            //show monster info
            List<PB.SynMonsterAttr> monsterInfoList = mInstanceSettleResult.monstersAttr;
            count = monsterInfoList.Count;
            if (count > 0)
            {
                //set monster info
                for (int i = 0; i < count; ++i)
                {
                    GameUnit originalMonster = mainPlayer.GetPetWithKey(monsterInfoList[i].monsterId);
                    if (originalMonster == null)
                    {
                        Logger.LogError("Score error, no this monster");
                        continue;
                    }

                    UIMonsterIconExp monsterIconExp = UIMonsterIconExp.Create();
                    monsterIconExp.transform.SetParent(mMonsterExpList.transform, false);
                    monsterIconExp.SetMonsterIconExpInfo(
                        originalMonster.pbUnit.id,
                        originalMonster.currentExp,
                        monsterInfoList[i].exp,
                        originalMonster.pbUnit.level,
                        monsterInfoList[i].level,
                        originalMonster.pbUnit.stage
                        );
                    mainPlayer.mainUnitList[i].unit.RefreshUnitLvl(monsterInfoList[i].level, monsterInfoList[i].exp);
                    if (UIUtil.CheckPetIsMaxLevel(monsterInfoList[i].level) == false)
                    {
                        mUIMonsterExpList.Add(originalMonster.pbUnit.guid, monsterIconExp);
                    }
                }
                //set exp gain
                count = rewardItemList.Count;
                for (int i = 0; i < count; ++i)
                {
                    PB.RewardItem item = rewardItemList[i];
                    if (item.type == (int)PB.itemType.MONSTER_ATTR)
                    {
                        if ((int)PB.changeType.CHANGE_MONSTER_EXP == int.Parse(item.itemId))
                        {
                            UIMonsterIconExp curMonsterExp = null;
                            if (mUIMonsterExpList.TryGetValue(item.id, out curMonsterExp) == true)
                            {
                                curMonsterExp.SetExpGain("+" + item.count.ToString());
                            }
                        }
                    }
                }
            }
            else
            {
                count = mainPlayer.mainUnitList.Count;
                for (int i = 0; i < count; ++i)
                {
                    UIMonsterIconExp monsterIconExp = UIMonsterIconExp.Create();
                    monsterIconExp.transform.SetParent(mMonsterExpList.transform, false);
                    GameUnit curUnit = mainPlayer.mainUnitList[i].unit;
                    monsterIconExp.SetMonsterIconExpInfo(
                        curUnit.pbUnit.id,
                        curUnit.currentExp,
                        curUnit.currentExp,
                        curUnit.pbUnit.level,
                        curUnit.pbUnit.level,
                        curUnit.pbUnit.stage,
                        0
                        );
                }
            }

            //show item drop info
            count = rewardItemList.Count;
            for (int i = 0; i < count; ++i)
            {
                PB.RewardItem item = rewardItemList[i];
                if (item.type == (int)PB.itemType.ITEM)
                {
                    ItemIcon icon = ItemIcon.CreateItemIcon(ItemData.valueof(item.itemId, item.count));
                    icon.transform.SetParent(mItemGainList.transform);
                    icon.transform.localScale = Vector3.one;
                    icon.ShowTips = true;
                }
                else if (item.type == (int)PB.itemType.EQUIP)
                {
                    EquipData equipData = new EquipData()
                    {
                        id = item.id,
                        equipId = item.itemId,
                        stage = item.stage,
                        level = item.level
                    };
                    ItemIcon icon = ItemIcon.CreateItemIcon(equipData);
                    icon.transform.SetParent(mItemGainList.transform);
                    icon.transform.localScale = Vector3.one;
                    icon.ShowTips = true;
                }
            }
        }
        //failed
        else
        {
            SetInitPlayerInfo(originalAttr, mainPlayer);
        }
    }
    //---------------------------------------------------------------------------------------------
    private void ShowScoreInfo()
    {
        mBackground.SetActive(true);
        mLineMonsterItem.SetActive(true);
        //show player info
        mPlayerInfoRoot.SetActive(true);
        //show monster info
        mMonsterExpList.gameObject.SetActive(true);
        //show item drop info
        mItemGainList.gameObject.SetActive(true);
        //show button
        if (mIsSuccess == true)
        {
            EnterInstanceParam curInstance = BattleController.Instance.GetCurrentInstance();
            if (curInstance != null)
            {
                InstanceEntryRuntimeData curData = InstanceMapService.Instance.GetNextRuntimeInstance(curInstance.instanceData.instanceId);
                mNextLevelBtn.gameObject.SetActive(curData != null);
            }
        }
        else
        {
            mNextLevelBtn.gameObject.SetActive(false);
        }
        mRetryBtn.gameObject.SetActive(true);
        mConfirmBtn.gameObject.SetActive(true);
    }
    //---------------------------------------------------------------------------------------------
    private void SetInitPlayerInfo(PlayerLevelAttr playerAttr, PlayerData playerData)
    {
        //TODO: duplicate code
        //mPlayerInfoRoot.SetActive(true);
        mPlayerGainGold.text = "+0";
        mPlayerGainExp.text = "+0";
        mPlayerProgress.SetLoopCount(0);
        float curExpRatio = playerData.exp / (float)playerAttr.exp;
        mPlayerProgress.SetCurrrentRatio(curExpRatio);
        if (playerAttr.level >= GameConfig.MaxPlayerLevel)
        {
            mPlayerLvl.text = "MAX LVL";
            mPlayerProgress.SetTargetRatio(0.0f);
        }
        else
        {
            mPlayerLvl.text = "LVL " + playerAttr.level.ToString();
            mPlayerProgress.SetTargetRatio(curExpRatio);
        }
        mPlayerLvlUp.SetActive(false);
    }
    //---------------------------------------------------------------------------------------------
}
