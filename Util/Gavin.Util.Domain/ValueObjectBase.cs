using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gavin.Util.Domain
{
    /// <summary>
    /// 值对象
    /// </summary>
    /// <typeparam name="T">值对象类型</typeparam>
    public abstract class ValueObjectBase<T> : DomainBase, IEquatable<T> where T : ValueObjectBase<T>
    {

        #region Equals(相等性比较)

        /// <summary>
        /// 相等性比较
        /// </summary>
        public bool Equals(T other)
        {
            return this == other;
        }

        /// <summary>
        /// 相等性比较
        /// </summary>
        public override bool Equals(object other)
        {
            return Equals(other as T);
        }

        #endregion

        #region ==(相等性比较)

        /// <summary>
        /// 相等性比较
        /// </summary>
        public static bool operator ==(ValueObjectBase<T> valueObject1, ValueObjectBase<T> valueObject2)
        {
            if ((object)valueObject1 == null && (object)valueObject2 == null)
                return true;
            if ((object)valueObject1 == null || (object)valueObject2 == null)
                return false;
            if (valueObject1.GetType() != valueObject2.GetType())
                return false;
            var properties = valueObject1.GetType().GetProperties();
            return properties.All(property => property.GetValue(valueObject1) == property.GetValue(valueObject2));
        }

        #endregion

        #region !=(不相等比较)

        /// <summary>
        /// 不相等比较
        /// </summary>
        public static bool operator !=(ValueObjectBase<T> valueObject1, ValueObjectBase<T> valueObject2)
        {
            return !(valueObject1 == valueObject2);
        }

        #endregion

        #region GetHashCode(获取哈希)

        /// <summary>
        /// 获取哈希
        /// </summary>
        public override int GetHashCode()
        {
            var properties = GetType().GetProperties();
            return properties.Select(property => property.GetValue(this))
                    .Where(value => value != null)
                    .Aggregate(0, (current, value) => current ^ value.GetHashCode());
        }

        #endregion

        #region Clone(克隆副本)

        /// <summary>
        /// 克隆副本
        /// </summary>
        public virtual T Clone()
        {
            return (T)MemberwiseClone();
        }

        #endregion
    }
}
