﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Wpf.Annotations;
using Wpf.CartesianChart;
using Wpf.CartesianChart.BasicLine;
using Wpf.CartesianChart.Basic_Bars;
using Wpf.CartesianChart.Basic_Stacked_Bar;
using Wpf.CartesianChart.Customized_Line_Series;
using Wpf.CartesianChart.Inverted_Series;
using Wpf.CartesianChart.Irregular_Intervals;
using Wpf.CartesianChart.LogarithmScale;
using Wpf.CartesianChart.Missing_Line_Points;
using Wpf.CartesianChart.NegativeStackedRow;
using Wpf.CartesianChart.StackedArea;
using Wpf.CartesianChart.StackedBar;
using Wpf.Gauges;
using Wpf.PieChart;
using BubblesExample = Wpf.CartesianChart.Bubbles.BubblesExample;
using ConstantChangesChart = Wpf.CartesianChart.ConstantChanges.ConstantChangesChart;
using DateTime = Wpf.CartesianChart.Using_DateTime.DateTime;
using LabelsExample = Wpf.CartesianChart.Labels.LabelsExample;
using SectionsExample = Wpf.CartesianChart.Sections.SectionsExample;
using StackedAreaExample = Wpf.CartesianChart.StackedArea.StackedAreaExample;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        private UserControl _cartesianView;
        private UserControl _pieView;
        private UserControl _gaugeView;

        public MainWindow()
        {
            InitializeComponent();

            #region Examples

            CartesianExamples = new List<UserControl>
            {

                new ConstantChangesChart(),

                new BasicStackedRowPercentageExample(),
                new BasicStackedColumnExample(),
                new NegativeStackedRowExample(),
                new BasicRowExample(),
                new BasicColumn(),
                new BasicLineExample(),

                new StackedAreaExample(),
                new WelcomeCartesian(),
                new FullyResponsive(),
                new CustomTypesPlotting(),
                new LineExample(),
                new LabelsExample(),
                //new LabelsHorizontalExample(),
                new CustomizedLineSeries(),
                new InvertedExample(),
                new BubblesExample(),
                //new StackedAreaExample(),
                new FinancialExample(),
                //new StackedColumnExample(),
                new StackedRowExample(),
                new MissingPointsExample(),
                
                //new IrregularIntervalsExample(),
                new DateTime(),
                //new LogarithmScaleExample(),
                new VerticalStackedAreaExample(),
                new SectionsExample(),
                new ZoomingAndPanning(),
                new MultiAxesChart(),
                new MixingTypes(),
                new InLineSyntaxTest()
            };

            PieExamples = new List<UserControl>
            {
                new PieExample()
            };

            GaugeExamples = new List<UserControl>
            {
                new Gauge180(), new Gauge360()
            };

            #endregion

            Func<List<UserControl>, UserControl> getView = x => x != null && x.Count > 0 ? x[0] : null;

            CartesianView = getView(CartesianExamples);
            PieView = getView(PieExamples);
            GaugeView = getView(GaugeExamples);

            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public UserControl CartesianView
        {
            get { return _cartesianView; }
            set
            {
                _cartesianView = value;
                OnPropertyChanged();
            }
        }
        public UserControl PieView
        {
            get { return _pieView; }
            set
            {
                _pieView = value;
                OnPropertyChanged();
            }
        }
        public UserControl GaugeView
        {
            get { return _gaugeView; }
            set
            {
                _gaugeView = value;
                OnPropertyChanged();
            }
        }

        public List<UserControl> CartesianExamples { get; set; }
        public List<UserControl> PieExamples { get; set; }
        public List<UserControl> GaugeExamples { get; set; }

        private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void NextCartesianOnClick(object sender, MouseButtonEventArgs e)
        {
            if (CartesianView == null) return;
            var current = CartesianExamples.IndexOf(CartesianView);
            current++;
            CartesianView = CartesianExamples.Count > current ? CartesianExamples[current] : CartesianExamples[0];
        }

        private void PreviousCartesianOnClick(object sender, MouseButtonEventArgs e)
        {
            if (CartesianView == null) return;
            var current = CartesianExamples.IndexOf(CartesianView);
            current--;
            CartesianView = current >= 0 ? CartesianExamples[current] : CartesianExamples[CartesianExamples.Count-1];
        }

        private void NextPieOnClick(object sender, MouseButtonEventArgs e)
        {
            if (PieView == null) return;
            var current = PieExamples.IndexOf(CartesianView);
            current++;
            PieView = PieExamples.Count > current ? PieExamples[current] : PieExamples[0];
        }

        private void PreviousPieOnClick(object sender, MouseButtonEventArgs e)
        {
            if (PieView == null) return;
            var current = PieExamples.IndexOf(CartesianView);
            current--;
            PieView = current >= 0 ? PieExamples[current] : PieExamples[PieExamples.Count - 1];
        }

        private void NextGaugeOnClick(object sender, MouseButtonEventArgs e)
        {
            if (GaugeView == null) return;
            var current = GaugeExamples.IndexOf(GaugeView);
            current++;
            GaugeView = GaugeExamples.Count > current ? GaugeExamples[current] : GaugeExamples[0];
        }

        private void PreviousGaugeOnClick(object sender, MouseButtonEventArgs e)
        {
            if (GaugeView == null) return;
            var current = GaugeExamples.IndexOf(GaugeView);
            current--;
            GaugeView = current >= 0 ? GaugeExamples[current] : GaugeExamples[GaugeExamples.Count - 1];
        }


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
