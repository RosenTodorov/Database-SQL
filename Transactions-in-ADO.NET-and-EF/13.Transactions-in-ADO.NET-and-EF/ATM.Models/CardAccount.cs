using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ATM.Models
{
    public class CardAccount
    {
        [Key]
        public int CardAccountId { get; set; }

        public string CardNumber { get; set; }

        public string CardPin { get; set; }

        public decimal CardCash { get; set; }
    }
}
