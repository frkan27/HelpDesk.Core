using HelpDesk.Model.Entities.BaseEntities;
using HelpDesk.Model.Enums.FaultEnums;
using HelpDesk.Model.IdentityEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [DisplayName("Aktif İletişim Maili")]
        public string Email { get; set; }

        // TODO Harita Alanı için gerekli kısım
        [DisplayName("Enlem Giriniz")]
        public double? latitude { get; set; }
        [DisplayName("Boylam Giriniz ")]
        public double? longitude { get; set; }

        // TODO REsimler için gerekli alanlar kısmı
       
        //todo view modelyapcaksın bu alanı resim için.
        [DisplayName("Fatura Resmini Ekleyiniz")]
        public string BillPath { get; set; }

        //TODO TARİH KISMI
        [DisplayName("Arızanın Olusturuldugu Tarihi")]
        public DateTime FaultCreatedDate { get; set; } = DateTime.Now;
        [DisplayName("Operator Kabul Tarihi")]
        public DateTime? OperatorAcceptDate { get; set; }
        [DisplayName("Operator Teknisyen Atadıgı Tarih")]
        public DateTime? TechnicianAppointedDate { get; set; }
        [DisplayName("Arızanın Çözüldüğü Tarih")]
        public DateTime? FaultSolveDate { get; set; }
        [DisplayName("Arıza Son Kontrol Tarihi")]
        public DateTime? FaultLastCheckDate { get; set; }

        //todo otomatik olarak false sen operator sayfasında false olanları getirirsin. eger onaylarsa yeni bir sayfasına true olanları alırsın. ve orda yönlendirmeyi yaparsın. Yerse belki ariza durum a da onaylandi eklenebilir.
        public bool OperatorAccept { get; set; } = false;

        //TODO Operatör icin bool alan.
        public string SurveyCode { get; set; }

        // Raporlamaiiçn belki gerekli olur.
        public FaultRecordState FaultRecordState { get; set; } = FaultRecordState.Unapproved;

        // Teknisyen durumu için gerekli alan
        public TechnicianState TechnicianState { get; set; } = TechnicianState.Available;

        [Required]
        public string CustomerId { get; set; }
        public string OperatorId { get; set; }
        public string TechnicianId { get; set; }

        [ForeignKey("CustomerId")]
        public ApplicationUser Customer { get; set; }
        [ForeignKey("OperatorId")]
        public ApplicationUser Operator { get; set; }
        [ForeignKey("TechnicianId")]
        public ApplicationUser Technician { get; set; }

        //TODO ANKET KISMI

        [DisplayName("Teknisyenin Konu Hakkında Bilgisi Yeterli miydi ?")]
        public SurveyEnum TechnicianInfoPoints
        { get; set; }
        [DisplayName("Teknisyenin Size Karşı Davranışı nasıldı ?")]
        public SurveyEnum TechnicianBehaviorScore { get; set; }
        [DisplayName("Çözüm Sürecinde Fitech Çalışanlarının iletişimi Nasıldı ?")]
        public SurveyEnum FitechBehaviorScorei { get; set; }
        [DisplayName("FiTechten Memnun Kaldınız mı ?")]
        public SurveyEnum ServiceScore { get; set; }
        [DisplayName("FİTech Hakkındaki Görüşleriniz.")]
        public string OpinionsAboutFitech { get; set; }

        //TODO anket yapıldımı için alan.
        public bool SurveyIsCompleted { get; set; } = false;

        public virtual List<Photo> Photos { get; set; } = new List<Photo>();

    }
}
