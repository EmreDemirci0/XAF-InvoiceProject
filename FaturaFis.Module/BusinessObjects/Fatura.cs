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
    //[ImageName("BO_Contact")]
    [DefaultProperty("FaturaNo")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Fatura : BaseObject
    {
        public Fatura(Session session)
              : base(session)
        {

        }
        private string _faturaTipi;
        private string _faturaNo;
        private DateTime _faturaTarihi;
        private DateTime _vadeTarihi;
        private Satici _satici;
        private Musteri _musteri;
        public override void AfterConstruction()
        {
            base.AfterConstruction();
           
            if (Session.IsNewObject(this))
            {
                // Yeni nesne için yapılacak işlemler
                // Örneğin, varsayılan bir değer atanabilir:
                // this.SomeProperty = "Default Value";
                _faturaTarihi = DateTime.Now;
            }
            
            

        }
       

        [Size(100)]
        [XafDisplayName("Fatura Tipi")]
        public string FaturaTipi
        {
            get => _faturaTipi;
            set => SetPropertyValue(nameof(FaturaTipi), ref _faturaTipi, value);
        }

        [Size(100)]
         [RuleRequiredField(DefaultContexts.Save)]
        [XafDisplayName("Fatura No")]
        public string FaturaNo
        {
            get => _faturaNo;
            set => SetPropertyValue(nameof(FaturaNo), ref _faturaNo, value);
        }

        [Size(100)]
         [RuleRequiredField(DefaultContexts.Save)]
        [XafDisplayName("Fatura Tarihi")]
        public DateTime FaturaTarihi
        {
            get => _faturaTarihi;
            set => SetPropertyValue(nameof(FaturaTarihi), ref _faturaTarihi, value);
        }

        [Size(100)]
        [XafDisplayName("Vade Tarihi")]
        public DateTime VadeTarihi
        {
            get => _vadeTarihi;
            set => SetPropertyValue(nameof(VadeTarihi), ref _vadeTarihi, value);
        }


        [Size(300)]
        [ModelDefault("RowCount", "0")]
         [RuleRequiredField(DefaultContexts.Save)]
        [XafDisplayName("Satıcı")]
        public Satici Satici
        {
            get => _satici;
            set => SetPropertyValue(nameof(Satici), ref _satici, value);
        }

        [Size(100)]
        [XafDisplayName("Alıcı")]
         [RuleRequiredField(DefaultContexts.Save)]
        public Musteri Musteri
        {
            get => _musteri;
            set => SetPropertyValue(nameof(Musteri), ref _musteri, value);
        }
        // Urunler Listesini tanımlama
        [Association("Fatura-FaturaHareketleri")]
        [DevExpress.Xpo.Aggregated]
         [RuleRequiredField(DefaultContexts.Save)]
        [XafDisplayName("Fatura Hareketleri")]
        public XPCollection<FaturaHareketleri> FaturaHareketleri
        {
            get
            {
                return GetCollection<FaturaHareketleri>(nameof(FaturaHareketleri));
            }
        }


    }
}