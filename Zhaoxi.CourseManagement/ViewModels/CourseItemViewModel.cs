using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.CourseManagement.Models;

namespace Zhaoxi.CourseManagement.ViewModels
{
    // prepare the data for consumption by the view
    public class CourseItemViewModel
    {
        private readonly CourseInfo course;

        public CourseItemViewModel(CourseInfo course)
        {
            this.course = course;
            // build the pie series
            foreach (var pd in course.PlatformDatas)
            {
                SeriesCollection.Add(new PieSeries
                {
                    Title = pd.PlatformName,
                    Values = new ChartValues<int> { pd.PlayCount },
                    DataLabels = false
                });
            }
        }

        public string Name => course.Name;

        public SeriesCollection SeriesCollection { get; } = new SeriesCollection();

        public IList<PlatformData> PlatformDatas => course.PlatformDatas.ToList();


    }
}
