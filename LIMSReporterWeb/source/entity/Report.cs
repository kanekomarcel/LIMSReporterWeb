using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LIMSReporterWeb.source.entity
{
    public class Report
    {
        private String id;

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private bool faturado;

        public bool Faturado
        {
            get { return faturado; }
            set { faturado = value; }
        }

        private String description;

        public String Description { get => description; set => description = value; }

        private String library;

        public string Library { get => library; set => library = value; }

        private String im_report;

        public string IM_Report { get => im_report; set => im_report = value; }
    }
}