using System;
using System.Collections;
using System.Collections.Generic;
using InGameScene;
using InGameScene.Weapons;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    
    [SerializeField] 
    private GameObject _FPSWeapon;
    [SerializeField] 
    private GameObject _planerWeapon;

    private void Awake()
    {
        GameStateDispatcher.Instance.AddListener(state => WeaponChange(state));
        WeaponChange(GameState.PlanningPhase);
    }

    private void OnDestroy()
    {
        GameStateDispatcher.Instance.RemoveListener(state => WeaponChange(state));
    }

    private void WeaponChange(GameState state)
    {
        _planerWeapon.gameObject.SetActive(state == GameState.PlanningPhase);
        _FPSWeapon.gameObject.SetActive(state == GameState.ShooterPhase);
    }
    
}
