using System;
using System.Collections.Generic;
using UnityEngine;
using JackUtil;

namespace SaveRedNS {

    public class BodyCol : MonoBehaviour {

        [HideInInspector]
        public string allowColBullet;
        public HitType hitType = HitType.Perfect;
        public ColorType colorType;

        void OnCollisionEnter2D(Collision2D _col) {

            print(_col.gameObject.name);

            if (hitType == HitType.Perfect) {

                if (_col.gameObject.tag == TagCollection.GetBulletTag(colorType)) {

                    RoomController.OnNormalHit();

                    DestroyImmediate(_col.gameObject);

                } else {

                    print("Dead");

                }

            } else {

                if (_col.gameObject.tag == TagCollection.GetBulletTag(colorType)) {

                    RoomController.OnPerfectHit();

                    DestroyImmediate(_col.gameObject);

                } else {

                    print("Dead");

                }

            }

        }

    }

}