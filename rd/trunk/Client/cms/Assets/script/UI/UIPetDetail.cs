﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIPetDetail : UIBase
{

    public static string ViewName = PetViewConst.UIPetDetailAssetName;

    public Button closeButton;
    public Button preButton;
    public Button nextButton;
    public PetDetailLeft leftView;
    public GameObject rightView;

    PetDetailRightBase m_rightDetail = null;
    GameObject m_cameraObject = null;

    List<GameUnit> m_curTypeList = null;
    int m_currentIndex = 0;
    public GameUnit CurrentUnit { get { return m_curTypeList[m_currentIndex]; } }

    int m_currentPart = 0;

    //UI 
    public Dictionary<string, PetDetailRightBase> uiRights = new Dictionary<string, PetDetailRightBase>();
    string currentRightType = "";


    void Start()
    {
        EventTriggerListener.Get(closeButton.gameObject).onClick = CloseButtonDown;
        EventTriggerListener.Get(preButton.gameObject).onClick = PreButtonDown;
        EventTriggerListener.Get(nextButton.gameObject).onClick = NextButtonDown;
    }

    void CloseButtonDown(GameObject go)
    {
        UIMgr.Instance.CloseUI_(UIPetDetail.ViewName);
    }

    public override void Init()
    {
        if (m_cameraObject == null)
        {
            m_cameraObject = ResourceMgr.Instance.LoadAsset(PetViewConst.UIPetModelCameraAssetName);
            m_cameraObject.name = PetViewConst.UIPetModelCameraAssetName;
        }
    }
    public override void Clean()
    {
        if (m_cameraObject != null)
        {
            ResourceMgr.Instance.DestroyAsset(m_cameraObject);
        }
    }

    void AddRightView(string assetName)
    {
        //clear
        if (m_rightDetail != null)
        {
            ResourceMgr.Instance.DestroyAsset(m_rightDetail.gameObject);
            m_rightDetail = null;
        }

        m_rightDetail = ResourceMgr.Instance.LoadAsset(assetName).GetComponent<PetDetailRightBase>();
        m_rightDetail.transform.SetParent(rightView.transform, false);
        m_rightDetail.transform.localScale = Vector3.one;
        m_rightDetail.gameObject.name = "contentView";
    }

    public void SkillButtonDown()
    {
        ReloadRigthData(PetViewConst.UIPetSkillAssetName);
    }

    public void DetailAttrButtonDown()
    {
        ReloadRigthData(PetViewConst.UIPetAttrAssetName);
    }

    public void StageButtonDown()
    {
        ReloadRigthData(PetViewConst.UIPetStageAssetName);
    }

    public void AdvanceButtonDown()
    {
        ReloadRigthData(PetViewConst.UIPetAdvanceAssetName);
    }

    public void OpenEquipInfo(PartType part,EquipData data)
    {
        ItemStaticData itemInfo = StaticDataMgr.Instance.GetItemData(data.equipId);
        m_currentPart = itemInfo.part;
        ReloadRigthData(PetViewConst.UIPetEquipInfoAssetName);
    }
    public void OpenEquipList(PartType part)
    {
        m_currentPart = (int)part;
        ReloadRigthData(PetViewConst.UIPetEquipListAssetName);
    }

    void PreButtonDown(GameObject go)
    {
        if (m_curTypeList.Count == 1)
        {
            return;
        }

        m_currentIndex = (m_currentIndex - 1 + m_curTypeList.Count) % m_curTypeList.Count;
        ReloadData();
    }

    void NextButtonDown(GameObject go)
    {
        if (m_curTypeList.Count == 1)
        {
            return;
        }

        m_currentIndex = (m_currentIndex + 1) % m_curTypeList.Count;
        ReloadData();
    }

    public void ReloadData()
    {
        ReloadLeftData();
        ReloadRigthData(currentRightType);
    }

    public void ReloadLeftData()
    {
        leftView.ReloadData(CurrentUnit);
    }
    public void ReloadRigthData(string rightAsset)
    {
        if (currentRightType != rightAsset)
        {
            currentRightType = rightAsset;
            AddRightView(currentRightType);
        }
        PetRightParamBase param=null;
        #region InitaLize Param
        switch (currentRightType)
        {
            case PetViewConst.UIPetSkillAssetName:
            case PetViewConst.UIPetAttrAssetName:
            case PetViewConst.UIPetStageAssetName:
            case PetViewConst.UIPetAdvanceAssetName:
                param = new PetRightParamBase()
                {
                    unit = CurrentUnit
                };
                break;
            case PetViewConst.UIPetEquipInfoAssetName:
            case PetViewConst.UIPetEquipListAssetName:
                param = new UIPetEquipParam()
                {
                    unit = CurrentUnit,
                    part = (PartType)m_currentPart
                };
                break;
            default:
                break;
        }
        #endregion

        m_rightDetail.ReloadData(param);
    }

    public void SetTypeList(GameUnit unit, List<GameUnit> unitList)
    {
        m_curTypeList = unitList;
        m_currentIndex = m_curTypeList.Count;
        for (int i = 0; i < m_curTypeList.Count; ++i)
        {
            if (m_curTypeList[i] == unit)
            {
                m_currentIndex = i;
                break;
            }
        }

        if (m_currentIndex == m_curTypeList.Count)
        {
            return;
        }

        //默认选中属性界面
        SkillButtonDown();
        leftView.ReloadData(unit);
    }
}
