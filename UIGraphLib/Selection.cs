//============================================================================
//ZedGraph Class Library - A Flexible Line Graph/Bar Graph Library in C#
//Copyright ?2007  John Champion and JCarpenter
//
//This library is free software; you can redistribute it and/or
//modify it under the terms of the GNU Lesser General Public
//License as published by the Free Software Foundation; either
//version 2.1 of the License, or (at your option) any later version.
//
//This library is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//Lesser General Public License for more details.
//
//You should have received a copy of the GNU Lesser General Public
//License along with this library; if not, write to the Free Software
//Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
//=============================================================================

using System;
using System.Drawing;

namespace UIGraphLib
{
	/// <summary>
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// 
	/// <author> John Champion and JCarpenter </author>
	/// <version> $Revision: 3.5 $ $Date: 2007-03-11 02:08:16 $ </version>
	public class Selection : CurveList
	{
		// Revision: JCarpenter 10/06
		/// <summary>
		/// Subscribe to this event to receive notice 
		/// that the list of selected CurveItems has changed
		/// </summary>
		public event EventHandler SelectionChangedEvent;

	#region static properties

		/// <summary>
		/// The <see c_ref="Border" /> type to be used for drawing "selected"
		/// <see c_ref="PieItem" />, <see c_ref="BarItem" />, <see c_ref="HiLowBarItem" />,
		/// <see c_ref="OHLCBarItem" />, and <see c_ref="JapaneseCandleStickItem" /> item types.
		/// </summary>
		public static Border Border = new Border( Color.Gray, 1.0f );
		/// <summary>
		/// The <see c_ref="Fill" /> type to be used for drawing "selected"
		/// <see c_ref="PieItem" />, <see c_ref="BarItem" />, <see c_ref="HiLowBarItem" />,
		/// and <see c_ref="JapaneseCandleStickItem" /> item types.
		/// </summary>
		public static Fill Fill = new Fill( Color.Gray );
		/// <summary>
		/// The <see c_ref="Line" /> type to be used for drawing "selected"
		/// <see c_ref="LineItem" /> and <see c_ref="StickItem" /> types
		/// </summary>
		public static Line Line = new Line( Color.Gray );
		//			public static ErrorBar ErrorBar = new ErrorBar( Color.Gray );
		/// <summary>
		/// The <see c_ref="Symbol" /> type to be used for drawing "selected"
		/// <see c_ref="LineItem" /> and <see c_ref="ErrorBarItem" /> types.
		/// </summary>
		public static Symbol Symbol = new Symbol( SymbolType.Circle, Color.Gray );

		//public static Color SelectedSymbolColor = Color.Gray;

	#endregion

	#region Methods

		/// <summary>
		/// Place a <see c_ref="CurveItem" /> in the selection list, removing all other
		/// items.
		/// </summary>
		/// <param name="master">The <see c_ref="MasterPane" /> that is the "owner"
		/// of the <see c_ref="CurveItem" />'s.</param>
		/// <param name="ci">The <see c_ref="CurveItem" /> to be added to the list.</param>
		public void Select( MasterPane master, CurveItem ci )
		{
			//Clear the selection, but don't send the event,
			//the event will be sent in "AddToSelection" by calling "UpdateSelection"
			ClearSelection( master, false );

			AddToSelection( master, ci );
		}

		/// <summary>
		/// Place a list of <see c_ref="CurveItem" />'s in the selection list, removing all other
		/// items.
		/// </summary>
		/// <param name="master">The <see c_ref="MasterPane" /> that is the "owner"
		/// of the <see c_ref="CurveItem" />'s.</param>
		/// <param name="ciList">The list of <see c_ref="CurveItem" /> to be added to the list.</param>
		public void Select( MasterPane master, CurveList ciList )
		{
			//Clear the selection, but don't send the event,
			//the event will be sent in "AddToSelection" by calling "UpdateSelection"
			ClearSelection( master, false );

			AddToSelection( master, ciList );
		}

		/// <summary>
		/// Add a <see c_ref="CurveItem" /> to the selection list.
		/// </summary>
		/// <param name="master">The <see c_ref="MasterPane" /> that is the "owner"
		/// of the <see c_ref="CurveItem" />'s.</param>
		/// <param name="ci">The <see c_ref="CurveItem" /> to be added to the list.</param>
		public void AddToSelection( MasterPane master, CurveItem ci )
		{
			if ( Contains( ci ) == false )
				Add( ci );

			UpdateSelection( master );
		}

