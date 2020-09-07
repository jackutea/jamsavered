using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JackUtil;

namespace SaveRedNS {

    public class Room : MonoBehaviour {

        public PurpleHuman purpleHuman;
        public RedHuman redHuman;
        public GreenHuman greenHuman;

        public Transform centerTrans;

        public Shooter purpleTopShooter;

        public Text hitTimesTxt;
        public Text perfectTimesTxt;
        public Text normalTimesTxt;
        int hitMaintainTimes;
        int perfectHitTimes;
        int normalHitTimes;

        bool isRunning = false;

        public int life;
        public int maxHit;

        void Start() {

            RoomController.NormalHit += NormalHit;
            RoomController.PerfectHit += PerfectHit;

        }

        public void Init() {

            hitMaintainTimes = 0;
            normalHitTimes = 0;
            perfectHitTimes = 0;

            RefreshHit();

            StartGame();

            purpleTopShooter.Init(120);

            if (!redHuman) {

                redHuman.Init();
                redHuman.transform.position = (Vector2)centerTrans.position;
                
            }

            if (!purpleHuman) {

                purpleHuman.Init();
                purpleHuman.transform.position = (Vector2)centerTrans.position + Vector2.left;

            }

            if (!greenHuman) {

                greenHuman.Init();
                greenHuman.transform.position = (Vector2)centerTrans.position + Vector2.right;

            }
            
        }

        void FixedUpdate() {

            if (!isRunning) {

                return;

            }

            greenHuman?.FixedExecute();
            redHuman?.FixedExecute();
            purpleHuman?.FixedExecute();

            purpleTopShooter?.FixedExecute();

        }

        public void StartGame() {

            isRunning = true;

        }

        public void StopGame() {

            isRunning = false;

        }

        public void PerfectHit() {

            perfectHitTimes += 1;
            hitMaintainTimes += 1;
            RefreshHit();

        }

        public void NormalHit() {

            normalHitTimes += 1;
            hitMaintainTimes += 1;
            RefreshHit();

        }

        void RefreshHit() {

            perfectTimesTxt.text = "P:" + perfectHitTimes.ToString();
            normalTimesTxt.text = "N: " + normalHitTimes.ToString();
            hitTimesTxt.text = "Combo: " + hitMaintainTimes.ToString();

        }

        public void BeHurt() {

            StopGame();

        }

    }

}