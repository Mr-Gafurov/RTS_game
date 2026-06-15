using UnityEngine;
using System;

namespace Generals.Core
{
    /// <summary>
    /// Обертки для типов данных для защиты от программ изменения памяти (типа GameGuardian).
    /// </summary>
    [Serializable]
    public struct AntiHackFloat
    {
        private float _value;
        private float _offset;

        public AntiHackFloat(float value)
        {
            _offset = UnityEngine.Random.Range(-1000f, 1000f);
            _value = value + _offset;
        }

        public float Value
        {
            get => _value - _offset;
            set => _value = value + _offset;
        }

        public override string ToString() => Value.ToString();
    }

    [Serializable]
    public struct AntiHackInt
    {
        private int _value;
        private int _offset;

        public AntiHackInt(int value)
        {
            _offset = UnityEngine.Random.Range(-1000, 1000);
            _value = value + _offset;
        }

        public int Value
        {
            get => _value - _offset;
            set => _value = value + _offset;
        }
    }
}
