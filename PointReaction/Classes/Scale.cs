﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointReaction.Classes
{
    public class Scale
    {
        private int MINIMAL_COOLDOWN = 0;
        private int MAXIMAL_COOLDOWN = 10000;

        private bool _GoesUp = true;
        private int _MinimumValue = 0;
        private int _MaximalValue = 0;
        private int _Counter = 0;
        private int _Cooldown = 0;

        public bool GoesUp
        {
            get => _GoesUp;
            set => SetGoesUp(value);
        }
        public int MinimumValue
        {
            get => _MinimumValue;
            set => SetMinimumValue(value);
        }
        public int MaximalValue
        {
            get => _MaximalValue;
            set => SetMaximalValue(value);
        }
        public int Counter
        {
            get => _Counter;
            set => SetCounter(value);
        }
        public int Cooldown
        {
            get => _Cooldown;
            set => SetCooldown(value);
        }

        public Scale() { }
        public Scale(bool goesUp)
        {
            SetGoesUp(goesUp);
        }
        public Scale(int cooldown)
        {
            SetCooldown(cooldown);
        }
        public Scale(int minimalValue, int maximalValue)
        {
            SetMinimumValue(minimalValue);
            SetMaximalValue(maximalValue);
        }
        public Scale(int minimalValue, int maximalValue, int counter)
        {
            SetMinimumValue(minimalValue);
            SetMaximalValue(maximalValue);
            SetCounter(counter);
        }

        private void SetGoesUp(bool goesUp)
        {
            _GoesUp = goesUp;
        }
        private void SetMinimumValue(int minimumValue)
        {
            _MinimumValue = minimumValue;
        }
        private void SetMaximalValue(int maximalValue)
        {
            _MaximalValue = maximalValue;
        }
        private void SetCounter(int counter)
        {
            if (counter >= MinimumValue && counter <= MaximalValue)
            {
                _Counter = counter;
            }
        }
        private void SetCooldown(int cooldown)
        {
            if (cooldown >= MINIMAL_COOLDOWN && cooldown <= MAXIMAL_COOLDOWN)
            {
                _Cooldown = cooldown;
            }
        }
    }
}