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

            if (_col.gameObject.tag == TagCollection.GetBulletTag(colorType)) {

                if (hitType == HitType.Perfect) {

                    RoomController.OnPerfectHit();

                } else {

                    RoomController.OnNormalHit();

                }

                Destroy(_col.gameObject);

            } else {

                RoomController.OnBeHurt(colorType);

            }

        }

    }

}