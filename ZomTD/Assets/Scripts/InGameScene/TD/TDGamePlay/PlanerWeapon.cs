using System;
using UnityEngine;

namespace InGameScene.TD.TDGamePlay
{
    public class PlanerWeapon : MonoBehaviour
    {
        private void Update()
        {
            PlannerActionDispatcher.Instance.ActionHappened(PlannerAction.Targeting);
            
            if (Input.GetButtonDown("Fire1"))
            {
                PlannerActionDispatcher.Instance.ActionHappened(PlannerAction.Select);
            }
            if (Input.GetButtonDown("Reload"))
            {
                PlannerActionDispatcher.Instance.ActionHappened(PlannerAction.Remove);
            }
            
        }
        
        
        
    }
}