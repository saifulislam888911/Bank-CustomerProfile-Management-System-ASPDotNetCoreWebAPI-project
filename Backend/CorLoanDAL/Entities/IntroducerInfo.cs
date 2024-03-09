using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CorLoan.DAL.Entities
{
    [Table("INTRODUCER_INFO_SA")]
    public class IntroducerInfo : ModelBase<IntroducerInfo>
    {
        [Key]
        [Column("INTRODUCER_ID")]
        [Display(Name = "INTRODUCER ID")]
        public string? INTRODUCER_ID { get; set; }

        [Key]
        [Column("CUSTOMER_ID")]
        [Display(Name = "Customer ID")]
        public string? CUSTOMER_ID { get; set; }



        [Column("INTRODUCER_TYPE")]
        [Display(Name = "INTRODUCER TYPE")]
        public string? IntroducerType { get; set; }

        [Column("INTRODUCER_ACCBRANCH")]
        [Display(Name = "INTRODUCER ACCBRANCH")]
        public string? IntroducerAccBranch { get; set; }

        [Column("INTRODUCER_ACCNO")]
        [Display(Name = "INTRODUCER ACCNO")]
        public string? IntroducerAccNo { get; set; }

        [Column("INTRODUCER_DETAILS")]
        [Display(Name = "INTRODUCER DETAILS")]
        public string? IntroducerDetails { get; set; }
  
    }
}
