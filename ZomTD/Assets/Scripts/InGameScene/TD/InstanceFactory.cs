using UnityEngine;

namespace InGameScene.TD
{
    public abstract class InstanceFactory : ScriptableObject
    {
        protected T GetInstance<T>(T prefab) where T : MonoBehaviour
        {
            T instance = Instantiate(prefab);
            return instance;
            
        }
    }
}