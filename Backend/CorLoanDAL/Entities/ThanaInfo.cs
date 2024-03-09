using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CorLoan.DAL.Entities
{
    [Table("THANA")]
    public class ThanaInfo : ModelBase<ThanaInfo>
    {
        [Key]
        [Column("DISTRICT_ID")]
        [Display(Name = "DISTRICT ID")]
        public string? DISTRICT_ID { get; set; }

        [Column("DISTRICT_NM")]
        [Display(Name = "DISTRICT_NM")]
        public string? DISTRICT_NM { get; set; }


        [Key]
        [Column("THANA_ID")]
        [Display(Name = "THANA ID")]
        public string? THANA_ID { get; set; }

        [Column("DISTRICT_NM")]
        [Display(Name = "THANA_NM")]
        public string? THANA_NM { get; set; }
    }
}
