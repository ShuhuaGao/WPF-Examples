using System;
using System.Collections.Generic;
using System.Linq;
using LiveCharts.Wpf;
using System.Windows.Media;
using LiveCharts;

namespace Zhaoxi.CourseManagement.ViewModels
{
    /// <summary>
    /// Represent the data underlying a card UI 
    /// https://www.bilibili.com/video/BV1Sy4y1b7FQ?p=35
    /// </summary>
    public class CardViewModel
    {
        public Brush Fill { get; set; }
        public Brush Stroke { get; set; }
        public double MonitorCurrentValue { get; private set; }
        public IChartValues Values { get; private set; }
        public string Icon { get; set; }
        public string MonitorName { get; set; }

        public CardViewModel()
        {
            var rnd = new Random();
            MonitorCurrentValue = rnd.NextDouble();
            Values = new ChartValues<double>(GenerateRandomNumbers(0.8, 30.0));
        }

        private IEnumerable<double> GenerateRandomNumbers(double min, double max, int n = 10)
        {
            var rnd = new Random();
            var numbers = new List<double>();
            for (int i = 0; i < n; i++)
                numbers.Add(rnd.NextDouble() * (max - min) + min);
            return numbers;
        }
    }
}
