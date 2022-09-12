using InGameScene.TD.Enemies;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace InGameScene.TD.TDGamePlay
{   
    [CreateAssetMenu(fileName = "New Enemy Wave", menuName = "Wave")]
    public class Waves : ScriptableObject
    {

        public EnemyType[] simpleEnemies;
        public int simpleEnemiesCount;
        public EnemyType bossEnemy;
        public int bossCount;
    }
    
}