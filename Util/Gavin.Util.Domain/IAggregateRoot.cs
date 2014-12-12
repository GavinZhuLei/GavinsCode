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
    public interface IAggregateRoot : IEntity
    {
        /// <summary>
        /// 版本号(乐观锁)
        /// </summary>
        byte[] Version { get; set; }
    }

    /// <summary>
    /// 聚合根
    /// </summary>
    /// <typeparam name="T">标识类型</typeparam>
    public interface IAggregateRoot<out T> : IEntity<T>, IAggregateRoot
    {
    }
}
