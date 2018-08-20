using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LIMSReporterWeb.source.entity
{
    public class ReportParameter
    {
        private String argument;

        public String Argument
        {
            get { return argument; }
            set { argument = value; }
        }

        private String labelText;

        public String LabelText
        {
            get { return labelText; }
            set { labelText = value; }
        }

        private bool mandatory;

        public bool Mandatory
        {
            get { return mandatory; }
            set { mandatory = value; }
        }

        private String type;

        public String Type
        {
            get { return type; }
            set { type = value; }
        }

        private String tableName;

        public String TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        private String tableColumn;

        public String TableColumn
        {
            get { return tableColumn; }
            set { tableColumn = value; }
        }

        private List<Phrase> phraseList;

        public List<Phrase> PhraseList
        {
            get { return phraseList; }
            set { phraseList = value; }
        }
    }
}