		/// <summary>
		/// Add a list of <see c_ref="CurveItem" />'s to the selection list.
		/// </summary>
		/// <param name="master">The <see c_ref="MasterPane" /> that is the "owner"
		/// of the <see c_ref="CurveItem" />'s.</param>
		/// <param name="ciList">The list of <see c_ref="CurveItem" />'s to be added to the list.</param>
		public void AddToSelection( MasterPane master, CurveList ciList )
		{
			foreach ( CurveItem ci in ciList )
			{
				if ( Contains( ci ) == false )
					Add( ci );
			}

			UpdateSelection( master );
		}

#if ( DOTNET1 )

		// Define a "Contains" method so that this class works with .Net 1.1 or 2.0
		internal bool Contains( CurveItem item )
		{
			foreach ( CurveItem ci in this )
				if ( item == ci )
					return true;

			return false;
		}
#endif

		/// <summary>
		/// Remove the specified <see c_ref="CurveItem" /> from the selection list.
		/// </summary>
		/// <param name="master">The <see c_ref="MasterPane" /> that is the "owner"
		/// of the <see c_ref="CurveItem" />'s.</param>
		/// <param name="ci">The <see c_ref="CurveItem" /> to be removed from the list.</param>
		public void RemoveFromSelection( MasterPane master, CurveItem ci )
		{
			if ( Contains( ci ) )
				Remove( ci );

			UpdateSelection( master );

		}

		/// <summary>
		/// Clear the selection list and trigger a <see c_ref="SelectionChangedEvent" />.
		/// </summary>
		/// <param name="master">The <see c_ref="MasterPane" /> that "owns" the selection list.</param>
		public void ClearSelection( MasterPane master )
		{
			ClearSelection( master, true );
		}

		/// <summary>
		/// Clear the selection list and optionally trigger a <see c_ref="SelectionChangedEvent" />.
		/// </summary>
		/// <param name="master">The <see c_ref="MasterPane" /> that "owns" the selection list.</param>
		/// <param name="sendEvent">true to trigger a <see c_ref="SelectionChangedEvent" />,
		/// false otherwise.</param>
		public void ClearSelection( MasterPane master, bool sendEvent )
		{
			Clear();

			foreach ( GraphPane pane in master.PaneList )
			{
				foreach ( CurveItem ci in pane.CurveList )
				{
					ci.IsSelected = false;
				}
			}

			if ( sendEvent )
			{
				if ( SelectionChangedEvent != null )
					SelectionChangedEvent( this, new EventArgs() );
			}
		}

		/// <summary>
		/// Mark the <see c_ref="CurveItem" />'s that are included in the selection list
		/// by setting the <see c_ref="CurveItem.IsSelected" /> property to true.
		/// </summary>
		/// <param name="master">The <see c_ref="MasterPane" /> that "owns" the selection list.</param>
		public void UpdateSelection( MasterPane master )
		{
			if ( Count <= 0 )
			{
				ClearSelection( master );
				return;
			}

			foreach ( GraphPane pane in master.PaneList )
			{
				foreach ( CurveItem ci in pane.CurveList )
				{
					//Make it Inactive
					ci.IsSelected = false;
				}

			}
			foreach ( CurveItem ci in  this )
			{
				//Make Active
				ci.IsSelected = true;

				//If it is a line / scatterplot, the selected Curve may be occluded by an unselected Curve
				//So, move it to the top of the ZOrder by removing it, and re-adding it.

				//Why only do this for Lines? ...Bar and Pie Curves are less likely to overlap, 
				//and adding and removing Pie elements changes thier display order
				if ( ci.IsLine )
				{
					//I don't know how to get a Pane, from a CurveItem, so I can only do it 
					//if there is one and only one Pane, based on the assumption that the 
					//Curve's Pane is MasterPane[0]

					//If there is only one Pane
					if ( master.PaneList.Count == 1 )
					{
						GraphPane pane = master.PaneList[0];
						pane.CurveList.Remove( ci );
						pane.CurveList.Insert( 0, ci );
					}

				}
			}

			//Send Selection Changed Event
			if ( SelectionChangedEvent != null )
				SelectionChangedEvent( this, new EventArgs() );

		}

		#endregion


	}
}
