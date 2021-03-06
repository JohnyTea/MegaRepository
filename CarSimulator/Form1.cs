﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarSimulator
{
    public partial class Form1 : Form
    {
        IEngine engine = null;
        IOdometer odometer = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            odometer.OdoChanged += Odometer_OdoChanged;
            engine.SpeedChanged += Engine_SpeedChanged;

            engine.SpeedUp(10);

            bStart.Enabled = false;
        }

        private void Engine_SpeedChanged(object sender, SpeedChangedArgs e)
        {
            lSpeed.Text = e.Speed.ToString();
        }

        private void Odometer_OdoChanged(object sender, OdoChangedArgs e)
        {
            lOdo.Text = e.Odo.ToString();
        }
    }
}
