using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gavin.Util.Validations;

namespace Gavin.Util.Domain.Tests.Sample
{
    /// <summary>
    /// 程序员老男人的工资验证规则
    /// </summary>
    public class OldProgrammerSalaryRule : IValidationRule
    {
        /// <summary>
        /// 初始化程序员老男人的工资验证规则
        /// </summary>
        /// <param name="employee">员工</param>
        public OldProgrammerSalaryRule(Employee employee)
        {
            _employee = employee;
        }

        /// <summary>
        /// 员工
        /// </summary>
        private readonly Employee _employee;

        /// <summary>
        /// 验证
        /// </summary>
        public ValidationResult Validate()
        {
            if (_employee.Job == "程序员" && _employee.Age > 40 && _employee.Gender == "男" && _employee.Salary < 10000)
                return new ValidationResult("程序员老男人的工资不能低于1万");
            return ValidationResult.Success;
        }
    }
}
