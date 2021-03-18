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
        #region 获得随机码
        /// <summary>
        /// 数字
        /// </summary>
        protected static char[] RANDOM_NUMBER_CONSTANT = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        /// <summary>
        /// 字母
        /// </summary>
        protected static char[] RANDOM_ALPHABET_CONSTANT = { 
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
        };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string GenerateRandomNumber(int Length) 
        {
            StringBuilder newRandom = new StringBuilder(10); 
            Random rd = new Random(); 
            for (int i = 0; i < Length; i++) { 
                newRandom.Append(RANDOM_NUMBER_CONSTANT[rd.Next(10)]); 
            } 
            return newRandom.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string GenerateRandomAlphabet(int Length)
        {
            StringBuilder newRandom = new StringBuilder(52);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(RANDOM_ALPHABET_CONSTANT[rd.Next(52)]);
            }
            return newRandom.ToString();
        }
        #endregion
    }
}
