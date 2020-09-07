using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveRedNS {

    public class App : MonoBehaviour {

        public Room room;

        void Awake() {

            Physics2D.IgnoreLayerCollision(LayerCollection.HUMAN_LAYER, LayerCollection.HUMAN_LAYER);
            Physics2D.IgnoreLayerCollision(LayerCollection.BULLET_LAYER, LayerCollection.BULLET_LAYER);
        }

        void Start() {

            room.Init();

        }

    }

}

