using System;
using System.Collections;
using System.Linq;

namespace AdventLibrary {
    public class OpProgram {
        private int[] _input;
        private bool _hasFinished = false;

        public OpProgram(int[] input) {
            UpdateInput(input);
        }

        private void UpdateInput(int[] input) {
            _input = new int[input.Length];
            input.CopyTo(_input, 0);
        }

        public int Run(int[] input = null) {
            if (_hasFinished && input == _input) return _input[0];
            if (input != null) UpdateInput(input);

            for (int i = 0; i < _input.Length; i += 4) {
                var opCode = _input[i];
                if (opCode == 99) break;

                var position1 = _input[i + 1];
                var position2 = _input[i + 2];
                var position3 = _input[i + 3];

                var result = 0;
                switch (opCode) {
                    case 1:
                        result = _input[position1] + _input[position2];
                        break;
                    case 2:
                        result = _input[position1] * _input[position2];
                        break;
                }


                _input[position3] = result;
            }

            _hasFinished = true;
            return _input[0];
        }

        public int[] GetAllResults() {
            if (_hasFinished) return _input;
            return null;
        }
    }
}