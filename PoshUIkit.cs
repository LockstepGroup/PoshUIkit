using System;
using System.Web.UI;
using System.IO;
using System.Collections.Generic;
namespace PoshUIkit {
    public class Button {
        public List<string> Classes;
        public string Label;
        public string Link;
        
        // Join classes together so we can apply them at the same time
        private string allClasses {
            get {
                return string.Join(" ", Classes);
            }
        }
        
        // Render Html
        public string Html() {
            StringWriter stringWriter = new StringWriter();
            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter)) {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, allClasses);
                
                if (String.IsNullOrEmpty(Link)) {
                    writer.RenderBeginTag(HtmlTextWriterTag.Button); // Begin #1
                } else {
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, Link);
                    writer.RenderBeginTag(HtmlTextWriterTag.A); // Begin #1
                }
                
                writer.Write(Label);
                
                writer.RenderEndTag(); // End #1
            }
            return stringWriter.ToString();
        }
        
        // Constructor
        public Button () {
			this.Classes = new List<string> {"uk-button"};
		}
    }
    public class ButtonGroup {
        public List<string> Elements { get; set; }
        public string Html() {
            StringWriter stringWriter = new StringWriter();
            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter)) {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "uk-button-group");
                writer.RenderBeginTag(HtmlTextWriterTag.Div); // Begin #1
                
                foreach (var e in Elements) {
                    writer.Write(e);
                }
                
                writer.RenderEndTag(); // End #1
            }
            return stringWriter.ToString();
        }
    }
}
