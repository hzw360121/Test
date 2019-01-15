/****************************************************************
*	Copyright:huzhiwen
*   Author：huzhiwen<hzw360121@163.com>
*   Create：2019/1/9 17:02:43
*	File：UserInfo.cs
*   Description：用户信息
*****************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodLuck.Model
{
    public class UserInfo
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string UserPhone { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string DepName { get; set; }
    }
    public class WinnerInfo
    {
        /// <summary>
        /// 获奖姓名
        /// </summary>
        public string WinnerName { get; set; }

        /// <summary>
        /// 获奖人手机号
        /// </summary>
        public string WinnerPhone { get; set; }


        /// <summary>
        /// 奖项ID
        /// </summary>
        public int PrizeID { get; set; }

    }




}
