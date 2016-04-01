using System;
using System.IO;
using System.Web.UI;
using System.Collections.Generic;

namespace PoshUIkit {
    public class UnorderedList {
        public List<string> UKClasses { get; set; }

        // Join classes together so we can apply them at the same time
        private string allClasses {
            get {
                if (UKClasses == null || UKClasses.Count == 0) {
                    return "uk-list";
                } else {
                    string requiredClasses = "uk-list ";
                    requiredClasses += string.Join(" ", UKClasses); 
                    return requiredClasses;
                }
            }
        }
        
        public List<ListItem> ListItems { get; set; }
        
        // Html method
        public string Html() {
            StringWriter stringWriter = new StringWriter();
            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter)) {
                
                writer.AddAttribute(HtmlTextWriterAttribute.Class, allClasses);
                writer.RenderBeginTag(HtmlTextWriterTag.Ul); // Begin #1
                
                
                foreach (var item in ListItems) {
                    writer.WriteLine(item.Html());
                }
                
                writer.RenderEndTag(); // End #1
            }
            return stringWriter.ToString();
        }
        
        // Constructor
        public UnorderedList () {
			this.ListItems = new List<ListItem> {};
            this.UKClasses = new List<string> {};
		}
    }
}