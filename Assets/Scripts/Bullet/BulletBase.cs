using System;
using System.Collections.Generic;
using UnityEngine;
using JackUtil;

namespace SaveRedNS {

    public class BulletBase : MonoBehaviour {

        [HideInInspector]
        public Rigidbody2D rig;

        public float bpm = 120;
        float speed;

        protected virtual void Awake() {

            print("AWAKE");

            rig = GetComponent<Rigidbody2D>();

        }

        public void Init(ColorType _color, Vector2 _dir, float _speed) {

            tag = TagCollection.GetBulletTag(_color);

            rig.velocity = _dir * _speed;

        }

    }

}