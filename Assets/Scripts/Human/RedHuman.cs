using System;
using System.Collections.Generic;
using UnityEngine;
using JackUtil;

namespace SaveRedNS {

    public class RedHuman : HumanBase {

        protected override void Awake() {
            
            base.Awake();

            colorType = ColorType.Red;

        }

        public override void Init() {

            sr.sprite = SpriteCollection.Instance.redHuman;

        }

        public override void FixedExecute() {

        }

        void OnCollisionEnter2D(Collision2D _col) {

            if (_col.gameObject.tag != TagCollection.GetBulletTag(ColorType.Red)) {

                Destroy(_col.gameObject);

                print("Dead: Red Be Hit");

            }

        }

    }
}