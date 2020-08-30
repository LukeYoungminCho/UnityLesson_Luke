using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum eHitPercent
{
    Perfect,
    Good,
    Bad,
    Miss,
}

[System.Serializable]
public class HitEffectData
{
    public GameObject screenEffect;
    public eHitPercent hitPercent;
    public int score;
}
