﻿/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2009-2013 Michael Möller <mmoeller@openhardwaremonitor.org>
	
*/

using OpenHardwareMonitor.Collections;
using OpenHardwareMonitor.Hardware;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OpenHardwareMonitor.GUI
{
    public class PlotPanel : UserControl
    {

        private readonly PersistentSettings settings;
        private readonly UnitManager unitManager;

        private readonly Plot plot;
        private readonly PlotModel model;
        private readonly TimeSpanAxis timeAxis = new TimeSpanAxis();
        private readonly SortedDictionary<SensorType, LinearAxis> axes =
          new SortedDictionary<SensorType, LinearAxis>();

        private UserOption stackedAxes;

        private DateTime now;

        public PlotPanel(PersistentSettings settings, UnitManager unitManager)
        {
            this.settings = settings;
            this.unitManager = unitManager;

            this.model = CreatePlotModel();

            this.plot = new Plot();
            this.plot.Dock = DockStyle.Fill;
            this.plot.Model = model;
            this.plot.BackColor = Color.White;
            this.plot.ContextMenuStrip = CreateMenu();

            UpdateAxesPosition();

            this.SuspendLayout();
            this.Controls.Add(plot);
            this.ResumeLayout(true);
        }

        public void SetCurrentSettings()
        {
            settings.SetValue("plotPanel.MinTimeSpan", (float)timeAxis.ViewMinimum);
            settings.SetValue("plotPanel.MaxTimeSpan", (float)timeAxis.ViewMaximum);

            foreach (var axis in axes.Values)
            {
                settings.SetValue("plotPanel.Min" + axis.Key, (float)axis.ViewMinimum);
                settings.SetValue("plotPanel.Max" + axis.Key, (float)axis.ViewMaximum);
            }
        }

        private ContextMenuStrip CreateMenu()
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            ToolStripMenuItem stackedAxesMenuItem = new ToolStripMenuItem("Stacked Axes");
            stackedAxes = new UserOption("stackedAxes", true,
              stackedAxesMenuItem, settings);
            stackedAxes.Changed += (sender, e) =>
            {
                UpdateAxesPosition();
                InvalidatePlot();
            };
            menu.Items.Add(stackedAxesMenuItem);

            ToolStripMenuItem timeWindow = new ToolStripMenuItem("Time Window");
            ToolStripMenuItem[] timeWindowMenuItems =
              { new ToolStripMenuItem("Auto", null,
            (s, e) => { timeAxis.Zoom(0, double.NaN); InvalidatePlot(); }),
          new ToolStripMenuItem("5 min", null,
            (s, e) => { timeAxis.Zoom(0, 5 * 60); InvalidatePlot(); }),
          new ToolStripMenuItem("10 min", null,
            (s, e) => { timeAxis.Zoom(0, 10 * 60); InvalidatePlot(); }),
          new ToolStripMenuItem("20 min", null,
            (s, e) => { timeAxis.Zoom(0, 20 * 60); InvalidatePlot(); }),
          new ToolStripMenuItem("30 min", null,
            (s, e) => { timeAxis.Zoom(0, 30 * 60); InvalidatePlot(); }),
          new ToolStripMenuItem("45 min", null,
            (s, e) => { timeAxis.Zoom(0, 45 * 60); InvalidatePlot(); }),
          new ToolStripMenuItem("1 h", null,
            (s, e) => { timeAxis.Zoom(0, 60 * 60); InvalidatePlot(); }),
          new ToolStripMenuItem("1.5 h", null,
            (s, e) => { timeAxis.Zoom(0, 1.5 * 60 * 60); InvalidatePlot(); }),
          new ToolStripMenuItem("2 h", null,
            (s, e) => { timeAxis.Zoom(0, 2 * 60 * 60); InvalidatePlot(); }),
          new ToolStripMenuItem("3 h", null,
            (s, e) => { timeAxis.Zoom(0, 3 * 60 * 60); InvalidatePlot(); }),
          new ToolStripMenuItem("6 h", null,
            (s, e) => { timeAxis.Zoom(0, 6 * 60 * 60); InvalidatePlot(); }),
          new ToolStripMenuItem("12 h", null,
            (s, e) => { timeAxis.Zoom(0, 12 * 60 * 60); InvalidatePlot(); }),
          new ToolStripMenuItem("24 h", null,
            (s, e) => { timeAxis.Zoom(0, 24 * 60 * 60); InvalidatePlot(); }) };
            foreach (ToolStripMenuItem mi in timeWindowMenuItems)
                timeWindow.DropDownItems.Add(mi);
            menu.Items.Add(timeWindow);

            return menu;
        }

        private PlotModel CreatePlotModel()
        {

            timeAxis.Position = AxisPosition.Bottom;
            timeAxis.MajorGridlineStyle = LineStyle.Solid;
            timeAxis.MajorGridlineThickness = 1;
            timeAxis.MajorGridlineColor = OxyColor.FromRgb(192, 192, 192);
            timeAxis.MinorGridlineStyle = LineStyle.Solid;
            timeAxis.MinorGridlineThickness = 1;
            timeAxis.MinorGridlineColor = OxyColor.FromRgb(232, 232, 232);
            timeAxis.StartPosition = 1;
            timeAxis.EndPosition = 0;
            timeAxis.MinimumPadding = 0;
            timeAxis.MaximumPadding = 0;
            timeAxis.AbsoluteMinimum = 0;
            timeAxis.Minimum = 0;
            timeAxis.AbsoluteMaximum = 24 * 60 * 60;
            timeAxis.Zoom(
              settings.GetValue("plotPanel.MinTimeSpan", 0.0f),
              settings.GetValue("plotPanel.MaxTimeSpan", 10.0f * 60));
            timeAxis.StringFormat = "h:mm";

            var units = new Dictionary<SensorType, string>();
            units.Add(SensorType.Voltage, "V");
            units.Add(SensorType.Clock, "MHz");
            units.Add(SensorType.Temperature, "°C");
            units.Add(SensorType.Load, "%");
            units.Add(SensorType.Fan, "RPM");
            units.Add(SensorType.Flow, "L/h");
            units.Add(SensorType.Control, "%");
            units.Add(SensorType.Level, "%");
            units.Add(SensorType.Factor, "1");
            units.Add(SensorType.Power, "W");
            units.Add(SensorType.Data, "GB");

            foreach (SensorType type in Enum.GetValues(typeof(SensorType)))
            {
                var axis = new LinearAxis();
                axis.Position = AxisPosition.Left;
                axis.MajorGridlineStyle = LineStyle.Solid;
                axis.MajorGridlineThickness = 1;
                axis.MajorGridlineColor = timeAxis.MajorGridlineColor;
                axis.MinorGridlineStyle = LineStyle.Solid;
                axis.MinorGridlineThickness = 1;
                axis.MinorGridlineColor = timeAxis.MinorGridlineColor;
                axis.AxislineStyle = LineStyle.Solid;
                axis.Title = type.ToString();
                axis.Key = type.ToString();

                axis.Zoom(
                  settings.GetValue("plotPanel.Min" + axis.Key, float.NaN),
                  settings.GetValue("plotPanel.Max" + axis.Key, float.NaN));

                if (units.ContainsKey(type))
                    axis.Unit = units[type];
                axes.Add(type, axis);
            }

            var model = new PlotModel();
            model.Axes.Add(timeAxis);
            foreach (var axis in axes.Values)
                model.Axes.Add(axis);
            model.PlotMargins = new OxyThickness(0);
            model.IsLegendVisible = false;

            return model;
        }

        public void SetSensors(List<ISensor> sensors,
          IDictionary<ISensor, Color> colors)
        {
            this.model.Series.Clear();

            ListSet<SensorType> types = new ListSet<SensorType>();

            foreach (ISensor sensor in sensors)
            {
                var series = new LineSeries();
                if (sensor.SensorType == SensorType.Temperature)
                {
                    series.ItemsSource = sensor.Values.Select(value => new DataPoint
                    {
                        X = (now - value.Time).TotalSeconds,
                        Y = unitManager.TemperatureUnit == TemperatureUnit.Celsius ?
                        value.Value : UnitManager.CelsiusToFahrenheit(value.Value).Value
                    });
                }
                else
                {
                    series.ItemsSource = sensor.Values.Select(value => new DataPoint
                    {
                        X = (now - value.Time).TotalSeconds,
                        Y = value.Value
                    });
                }
                series.Color = colors[sensor].ToOxyColor();
                series.StrokeThickness = 1;
                series.YAxisKey = axes[sensor.SensorType].Key;
                series.Title = sensor.Hardware.Name + " " + sensor.Name;
                this.model.Series.Add(series);

                types.Add(sensor.SensorType);
            }

            foreach (var pair in axes.Reverse())
            {
                var axis = pair.Value;
                var type = pair.Key;
                axis.IsAxisVisible = types.Contains(type);
            }

            UpdateAxesPosition();
            InvalidatePlot();
        }

        private void UpdateAxesPosition()
        {
            if (stackedAxes.Value)
            {
                var count = axes.Values.Count(axis => axis.IsAxisVisible);
                var start = 0.0;
                foreach (var pair in axes.Reverse())
                {
                    var axis = pair.Value;
                    var type = pair.Key;
                    axis.StartPosition = start;
                    var delta = axis.IsAxisVisible ? 1.0 / count : 0;
                    start += delta;
                    axis.EndPosition = start;
                    axis.PositionTier = 0;
                    axis.MajorGridlineStyle = LineStyle.Solid;
                    axis.MinorGridlineStyle = LineStyle.Solid;
                }
            }
            else
            {
                var tier = 0;
                foreach (var pair in axes.Reverse())
                {
                    var axis = pair.Value;
                    var type = pair.Key;
                    if (axis.IsAxisVisible)
                    {
                        axis.StartPosition = 0;
                        axis.EndPosition = 1;
                        axis.PositionTier = tier;
                        tier++;
                    }
                    else
                    {
                        axis.StartPosition = 0;
                        axis.EndPosition = 0;
                        axis.PositionTier = 0;
                    }
                    axis.MajorGridlineStyle = LineStyle.None;
                    axis.MinorGridlineStyle = LineStyle.None;
                }
            }

        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // PlotPanel
            // 
            Name="PlotPanel";
            ResumeLayout(false);
        }

        public void InvalidatePlot()
        {
            this.now = DateTime.UtcNow;

            foreach (var pair in axes)
            {
                var axis = pair.Value;
                var type = pair.Key;
                if (type == SensorType.Temperature)
                    axis.Unit = unitManager.TemperatureUnit == TemperatureUnit.Celsius ?
                    "°C" : "°F";
            }

            this.plot.InvalidatePlot(true);
        }

    }
}
