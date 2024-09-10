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
    [DefaultProperty("MusteriAd")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Musteri : XPObject
    {

        public Musteri(Session session)
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
        private string _musteriAdi;
        private string _musteriAdresi;
        private string _telNo;
        private string _eposta;
        private string _vergiDairesi;
        private string _vergiKimlikNo;

        [Size(300)]
         [RuleRequiredField(DefaultContexts.Save)]
        [ModelDefault("RowCount", "0")]
        [XafDisplayName("Müşteri Adı")]
        public string MusteriAd
        {
            get => _musteriAdi;
            set => SetPropertyValue(nameof(MusteriAd), ref _musteriAdi, value);
        }

        [Size(100)]
        [XafDisplayName("Müşteri Adresi")]
        public string Adres
        {
            get => _musteriAdresi;
            set => SetPropertyValue(nameof(Adres), ref _musteriAdresi, value);
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
        

    }
}