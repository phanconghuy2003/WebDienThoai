using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bandienthoai.Models.DAO.Comparers
{
    public class CorrelationUserComparer 
    {
        //Similar calculator
        //param 1:rating data for vector1
        //param 2:rating data for vector2
        //based on formula (Eq.3) in https://en.wikipedia.org/wiki/Pearson_correlation_coefficient
        public double CompareVectors(int[] userFeaturesOne, int[] userFeaturesTwo)
        {
            double average1 = 0.0;
            double average2 = 0.0;
            int count = 0;

            for (int i = 0; i < userFeaturesOne.Length; i++)
            {
                if (userFeaturesOne[i] != 0 && userFeaturesTwo[i] != 0)
                {
                    average1 += userFeaturesOne[i];
                    average2 += userFeaturesTwo[i];
                    count++;
                }
            }

            average1 /= count;
            average2 /= count;

            double sum = 0.0;
            double squares1 = 0.0;
            double squares2 = 0.0;

            for (int i = 0; i < userFeaturesOne.Length; i++)
            {
                if (userFeaturesOne[i] != 0 && userFeaturesTwo[i] != 0)
                {
                    sum += (userFeaturesOne[i] - average1) * (userFeaturesTwo[i] - average2);
                    squares1 += Math.Pow(userFeaturesOne[i] - average1, 2);
                    squares2 += Math.Pow(userFeaturesTwo[i] - average2, 2);
                }
            }
            return sum / Math.Sqrt(squares1 * squares2);
        }
    }
}
