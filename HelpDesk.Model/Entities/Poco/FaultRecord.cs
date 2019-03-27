using HelpDesk.Model.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HelpDesk.Model.Entities.Poco
{
    [Table("FaultRecords")]
    public class FaultRecord : BaseEntity<int>
    {
        [Required(ErrorMessage = "Lütfen Açıklama Kısmını Doldurunuz.")]
        [DisplayName("Arıza Açıklaması")]
        [StringLength(1000, ErrorMessage = "Açıklama 1000 karakterden fazla olamaz.")]
        public string FaultDescription { get; set; }

        [Required(ErrorMessage = "Adres Alanını Doldurunuz.")]
        [DisplayName("Adres Giriniz")]
        [StringLength(500, ErrorMessage = "Adres Alanı max 500 karakter olabilir.")]
        public string Adress { get; set; }
        [DisplayName("Telefon numarası")]
        public string PhoneNumber { get; set; }

    }
}
