using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_03_class
{
    public class MyClass_1
    {
        public int min;
        public int max;

        public MyClass_1(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
    }

    public class MyClass_2
    {
        public MyClass_1 GetMinMax(int[] nums)
        {
            return new MyClass_1(nums.Min(), nums.Max());
        }
    }
}
