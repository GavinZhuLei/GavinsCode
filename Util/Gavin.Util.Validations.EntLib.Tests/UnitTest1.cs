using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gavin.Util.Validations.EntLib.Tests
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// 验证测试
        /// </summary>
        [TestClass]
        public class ValidationTest
        {
            /// <summary>
            /// 测试
            /// </summary>
            private Test _test;
            /// <summary>
            /// 验证操作
            /// </summary>
            private IValidation _validation;

            /// <summary>
            /// 测试初始化
            /// </summary>
            [TestInitialize]
            public void TestInit()
            {
                _test = new Test();
                _validation = new Validation();
            }

            /// <summary>
            /// 验证姓名为必填项
            /// </summary>
            [TestMethod]
            public void TestRequired()
            {
                var result = _validation.Validate(_test);
                Assert.AreEqual("姓名不能为空", result.First().ErrorMessage);
            }

            /// <summary>
            /// 验证姓名为必填项及描述过长
            /// </summary>
            [TestMethod]
            public void TestRequired_StringLength()
            {
                _test.Description = "123456";
                var result = _validation.Validate(_test);
                Assert.AreEqual(2, result.Count);
                Assert.AreEqual("描述不能超过5位", result.Last().ErrorMessage);
            }
        }
    }
}
