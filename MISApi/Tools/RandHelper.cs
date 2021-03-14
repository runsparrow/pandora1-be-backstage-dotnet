using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISApi.Tools
{
    /// <summary>
    /// 
    /// </summary>
    public class RandHelper
    {
        #region 获得6位优惠码 
        /// <summary>
        /// 
        /// </summary>
        protected static char[] RANDOM_NUMBER_CONSTANT = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'}; 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string GenerateRandomNumber(int Length) 
        {
            StringBuilder newRandom = new StringBuilder(10); 
            Random rd = new Random(); for (int i = 0; i < Length; i++) { 
                newRandom.Append(RANDOM_NUMBER_CONSTANT[rd.Next(10)]); 
            } 
            return newRandom.ToString(); 
        }
        #endregion
    }
}
