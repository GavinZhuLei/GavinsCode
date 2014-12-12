using System;
using Gavin.Util.Domain.Tests.Sample;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gavin.Util.Domain.Tests
{
    /// <summary>
    /// 值对象测试
    /// </summary>
    [TestClass]
    public class ValueObjectBaseTest
    {
        /// <summary>
        /// 地址1
        /// </summary>
        private Address _address1;
        /// <summary>
        /// 地址2
        /// </summary>
        private Address _address2;
        /// <summary>
        /// 地址3
        /// </summary>
        private Address _address3;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit()
        {
            _address1 = new Address("a", "b");
            _address2 = new Address("a", "b");
            _address3 = new Address("1", "");
        }

        /// <summary>
        /// 测试对象相等性
        /// </summary>
        [TestMethod]
        public void TestEquals()
        {
            Assert.IsFalse(_address1.Equals(null));
            Assert.IsFalse(_address1 == null);
            Assert.IsFalse(null == _address1);
            Assert.IsTrue(_address1.Equals(_address2), "_address1.Equals( _address2 )");
            Assert.IsTrue(_address1 == _address2, "_address1 == _address2");
            Assert.IsFalse(_address1 != _address2, "_address1 != _address2");
            Assert.IsFalse(_address1 == _address3, "_address1 == _address3");
        }

        /// <summary>
        /// 测试哈希
        /// </summary>
        [TestMethod]
        public void TestGetHashCode()
        {
            Assert.IsTrue(_address1.GetHashCode() == _address2.GetHashCode(), "_address1.GetHashCode() == _address2.GetHashCode()");
            Assert.IsFalse(_address1.GetHashCode() == _address3.GetHashCode(), "_address1.GetHashCode() == _address3.GetHashCode()");
        }

        /// <summary>
        /// 测试克隆
        /// </summary>
        [TestMethod]
        public void TestClone()
        {
            _address3 = _address1.Clone();
            Assert.IsTrue(_address1 == _address3);
        }
    }
}
