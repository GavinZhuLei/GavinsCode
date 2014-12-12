using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gavin.Util.Validations;

namespace Gavin.Util.Domain
{
    /// <summary>
    /// 领域实体
    /// </summary>
    /// <typeparam name="T">标识类型</typeparam>
    public abstract class EntityBase<T>:DomainBase
    {
        #region 构造方法
        /// <summary>
        /// 初始化领域实体
        /// </summary>
        /// <param name="id">标识</param>
        protected EntityBase(T id)
        {
            Id = id;
        }
        #endregion

        #region 字段


        #endregion

        #region Id(标识)

        /// <summary>
        /// 标识
        /// </summary>
        [Required]
        public T Id { get; private set; }

        #endregion

        #region Equals(相等运算)

        /// <summary>
        /// 相等运算
        /// </summary>
        public override bool Equals(object entity)
        {
            if (entity == null)
                return false;
            if (!(entity is EntityBase<T>))
                return false;
            return this == (EntityBase<T>)entity;
        }

        #endregion

        #region GetHashCode(获取哈希)

        /// <summary>
        /// 获取哈希
        /// </summary>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion

        #region ==(相等比较)

        /// <summary>
        /// 相等比较
        /// </summary>
        /// <param name="entity1">领域实体1</param>
        /// <param name="entity2">领域实体2</param>
        public static bool operator == (EntityBase<T> entity1, EntityBase<T> entity2)
        {
            if ((object)entity1 == null && (object)entity2 == null)
                return true;
            if ((object)entity1 == null || (object)entity2 == null)
                return false;
            if (entity1.Id == null)
                return false;
            if (entity1.Id.Equals(default(T)))
                return false;
            return entity1.Id.Equals(entity2.Id);
        }

        #endregion

        #region !=(不相等比较)

        /// <summary>
        /// 不相等比较
        /// </summary>
        /// <param name="entity1">领域实体1</param>
        /// <param name="entity2">领域实体2</param>
        public static bool operator !=(EntityBase<T> entity1, EntityBase<T> entity2)
        {
            return !(entity1 == entity2);
        }

        #endregion
    }
}
