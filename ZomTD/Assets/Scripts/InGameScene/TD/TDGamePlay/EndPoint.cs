using InGameScene.TD.Enemies;
using UnityEngine;

namespace InGameScene.TD.TDGamePlay
{
    public class EndPoint : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                EndPointHealthDispatcher.Instance.ActionHappened(-other.GetComponent<Enemy>().EndPointReachDamage());
            }
        }
    }
}