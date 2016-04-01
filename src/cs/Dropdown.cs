using System;
using System.IO;
using System.Web.UI;
using System.Collections.Generic;

namespace PoshUIkit {
    public class Dropdown {
        public List<string> UKClasses { get; set; }
        public Button Button;
        public UnorderedList List;
        public string Mode;

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
            // Add needed classes to List
            List.UKClasses.Add("uk-nav");
            List.UKClasses.Add("uk-nav-dropdown");
            
            StringWriter stringWriter = new StringWriter();
            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter)) {
                                
                // Outer Div
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "uk-button-dropdown");
                
                switch (this.Mode) {
                    case "hover":
                        writer.AddAttribute("data-uk-dropdown", null);
                        break;
                    case "click":
                        writer.AddAttribute("data-uk-dropdown", "{mode:'click'}", false);
                        break;
                }
                
                writer.RenderBeginTag(HtmlTextWriterTag.Div); // Begin #1
                
                //Button
                writer.WriteLine(Button.Html());
                
                //List Div
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "uk-dropdown uk-dropdown-small");
                writer.RenderBeginTag(HtmlTextWriterTag.Div); // Begin #2
                
                writer.Write(List.Html());
                
                writer.RenderEndTag(); // End #2
                writer.RenderEndTag(); // End #1
            }
            return stringWriter.ToString();
        }
        
        // Constructor
        public Dropdown () {
            this.Mode = "hover";
		}
    }
}