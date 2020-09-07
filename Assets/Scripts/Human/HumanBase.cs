using System;
using System.Collections.Generic;
using UnityEngine;
using JackUtil;

namespace SaveRedNS {

    public enum ColorType {

        Green,
        Red,
        Purple

    }

    public enum HitType {

        Perfect,
        Normal,

    }

    public class HumanBase : MonoBehaviour {

        public ColorType colorType = ColorType.Red;

        protected SpriteRenderer sr;
        Vector2 defaultPos;

        protected virtual void Awake() {

            sr = GetComponent<SpriteRenderer>();

            defaultPos = transform.position;

        }

        public virtual void FixedExecute() {
            
        }

        public virtual void Init() {

        }

        // public virtual void Init(ColorType _colorType) {

        //     colorType = _colorType;

        //     // Sprite
        //     switch(colorType) {
        //         case ColorType.Purple:
        //             sr.sprite = SpriteCollection.Instance.purpleHuman;
        //             sr.flipX = true;
        //             break;
        //         case ColorType.Red:
        //             sr.sprite = SpriteCollection.Instance.redHuman;
        //             break;
        //         case ColorType.Green:
        //             sr.sprite = SpriteCollection.Instance.greenHuman;
        //             break;
        //     }

        // }

        public virtual void Move(float _yAxis) {

            if (_yAxis > 0) {

                transform.position = defaultPos + Vector2.up * 0.4f;

            } else if (_yAxis == 0) {

                transform.position = defaultPos;

            } else if (_yAxis < 0) {

                transform.position = defaultPos + Vector2.down * 0.4f;

            }

        }

    }

}