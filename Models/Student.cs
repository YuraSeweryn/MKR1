using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MKR1.Models
{
    public class Student
    {
        public Student() {}

        public Student(string nickName, string name, string surname)
        {
            NickName = nickName;
            Name = name;
            Surname = surname;
        }

        [Key]
        public string NickName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}