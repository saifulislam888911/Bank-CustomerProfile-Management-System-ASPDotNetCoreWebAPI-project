using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CorLoan.DAL.Entities
{
    [Table("COUNTRY")]
    public class CountryInfo : ModelBase<CountryInfo>
    {        
        [Key]
        [Column("COUNTRY_ID")]
        [Display(Name = "COUNTRY ID")]
        public string? COUNTRY_ID { get; set; }


        [Column("COUNTRY_NM")]
        [Display(Name = "COUNTRY NM")]
        public string? COUNTRY_NM { get; set; }
    }
}
