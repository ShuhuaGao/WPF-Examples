﻿using System;
using System.Collections.Generic;
using LiveCharts.Wpf;
using LiveCharts;
using Stylet;
using System.Windows.Media;
using Zhaoxi.CourseManagement.Models;

namespace Zhaoxi.CourseManagement.ViewModels
{
    public class FirstPageViewModel : Screen
    {
        public CardViewModel Card1 { get; set; }
        public CardViewModel Card2 { get; set; }
        public CardViewModel Card3 { get; set; }
        public CardViewModel Card4 { get; set; }
        public IEnumerable<CourseItemViewModel> CourseItemViewModels { get; }

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

            // getter-only property can ONLY be set in the constructor
            CourseItemViewModels = InitCourseItemViewModels();
        }

        private IEnumerable<CourseItemViewModel> InitCourseItemViewModels(int n = 20)
        {
            var courseNames = new string[] { "C#/.Net架构师蜕变营", "C#/.Net高级进阶VIP班", "JAVA高级实战班", "Python培训冲刺30天", "Node.js全栈开发" };
            var courseItemViewModels = new List<CourseItemViewModel>();
            var rand = new Random();
            for (int i = 0; i < n; i++)
            {
                var ci = new CourseInfo(courseNames[rand.Next(0, courseNames.Length)]);
                courseItemViewModels.Add(new CourseItemViewModel(ci));
            }
            return courseItemViewModels;
        }
    }
}
