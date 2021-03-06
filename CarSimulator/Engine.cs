﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulator
{
    class Engine : IEngine
    {
        private int _speed;
        public int Speed => _speed;

        public event EventHandler<SpeedChangedArgs> SpeedChanged;

        public void SpeedDown(int value)
        {
            int newValue = Speed - value;
            OnSpeedChanged(newValue);
        }
        public void SpeedUp(int value)
        {
            int newValue = Speed + value;
            OnSpeedChanged(newValue);
        }

        private void OnSpeedChanged(int newSpeed)
        {
            var args = new SpeedChangedArgs(newSpeed);
            SpeedChanged?.Invoke(this, args);
        }

        private void SetSpeed(int value) 
        {
            int newValue = Math.Max(-20, Math.Min(value, 180));
            this._speed = newValue;
        }
    }
}
