using AttributeDay1.eg.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDay1.eg
{
    public enum UserStateEnum
    {
        /// <summary>
        /// 正常状态
        /// </summary>
        [Remark("正常")]
        Normal=0,
        /// <summary>
        /// 冻结
        /// </summary>
        [Remark("冻结")]
        Forzen=1,
        /// <summary>
        /// 删除
        /// </summary>
        [Remark("删除")]
        Deleted=2
    }
}
