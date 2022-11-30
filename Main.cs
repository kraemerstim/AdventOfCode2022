﻿using System;
using System.Linq;
using System.Windows.Forms;
using AdventOfCode2022.solutions;

namespace AdventOfCode2022
{
    public partial class Main : Form
    {
        public enum LogLevel
        {
            Result1,
            Result2,
            Normal,
            Debug
        }

        public Main()
        {
            InitializeComponent();
            var projectDayType = typeof(ProjectDay);
            var projectDays = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(t => projectDayType.IsAssignableFrom(t));
            foreach (var dayClass in projectDays.OrderBy(type => type.Name.Length))
            {
                if (!dayClass.IsAbstract)
                {
                    cmbDaySelector.Items.Add(dayClass.Name);
                }
            }

            cmbDaySelector.SelectedIndex = cmbDaySelector.Items.Count - 1;
        }

        private ProjectDay GetDayForSelectedIndex()
        {
            Type t = Type.GetType($"AdventOfCode2022.solutions.{cmbDaySelector.Text}");
            try
            {
                var newDay = (ProjectDay) Activator.CreateInstance(t);
                newDay.SetLogFunction(LogFunction);
                return newDay;
            }
            catch (Exception e)
            {
                LogFunction(e.Message);
                throw;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            GetDayForSelectedIndex().Run();
        }

        private void LogFunction(string message, LogLevel logLevel = LogLevel.Normal)
        {
            if (lbLog.InvokeRequired)
            {
                void Log()
                {
                    LogFunction(message, logLevel);
                }

                lbLog.Invoke((Action) Log);
            }
            else
            {
                switch (logLevel)
                {
                    case LogLevel.Result1:
                        tbResult1.Text = message;
                        break;
                    case LogLevel.Result2:
                        tbResult2.Text = message;
                        break;
                    default:
                        lbLog.Items.Add(message);
                        lbLog.SelectedIndex = lbLog.Items.Count - 1;
                        lbLog.SelectedIndex = -1;
                        break;
                }
            }
        }
    }
}