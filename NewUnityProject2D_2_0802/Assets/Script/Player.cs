using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// 플레이어 상태 및 수치 관리 스크립트
public class Player : Charactor
{   
    // 싱글톤 패턴
    public static Player Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<Player>();
            return _instance;
        }
    }
    private static Player _instance;
 
    public PlayerMovement playerMovement;
    public PlayerWeapon playerWeapon;
}
