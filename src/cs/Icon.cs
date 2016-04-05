using System;
using System.IO;
using System.Web.UI;
using System.Collections.Generic;

namespace PoshUIkit {
    public class Icon {
        public string Type;
        public string Name;
        public string Size;
        public List<string> UKClasses;
        
        // Join classes together so we can apply them at the same time
        private string allClasses {
            get {
                string requiredClasses = this.Name;
                
                if (!(UKClasses == null || UKClasses.Count == 0)) {
                    requiredClasses += " " + string.Join(" ", UKClasses);
                }
                
                if (!(String.IsNullOrEmpty(Size))) {
                    requiredClasses += " " + this.Size;
                } 
                return requiredClasses;
            }
        }
        
        // Render Html
        public string Html() {
            StringWriter stringWriter = new StringWriter();
            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter)) {
                
                writer.AddAttribute(HtmlTextWriterAttribute.Class, allClasses);
                
                if (this.Type == "span") {
                    writer.RenderBeginTag(HtmlTextWriterTag.Span); // Begin #1
                } else {
                    writer.RenderBeginTag(HtmlTextWriterTag.I); // Begin #1
                }
                
                writer.RenderEndTag(); // End #1
                
            }
            return stringWriter.ToString();
        }
        
        // Constructor
        public Icon () {
			this.Type = "icon";
		}
    }
}