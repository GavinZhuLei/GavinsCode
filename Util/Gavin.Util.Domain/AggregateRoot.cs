using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gavin.Util.Domain
{
    /// <summary>
    /// 聚合根
    /// </summary>
    /// <typeparam name="T">标识类型</typeparam>
    public abstract class AggregateRoot<T> : EntityBase<T>, IAggregateRoot<T>
    {
        /// <summary>
        /// 初始化聚合根
        /// </summary>
        /// <param name="id">标识</param>
        protected AggregateRoot(T id)
            : base(id)
        {
        }

        /// <summary>
        /// 版本号(乐观锁)
        /// </summary>
        public byte[] Version { get; set; }
    }
}
