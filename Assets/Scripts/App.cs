using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SaveRedNS {

    public class App : MonoBehaviour {

        public Room room;
        public Button startButton;
        public GameObject menuBd;

        public Music test;

        void Awake() {

            Physics2D.IgnoreLayerCollision(LayerCollection.HUMAN_LAYER, LayerCollection.HUMAN_LAYER);
            Physics2D.IgnoreLayerCollision(LayerCollection.BULLET_LAYER, LayerCollection.BULLET_LAYER);

        }

        void Start() {

            startButton.onClick.AddListener(() => {

                room.Init(test);

                menuBd.SetActive(false);

            });

        }

    }

}

