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
    [DefaultProperty("IlceAdi")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Ilceler : BaseObject
    {
        public Ilceler(Session session)
              : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        Iller _ilId;
        string _ilceAdi;

        [XafDisplayName("İlçe Adı")]
         [RuleRequiredField(DefaultContexts.Save)]
        public string IlceAdi
        {
            get => _ilceAdi;
            set => SetPropertyValue(nameof(IlceAdi), ref _ilceAdi, value);
        }

        [XafDisplayName("İl")]
         [RuleRequiredField(DefaultContexts.Save)]
        [Association("Iller-Ilceler")]
        public Iller IlID
        {
            get => _ilId;
            set => SetPropertyValue(nameof(IlID), ref _ilId, value);
        }
    }
}