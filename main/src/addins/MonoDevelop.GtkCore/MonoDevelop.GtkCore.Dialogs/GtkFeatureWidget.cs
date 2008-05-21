
using System;
using MonoDevelop.Ide.Templates;
using MonoDevelop.Core;
using MonoDevelop.Projects;
using Gtk;

namespace MonoDevelop.GtkCore.Dialogs
{
	class GtkFeatureWidget : Gtk.VBox
	{
		CheckButton libCheck;
		ComboBox versionCombo;
		
		public GtkFeatureWidget (DotNetProject project)
		{
			Spacing = 6;
			
			versionCombo = Gtk.ComboBox.NewText ();
			foreach (string v in GtkCoreService.SupportedGtkVersions)
				versionCombo.AppendText (v);
			versionCombo.Active = 0;
			
			// GTK# version selector
			HBox box = new HBox (false, 6);
			Gtk.Label vlab = new Label (GettextCatalog.GetString ("Target GTK# version:"));
			box.PackStart (vlab, false, false, 0);
			box.PackStart (versionCombo, false, false, 0);
			box.PackStart (new Label (GettextCatalog.GetString ("(or upper)")), false, false, 0);
			PackStart (box, false, false, 0);
			
			if (project.CompileTarget == CompileTarget.Library) {
				GtkDesignInfo info = GtkCoreService.GetGtkInfo (project);
				libCheck = new CheckButton (GettextCatalog.GetString ("This assembly is a widget library"));
				libCheck.Active = info != null && info.IsWidgetLibrary;
				PackStart (libCheck, false, false, 0);
			}

			ShowAll ();
		}
		
		public bool IsWidgetLibrary {
			get { return libCheck != null && libCheck.Active; }
		}
		
		public string SelectedVersion {
			get { return versionCombo.ActiveText; }
		}
	}
	
	class GtkProjectFeature: ISolutionItemFeature
	{
		public string Title {
			get { return GettextCatalog.GetString ("Gtk# Support"); }
		}
		
		public string Description {
			get { return GettextCatalog.GetString ("Enables support for GTK# in the project. Allows the visual design of GTK# windows, and the creation of a GTK# widget library."); }
		}

		public bool SupportsSolutionItem (SolutionFolder parentCombine, SolutionItem entry)
		{
			return entry is DotNetProject;
		}
		
		public Widget CreateFeatureEditor (SolutionFolder parentCombine, SolutionItem entry)
		{
			return new GtkFeatureWidget ((DotNetProject) entry);
		}

		public void ApplyFeature (SolutionFolder parentCombine, SolutionItem entry, Widget editor)
		{
			GtkDesignInfo info = GtkCoreService.EnableGtkSupport ((DotNetProject) entry);
			GtkFeatureWidget fw = (GtkFeatureWidget) editor;
			info.IsWidgetLibrary = fw.IsWidgetLibrary;
			info.TargetGtkVersion = fw.SelectedVersion;
			info.UpdateGtkFolder ();
		}
		
		public string Validate (SolutionFolder parentCombine, SolutionItem entry, Gtk.Widget editor)
		{
			return null;
		}
		
		public bool IsEnabled (SolutionFolder parentCombine, SolutionItem entry) 
		{
			return GtkCoreService.GetGtkInfo ((Project)entry) != null;
		}
	}
}
