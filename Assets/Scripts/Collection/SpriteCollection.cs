using System;
using System.Collections.Generic;
using UnityEngine;
using JackUtil;

namespace SaveRedNS {

    public class SpriteCollection : MonoBehaviour {

        static SpriteCollection m_instance;
        public static SpriteCollection Instance => m_instance;

        public Sprite purpleHuman;
        public Sprite redHuman;
        public Sprite greenHuman;

        public Sprite purpleBullet;
        public Sprite redBullet;
        public Sprite greenBullet;

        void Awake() {

            if (m_instance == null) {

                m_instance = this;

            }

        }
    }
}