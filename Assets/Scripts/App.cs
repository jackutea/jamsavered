using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SaveRedNS {

    public class App : MonoBehaviour {

        static App m_instance;
        public static App Instance => m_instance;

        public Room room;
        public GameObject menuBd;
        public Button startButton;

        public GameObject thankBd;
        public Button backButton;

        public Music test;

        void Awake() {

            if (m_instance == null) {

                m_instance = this;
                
            }

            Physics2D.IgnoreLayerCollision(LayerCollection.HUMAN_LAYER, LayerCollection.HUMAN_LAYER);
            Physics2D.IgnoreLayerCollision(LayerCollection.BULLET_LAYER, LayerCollection.BULLET_LAYER);

        }

        void Start() {

            startButton.onClick.AddListener(EnterGame);

            backButton.onClick.AddListener(EnterThank);

            EnterMenu();

        }

        public void EnterGame() {

            room.Init(test);

            menuBd.SetActive(false);

            thankBd.SetActive(false);

        }

        public void EnterMenu() {

            menuBd.SetActive(true);

            thankBd.SetActive(false);

        }

        public void EnterThank() {

            menuBd.SetActive(false);

            thankBd.SetActive(true);

        }

    }

}

