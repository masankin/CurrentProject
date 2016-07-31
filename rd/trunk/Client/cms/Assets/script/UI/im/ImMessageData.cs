﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImMessageData : MonoBehaviour {

    public Text mChannel;
    public Text mContent;
    public Text mSpeaker;
    public Image mPlayer;
    [HideInInspector]
    public int speakerID;
    [HideInInspector]
    public string playerName;
}
