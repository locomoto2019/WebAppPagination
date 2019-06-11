using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppPagination.Models
{
    [Table("StudentDetails")]
    public class StudentModel
    {
        [Key]
        public string studentid { get; set; }
        public string shortname { get; set; }
        public string classname { get; set; }
    }
}