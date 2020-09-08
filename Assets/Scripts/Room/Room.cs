using System;
using System.Threading.Tasks;
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
        public Shooter purpleBottomShooter;
        public Shooter greenTopShooter;
        public Shooter greenBottomShooter;

        public AudioSource audioPlayer;
        public Music currentMusic;

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
            // RoomController.BeHurt += BeHurt;

        }

        public void Init(Music _music) {

            currentMusic = _music;

            hitMaintainTimes = 0;
            normalHitTimes = 0;
            perfectHitTimes = 0;

            RefreshHit();

            StartGame();

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

            audioPlayer.clip = currentMusic.clip;
            print(audioPlayer.clip.length);
            print(audioPlayer.clip.samples);
            audioPlayer.PlayDelayed(currentMusic.preGap + currentMusic.bpm / 240f * 8f);

            // ---- Settle Humans ----
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

            // ---- Settle Shooter ----
            purpleTopShooter.Init(currentMusic.bpm);

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