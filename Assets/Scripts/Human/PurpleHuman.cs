using System;
using System.Collections.Generic;
using UnityEngine;
using JackUtil;

namespace SaveRedNS {

    public class PurpleHuman : HumanBase {

        protected override void Awake() {
            
            base.Awake();

            colorType = ColorType.Purple;

        }

        public override void Init() {

            sr.sprite = SpriteCollection.Instance.purpleHuman;

        }

        public override void FixedExecute() {

            bool _up = Input.GetKey(KeyCode.R);
            bool _down = Input.GetKey(KeyCode.F);

            if (_up) {

                Move(1);

            } else if (_down) {

                Move(-1);

            } else {

                Move(0);

            }

        }

    }
}