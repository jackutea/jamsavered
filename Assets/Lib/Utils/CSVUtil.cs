using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace JackUtil {

    public static class CSVUtil {

        public static void SaveCSV(string _path, List<string[]> _dataList) {

            using(StreamWriter _sw = File.CreateText(_path)) {

                for (int i = 0; i < _dataList.Count; i += 1) {

                    string _l = string.Empty;

                    string[] _d = _dataList[i];

                    for (int j = 0; j < _d.Length; j += 1) {

                        string _n = _d[j];

                        if (j == _d.Length - 1) {

                            _l += _n;

                        } else {

                            _l += _n + ",";

                        }

                    }

                    _sw.WriteLine(_l);

                }

            }

        }

        /// <summary>
        /// string[行, 列] _arr;
        /// 例: _arr[0, 1] 是第0行的第1列
        /// </summary>
        public static string[,] LoadToString(string _path) {

            string[] _str = File.ReadAllLines(_path);

            return LoadToString(_str);

        }

        public static string[,] LoadToString(string[] _csvLines) {

            string[,] _csv = null;

            for (int i = 0; i < _csvLines.Length; i += 1) {

                string _line = _csvLines[i];

                string[] _oneLine = _line.Trim().Split(',');

                if (_csv == null) {

                    _csv = new string[_csvLines.Length, _oneLine.Length];

                }

                for (int j = 0; j < _oneLine.Length; j += 1) {

                    _oneLine[j] = _oneLine[j].Trim();

                    _csv[i, j] = _oneLine[j];

                }

            }

            return _csv;

        }
        
    }
}