using System;
using System.Web.UI;
using System.IO;
using System.Collections.Generic;
namespace PoshUIkit {
    public class Button {
        public List<string> UKClasses;
        public string Label;
        public string Link;
        
        // Join classes together so we can apply them at the same time
        public string allClasses {
            get {
                if (this.UKClasses.Count == 0) {
                    return "uk-button";
                } else {
                    string requiredClasses = "uk-button ";
                    requiredClasses += string.Join(" ", UKClasses); 
                    return requiredClasses;
                }
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
                
                // Button Text
                writer.Write(Label);
                
                
                writer.RenderEndTag(); // End #1
                
            }
            return stringWriter.ToString();
        }
        
        // Constructor
        public Button () {
			this.UKClasses = new List<string> {};
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
    public class Icon {
        public string Type;
        public string Name;
        public string Size;
        
        // Join classes together so we can apply them at the same time
        public string allClasses {
            get {
                if (String.IsNullOrEmpty(Size)) {
                    return this.Name;
                } else {
                    return (this.Name + " " + this.Size);
                }
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
    public class UnorderedList {
        public List<string> UKClasses { get; set; }

        // Join classes together so we can apply them at the same time
        public string allClasses {
            get {
                if (this.UKClasses.Count == 0) {
                    return "uk-list";
                } else {
                    return string.Join(" ", UKClasses);
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
