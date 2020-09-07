using System;
using System.Collections.Generic;
using JackUtil;

namespace SaveRedNS {

    public static class TagCollection {

        public static SortedDictionary<ColorType, string> bulletTagDic;
        public const string PURPLE_BULLET = "PurpleBullet";
        public const string GREEN_BULLET = "GreenBullet";
        public const string RED_BULLET = "RedBullet";

        static TagCollection() {

            bulletTagDic = new SortedDictionary<ColorType, string>();
            bulletTagDic.AddOrReplace(ColorType.Purple, PURPLE_BULLET);
            bulletTagDic.AddOrReplace(ColorType.Green, GREEN_BULLET);
            bulletTagDic.AddOrReplace(ColorType.Red, RED_BULLET);

        }

        public static string GetBulletTag(ColorType _color) {
            return bulletTagDic.GetValue(_color);
        }

    }
}