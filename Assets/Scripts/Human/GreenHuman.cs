using System;
using System.Collections.Generic;
using UnityEngine;
using JackUtil;

namespace SaveRedNS {

    public class GreenHuman : HumanBase {

        protected override void Awake() {
            
            base.Awake();

            colorType = ColorType.Green;

        }

        public override void Init() {

            sr.sprite = SpriteCollection.Instance.greenHuman;

        }

        public override void FixedExecute() {

            bool _up = Input.GetKey(KeyCode.U);
            bool _down = Input.GetKey(KeyCode.J);

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