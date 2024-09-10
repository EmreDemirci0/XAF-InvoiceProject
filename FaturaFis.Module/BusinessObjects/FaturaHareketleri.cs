using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace FaturaFis.Module.BusinessObjects
{
    [DefaultClassOptions]

    public class FaturaHareketleri : BaseObject
    {
        public FaturaHareketleri(Session session)
             : base(session)
        {

        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }
        private Fatura _fatura;
        private Urunler _urunler;
        private decimal _miktar;
        private decimal _birimFiyat;
        private decimal _kdvOrani;
        private decimal _kdvTutari;
        private decimal _iskontoOrani;
        private decimal _iskontoTutari;
        private decimal _matrah;
        private decimal _hamTutar;
        private decimal _totalTutar;

        [Association("Fatura-FaturaHareketleri")]
        [XafDisplayName("Fatura")]
        public Fatura Fatura
        {
            get => _fatura;
            set => SetPropertyValue(nameof(Fatura), ref _fatura, value);
        }

        [XafDisplayName("Ürün")]
        [RuleRequiredField(DefaultContexts.Save)]
        public Urunler Ürün
        {
            get => _urunler;
            set => SetPropertyValue(nameof(Ürün), ref _urunler, value);
        }

        [XafDisplayName("Miktar")]
        [ModelDefault("EditMask", "N")]
        [ModelDefault("DisplayFormat", "{0:N2}")]
        [RuleValueComparison("Miktar_GreaterThanZero", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        public decimal Miktar
        {
            get => _miktar;
            set
            {
                if (SetPropertyValue(nameof(Miktar), ref _miktar, value))
                {
                    if (!IsLoading && !IsSaving)
                    {
                        HamTutarHesapla();
                        IskontoHesapla();
                        KdvHesapla();
                    }
                }
            }
        }

        [XafDisplayName("Birim Fiyat")]
        [ModelDefault("EditMask", "C2")]
        [ModelDefault("DisplayFormat", "{0:C2}")]
        [RuleValueComparison("BirimFiyat_GreaterThanZero", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]

        public decimal BirimFiyat
        {
            get => _birimFiyat;
            set
            {
                if (SetPropertyValue(nameof(BirimFiyat), ref _birimFiyat, value))
                {
                    if (!IsLoading && !IsSaving)
                    {
                        HamTutarHesapla();
                        IskontoHesapla();
                        KdvHesapla();
                    }
                }
            }
        }

        [XafDisplayName("KDV Oranı")]
        [ModelDefault("EditMask", "N")]
        [ModelDefault("DisplayFormat", "{0:N2}")]
        [RuleValueComparison("KDVOrani_GreaterThanZero", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]
        [RuleValueComparison("KDVOrani_LessThanOrEqualToOne", DefaultContexts.Save, ValueComparisonType.LessThanOrEqual, 100)]
        public decimal KDVOrani
        {
            get => _kdvOrani;
            set
            {
                if (SetPropertyValue(nameof(KDVOrani), ref _kdvOrani, value))
                {
                    if(!IsLoading && !IsSaving)
                    {
                        HamTutarHesapla();
                        KdvHesapla();
                        IskontoHesapla();
                    }
                }
            }
        }

        [XafDisplayName("KDV Değer Karşılığı")]
        [ModelDefault("EditMask", "C2")]
        [ModelDefault("DisplayFormat", "{0:C2}")]
        
        public decimal KDVtutari
        {
            get => _kdvTutari;
            set => SetPropertyValue(nameof(KDVtutari), ref _kdvTutari, value);
        }

        [XafDisplayName("İskonto Oranı")]
        [ModelDefault("EditMask", "N")]
        [ModelDefault("DisplayFormat", "{0:N2}")]
        [RuleValueComparison("IskontoOrani_GreaterThanZero", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]

        public decimal IskontoOrani
        {
            get => _iskontoOrani;
            set
            {
                if (SetPropertyValue(nameof(IskontoOrani), ref _iskontoOrani, value))
                {
                    if (!IsLoading && !IsSaving)
                    {
                        HamTutarHesapla();
                        IskontoHesapla();
                        KdvHesapla();

                    }
                }
            }
        }

        [XafDisplayName("İskonto Değer Karşılığı")]
        [ModelDefault("EditMask", "C2")]
        [ModelDefault("DisplayFormat", "{0:C2}")]
        public decimal IskontoTutari
        {
            get => _iskontoTutari;
            set => SetPropertyValue(nameof(IskontoTutari), ref _iskontoTutari, value);
        }
        //?
        [XafDisplayName("Matrah")]
        [ModelDefault("EditMask", "C2")]
        [ModelDefault("DisplayFormat", "{0:C2}")]
        [RuleValueComparison("Matrah_GreaterThanZero", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]

        public decimal Matrah
        {
            get => _matrah;
            set => SetPropertyValue(nameof(Matrah), ref _matrah, value);
        }

        [XafDisplayName("Toplam Tutar")]
        [ModelDefault("EditMask", "C2")]
        [ModelDefault("DisplayFormat", "{0:C2}")]
        [RuleValueComparison("TotalTutar_GreaterThanZero", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]

        public decimal TotalTutar
        {
            get => _totalTutar;
            set => SetPropertyValue(nameof(TotalTutar), ref _totalTutar, value);
        }
        [XafDisplayName("Ham Tutar")]
        [ModelDefault("EditMask", "C2")]
        [ModelDefault("DisplayFormat", "{0:C2}")]
        [RuleValueComparison("HamTutar_GreaterThanZero", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 0)]

        public decimal HamTutar
        {
            get => _hamTutar;
            set => SetPropertyValue(nameof(HamTutar), ref _hamTutar, value);
        }
        protected override void OnSaving()
        {
            base.OnSaving();

        }
        private void HamTutarHesapla()
        {
            HamTutar = (BirimFiyat * Miktar);//?
            TotalTutar = HamTutar;
            MatrahHesapla();
        }
        private void KdvHesapla()
        {
            KDVtutari = ((HamTutar- IskontoTutari) * (KDVOrani / 100));
            TotalTutar += KDVtutari;
        }
        private void IskontoHesapla()
        {
            IskontoTutari = /* eksi olsun, rule koyduk ordan değişcez*/(HamTutar * IskontoOrani / 100);
            TotalTutar -= IskontoTutari;
            MatrahHesapla();
        }
        private void MatrahHesapla()
        {
            Matrah = HamTutar - IskontoTutari;
        }

    }
}