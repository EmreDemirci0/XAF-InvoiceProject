using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace FaturaFis.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty("FirmaAd")]
    public class Satici : XPObject
    {

        public Satici(Session session)
              : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        private Iller _il;
        private Ilceler _ilce;
        private string _firmaAdi;
        private string _firmaAdresi;
        private string _telNo;
        private string _webSitesi;
        private string _eposta;
        private string _vergiDairesi;
        private string _vergiKimlikNo;
        private string _ticaretSicilNo;

        [Size(300)]
         [RuleRequiredField(DefaultContexts.Save)]
        [XafDisplayName("Firma Adı")]
        public string FirmaAd
        {
            get => _firmaAdi;
            set => SetPropertyValue(nameof(FirmaAd), ref _firmaAdi, value);
        }

        [Size(100)]
        [XafDisplayName("Firma Adresi")]
        public string Adres
        {
            get => _firmaAdresi;
            set => SetPropertyValue(nameof(Adres), ref _firmaAdresi, value);
        }


        [XafDisplayName("İl")]

        public Iller Il
        {
            get => _il;
            set => SetPropertyValue(nameof(Il), ref _il, value);
        }
        [XafDisplayName("İlçe")]
        [DataSourceProperty("Il.Ilceler")]

        public Ilceler Ilce
        {
            get => _ilce;
            set => SetPropertyValue(nameof(Ilce), ref _ilce, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [XafDisplayName("Web Adresi")]
        public string WebSitesi
        {
            get => _webSitesi;
            set => SetPropertyValue(nameof(WebSitesi), ref _webSitesi, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [ModelDefault("EditMask", "(000)-000-0000")]
        [XafDisplayName("Telefon Numarası")]
        public string TelefonNumarasi
        {
            get => _telNo;
            set => SetPropertyValue(nameof(TelefonNumarasi), ref _telNo, value);
        }
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [XafDisplayName("E-Mail Adresi")]
        public string EPosta
        {
            get => _eposta;
            set => SetPropertyValue(nameof(EPosta), ref _eposta, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [Index(7)]
        [XafDisplayName("Vergi Dairesi")]
        public string VergiDairesi
        {
            get => _vergiDairesi;
            set => SetPropertyValue(nameof(VergiDairesi), ref _vergiDairesi, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [Index(8)]
        [XafDisplayName("Vergi Kimlik No")]
        public string VergiKimlikNo
        {
            get => _vergiKimlikNo;
            set => SetPropertyValue(nameof(VergiKimlikNo), ref _vergiKimlikNo, value);
        }
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [XafDisplayName("Ticaret Sicil No")]
        public string TicaretSicilNo
        {
            get => _ticaretSicilNo;
            set => SetPropertyValue(nameof(TicaretSicilNo), ref _ticaretSicilNo, value);
        }

    }
}