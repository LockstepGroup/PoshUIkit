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
                if (UKClasses == null || UKClasses.Count == 0) {
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
    public class Dropdown {
        public List<string> UKClasses { get; set; }
        public Button Button;
        public UnorderedList List;
        public string Mode;

        // Join classes together so we can apply them at the same time
        public string allClasses {
            get {
                if (UKClasses == null || UKClasses.Count == 0) {
                    return "uk-button-dropdown";
                } else {
                    string requiredClasses = "uk-button-dropdown ";
                    requiredClasses += string.Join(" ", UKClasses); 
                    return requiredClasses;
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
                writer.AddAttribute(HtmlTextWriterAttribute.Class, allClasses);
                
                
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
