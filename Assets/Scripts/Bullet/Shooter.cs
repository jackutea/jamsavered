using System;
using System.Collections.Generic;
using UnityEngine;
using JackUtil;

namespace SaveRedNS {

    public class Shooter : MonoBehaviour {

        public float bpm;
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

            gapTimeBase = 240f / _bpm * 0.25f;

            gapTime = 0;

            // Shoot();

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

            float _speed = bpm / 240f * 8f;

            BulletBase _bulletGo = Instantiate(bulletPrefab);
            _bulletGo.transform.position = startTrans.position;
            print("SHOOT");
            _bulletGo.Init(colorType, dir, _speed);

        }

    }

}