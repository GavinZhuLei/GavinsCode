using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gavin.Util.Domain
{
    /// <summary>
    /// 实体
    /// </summary>
    public interface IEntity
    {
    }

    /// <summary>
    /// 实体
    /// </summary>
    /// <typeparam name="T">标识类型</typeparam>
    public interface IEntity<out T> : IEntity
    {
        /// <summary>
        /// 标识
        /// </summary>
        T Id { get; }
    }
}
