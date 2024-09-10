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
    [DefaultProperty("SehirAdi")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Iller : BaseObject
    {  public Iller(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        string _sehirAdi;
        int _plakaKodu;

        [XafDisplayName("Şehir Adı")]
         [RuleRequiredField(DefaultContexts.Save)]
        public string SehirAdi
        {
            get => _sehirAdi;
            set => SetPropertyValue(nameof(SehirAdi), ref _sehirAdi, value);
        }

        [Size(2)]
        [XafDisplayName("Şehir Plaka Kodu")]
        public int PlakaKodu
        {
            get => _plakaKodu;
            set => SetPropertyValue(nameof(PlakaKodu), ref _plakaKodu, value);
        }

        [Association("Iller-Ilceler")]
        public XPCollection<Ilceler> Ilceler
        {
            get
            {
                return GetCollection<Ilceler>(nameof(Ilceler));
            }
        }
    }
}