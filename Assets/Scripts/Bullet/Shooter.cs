using System;
using System.Collections.Generic;
using UnityEngine;
using JackUtil;

namespace SaveRedNS {

    public class Shooter : MonoBehaviour {

        public float bpm = 120;
        public float gapTime;
        public float gapTimeBase;

        public bool isRunning = false;

        public ColorType colorType;
        public Vector2 dir = Vector2.right;

        public Transform startTrans;
        public BulletBase bulletPrefab;

        void Start() {

            isRunning = false;

        }

        public void Init(float _bpm) {

            bpm = _bpm;

            gapTimeBase = bpm * 0.25f * 0.125f * 0.125f;

            gapTime = 0;

            Shoot();

            isRunning = true;

        }

        public void FixedExecute() {

            if (!isRunning) {

                return;

            }

            gapTime += Time.fixedDeltaTime;

            if (gapTime >= gapTimeBase) {

                gapTime = 0;

                Shoot();

            }

        }

        public void Shoot() {

            float _speed = bpm * 0.25f * 0.125f;

            BulletBase _bulletGo = Instantiate(bulletPrefab);
            _bulletGo.transform.position = startTrans.position;
            _bulletGo.Init(colorType, dir, _speed);

        }

    }

}