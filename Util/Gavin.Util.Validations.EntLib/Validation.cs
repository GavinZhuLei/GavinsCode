﻿using Microsoft.Practices.EnterpriseLibrary.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gavin.Util.Validations.EntLib
{
    public class Validation:IValidation
    {
        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="target">验证目标</param>
        public ValidationResultCollection Validate(object target)
        {
            var validator = ValidationFactory.CreateValidator(target.GetType());
            var results = validator.Validate(target);
            return GetResult(results);
        }

        /// <summary>
        /// 获取验证结果
        /// </summary>
        private ValidationResultCollection GetResult(IEnumerable<ValidationResult> results)
        {
            var result = new ValidationResultCollection();
            foreach (var each in results)
                result.Add(new System.ComponentModel.DataAnnotations.ValidationResult(each.Message));
            return result;
        }
    }
}
