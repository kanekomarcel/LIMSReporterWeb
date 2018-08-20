using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LIMSReporterWeb.source.entity
{
    public class Phrase
    {
        #region construtores
        public Phrase() { }

        public Phrase(String id, String text, String type)
        {
            this.id = id;
            this.text = text;
            this.type = type;
        }
        #endregion

        private String id;

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        private String type;

        public String Type
        {
            get { return type; }
            set { type = value; }
        }

        private String text;

        public String Text
        {
            get { return text; }
            set { text = value; }
        }
    }
}