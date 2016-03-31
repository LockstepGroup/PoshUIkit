using System;
using System.IO;
using System.Web.UI;
using System.Collections.Generic;

namespace PoshUIkit {
    public class ListItem {
        public string Label;
        public string Link;
        
        private bool isHeader;
        public bool IsHeader {
            set {
                if (value) {
                    this.IsDivider = false;
                }
                this.isHeader = value;
            }
            get {
                return this.isHeader;
            }
        }
        
        private bool isDivider;
        public bool IsDivider {
            set {
                if (value) {
                    this.IsHeader = false;
                }
                this.isDivider = value;
            }
            get {
                return this.isDivider;
            }
        }
        
        // Html method
        public string Html() {
            StringWriter stringWriter = new StringWriter();
            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter)) {
                
                if (IsHeader) {
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, "uk-nav-header");
                }
                
                if (IsDivider) {
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, "uk-nav-divider");
                }
                
                writer.RenderBeginTag(HtmlTextWriterTag.Li); // Begin #1
                
                if (String.IsNullOrEmpty(Link)) {
                    // Item Text
                    writer.Write(Label);
                } else {
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, Link);
                    writer.RenderBeginTag(HtmlTextWriterTag.A); // Begin #2
                    writer.Write(Label);
                    writer.RenderEndTag(); // End #2
                }
                
                writer.RenderEndTag(); // End #1
            }
            return stringWriter.ToString();
        }
    }
}