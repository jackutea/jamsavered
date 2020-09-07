using System;
using System.Collections.Generic;
using UnityEngine;
using JackUtil;

namespace SaveRedNS {

    public class BulletBase : MonoBehaviour {

        public Rigidbody2D rig;
        public Sprite greenBullet;
        public Sprite purpleBullet;
        public Sprite redBullet;

        protected virtual void Awake() {

            rig = GetComponent<Rigidbody2D>();

        }

    }
}