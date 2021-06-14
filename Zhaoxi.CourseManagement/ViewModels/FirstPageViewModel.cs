using System;
using System.Collections.Generic;
using LiveCharts.Wpf;
using LiveCharts;
using Stylet;
using System.Windows.Media;

namespace Zhaoxi.CourseManagement.ViewModels
{
    public class FirstPageViewModel : Screen
    {
        public CardViewModel Card1 { get; set; }
        public CardViewModel Card2 { get; set; }
        public CardViewModel Card3 { get; set; }
        public CardViewModel Card4 { get; set; }

        public FirstPageViewModel()
        {
            // four cards for demo
            Card1 = new CardViewModel
            {
                Fill = new SolidColorBrush(Colors.Aqua),
                Stroke = new SolidColorBrush(Colors.Aquamarine),
                MonitorName = "监控数据一",
                Icon = "\uE84D"
            };

            Card2 = new CardViewModel
            {
                Fill = new SolidColorBrush(Colors.Brown),
                Stroke = new SolidColorBrush(Colors.BlanchedAlmond),
                MonitorName = "监控数据二",
                Icon = "\uE854"
            };
            Card3 = new CardViewModel
            {
                Fill = new SolidColorBrush(Colors.MediumSeaGreen),
                Stroke = new SolidColorBrush(Colors.Teal),
                MonitorName = "监控数据三",
                Icon = "\uE852"
            };
            Card4 = new CardViewModel
            {
                Fill = new SolidColorBrush(Colors.Olive),
                Stroke = new SolidColorBrush(Colors.Orange),
                MonitorName = "监控数据四",
                Icon = "\uE84E"
            };
        }
    }
}
