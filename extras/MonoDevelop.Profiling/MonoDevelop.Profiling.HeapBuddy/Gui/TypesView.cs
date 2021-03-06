//
// Authors:
//   Ben Maurer  <bmaurer@ximian.com>
//   Jon Trowbridge  <trow@novell.com>
//   Ben Motmans  <ben.motmans@gmail.com>
//
// Copyright (C) 2005 Novell, Inc.
// Copyright (C) 2007 Ben Motmans
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using Gtk;
using System;
using MonoDevelop.Core;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Ide.Gui.Pads;

namespace MonoDevelop.Profiling.HeapBuddy
{
	public class TypesView : AbstractViewContent
	{
		private HeapBuddyProfilingSnapshot snapshot;

		private ScrolledWindow window;
		private TreeView list;
		private ListStore store;

		public TypesView ()
		{
			window = new ScrolledWindow ();
			list = new TreeView ();
			list.RulesHint = true;
			
			//                               icon            type            count            #bytes         avg size         avg age          # backtraces
			store = new ListStore (typeof (string), typeof (string), typeof (string), typeof (string), typeof (string), typeof (string), typeof (string), typeof (object));
			list.Model = store;

			CellRendererPixbuf pixbufRenderer = new CellRendererPixbuf ();
			CellRendererText typeRenderer = new CellRendererText ();
			CellRendererText countRenderer = new CellRendererText ();
			CellRendererText totalSizeRenderer = new CellRendererText ();
			CellRendererText avgSizeRenderer = new CellRendererText ();
			CellRendererText avgAgeRenderer = new CellRendererText ();
			CellRendererText backtracesRenderer = new CellRendererText ();
			
			TreeViewColumn columnType = new TreeViewColumn ();
			TreeViewColumn columnCount = new TreeViewColumn ();
			TreeViewColumn columnTotalSize = new TreeViewColumn ();
			TreeViewColumn columnAvgSize = new TreeViewColumn ();
			TreeViewColumn columnAvgAge = new TreeViewColumn ();
			TreeViewColumn columnBacktraces = new TreeViewColumn ();
			
			columnType.Title = GettextCatalog.GetString ("Type");
			columnCount.Title = GettextCatalog.GetString ("Count");
			columnTotalSize.Title = GettextCatalog.GetString ("Total Size");
			columnAvgSize.Title = GettextCatalog.GetString ("Avg Size");
			columnAvgAge.Title = GettextCatalog.GetString ("Avg Age");
			columnBacktraces.Title = GettextCatalog.GetString ("Backtraces");
			
			columnType.PackStart (pixbufRenderer, false);
			columnType.PackStart (typeRenderer, true);
			columnCount.PackStart (countRenderer, true);
			columnTotalSize.PackStart (totalSizeRenderer, true);
			columnAvgSize.PackStart (avgSizeRenderer, true);
			columnAvgAge.PackStart (avgAgeRenderer, true);
			columnBacktraces.PackStart (backtracesRenderer, true);
			
			columnType.AddAttribute (pixbufRenderer, "stock-id", 0);
			columnType.AddAttribute (typeRenderer, "text", 1);
			columnCount.AddAttribute (countRenderer, "text", 2);
			columnTotalSize.AddAttribute (totalSizeRenderer, "text", 3);
			columnAvgSize.AddAttribute (avgSizeRenderer, "text", 4);
			columnAvgAge.AddAttribute (avgAgeRenderer, "text", 5);
			columnBacktraces.AddAttribute (backtracesRenderer, "text", 6);
			
			list.AppendColumn (columnType);
			list.AppendColumn (columnCount);
			list.AppendColumn (columnTotalSize);
			list.AppendColumn (columnAvgSize);
			list.AppendColumn (columnAvgAge);
			list.AppendColumn (columnBacktraces);
			
			int nc = 0;
			foreach (TreeViewColumn c in list.Columns) {
				store.SetSortFunc (nc, CompareNodes);
				c.SortColumnId = nc++;
			}
			store.SetSortColumnId (1, SortType.Descending);
			
			window.Add (list);
			window.ShowAll ();
		}

		public override bool IsDirty {
			get { return false; }
			set {  }
		}

		public override string StockIconId {
			get { return "md-class"; }
		}
		
		public override string UntitledName {
			get { return snapshot.Name + " - " + GettextCatalog.GetString ("Types"); }
		}

		public override Widget Control {
			get { return window; }
		}
		
		public override void Load (string fileName) {}
		
		public void Load (HeapBuddyProfilingSnapshot snapshot)
		{
			this.snapshot = snapshot;
			
			foreach (Type type in snapshot.Outfile.Types) {
				store.AppendValues ("md-class", type.Name, type.LastObjectStats.AllocatedCount.ToString (),
					ProfilingService.PrettySize (type.LastObjectStats.AllocatedTotalBytes),
					String.Format ("{0:0.0}", type.LastObjectStats.AllocatedAverageBytes),
					String.Format ("{0:0.0}", type.LastObjectStats.AllocatedAverageAge),
					type.BacktraceCount.ToString (), type);
			}
		}
		
		int CompareNodes (Gtk.TreeModel model, Gtk.TreeIter a, Gtk.TreeIter b)
		{
			int col;
			SortType type;
			store.GetSortColumnId (out col, out type);
			
			object o1 = model.GetValue (a, 7);
			object o2 = model.GetValue (b, 7);
			
			if (o1 is Type && o2 is Type) {
				Type t1 = (Type) o1;
				Type t2 = (Type) o2;
				switch (col) {
					case 0:
						return string.Compare (t1.Name, t2.Name);
					case 1:
						return t1.LastObjectStats.AllocatedCount.CompareTo (t2.LastObjectStats.AllocatedCount);
					case 2:
						return t1.LastObjectStats.AllocatedTotalBytes.CompareTo (t2.LastObjectStats.AllocatedTotalBytes);
					case 3:
						return t1.LastObjectStats.AllocatedAverageBytes.CompareTo (t2.LastObjectStats.AllocatedAverageBytes);
					case 4:
						return t1.LastObjectStats.AllocatedAverageAge.CompareTo (t2.LastObjectStats.AllocatedAverageAge);
					case 5:
						return t1.BacktraceCount.CompareTo (t2.BacktraceCount);
					default:
						return 1;
				}
			} else if (o1 is Type) {
				return 1;
			} else {
				return -1;
			}
		}
	}
}
