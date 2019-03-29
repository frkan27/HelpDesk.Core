using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HelpDesk.Model.Entities.Poco;
using HelpDesk.Model.Enums.FaultEnums;
using Microsoft.AspNetCore.Http;

namespace HelpDesk.Model.ViewModels.FaultViewModels
{
    public class FaultViewModels
    {
        
        public int ArizaId { get; set; }

        [Required(ErrorMessage = "Lütfen Açıklama kısmını doldurdunuz.")]
        [DisplayName("Arıza Açıklaması")]
        [StringLength(1000)]
        public string ArızaAcıklaması { get; set; }

        [Required(ErrorMessage = "Adres Alanını doldurunuz.")]
        [DisplayName("Adres Giriniz :")]
        [StringLength(500, ErrorMessage = "Adres Alanı max 500 karakter olabilir.")]
        public string Adres { get; set; }

        [DisplayName("Telefon Numarası :")]
        public string Telno { get; set; }

        [DisplayName("İletişim Maili")]
        public string Email { get; set; }


        public double? Enlem { get; set; }

        public double? Boylam { get; set; }

        public string UserId { get; set; }

        //TODO resimler için gerekli alanlar kısmı
        [DisplayName("Ürün Resmi Ekleyiniz :")]
        public List<string> ArızaPath { get; set; }
        [DisplayName("Arızali Ürün Resmini Ekleyiniz :")]
        public List<IFormFile> PostedFileAriza { get; set; }
        [DisplayName("Fatura Resmini Ekleyiniz")]
        public string FaturaPath { get; set; }
        [DisplayName("Ürünün Fatura Resmini Ekleyiniz.")]
        public IFormFile PostedFileFatura { get; set; }


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
        //default olarak çözülemedi atadık.


        //TODO ENUMS
        [DisplayName("Çözüm Durumunu Seçiniz")]
        public TechnicianState? TechnicianFailureCondition { get; set; }
        public FaultCondition FaultCondition { get; set; } = FaultCondition.Waiting;
        [DisplayName("Ürün Tipini Seçiniz")]
        public Brand BeyazEsya { get; set; }
        public bool OperatorAccept { get; set; } = false;
        [DisplayName("Teknisyen Arıza Açıklaması")]
        public string TechnicialFaultDescription { get; set; }

        //TODO Bosta alan teknisyenleri için
        public TechnicianState TechnicianState { get; set; } = TechnicianState.Available;


        [Required]
        public string MusteriId { get; set; }
        public string OperatorId { get; set; }
        public string TeknisyenId { get; set; }

        //TODO arizaLogViewModel için
        public List<FaultLOG> FaultLogs { get; set; }

        //TODO ANKET KISMI
        [DisplayName("Teknisyenin Konu Hakkında Bilgisi Yeterli miydi ?")]
        public SurveyEnum TechnicianInfoPoints { get; set; }
        [DisplayName("Teknisyenin Size Karşı Davranışı nasıldı ?")]
        public SurveyEnum TechnicianBehaviorScore { get; set; }
        [DisplayName("Çözüm Sürecinde Fitech Çalışanlarının iletişimi Nasıldı ?")]
        public SurveyEnum FitechBehaviorScorei { get; set; }
        [DisplayName("FiTechten Memnun Kaldınız mı ?")]
        public SurveyEnum ServiceScore { get; set; }
        [DisplayName("FİTech Hakkındaki Görüşleriniz.")]
        public string OpinionsAboutFitech { get; set; }

        public bool SurveyIsCompleted { get; set; } = false;
        public virtual List<Photo> Fotograflar { get; set; } = new List<Photo>();
    }
}
