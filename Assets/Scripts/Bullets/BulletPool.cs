using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using static CosmicCuration.Bullets.BulletPool;

namespace CosmicCuration.Bullets
{
    public class BulletPool
    {
        private BulletView bulletView;
        private BulletScriptableObject bulletScriptableObject;
        private List<PooledBullet> pooledbullet = new List<PooledBullet>();
        public BulletPool(BulletView bulletView, BulletScriptableObject bulletScriptableObject) 
        { 
            this.bulletView = bulletView;
            this.bulletScriptableObject = bulletScriptableObject;
        }
        public BulletController GetBullet()
        {
            if (pooledbullet.Count > 0)
            {
                PooledBullet pool = pooledbullet.Find(item => !item.isUsed);
                if (pool != null)
                {
                    pool.isUsed = true;
                    return pool.Bullet;
                }
            }            
            return CreateNewPooledBullet();
        }
        public void ReturnToBulletPool(BulletController returnedBullet)
        {
            PooledBullet pooledBullet = pooledbullet.Find(item => item.Bullet.Equals(returnedBullet));
            pooledBullet.isUsed = false;
        }
        private BulletController CreateNewPooledBullet()
        {
            PooledBullet pooledBullet = new PooledBullet();
            pooledBullet.Bullet = new BulletController(bulletView, bulletScriptableObject);
            pooledBullet.isUsed = true;
            pooledbullet.Add(pooledBullet);
            return pooledBullet.Bullet;
        }
        public class PooledBullet
        {
            public BulletController Bullet;
            public bool isUsed;
        }
    }

}
