using System;
using System.IO;
using System.Web.UI;
using System.Collections.Generic;

namespace PoshUIkit {
    public class Dropdown {
        public List<string> UKClasses { get; set; }
        public Button Button;

        // Join classes together so we can apply them at the same time
        public string allClasses {
            get {
                if (this.UKClasses.Count == 0) {
                    return null;
                } else {
                    return string.Join(" ", UKClasses);
                }
            }
        }
        
        // Html method
        public string Html() {
            StringWriter stringWriter = new StringWriter();
            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter)) {
                
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "uk-button-dropdown");
                writer.AddAttribute("data-uk-dropdown", null);
                writer.RenderBeginTag(HtmlTextWriterTag.Div); // Begin #1
                
                writer.WriteLine(Button.Html());
                
                writer.RenderEndTag(); // End #1
            }
            return stringWriter.ToString();
        }
        
        // Constructor
        public Dropdown () {
		}
    }
}