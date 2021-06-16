using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.CourseManagement.Models
{
    public class PlatformData
    {
        public int PlayCount { get; set; }
        public int GrowingRate { get; set; }
        public bool IsGrowing { get; set; }
        public string PlatformName { get; set; }

    }

    public class CourseInfo
    {
        public string Name { get; set; }
        public string ID { get; set; }
        IEnumerable<PlatformData> PlatformDatas { get; set; }

        public CourseInfo(string name)
        {
            Name = name;
            var rand = new Random();
            var platformNames = new string[] { "云课堂", "B站", "知乎", "抖音", "博客" };
            var platformDataArr = new PlatformData[platformNames.Length];
            for (int i = 0; i < platformNames.Length; i++)
            {
                platformDataArr[i].PlayCount = rand.Next(100, 1000);
                platformDataArr[i].GrowingRate = rand.Next(-50, 50);
                platformDataArr[i].IsGrowing = rand.Next() < 0.5;
                platformDataArr[i].PlatformName = platformNames[i];
            }

        }
    }


}
