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
    /// <typeparam name="T"></typeparam>
    public abstract class EntityBase<T>
    {
        #region 构造方法
        /// <summary>
        /// 初始化领域实体
        /// </summary>
        /// <param name="id">标识</param>
        protected EntityBase(T id)
        {
            Id = id;
            _rules = new List<IValidationRule>();
            _handler = new ValidationHandler();
        }
        #endregion

        #region 字段

        /// <summary>
        /// 验证规则集合
        /// </summary>
        private readonly List<IValidationRule> _rules;

        /// <summary>
        /// 验证处理器
        /// </summary>
        private IValidationHandler _handler;

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


        #region SetValidationHandler(设置验证处理器)
        /// <summary>
        /// 设置验证处理器
        /// </summary>
        /// <param name="handler">验证处理器</param>
        public void SetValidationHandler(IValidationHandler handler)
        {
            if (handler == null)
                return;
            _handler = handler;
        }

        #endregion

        #region AddValidationRule(添加验证规则)
        /// <summary>
        /// 添加验证规则
        /// </summary>
        /// <param name="rule">验证规则</param>
        public void AddValidationRule(IValidationRule rule)
        {
            if (rule == null)
                return;
            _rules.Add(rule);
        }
        #endregion

        



        #region Validate(验证)

        /// <summary>
        /// 验证
        /// </summary>
        public virtual void Validate()
        {
            var result = GetValidationResult();
            HandleValidationResult(result);
        }

        /// <summary>
        /// 获取验证结果
        /// </summary>
        private ValidationResultCollection GetValidationResult()
        {
            var result = ValidationFactory.Create().Validate(this);
            Validate(result);
            foreach (var rule in _rules)
                result.Add(rule.Validate());
            return result;
        }

        /// <summary>
        /// 验证并添加到验证结果集合
        /// </summary>
        /// <param name="results">验证结果集合</param>
        protected virtual void Validate(ValidationResultCollection results)
        {
        }

        /// <summary>
        /// 处理验证结果
        /// </summary>
        private void HandleValidationResult(ValidationResultCollection results)
        {
            if (results.IsValid)
                return;
            _handler.Handle(results);
        }

        #endregion
    }
}
