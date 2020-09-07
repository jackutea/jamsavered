using System;
using System.Collections.Generic;
using UnityEngine;

namespace SaveRedNS {

    public static class RoomController {

        public static event Action perfectHit;
        public static event Action normalHit;
        public static event Action<ColorType> beHurt;

        public static void OnPerfectHit() {

            perfectHit?.Invoke();

        }

        public static void OnNormalHit() {

            normalHit?.Invoke();

        }

        public static void OnBeHurt(ColorType _humanColor) {

            beHurt?.Invoke(_humanColor);
            
        }
        
    }
}