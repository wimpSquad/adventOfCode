using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Classes
{
    public class Keypad
    {
        public static char[] Combination;
        private List<char> _combination = new List<char>();
        private KeyPad _currentKey = KeyPad.Five;
        private KeyPad _endingKey = KeyPad.Five;
        public char FindKey(string input)
        {
            foreach (var item in input)
            {
                _endingKey = FindRelativeKeyDiamond(GetInputKeyDirection(item.ToString()));
            }

            var combinationValue = GetKeyPadValue(_endingKey);

            _combination.Add(combinationValue);
            Combination = _combination.ToArray();

            return combinationValue;
        }

        private KeyPadDirection GetInputKeyDirection(string value)
        {
            switch (value.ToUpper())
            {
                case "U":
                    return KeyPadDirection.Up;
                case "D":
                    return KeyPadDirection.Down;
                case "L":
                    return KeyPadDirection.Left;
                case "R":
                    return KeyPadDirection.Right;
                default:
                    return KeyPadDirection.Neutral;
            }
        }

        private KeyPad FindRelativeKeySquare(KeyPadDirection direction)
        {
            switch (direction)
            {
                    case KeyPadDirection.Up:
                        switch (_currentKey)
                        {
                            case KeyPad.One:
                                _currentKey = KeyPad.One;
                                break;
                            case KeyPad.Two:
                                _currentKey = KeyPad.Two;
                                break;
                            case KeyPad.Three:
                                _currentKey = KeyPad.Three;
                                break;
                            case KeyPad.Four:
                                _currentKey = KeyPad.One;
                                break;
                            case KeyPad.Five:
                                _currentKey = KeyPad.Two;
                                break;
                            case KeyPad.Six:
                                _currentKey = KeyPad.Three;
                                break;
                            case KeyPad.Seven:
                                _currentKey = KeyPad.Four;
                                break;
                            case KeyPad.Eight:
                                _currentKey = KeyPad.Five;
                                break;
                            case KeyPad.Nine:
                                _currentKey = KeyPad.Six;
                                break;
                        }
                    break;
                case KeyPadDirection.Down:
                    switch (_currentKey)
                    {
                        case KeyPad.One:
                            _currentKey = KeyPad.Four;
                            break;
                        case KeyPad.Two:
                            _currentKey = KeyPad.Five;
                            break;
                        case KeyPad.Three:
                            _currentKey = KeyPad.Six;
                            break;
                        case KeyPad.Four:
                            _currentKey = KeyPad.Seven;
                            break;
                        case KeyPad.Five:
                            _currentKey = KeyPad.Eight;
                            break;
                        case KeyPad.Six:
                            _currentKey = KeyPad.Nine;
                            break;
                        case KeyPad.Seven:
                            _currentKey = KeyPad.Seven;
                            break;
                        case KeyPad.Eight:
                            _currentKey = KeyPad.Eight;
                            break;
                        case KeyPad.Nine:
                            _currentKey = KeyPad.Nine;
                            break;
                    }
                    break;
                case KeyPadDirection.Left:
                    switch (_currentKey)
                    {
                        case KeyPad.One:
                            _currentKey = KeyPad.One;
                            break;
                        case KeyPad.Two:
                            _currentKey = KeyPad.One;
                            break;
                        case KeyPad.Three:
                            _currentKey = KeyPad.Two;
                            break;
                        case KeyPad.Four:
                            _currentKey = KeyPad.Four;
                            break;
                        case KeyPad.Five:
                            _currentKey = KeyPad.Four;
                            break;
                        case KeyPad.Six:
                            _currentKey = KeyPad.Five;
                            break;
                        case KeyPad.Seven:
                            _currentKey = KeyPad.Seven;
                            break;
                        case KeyPad.Eight:
                            _currentKey = KeyPad.Seven;
                            break;
                        case KeyPad.Nine:
                            _currentKey = KeyPad.Eight;
                            break;
                    }
                    break;
                case KeyPadDirection.Right:
                    switch (_currentKey)
                    {
                        case KeyPad.One:
                            _currentKey = KeyPad.Two;
                            break;
                        case KeyPad.Two:
                            _currentKey = KeyPad.Three;
                            break;
                        case KeyPad.Three:
                            _currentKey = KeyPad.Three;
                            break;
                        case KeyPad.Four:
                            _currentKey = KeyPad.Five;
                            break;
                        case KeyPad.Five:
                            _currentKey = KeyPad.Six;
                            break;
                        case KeyPad.Six:
                            _currentKey = KeyPad.Six;
                            break;
                        case KeyPad.Seven:
                            _currentKey = KeyPad.Eight;
                            break;
                        case KeyPad.Eight:
                            _currentKey = KeyPad.Nine;
                            break;
                        case KeyPad.Nine:
                            _currentKey = KeyPad.Nine;
                            break;
                    }
                    break;
                    case KeyPadDirection.Neutral:
                        return _currentKey;
                default:
                    return _currentKey;
            }
            return _currentKey;
        }

        private KeyPad FindRelativeKeyDiamond(KeyPadDirection direction)
        {
            switch (direction)
            {
                case KeyPadDirection.Up:
                    switch (_currentKey)
                    {
                        case KeyPad.One:
                            _currentKey = KeyPad.One;
                            break;
                        case KeyPad.Two:
                            _currentKey = KeyPad.Two;
                            break;
                        case KeyPad.Three:
                            _currentKey = KeyPad.One;
                            break;
                        case KeyPad.Four:
                            _currentKey = KeyPad.Four;
                            break;
                        case KeyPad.Five:
                            _currentKey = KeyPad.Five;
                            break;
                        case KeyPad.Six:
                            _currentKey = KeyPad.Two;
                            break;
                        case KeyPad.Seven:
                            _currentKey = KeyPad.Three;
                            break;
                        case KeyPad.Eight:
                            _currentKey = KeyPad.Four;
                            break;
                        case KeyPad.Nine:
                            _currentKey = KeyPad.Nine;
                            break;
                        case KeyPad.A:
                            _currentKey = KeyPad.Six;
                            break;
                        case KeyPad.B:
                            _currentKey = KeyPad.Seven;
                            break;
                        case KeyPad.C:
                            _currentKey = KeyPad.Eight;
                            break;
                        case KeyPad.D:
                            _currentKey = KeyPad.B;
                        break;
                    }
                    break;
                case KeyPadDirection.Down:
                    switch (_currentKey)
                    {
                        case KeyPad.One:
                            _currentKey = KeyPad.Three;
                            break;
                        case KeyPad.Two:
                            _currentKey = KeyPad.Six;
                            break;
                        case KeyPad.Three:
                            _currentKey = KeyPad.Seven;
                            break;
                        case KeyPad.Four:
                            _currentKey = KeyPad.Eight;
                            break;
                        case KeyPad.Five:
                            _currentKey = KeyPad.Five;
                            break;
                        case KeyPad.Six:
                            _currentKey = KeyPad.A;
                            break;
                        case KeyPad.Seven:
                            _currentKey = KeyPad.B;
                            break;
                        case KeyPad.Eight:
                            _currentKey = KeyPad.C;
                            break;
                        case KeyPad.Nine:
                            _currentKey = KeyPad.Nine;
                            break;
                        case KeyPad.A:
                            _currentKey = KeyPad.A;
                            break;
                        case KeyPad.B:
                            _currentKey = KeyPad.D;
                            break;
                        case KeyPad.C:
                            _currentKey = KeyPad.C;
                            break;
                        case KeyPad.D:
                            _currentKey = KeyPad.D;
                            break;
                    }
                    break;
                case KeyPadDirection.Left:
                    switch (_currentKey)
                    {
                        case KeyPad.One:
                            _currentKey = KeyPad.One;
                            break;
                        case KeyPad.Two:
                            _currentKey = KeyPad.Two;
                            break;
                        case KeyPad.Three:
                            _currentKey = KeyPad.Two;
                            break;
                        case KeyPad.Four:
                            _currentKey = KeyPad.Three;
                            break;
                        case KeyPad.Five:
                            _currentKey = KeyPad.Five;
                            break;
                        case KeyPad.Six:
                            _currentKey = KeyPad.Five;
                            break;
                        case KeyPad.Seven:
                            _currentKey = KeyPad.Six;
                            break;
                        case KeyPad.Eight:
                            _currentKey = KeyPad.Seven;
                            break;
                        case KeyPad.Nine:
                            _currentKey = KeyPad.Eight;
                            break;
                        case KeyPad.A:
                            _currentKey = KeyPad.A;
                            break;
                        case KeyPad.B:
                            _currentKey = KeyPad.A;
                            break;
                        case KeyPad.C:
                            _currentKey = KeyPad.B;
                            break;
                        case KeyPad.D:
                            _currentKey = KeyPad.D;
                            break;
                    }
                    break;
                case KeyPadDirection.Right:
                    switch (_currentKey)
                    {
                        case KeyPad.One:
                            _currentKey = KeyPad.One;
                            break;
                        case KeyPad.Two:
                            _currentKey = KeyPad.Three;
                            break;
                        case KeyPad.Three:
                            _currentKey = KeyPad.Four;
                            break;
                        case KeyPad.Four:
                            _currentKey = KeyPad.Four;
                            break;
                        case KeyPad.Five:
                            _currentKey = KeyPad.Six;
                            break;
                        case KeyPad.Six:
                            _currentKey = KeyPad.Seven;
                            break;
                        case KeyPad.Seven:
                            _currentKey = KeyPad.Eight;
                            break;
                        case KeyPad.Eight:
                            _currentKey = KeyPad.Nine;
                            break;
                        case KeyPad.Nine:
                            _currentKey = KeyPad.Nine;
                            break;
                        case KeyPad.A:
                            _currentKey = KeyPad.A;
                            break;
                        case KeyPad.B:
                            _currentKey = KeyPad.C;
                            break;
                        case KeyPad.C:
                            _currentKey = KeyPad.C;
                            break;
                        case KeyPad.D:
                            _currentKey = KeyPad.D;
                            break;
                    }
                    break;
                case KeyPadDirection.Neutral:
                    return _currentKey;
                default:
                    return _currentKey;
            }
            return _currentKey;
        }

        private char GetKeyPadValue(KeyPad input)
        {
            switch(input)
            {
                case KeyPad.One:
                    return '1';
                case KeyPad.Two:
                    return '2';
                case KeyPad.Three:
                    return '3';
                case KeyPad.Four:
                    return '4';
                case KeyPad.Five:
                    return '5';
                case KeyPad.Six:
                    return '6';
                case KeyPad.Seven:
                    return '7';
                case KeyPad.Eight:
                    return '8';
                case KeyPad.Nine:
                    return '9';
                case KeyPad.A:
                    return 'A';
                case KeyPad.B:
                    return 'B';
                case KeyPad.C:
                    return 'C';
                case KeyPad.D:
                    return 'D';
                default:
                    return '0';
            }
        }
    }

    public enum KeyPad
    {
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        A,
        B,
        C,
        D
    }

    public enum KeyPadDirection
    {
        Up,
        Down,
        Left,
        Right,
        Neutral
    }
}
