using System;
using Gavin.Util.Domain.Tests.Sample;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gavin.Util.Domain.Tests
{
    /// <summary>
    /// 实体基类测试
    /// </summary>
    [TestClass]
    public class EntityBaseTest
    {
        /// <summary>
        /// 测试验证
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Warning))]
        public void TestValidate()
        {
            try
            {
                Employee employee = new Employee { Name = "程序猿", Gender = "男", Job = "程序员", Age = 41, Salary = 1500 };
                employee.AddValidationRule(new OldProgrammerSalaryRule(employee));
                employee.Validate();
            }
            catch (Warning ex)
            {
                Assert.AreEqual("程序员老男人的工资不能低于1万", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 设置空操作验证处理器,不进行任何操作，所以不会抛出异常
        /// </summary>
        [TestMethod]
        public void TestSetValidationHandler()
        {
            Employee employee = new Employee();
            //employee.SetValidationHandler(new NothingValidationHandler());
            //employee.Validate();
        }
    }
}
