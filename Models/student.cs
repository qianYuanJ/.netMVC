using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace netcoremvc
{
    public partial class student
    {
        public int Id { get; set; }
        [Required]
        [StringLength(300, ErrorMessage = "不能超过300")]
        [DisplayName("姓名")]
        public string Name { get; set; }
        [Required]
        [StringLength(1, ErrorMessage = "只能输入一个")]
        [DisplayName("性别")]
        public string Sex { get; set; }
        [Range(1,200,ErrorMessage ="范围只能在1-200之间")]
        [DisplayName("年龄")]
        public int Age { get; set; }
        [DisplayName("出生日期")]
        public string Birthday { get; set; }
        [Required]
        [StringLength(13,ErrorMessage ="长度为13位")]
        [DisplayName("手机")]
        public string Mobile { get; set; }
        [Range(30, 50, ErrorMessage = "范围只能在30-50之间")] 
        [DisplayName("体温")]
        public decimal Temperature { get; set; }
        [DisplayName("填表日期")]
        public DateTime CreateTime { get; set; }
    }
}
