using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CorLoan.DAL.Entities
{
    [Table("DISTRICT")]
    public class DistrictInfo : ModelBase<DistrictInfo>
    {
        [Key]
        [Column("DIVISION_ID")]
        [Display(Name = "DIVISION ID")]
        public string? DIVISION_ID { get; set; }

        [Column("DIVISION_NM")]
        [Display(Name = "DIVISION_NM")]
        public string? DIVISION_NM { get; set; }


        [Key]
        [Column("DISTRICT_ID")]
        [Display(Name = "DISTRICT ID")]
        public string? DISTRICT_ID { get; set; }

        [Column("DISTRICT_NM")]
        [Display(Name = "DISTRICT_NM")]
        public string? DISTRICT_NM { get; set; }
    }
}
