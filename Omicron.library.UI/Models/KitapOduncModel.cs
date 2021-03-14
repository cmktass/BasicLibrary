using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Omicron.library.UI.Models
{
    public class KitapOduncModel
    {
        [Required(ErrorMessage ="Bu Alan Boş Geçilemez.")]
        public Guid ISBN { get; set; }

        [Required(ErrorMessage = "Bu Alan Boş Geçilemez.")]
        public int Tc { get; set; }
    }
}
