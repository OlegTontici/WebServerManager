using System;
using System.Collections.Generic;
using Microsoft.Web.Administration;

namespace IISManager.Models
{
    public class SiteData
    {
        public Site Site { get; set; }
        public ApplicationPool ApplicationPool { get; set; }

        public SiteData(Site site,ApplicationPool applicationPool)
        {
            Site = site;
            ApplicationPool = applicationPool;
        }
    }
}
