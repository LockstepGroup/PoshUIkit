using System;
using System.IO;
using System.Web.UI;


namespace PoshUIkit {
    public class ButtonGroup {
        public string Html() {
            StringWriter stringWriter = new StringWriter();
            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter)) {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "uk-button-group");
                writer.RenderBeginTag(HtmlTextWriterTag.Div); // Begin #1
                writer.RenderEndTag(); // End #1
            }
            return stringWriter.ToString();
        }
    }
}