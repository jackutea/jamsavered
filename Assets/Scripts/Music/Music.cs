using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using JackUtil;

namespace SaveRedNS {

    public class Music : MonoBehaviour {

        public AudioClip clip;
        public float preGap;
        public float bpm;

        int noteLength;
        System.Random random;

        [HideInInspector]
        public string path;

        void Start() {

            noteLength = -4 + (int)Math.Floor((clip.length + preGap) / 60f * bpm);
            // noteLength = noteLength * 4;

            random = new System.Random(0);

            string _dir = Application.dataPath + "/BGMData/";

            FileUtil.CreateDirIfNorExist(_dir);

            path = _dir + clip.name;

            GenerateCSV(path);

        }

        void GenerateCSV(string _path) {

            List<string[]> _noteList = new List<string[]>(noteLength);

            for (int i = 0; i < noteLength; i += 1) {

                string[] _note = GenerateSideNote();
                _noteList.Add(_note);

            }

            CSVUtil.SaveCSV(_path, _noteList);

        }

        string[] GenerateSideNote() {

            string[] _arr = new string[4];
            _arr[0] = string.Empty;
            _arr[1] = string.Empty;
            _arr[2] = string.Empty;
            _arr[3] = string.Empty;

            int _rd = random.Next(100);

            // 左边有符
            if (_rd >= 15) {

                int _isTop = random.Next(100);

                if (_isTop < 48) {

                    _arr[0] = "1";

                } else {

                    _arr[1] = "1";

                }

            }

            _rd = random.Next(100);

            // 右边有符
            if (_rd >= 15) {

                int _isTop = random.Next(100);

                if (_isTop < 48) {

                    _arr[2] = "1";

                } else {

                    _arr[3] = "1";

                }

            }

            return _arr;

        }

    }

}