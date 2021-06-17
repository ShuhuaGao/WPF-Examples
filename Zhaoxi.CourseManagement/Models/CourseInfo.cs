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
        public IEnumerable<PlatformData> PlatformDatas { get; }

        public CourseInfo(string name)
        {
            Name = name;
            var rand = new Random();
            var platformNames = new string[] { "云课堂", "B站", "知乎", "抖音", "博客" };
            //var platformDataArr = new PlatformData[platformNames.Length];
            var platformDataArr = new List<PlatformData>();
            for (int i = 0; i < platformNames.Length; i++)
            {
                platformDataArr.Add(new PlatformData
                {
                    PlayCount = rand.Next(100, 1000),
                    GrowingRate = rand.Next(-50, 50),
                    IsGrowing = rand.NextDouble() < 0.5,
                    PlatformName = platformNames[i]
                });
            }

            PlatformDatas = platformDataArr;
        }
    }


}
