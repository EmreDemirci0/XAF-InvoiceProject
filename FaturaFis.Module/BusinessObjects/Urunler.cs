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
    [DefaultProperty("MalHizmetAdi")]
    public class Urunler : XPObject
    {
        public Urunler(Session session)
             : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private int _siraNo;
        private string _malHizmetKodu;
        private string _malHizmetAdi;
        private string _aciklama;
        //-----------------------------
        //private int _miktar;
        //private double _birimFiyat;
        //private double _iskontoOrani;
        //private double _iskontoTutari;
        //private double _kdvOrani;
        //private double _kdvTutari;
        //private double _malHizmetTutari;
        //-----------------------------

        // [RuleRequiredField(DefaultContexts.Save)]
        [XafDisplayName("Sıra No")]
        [VisibleInDetailView(false)]
        public int SiraNo
        {
            get => _siraNo;
            set => SetPropertyValue(nameof(SiraNo), ref _siraNo, value);
        }

        [Size(100)]
        [RuleRequiredField(DefaultContexts.Save)]
        [XafDisplayName("Mal Hizmet Kodu")]
        public string MalHizmetKodu
        {
            get => _malHizmetKodu;
            set => SetPropertyValue(nameof(MalHizmetKodu), ref _malHizmetKodu, value);
        }

        
        [XafDisplayName("Mal Hizmet Adi")]
         [RuleRequiredField(DefaultContexts.Save)]
        public string MalHizmetAdi
        {
            get => _malHizmetAdi;
            set => SetPropertyValue(nameof(MalHizmetAdi), ref _malHizmetAdi, value);
        }

        [XafDisplayName("Açıklama")]
       
        public string Aciklama
        {
            get => _aciklama;
            set => SetPropertyValue(nameof(Aciklama), ref _aciklama, value);
        }
        protected override void OnSaving()
        {
            base.OnSaving();
            //if (!(Session is NestedUnitOfWork) && (Session.DataLayer != null) && Session.IsNewObject(this) /*&& string.IsNullOrEmpty(SiraNo)*/)
            //{
            //    int deger = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "ProductGroup2");
            //    SiraNo = deger;
            //}
            var maxSiraNo = Session.Query<Urunler>().Max(p => p.SiraNo);
            SiraNo = maxSiraNo + 1;
           
        }
        //[Size(SizeAttribute.DefaultStringMappingFieldSize)]
        //[XafDisplayName("Miktar")]
        //public int Miktar
        //{
        //    get => _miktar;
        //    set => SetPropertyValue(nameof(Miktar), ref _miktar, value);
        //}

        //[Size(SizeAttribute.DefaultStringMappingFieldSize)]
        //[XafDisplayName("Birim Fiyat")]
        //public double BirimFiyat
        //{
        //    get => _birimFiyat;
        //    set => SetPropertyValue(nameof(BirimFiyat), ref _birimFiyat, value);
        //}

        //[Size(SizeAttribute.DefaultStringMappingFieldSize)]
        //[XafDisplayName("İskonto Oranı")]
        //public double IskontoOrani
        //{
        //    get => _iskontoOrani;
        //    set => SetPropertyValue(nameof(IskontoOrani), ref _iskontoOrani, value);
        //}

        //[Size(SizeAttribute.DefaultStringMappingFieldSize)]
        //[XafDisplayName("İskonto Tutarı")]
        //public double IskontoTutari
        //{
        //    get => _iskontoTutari;
        //    set => SetPropertyValue(nameof(IskontoTutari), ref _iskontoTutari, value);
        //}
        //[Size(SizeAttribute.DefaultStringMappingFieldSize)]
        //[XafDisplayName("KDV Oranı")]
        //public double KDVOrani
        //{
        //    get => _kdvOrani;
        //    set => SetPropertyValue(nameof(KDVOrani), ref _kdvOrani, value);
        //}
        //[Size(SizeAttribute.DefaultStringMappingFieldSize)]
        //[XafDisplayName("KDV Tutarı")]
        //public double KDVTutari
        //{
        //    get => _kdvTutari;
        //    set => SetPropertyValue(nameof(KDVTutari), ref _kdvTutari, value);
        //}

        //[Size(SizeAttribute.DefaultStringMappingFieldSize)]
        //[XafDisplayName("Mal Hizmet Tutarı")]
        //public double MalHizmetTutari
        //{
        //    get => _malHizmetTutari;
        //    set => SetPropertyValue(nameof(MalHizmetTutari), ref _malHizmetTutari, value);
        //}

        //[Association("Fatura-Urunler")]
        //public Fatura Fatura
        //{
        //    get => _fatura;
        //    set => SetPropertyValue(nameof(Fatura), ref _fatura, value);
        //}
    }
}