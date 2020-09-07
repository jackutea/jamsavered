using System;
using System.Collections.Generic;
using UnityEngine;
using JackUtil;

namespace SaveRedNS {

    public class Room : MonoBehaviour {

        public HumanBase humanPrefab;
        [HideInInspector]
        public HumanBase purpleHuman;
        [HideInInspector]
        public HumanBase redHuman;
        [HideInInspector]
        public HumanBase greenHuman;

        public Transform centerTrans;

        public int life;
        public int maxHit;

        public void Init() {

            if (!redHuman) {

                redHuman = Instantiate(humanPrefab);
                redHuman.Init(ColorType.Red);
                redHuman.transform.position = (Vector2)centerTrans.position;
                
            }

            if (!purpleHuman) {

                purpleHuman = Instantiate(humanPrefab);
                purpleHuman.Init(ColorType.Purple);
                purpleHuman.transform.position = (Vector2)centerTrans.position + Vector2.left;

            }

            if (!greenHuman) {

                greenHuman = Instantiate(humanPrefab);
                greenHuman.Init(ColorType.Green);
                greenHuman.transform.position = (Vector2)centerTrans.position + Vector2.right;

            }
            
        }

    }

}