﻿/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2009-2012 Michael Möller <mmoeller@openhardwaremonitor.org>
	
*/

using OpenHardwareMonitor.Hardware;
using OpenHardwareMonitor.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OpenHardwareMonitor.GUI
{
    public class SystemTray : IDisposable
    {
        private IComputer computer;
        private PersistentSettings settings;
        private UnitManager unitManager;
        private List<SensorNotifyIcon> list = new List<SensorNotifyIcon>();
        private bool mainIconEnabled = false;
        private NotifyIconAdv mainIcon;

        public SystemTray(IComputer computer, PersistentSettings settings,
          UnitManager unitManager)
        {
            this.computer = computer;
            this.settings = settings;
            this.unitManager = unitManager;
            computer.HardwareAdded += new HardwareEventHandler(HardwareAdded);
            computer.HardwareRemoved += new HardwareEventHandler(HardwareRemoved);

            this.mainIcon = new NotifyIconAdv();

            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem hideShowItem = new ToolStripMenuItem("Hide/Show");
            hideShowItem.Click += delegate (object obj, EventArgs args)
            {
                SendHideShowCommand();
            };
            contextMenu.Items.Add(hideShowItem);
            contextMenu.Items.Add(new ToolStripMenuItem("-"));
            ToolStripMenuItem exitItem = new ToolStripMenuItem("Exit");
            exitItem.Click += delegate (object obj, EventArgs args)
            {
                SendExitCommand();
            };
            contextMenu.Items.Add(exitItem);
            this.mainIcon.ContextMenu = contextMenu;
            this.mainIcon.DoubleClick += delegate (object obj, EventArgs args)
            {
                SendHideShowCommand();
            };
            this.mainIcon.Icon = EmbeddedResources.GetIcon("smallicon.ico");
            this.mainIcon.Text = "Open Hardware Monitor";
        }

        private void HardwareRemoved(IHardware hardware)
        {
            hardware.SensorAdded -= new SensorEventHandler(SensorAdded);
            hardware.SensorRemoved -= new SensorEventHandler(SensorRemoved);
            foreach (ISensor sensor in hardware.Sensors)
                SensorRemoved(sensor);
            foreach (IHardware subHardware in hardware.SubHardware)
                HardwareRemoved(subHardware);
        }

        private void HardwareAdded(IHardware hardware)
        {
            foreach (ISensor sensor in hardware.Sensors)
                SensorAdded(sensor);
            hardware.SensorAdded += new SensorEventHandler(SensorAdded);
            hardware.SensorRemoved += new SensorEventHandler(SensorRemoved);
            foreach (IHardware subHardware in hardware.SubHardware)
                HardwareAdded(subHardware);
        }

        private void SensorAdded(ISensor sensor)
        {
            if (settings.GetValue(new Identifier(sensor.Identifier,
              "tray").ToString(), false))
                Add(sensor, false);
        }

        private void SensorRemoved(ISensor sensor)
        {
            if (Contains(sensor))
                Remove(sensor, false);
        }

        public void Dispose()
        {
            foreach (SensorNotifyIcon icon in list)
                icon.Dispose();
            mainIcon.Dispose();
        }

        public void Redraw()
        {
            foreach (SensorNotifyIcon icon in list)
                icon.Update();
        }

        public bool Contains(ISensor sensor)
        {
            foreach (SensorNotifyIcon icon in list)
                if (icon.Sensor == sensor)
                    return true;
            return false;
        }

        public void Add(ISensor sensor, bool balloonTip)
        {
            if (Contains(sensor))
            {
                return;
            }
            else
            {
                list.Add(new SensorNotifyIcon(this, sensor, balloonTip, settings, unitManager));
                UpdateMainIconVisibilty();
                settings.SetValue(new Identifier(sensor.Identifier, "tray").ToString(), true);
            }
        }

        public void Remove(ISensor sensor)
        {
            Remove(sensor, true);
        }

        private void Remove(ISensor sensor, bool deleteConfig)
        {
            if (deleteConfig)
            {
                settings.Remove(
                  new Identifier(sensor.Identifier, "tray").ToString());
                settings.Remove(
                  new Identifier(sensor.Identifier, "traycolor").ToString());
            }
            SensorNotifyIcon instance = null;
            foreach (SensorNotifyIcon icon in list)
                if (icon.Sensor == sensor)
                    instance = icon;
            if (instance != null)
            {
                list.Remove(instance);
                UpdateMainIconVisibilty();
                instance.Dispose();
            }
        }

        public event EventHandler HideShowCommand;

        public void SendHideShowCommand()
        {
            if (HideShowCommand != null)
                HideShowCommand(this, null);
        }

        public event EventHandler ExitCommand;

        public void SendExitCommand()
        {
            if (ExitCommand != null)
                ExitCommand(this, null);
        }

        private void UpdateMainIconVisibilty()
        {
            if (mainIconEnabled)
            {
                mainIcon.Visible = list.Count == 0;
            }
            else
            {
                mainIcon.Visible = false;
            }
        }

        public bool IsMainIconEnabled
        {
            get { return mainIconEnabled; }
            set
            {
                if (mainIconEnabled != value)
                {
                    mainIconEnabled = value;
                    UpdateMainIconVisibilty();
                }
            }
        }
    }
}
