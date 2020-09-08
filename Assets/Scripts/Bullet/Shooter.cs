using System;
using System.Collections.Generic;
using UnityEngine;
using JackUtil;

namespace SaveRedNS {

    public class Shooter : MonoBehaviour {

        public ColorType colorType;
        public Vector2 dir = Vector2.right;

        public Transform startTrans;
        public BulletBase bulletPrefab;

        List<BulletBase> bulletList;

        void Start() {

        }

        public void Shoot(float _bpm, Vector2 _pos) {

            float _speed = _bpm / 240f * 8f;

            BulletBase _bulletGo = Instantiate(bulletPrefab);
            _bulletGo.transform.position = _pos;
            _bulletGo.Init(colorType, dir, _speed);

            if (bulletList == null) {

                bulletList = new List<BulletBase>();

            }

            bulletList.Add(_bulletGo);

        }

        public void StopAllBullets() {

            if (bulletList == null) {

                DebugUtil.LogError("列表不存在");
                return;

            }

            for (int i = 0; i < bulletList.Count; i += 1) {

                BulletBase _b = bulletList[i];
                Destroy(_b.gameObject);

            }

        }

    }

}