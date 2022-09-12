using System;
using UnityEngine;

namespace InGameScene.TD.TDGamePlay
{
    public class MoneyManger : MonoBehaviour
    {
        [SerializeField]
        private int _moneyBalance;

        public int MoneyBalance => _moneyBalance;

        private void Awake()
        {
            MoneyIncomeDispatcher.Instance.AddListener(AddMoney);
        }

        private void OnDestroy()
        {
            MoneyIncomeDispatcher.Instance.RemoveListener(AddMoney);
        }

        public void AddMoney(int value)
        {
            _moneyBalance += value;
        }

        public bool SpendMoney(int value)
        {
            if (_moneyBalance - value >= 0)
            {
                _moneyBalance -= value;
                return true;
            }
            else
            {
                return false;
            }
            
        }
        
    }
}