// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.42
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace MonoDevelop.Deployment.Gui {
    
    
    internal partial class EditPackageDialog {
        
        private Gtk.VBox vbox2;
        
        private Gtk.Notebook notebook;
        
        private Gtk.VBox targetBox;
        
        private Gtk.HBox hbox4;
        
        private Gtk.Label label4;
        
        private Gtk.Entry entryName;
        
        private Gtk.HSeparator hseparator1;
        
        private Gtk.Label label2;
        
        private Gtk.VBox vbox4;
        
        private Gtk.Label label6;
        
        private MonoDevelop.Deployment.Gui.EntrySelectionTree entrySelector;
        
        private Gtk.Label label1;
        
        private Gtk.HBox pageFiles;
        
        private MonoDevelop.Deployment.DeployFileListWidget fileListView;
        
        private Gtk.Label label5;
        
        private Gtk.Button buttonCancel;
        
        private Gtk.Button okbutton;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget MonoDevelop.Deployment.Gui.EditPackageDialog
            this.Name = "MonoDevelop.Deployment.Gui.EditPackageDialog";
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            this.HasSeparator = false;
            // Internal child MonoDevelop.Deployment.Gui.EditPackageDialog.VBox
            Gtk.VBox w1 = this.VBox;
            w1.Name = "dialog1_VBox";
            w1.BorderWidth = ((uint)(2));
            // Container child dialog1_VBox.Gtk.Box+BoxChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            this.vbox2.BorderWidth = ((uint)(12));
            // Container child vbox2.Gtk.Box+BoxChild
            this.notebook = new Gtk.Notebook();
            this.notebook.CanFocus = true;
            this.notebook.Name = "notebook";
            this.notebook.CurrentPage = 0;
            // Container child notebook.Gtk.Notebook+NotebookChild
            this.targetBox = new Gtk.VBox();
            this.targetBox.Name = "targetBox";
            this.targetBox.Spacing = 6;
            this.targetBox.BorderWidth = ((uint)(12));
            // Container child targetBox.Gtk.Box+BoxChild
            this.hbox4 = new Gtk.HBox();
            this.hbox4.Name = "hbox4";
            this.hbox4.Spacing = 6;
            // Container child hbox4.Gtk.Box+BoxChild
            this.label4 = new Gtk.Label();
            this.label4.Name = "label4";
            this.label4.LabelProp = Mono.Unix.Catalog.GetString("Name:");
            this.hbox4.Add(this.label4);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.hbox4[this.label4]));
            w2.Position = 0;
            w2.Expand = false;
            w2.Fill = false;
            // Container child hbox4.Gtk.Box+BoxChild
            this.entryName = new Gtk.Entry();
            this.entryName.CanFocus = true;
            this.entryName.Name = "entryName";
            this.entryName.IsEditable = true;
            this.entryName.WidthChars = 40;
            this.entryName.InvisibleChar = '●';
            this.hbox4.Add(this.entryName);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.hbox4[this.entryName]));
            w3.Position = 1;
            w3.Expand = false;
            w3.Fill = false;
            this.targetBox.Add(this.hbox4);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.targetBox[this.hbox4]));
            w4.Position = 0;
            w4.Expand = false;
            w4.Fill = false;
            // Container child targetBox.Gtk.Box+BoxChild
            this.hseparator1 = new Gtk.HSeparator();
            this.hseparator1.Name = "hseparator1";
            this.targetBox.Add(this.hseparator1);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.targetBox[this.hseparator1]));
            w5.Position = 1;
            w5.Expand = false;
            w5.Fill = false;
            this.notebook.Add(this.targetBox);
            // Notebook tab
            this.label2 = new Gtk.Label();
            this.label2.Name = "label2";
            this.label2.LabelProp = Mono.Unix.Catalog.GetString("Package Settings");
            this.notebook.SetTabLabel(this.targetBox, this.label2);
            this.label2.ShowAll();
            // Container child notebook.Gtk.Notebook+NotebookChild
            this.vbox4 = new Gtk.VBox();
            this.vbox4.Name = "vbox4";
            this.vbox4.Spacing = 6;
            this.vbox4.BorderWidth = ((uint)(12));
            // Container child vbox4.Gtk.Box+BoxChild
            this.label6 = new Gtk.Label();
            this.label6.Name = "label6";
            this.label6.Xalign = 0F;
            this.label6.LabelProp = Mono.Unix.Catalog.GetString("Select the projects and solutions you want to include in the package:");
            this.vbox4.Add(this.label6);
            Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.vbox4[this.label6]));
            w7.Position = 0;
            w7.Expand = false;
            w7.Fill = false;
            // Container child vbox4.Gtk.Box+BoxChild
            this.entrySelector = new MonoDevelop.Deployment.Gui.EntrySelectionTree();
            this.entrySelector.Events = ((Gdk.EventMask)(256));
            this.entrySelector.Name = "entrySelector";
            this.vbox4.Add(this.entrySelector);
            Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(this.vbox4[this.entrySelector]));
            w8.Position = 1;
            this.notebook.Add(this.vbox4);
            Gtk.Notebook.NotebookChild w9 = ((Gtk.Notebook.NotebookChild)(this.notebook[this.vbox4]));
            w9.Position = 1;
            // Notebook tab
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("Projects/Solutions");
            this.notebook.SetTabLabel(this.vbox4, this.label1);
            this.label1.ShowAll();
            // Container child notebook.Gtk.Notebook+NotebookChild
            this.pageFiles = new Gtk.HBox();
            this.pageFiles.Name = "pageFiles";
            this.pageFiles.Spacing = 6;
            this.pageFiles.BorderWidth = ((uint)(12));
            // Container child pageFiles.Gtk.Box+BoxChild
            this.fileListView = new MonoDevelop.Deployment.DeployFileListWidget();
            this.fileListView.Events = ((Gdk.EventMask)(256));
            this.fileListView.Name = "fileListView";
            this.pageFiles.Add(this.fileListView);
            Gtk.Box.BoxChild w10 = ((Gtk.Box.BoxChild)(this.pageFiles[this.fileListView]));
            w10.Position = 0;
            this.notebook.Add(this.pageFiles);
            Gtk.Notebook.NotebookChild w11 = ((Gtk.Notebook.NotebookChild)(this.notebook[this.pageFiles]));
            w11.Position = 2;
            // Notebook tab
            this.label5 = new Gtk.Label();
            this.label5.Name = "label5";
            this.label5.LabelProp = Mono.Unix.Catalog.GetString("Files");
            this.notebook.SetTabLabel(this.pageFiles, this.label5);
            this.label5.ShowAll();
            this.vbox2.Add(this.notebook);
            Gtk.Box.BoxChild w12 = ((Gtk.Box.BoxChild)(this.vbox2[this.notebook]));
            w12.Position = 0;
            w1.Add(this.vbox2);
            Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(w1[this.vbox2]));
            w13.Position = 0;
            // Internal child MonoDevelop.Deployment.Gui.EditPackageDialog.ActionArea
            Gtk.HButtonBox w14 = this.ActionArea;
            w14.Name = "dialog1_ActionArea";
            w14.Spacing = 6;
            w14.BorderWidth = ((uint)(5));
            w14.LayoutStyle = ((Gtk.ButtonBoxStyle)(4));
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonCancel = new Gtk.Button();
            this.buttonCancel.CanDefault = true;
            this.buttonCancel.CanFocus = true;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseStock = true;
            this.buttonCancel.UseUnderline = true;
            this.buttonCancel.Label = "gtk-cancel";
            this.AddActionWidget(this.buttonCancel, -6);
            Gtk.ButtonBox.ButtonBoxChild w15 = ((Gtk.ButtonBox.ButtonBoxChild)(w14[this.buttonCancel]));
            w15.Expand = false;
            w15.Fill = false;
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.okbutton = new Gtk.Button();
            this.okbutton.CanDefault = true;
            this.okbutton.CanFocus = true;
            this.okbutton.Name = "okbutton";
            this.okbutton.UseStock = true;
            this.okbutton.UseUnderline = true;
            this.okbutton.Label = "gtk-ok";
            w14.Add(this.okbutton);
            Gtk.ButtonBox.ButtonBoxChild w16 = ((Gtk.ButtonBox.ButtonBoxChild)(w14[this.okbutton]));
            w16.Position = 1;
            w16.Expand = false;
            w16.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 599;
            this.DefaultHeight = 450;
            this.Show();
            this.notebook.SwitchPage += new Gtk.SwitchPageHandler(this.OnNotebookSwitchPage);
            this.entryName.Changed += new System.EventHandler(this.OnEntryNameChanged);
            this.entrySelector.SelectionChanged += new System.EventHandler(this.OnEntrySelectorSelectionChanged);
            this.okbutton.Clicked += new System.EventHandler(this.OnOkbuttonClicked);
        }
    }
}
