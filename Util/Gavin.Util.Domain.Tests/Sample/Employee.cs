using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gavin.Util.Domain.Tests.Sample
{
    public class Employee:EntityBase<Guid>
    {
        public Employee(Guid id)
            : base(id)
        {
        }

        public Employee()
            : this(Guid.NewGuid())
        {
        }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage = "姓名不能为空")]
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Required(ErrorMessage = "性别不能为空")]
        public string Gender { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [Range(18, 50, ErrorMessage = "年龄范围为18岁到50岁")]
        public int Age { get; set; }

        /// <summary>
        /// 职业
        /// </summary>
        [Required(ErrorMessage = "职业不能为空")]
        public string Job { get; set; }

        /// <summary>
        /// 工资
        /// </summary>
        public double Salary { get; set; }

    }
}
