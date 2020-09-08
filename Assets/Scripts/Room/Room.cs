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

        public Text bgmNameTxt;
        
        public Text hitTimesTxt;
        public Text perfectTimesTxt;
        public Text normalTimesTxt;
        public Text missTimesTxt;
        int hitMaintainTimes;
        int perfectHitTimes;
        int normalHitTimes;
        int missTimes;

        float timer;

        bool isRunning = false;

        public int life;
        public int maxHit;

        void Start() {

            RoomController.NormalHit += NormalHit;
            RoomController.PerfectHit += PerfectHit;
            RoomController.BeHurt += BeHurt;

        }

        public void Init(Music _music) {

            timer = 0;

            currentMusic = _music;

            bgmNameTxt.text = "BGM: " + currentMusic.clip.name;

            hitMaintainTimes = 0;
            normalHitTimes = 0;
            perfectHitTimes = 0;
            missTimes = 0;

            RefreshHit();

            StartGame();

        }

        void FixedUpdate() {

            if (!isRunning) {

                return;

            }

            timer += Time.fixedDeltaTime;

            if (timer >= currentMusic.clip.length + 4) {

                Finished();
                return;

            }

            if (Input.GetKeyUp(KeyCode.Escape)) {

                Finished();
                return;

            }

            greenHuman?.FixedExecute();
            redHuman?.FixedExecute();
            purpleHuman?.FixedExecute();

        }

        public void StartGame() {

            isRunning = true;

            PlayMusic();

            SettleHumans();

            SettleShooters();

        }

        void PlayMusic() {

            audioPlayer.clip = currentMusic.clip;
            audioPlayer.PlayDelayed(currentMusic.preGap + currentMusic.bpm / 240f * 8f);

        }

        void SettleHumans() {

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

        }

        void SettleShooters() {

            string[,] _csv = CSVUtil.LoadToString(currentMusic.path);

            // ---- Settle Shooter ----
            for (int i = 0; i < _csv.GetLength(0); i += 1) {

                // PurpleTop
                if (_csv[i, 0] == "1") {
                    purpleTopShooter.Shoot(currentMusic.bpm, (Vector2)purpleTopShooter.startTrans.position + i * Vector2.left * 2);
                }

                if (_csv[i, 1] == "1") {
                    purpleBottomShooter.Shoot(currentMusic.bpm, (Vector2)purpleBottomShooter.startTrans.position + i * Vector2.left * 2);
                }

                if (_csv[i, 2] == "1") {
                    greenTopShooter.Shoot(currentMusic.bpm, (Vector2)greenTopShooter.startTrans.position + i * Vector2.right * 2);
                }

                if (_csv[i, 3] == "1") {
                    greenBottomShooter.Shoot(currentMusic.bpm, (Vector2)greenBottomShooter.startTrans.position + i * Vector2.right * 2);
                }

            }

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

            perfectTimesTxt.text = "Perfect:" + perfectHitTimes.ToString();
            normalTimesTxt.text = "Normal: " + normalHitTimes.ToString();
            missTimesTxt.text = "Ignore: " + missTimes.ToString();
            hitTimesTxt.text = "Combo: " + hitMaintainTimes.ToString();

        }

        public void BeHurt(ColorType _colorType) {

            missTimes += 1;
            hitMaintainTimes = 0;
            RefreshHit();

        }

        void Finished() {

            isRunning = false;

            purpleTopShooter.StopAllBullets();
            purpleBottomShooter.StopAllBullets();
            greenTopShooter.StopAllBullets();
            greenBottomShooter.StopAllBullets();

            App.Instance.EnterThank();


        }

    }

}