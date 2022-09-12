using System;
using UnityEngine;

namespace InGameScene.TD.TDGamePlay
{
    public class PlanerWeapon : MonoBehaviour
    {
        private void Update()
        {
            PlannerActionDispatcher.Instance.ActionHappened(PlannerAction.Targeting);
            
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                PlannerActionDispatcher.Instance.ActionHappened(PlannerAction.Box);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                PlannerActionDispatcher.Instance.ActionHappened(PlannerAction.Tower);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                PlannerActionDispatcher.Instance.ActionHappened(PlannerAction.FrostGun);
            }
            if (Input.GetButtonDown("Reload"))
            {
                PlannerActionDispatcher.Instance.ActionHappened(PlannerAction.Remove);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                PlannerActionDispatcher.Instance.ActionHappened(PlannerAction.Upgrade);
            }
            
        }
        
        
        
    }
}