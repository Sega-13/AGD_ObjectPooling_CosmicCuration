using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Enemy
{
    public class EnemyPool
    {
        private EnemyView enemyPrefab;
        private EnemyData enemyData;
        private List<PooledEnemy> pooledEnemies = new List<PooledEnemy>();

        public EnemyPool(EnemyView enemyPrefab, EnemyData enemyData)
        {
            this.enemyPrefab = enemyPrefab; 
            this.enemyData = enemyData;
        }
        public EnemyController GetEnemy()
        {
            if(pooledEnemies.Count > 0)
            {
                PooledEnemy enemy = pooledEnemies.Find(item => !item.isUsed);
                if(enemy != null )
                {
                    enemy.isUsed = true;
                    return enemy.Enemy;
                }
            }
            return CreateNewPooledEnemy();
        }
        private EnemyController CreateNewPooledEnemy()
        {
            PooledEnemy enemy = new PooledEnemy();
            enemy.Enemy = new EnemyController(enemyPrefab, enemyData);
            enemy.isUsed = true;
            pooledEnemies.Add(enemy);
            return enemy.Enemy;
        }
        public void ReturnEnemy(EnemyController enemy)
        {
            PooledEnemy pooledEnemy = pooledEnemies.Find(item => item.Enemy.Equals(enemy));
            pooledEnemy.isUsed = false;
        }
        public class PooledEnemy
        {
            public EnemyController Enemy;
            public bool isUsed;
        }



    }
}

