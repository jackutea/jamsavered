using System;
using System.Collections.Generic;
using UnityEngine;

namespace SaveRedNS {

    public static class RoomController {

        public static event Action PerfectHit;
        public static event Action NormalHit;
        public static event Action<ColorType> BeHurt;

        public static void OnPerfectHit() {

            PerfectHit?.Invoke();

        }

        public static void OnNormalHit() {

            NormalHit?.Invoke();

        }

        public static void OnBeHurt(ColorType _humanColor) {

            BeHurt?.Invoke(_humanColor);
            
        }
        
    }
}