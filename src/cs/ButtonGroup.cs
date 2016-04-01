using System;
using System.IO;
using System.Web.UI;
using System.Collections.Generic;

namespace PoshUIkit {
    public class ButtonGroup {
        public List<Button> Buttons;
        public Dropdown Dropdown;
        
        public string Html() {
            StringWriter stringWriter = new StringWriter();
            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter)) {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "uk-button-group");
                writer.RenderBeginTag(HtmlTextWriterTag.Div); // Begin #1
                
                if (Buttons.Count != 0) {
                    foreach (var b in Buttons) {
                        writer.WriteLine(b.Html());
                    }
                } else {
                    writer.WriteLine(Dropdown.Button.Html());
                    Icon caretIcon = new Icon {};
                    caretIcon.Name = "uk-icon-caret-down";
                    Dropdown.Button.Label = caretIcon.Html();
                    writer.Write(Dropdown.Html());
                }
                
                writer.RenderEndTag(); // End #1
            }
            return stringWriter.ToString();
        }
        
        public ButtonGroup () {
			this.Buttons = new List<Button> {};
		}
    }
}