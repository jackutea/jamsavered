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

        public BodyCol bodyCol;
        public BodyCol headCol;
        public BodyCol footCol;

        SpriteRenderer sr;
        Vector2 defaultPos;

        public virtual void Awake() {

            sr = GetComponent<SpriteRenderer>();

            defaultPos = transform.position;

        }

        public virtual void Init(ColorType _colorType) {

            bodyCol.hitType = HitType.Perfect;
            headCol.hitType = HitType.Normal;

            colorType = _colorType;

            // Sprite
            switch(colorType) {
                case ColorType.Purple:
                    sr.sprite = SpriteCollection.Instance.purpleHuman;
                    sr.flipX = true;
                    break;
                case ColorType.Red:
                    sr.sprite = SpriteCollection.Instance.redHuman;
                    break;
                case ColorType.Green:
                    sr.sprite = SpriteCollection.Instance.greenHuman;
                    break;
            }

            // Set Allow
            bodyCol.allowColBullet = TagCollection.bulletTagDic.GetValue(colorType);
            headCol.allowColBullet = TagCollection.bulletTagDic.GetValue(colorType);
            footCol.allowColBullet = TagCollection.bulletTagDic.GetValue(colorType);

        }

        public virtual void Move(float _yAxis) {

            if (_yAxis > 0) {

                transform.position = defaultPos + Vector2.up * 0.4f;

            } else if (_yAxis == 0) {

                transform.position = defaultPos + Vector2.down * 0.4f;

            } else if (_yAxis < 0) {

                transform.position = defaultPos;

            }

        }

    }

}