using System;
using System.Web.UI;
using System.IO;
using System.Collections.Generic;
namespace PoshUIkit {
    public class Button {
        public List<string> Classes;
        public string Label;
        public string Link;
        public bool IsDropdown;
        public string DropdownMode;
        //public Dropdown DropdownContents;
        
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
                
                // Dropdown
                if (IsDropdown) {
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, "uk-button-dropdown");
                    writer.AddAttribute("data-uk-dropdown",null);
                    writer.RenderBeginTag(HtmlTextWriterTag.Div); // Begin #1
                }
                
                writer.AddAttribute(HtmlTextWriterAttribute.Class, allClasses);
                
                if (String.IsNullOrEmpty(Link)) {
                    writer.RenderBeginTag(HtmlTextWriterTag.Button); // Begin #2
                } else {
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, Link);
                    writer.RenderBeginTag(HtmlTextWriterTag.A); // Begin #2
                }
                
                // Button Text
                writer.Write(Label);
                
                
                writer.RenderEndTag(); // End #2
                
                // Dropdown
                if (IsDropdown) {
                    writer.RenderEndTag(); // End #1
                }
                
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
                    writer.Write(item.Html());
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
