﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.Models.ViewModel
{
    public class inboxlist_viewmodel
    {

        public int ID { get; set; }
        public string Recipient { get; set; }
        public string Sender { get; set; }
        public System.DateTime Senddate { get; set; }
        public string subject { get; set; }
        public byte[] attachments { get; set; }
    }
}