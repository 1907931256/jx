//============================================================================
//ZedGraph Class Library - A Flexible Line Graph/Bar Graph Library in C#
//Copyright ?2004  John Champion
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
using System.Drawing.Printing;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace UIGraphLib
{
/*
	/// <summary>
	/// 
	/// </summary>
	public struct DrawingThreadData
	{
		/// <summary>
		/// 
		/// </summary>
		public Graphics _g;
		/// <summary>
		/// 
		/// </summary>
		public MasterPane _masterPane;

//		public DrawingThread( Graphics g, MasterPane masterPane )
//		{
//			_g = g;
//			_masterPane = masterPane;
//		}
	}
*/

	/// <summary>
	/// The ZedGraphControl class provides a UserControl interface to the
	/// <see c_ref="ZedGraph"/> class library.  This allows ZedGraph to be installed
	/// as a control in the Visual Studio toolbox.  You can use the control by simply
	/// dragging it onto a form in the Visual Studio form editor.  All graph
	/// attributes are accessible via the <see c_ref="ZedGraphControl.GraphPane"/>
	/// property.
	/// </summary>
	/// <author> John Champion revised by Jerry Vos </author>
	/// <version> $Revision: 3.86 $ $Date: 2007-11-03 04:41:29 $ </version>
	public partial class GraphControl : UserControl
	{

	#region Private Fields

		/// <summary>
		/// This private field contains the instance for the MasterPane object of this control.
		/// You can access the MasterPane object through the public property
		/// <see c_ref="ZedGraphControl.MasterPane"/>. This is nulled when this Control is
		/// disposed.
		/// </summary>
		private MasterPane _masterPane;

		/// <summary>
		/// private field that determines whether or not tooltips will be displayed
		/// when the mouse hovers over data values.  Use the public property
		/// <see c_ref="IsShowPointValues"/> to access this value.
		/// </summary>
		private bool _isShowPointValues;
		/// <summary>
		/// private field that determines whether or not tooltips will be displayed
		/// showing the scale values while the mouse is located within the ChartRect.
		/// Use the public property <see c_ref="IsShowCursorValues"/> to access this value.
		/// </summary>
		private bool _isShowCursorValues;
		/// <summary>
		/// private field that determines the format for displaying tooltip values.
		/// This format is passed to <see c_ref="PointPairBase.ToString(string)"/>.
		/// Use the public property <see c_ref="PointValueFormat"/> to access this
		/// value.
		/// </summary>
		private string _pointValueFormat = PointPair.DefaultFormat;

		/// <summary>
		/// private field that determines whether or not the context menu will be available.  Use the
		/// public property <see c_ref="IsShowContextMenu"/> to access this value.
		/// </summary>
		private bool _isShowContextMenu = true;

		/// <summary>
		/// private field that determines whether or not a message box will be shown in response to
		/// a context menu "Copy" command.  Use the
		/// public property <see c_ref="IsShowCopyMessage"/> to access this value.
		/// </summary>
		/// <remarks>
		/// Note that, if this value is set to false, the user will receive no indicative feedback
		/// in response to a Copy action.
		/// </remarks>
		private bool _isShowCopyMessage = true;

		private SaveFileDialog _saveFileDialog = new SaveFileDialog();

		/// <summary>
		/// private field that determines whether the settings of
		/// <see c_ref="ZedGraph.PaneBase.IsFontsScaled" /> and <see c_ref="PaneBase.IsPenWidthScaled" />
		/// will be overridden to true during printing operations.
		/// </summary>
		/// <remarks>
		/// Printing involves pixel maps that are typically of a dramatically different dimension
		/// than on-screen pixel maps.  Therefore, it becomes more important to scale the fonts and
		/// lines to give a printed image that looks like what is shown on-screen.  The default
		/// setting for <see c_ref="ZedGraph.PaneBase.IsFontsScaled" /> is true, but the default
		/// setting for <see c_ref="PaneBase.IsPenWidthScaled" /> is false.
		/// </remarks>
		/// <value>
		/// A value of true will cause both <see c_ref="ZedGraph.PaneBase.IsFontsScaled" /> and
		/// <see c_ref="PaneBase.IsPenWidthScaled" /> to be temporarily set to true during
		/// printing operations.
		/// </value>
		private bool _isPrintScaleAll = true;
		/// <summary>
		/// private field that determines whether or not the visible aspect ratio of the
		/// <see c_ref="MasterPane" /> <see c_ref="PaneBase.Rect" /> will be preserved
		/// when printing this <see c_ref="ZedGraphControl" />.
		/// </summary>
		private bool _isPrintKeepAspectRatio = true;
		/// <summary>
		/// private field that determines whether or not the <see c_ref="MasterPane" />
		/// <see c_ref="PaneBase.Rect" /> dimensions will be expanded to fill the
		/// available space when printing this <see c_ref="ZedGraphControl" />.
		/// </summary>
		/// <remarks>
		/// If <see c_ref="IsPrintKeepAspectRatio" /> is also true, then the <see c_ref="MasterPane" />
		/// <see c_ref="PaneBase.Rect" /> dimensions will be expanded to fit as large
		/// a space as possible while still honoring the visible aspect ratio.
		/// </remarks>
		private bool _isPrintFillPage = true;

		/// <summary>
		/// private field that determines the format for displaying tooltip date values.
		/// This format is passed to <see c_ref="XDate.ToString(string)"/>.
		/// Use the public property <see c_ref="PointDateFormat"/> to access this
		/// value.
		/// </summary>
		private string _pointDateFormat = XDate.DefaultFormatStr;

		/// <summary>
		/// private value that determines whether or not zooming is enabled for the control in the
		/// vertical direction.  Use the public property <see c_ref="IsEnableVZoom"/> to access this
		/// value.
		/// </summary>
		private bool _isEnableVZoom = true;
		/// <summary>
		/// private value that determines whether or not zooming is enabled for the control in the
		/// horizontal direction.  Use the public property <see c_ref="IsEnableHZoom"/> to access this
		/// value.
		/// </summary>
		private bool _isEnableHZoom = true;

		/// <summary>
		/// private value that determines whether or not zooming is enabled with the mousewheel.
		/// Note that this property is used in combination with the <see c_ref="IsEnableHZoom"/> and
		/// <see c_ref="IsEnableVZoom" /> properties to control zoom options.
		/// </summary>
		private bool _isEnableWheelZoom = true;

		/// <summary>
		/// private value that determines whether or not point editing is enabled in the
		/// vertical direction.  Use the public property <see c_ref="IsEnableVEdit"/> to access this
		/// value.
		/// </summary>
		private bool _isEnableVEdit;
		/// <summary>
		/// private value that determines whether or not point editing is enabled in the
		/// horizontal direction.  Use the public property <see c_ref="IsEnableHEdit"/> to access this
		/// value.
		/// </summary>
		private bool _isEnableHEdit;

		/// <summary>
		/// private value that determines whether or not panning is allowed for the control in the
		/// horizontal direction.  Use the
		/// public property <see c_ref="IsEnableHPan"/> to access this value.
		/// </summary>
		private bool _isEnableHPan = true;
		/// <summary>
		/// private value that determines whether or not panning is allowed for the control in the
		/// vertical direction.  Use the
		/// public property <see c_ref="IsEnableVPan"/> to access this value.
		/// </summary>
		private bool _isEnableVPan = true;

		// Revision: JCarpenter 10/06
		/// <summary>
		/// Internal variable that indicates if the control can manage selections. 
		/// </summary>
		private bool _isEnableSelection;

		private double _zoomStepFraction = 0.1;

		private ScrollRange _xScrollRange;

		private ScrollRangeList _yScrollRangeList;
		private ScrollRangeList _y2ScrollRangeList;

		private bool _isShowHScrollBar;
		private bool _isShowVScrollBar;
		//private bool		isScrollY2 = false;
		private bool _isAutoScrollRange;

		private double _scrollGrace; //0.05;

		private bool _isSynchronizeXAxes;
		private bool _isSynchronizeYAxes;

		//private System.Windows.Forms.HScrollBar hScrollBar1;
		//private System.Windows.Forms.VScrollBar vScrollBar1;

		// The range of values to use the scroll control bars
		private const int _ScrollControlSpan = int.MaxValue;
		// The ratio of the largeChange to the smallChange for the scroll bars
		private const int _ScrollSmallRatio = 10;

		private bool _isZoomOnMouseCenter;

		private ResourceManager _resourceManager;

		/// <summary>
		/// private field that stores a <see c_ref="PrintDocument" /> instance, which maintains
		/// a persistent selection of printer options.
		/// </summary>
		/// <remarks>
		/// This is needed so that a "Print" action utilizes the settings from a prior
		/// "Page Setup" action.</remarks>
		private PrintDocument _pdSave;
		//private PrinterSettings printSave = null;
		//private PageSettings pageSave = null;

		/// <summary>
		/// This private field contains a list of selected CurveItems.
		/// </summary>
		//private List<CurveItem> _selection = new List<CurveItem>();
		private Selection _selection = new Selection();

	#endregion

	#region Fields: Buttons & Keys Properties

		/// <summary>
		/// Gets or sets a value that determines which Mouse button will be used to click on
		/// linkable objects
		/// </summary>
		/// <seealso c_ref="LinkModifierKeys" />
		private MouseButtons _linkButtons = MouseButtons.Left;
		/// <summary>
		/// Gets or sets a value that determines which modifier keys will be used to click
		/// on linkable objects
		/// </summary>
		/// <seealso c_ref="LinkButtons" />
		private Keys _linkModifierKeys = Keys.Alt;

		/// <summary>
		/// Gets or sets a value that determines which Mouse button will be used to edit point
		/// data values
		/// </summary>
		/// <remarks>
		/// This setting only applies if <see c_ref="IsEnableHEdit" /> and/or
		/// <see c_ref="IsEnableVEdit" /> are true.
		/// </remarks>
		/// <seealso c_ref="EditModifierKeys" />
		private MouseButtons _editButtons = MouseButtons.Right;
		/// <summary>
		/// Gets or sets a value that determines which modifier keys will be used to edit point
		/// data values
		/// </summary>
		/// <remarks>
		/// This setting only applies if <see c_ref="IsEnableHEdit" /> and/or
		/// <see c_ref="IsEnableVEdit" /> are true.
		/// </remarks>
		/// <seealso c_ref="EditButtons" />
		private Keys _editModifierKeys = Keys.Alt;

		/// <summary>
		/// Gets or sets a value that determines which mouse button will be used to select
		/// <see c_ref="CurveItem" />'s.
		/// </summary>
		/// <remarks>
		/// This setting only applies if <see c_ref="IsEnableSelection" /> is true.
		/// </remarks>
		/// <seealso c_ref="SelectModifierKeys" />
		private MouseButtons _selectButtons = MouseButtons.Left;
		/// <summary>
		/// Gets or sets a value that determines which modifier keys will be used to select
		/// <see c_ref="CurveItem" />'s.
		/// </summary>
		/// <remarks>
		/// This setting only applies if <see c_ref="IsEnableSelection" /> is true.
		/// </remarks>
		/// <seealso c_ref="SelectButtons" />
		private Keys _selectModifierKeys = Keys.Shift;

		private Keys _selectAppendModifierKeys = Keys.Shift | Keys.Control;

		/// <summary>
		/// Gets or sets a value that determines which Mouse button will be used to perform
		/// zoom operations
		/// </summary>
		/// <remarks>
		/// This setting only applies if <see c_ref="IsEnableHZoom" /> and/or
		/// <see c_ref="IsEnableVZoom" /> are true.
		/// </remarks>
		/// <seealso c_ref="ZoomModifierKeys" />
		/// <seealso c_ref="ZoomButtons2" />
		/// <seealso c_ref="ZoomModifierKeys2" />
		private MouseButtons _zoomButtons = MouseButtons.Left;
		/// <summary>
		/// Gets or sets a value that determines which modifier keys will be used to perform
		/// zoom operations
		/// </summary>
		/// <remarks>
		/// This setting only applies if <see c_ref="IsEnableHZoom" /> and/or
		/// <see c_ref="IsEnableVZoom" /> are true.
		/// </remarks>
		/// <seealso c_ref="ZoomButtons" />
		/// <seealso c_ref="ZoomButtons2" />
		/// <seealso c_ref="ZoomModifierKeys2" />
		private Keys _zoomModifierKeys = Keys.None;

		/// <summary>
		/// Gets or sets a value that determines which Mouse button will be used as a
		/// secondary option to perform zoom operations
		/// </summary>
		/// <remarks>
		/// This setting only applies if <see c_ref="IsEnableHZoom" /> and/or
		/// <see c_ref="IsEnableVZoom" /> are true.
		/// </remarks>
		/// <seealso c_ref="ZoomModifierKeys2" />
		/// <seealso c_ref="ZoomButtons" />
		/// <seealso c_ref="ZoomModifierKeys" />
		private MouseButtons _zoomButtons2 = MouseButtons.None;
		/// <summary>
		/// Gets or sets a value that determines which modifier keys will be used as a
		/// secondary option to perform zoom operations
		/// </summary>
		/// <remarks>
		/// This setting only applies if <see c_ref="IsEnableHZoom" /> and/or
		/// <see c_ref="IsEnableVZoom" /> are true.
		/// </remarks>
		/// <seealso c_ref="ZoomButtons" />
		/// <seealso c_ref="ZoomButtons2" />
		/// <seealso c_ref="ZoomModifierKeys2" />
		private Keys _zoomModifierKeys2 = Keys.None;

		/// <summary>
		/// Gets or sets a value that determines which Mouse button will be used to perform
		/// panning operations
		/// </summary>
		/// <remarks>
		/// This setting only applies if <see c_ref="IsEnableHPan" /> and/or
		/// <see c_ref="IsEnableVPan" /> are true.  A Pan operation (dragging the graph with
		/// the mouse) should not be confused with a scroll operation (using a scroll bar to
		/// move the graph).
		/// </remarks>
		/// <seealso c_ref="PanModifierKeys" />
		/// <seealso c_ref="PanButtons2" />
		/// <seealso c_ref="PanModifierKeys2" />
		private MouseButtons _panButtons = MouseButtons.Left;

		// Setting this field to Keys.Shift here
		// causes an apparent bug to crop up in VS 2003, by which it will have the value:
		// "System.Windows.Forms.Keys.Shift+None", which won't compile
		/// <summary>
		/// Gets or sets a value that determines which modifier keys will be used to perform
		/// panning operations
		/// </summary>
		/// <remarks>
		/// This setting only applies if <see c_ref="IsEnableHPan" /> and/or
		/// <see c_ref="IsEnableVPan" /> are true.  A Pan operation (dragging the graph with
		/// the mouse) should not be confused with a scroll operation (using a scroll bar to
		/// move the graph).
		/// </remarks>
		/// <seealso c_ref="PanButtons" />
		/// <seealso c_ref="PanButtons2" />
		/// <seealso c_ref="PanModifierKeys2" />
		private Keys _panModifierKeys = Keys.Control;

		/// <summary>
		/// Gets or sets a value that determines which Mouse button will be used as a
		/// secondary option to perform panning operations
		/// </summary>
		/// <remarks>
		/// This setting only applies if <see c_ref="IsEnableHPan" /> and/or
		/// <see c_ref="IsEnableVPan" /> are true.  A Pan operation (dragging the graph with
		/// the mouse) should not be confused with a scroll operation (using a scroll bar to
		/// move the graph).
		/// </remarks>
		/// <seealso c_ref="PanModifierKeys2" />
		/// <seealso c_ref="PanButtons" />
		/// <seealso c_ref="PanModifierKeys" />
		private MouseButtons _panButtons2 = MouseButtons.Middle;

		// Setting this field to Keys.Shift here
		// causes an apparent bug to crop up in VS 2003, by which it will have the value:
		// "System.Windows.Forms.Keys.Shift+None", which won't compile
		/// <summary>
		/// Gets or sets a value that determines which modifier keys will be used as a
		/// secondary option to perform panning operations
		/// </summary>
		/// <remarks>
		/// This setting only applies if <see c_ref="IsEnableHPan" /> and/or
		/// <see c_ref="IsEnableVPan" /> are true.  A Pan operation (dragging the graph with
		/// the mouse) should not be confused with a scroll operation (using a scroll bar to
		/// move the graph).
		/// </remarks>
		/// <seealso c_ref="PanButtons2" />
		/// <seealso c_ref="PanButtons" />
		/// <seealso c_ref="PanModifierKeys" />
		private Keys _panModifierKeys2 = Keys.None;

	#endregion

	#region Fields: Temporary state variables

		/// <summary>
		/// Internal variable that indicates the control is currently being zoomed. 
		/// </summary>
		private bool _isZooming;
		/// <summary>
		/// Internal variable that indicates the control is currently being panned.
		/// </summary>
		private bool _isPanning;
		/// <summary>
		/// Internal variable that indicates a point value is currently being edited.
		/// </summary>
		private bool _isEditing;

		// Revision: JCarpenter 10/06
		/// <summary>
		/// Internal variable that indicates the control is currently using selection. 
		/// </summary>
		private bool _isSelecting;

		/// <summary>
		/// Internal variable that stores the <see c_ref="GraphPane"/> reference for the Pane that is
		/// currently being zoomed or panned.
		/// </summary>
		private GraphPane _dragPane;
		/// <summary>
		/// Internal variable that stores a rectangle which is either the zoom rectangle, or the incremental
		/// pan amount since the last mousemove event.
		/// </summary>
		private Point _dragStartPt;
		private Point _dragEndPt;

		private int _dragIndex;
		private CurveItem _dragCurve;
		private PointPair _dragStartPair;
		/// <summary>
		/// private field that stores the state of the scale ranges prior to starting a panning action.
		/// </summary>
		private ZoomState _zoomState;
		private ZoomStateStack _zoomStateStack;

		//temporarily save the location of a context menu click so we can use it for reference
		// Note that Control.MousePosition ends up returning the position after the mouse has
		// moved to the menu item within the context menu.  Therefore, this point is saved so
		// that we have the point at which the context menu was first right-clicked
		internal Point _menuClickPt;

	#endregion

	#region Constructors

		/// <summary>
		/// Default Constructor
		/// </summary>
		public GraphControl()
		{
			InitializeComponent();

			// These commands do nothing, but they get rid of the compiler warnings for
			// unused events
			bool b = MouseDown == null || MouseUp == null || MouseMove == null;

			// Link in these events from the base class, since we disable them from this class.
			base.MouseDown += ZedGraphControl_MouseDown;
			base.MouseUp += ZedGraphControl_MouseUp;
			base.MouseMove += ZedGraphControl_MouseMove;

			//this.MouseWheel += new System.Windows.Forms.MouseEventHandler( this.ZedGraphControl_MouseWheel );

			// Use double-buffering for flicker-free updating:
			SetStyle( ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint
				| ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true );
			//isTransparentBackground = false;
			//SetStyle( ControlStyles.Opaque, false );
			SetStyle( ControlStyles.SupportsTransparentBackColor, true );
			//this.BackColor = Color.Transparent;

            _resourceManager = new ResourceManager("UIGraphLib.GraphLocale",
				Assembly.GetExecutingAssembly() );

			Rectangle rect = new Rectangle( 0, 0, Size.Width, Size.Height );
			_masterPane = new MasterPane( "", rect );
			_masterPane.Margin.All = 0;
			_masterPane.Title.IsVisible = false;

			string titleStr = _resourceManager.GetString( "title_def" );
			string xStr = _resourceManager.GetString( "x_title_def" );
			string yStr = _resourceManager.GetString( "y_title_def" );

			//GraphPane graphPane = new GraphPane( rect, "Title", "X Axis", "Y Axis" );
			GraphPane graphPane = new GraphPane( rect, titleStr, xStr, yStr );
			using ( Graphics g = CreateGraphics() )
			{
				graphPane.AxisChange( g );
				//g.Dispose();
			}
			_masterPane.Add( graphPane );

			hScrollBar1.Minimum = 0;
			hScrollBar1.Maximum = 100;
			hScrollBar1.Value = 0;

			vScrollBar1.Minimum = 0;
			vScrollBar1.Maximum = 100;
			vScrollBar1.Value = 0;

			_xScrollRange = new ScrollRange( true );
			_yScrollRangeList = new ScrollRangeList();
			_y2ScrollRangeList = new ScrollRangeList();

			_yScrollRangeList.Add( new ScrollRange( true ) );
			_y2ScrollRangeList.Add( new ScrollRange( false ) );

			_zoomState = null;
			_zoomStateStack = new ZoomStateStack();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if the components should be
		/// disposed, false otherwise</param>
		protected override void Dispose( bool disposing )
		{
			lock ( this )
			{
				if ( disposing )
				{
					if ( components != null )
						components.Dispose();
				}
				base.Dispose( disposing );

				_masterPane = null;
			}
		}
	
	#endregion

	#region Methods

		/// <summary>
		/// Called by the system to update the control on-screen
		/// </summary>
		/// <param name="e">
		/// A PaintEventArgs object containing the Graphics specifications
		/// for this Paint event.
		/// </param>
		protected override void OnPaint( PaintEventArgs e )
		{
			lock ( this )
			{
				if ( BeenDisposed || _masterPane == null || GraphPane == null )
					return;

				if ( hScrollBar1 != null && GraphPane != null &&
					vScrollBar1 != null && _yScrollRangeList != null )
				{
					SetScroll( hScrollBar1, GraphPane.XAxis, _xScrollRange.Min, _xScrollRange.Max );
					SetScroll( vScrollBar1, GraphPane.YAxis, _yScrollRangeList[0].Min,
						_yScrollRangeList[0].Max );
				}

				base.OnPaint( e );

				// Add a try/catch pair since the users of the control can't catch this one
				try { _masterPane.Draw( e.Graphics ); }
				catch { }
			}

/*
			// first, see if an old thread is still running
			if ( t != null && t.IsAlive )
			{
				t.Abort();
			}

			//dt = new DrawingThread( e.Graphics, _masterPane );
			//g = e.Graphics;

			// Fire off the new thread
			t = new Thread( new ParameterizedThreadStart( DoDrawingThread ) );
			//ct.ApartmentState = ApartmentState.STA;
			//ct.SetApartmentState( ApartmentState.STA );
			DrawingThreadData dtd;
			dtd._g = e.Graphics;
			dtd._masterPane = _masterPane;

			t.Start( dtd );
			//ct.Join();
*/
		}

//		Thread t = null;
		//DrawingThread dt = null;

/*
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dtdobj"></param>
		public void DoDrawingThread( object dtdobj )
		{
			try
			{
				DrawingThreadData dtd = (DrawingThreadData) dtdobj;

				if ( dtd._g != null && dtd._masterPane != null )
					dtd._masterPane.Draw( dtd._g );

				//				else
				//				{
				//					using ( Graphics g2 = CreateGraphics() )
				//						_masterPane.Draw( g2 );
				//				}
			}
			catch
			{

			}
		}
*/

		/// <summary>
		/// Called when the control has been resized.
		/// </summary>
		/// <param name="sender">
		/// A reference to the control that has been resized.
		/// </param>
		/// <param name="e">
		/// An EventArgs object.
		/// </param>
		protected void ZedGraphControl_ReSize( object sender, EventArgs e )
		{
			lock ( this )
			{
				if ( BeenDisposed || _masterPane == null )
					return;

				Size newSize = Size;

				if ( _isShowHScrollBar )
				{
					hScrollBar1.Visible = true;
					newSize.Height -= hScrollBar1.Size.Height;
					hScrollBar1.Location = new Point( 0, newSize.Height );
					hScrollBar1.Size = new Size( newSize.Width, hScrollBar1.Height );
				}
				else
					hScrollBar1.Visible = false;

				if ( _isShowVScrollBar )
				{
					vScrollBar1.Visible = true;
					newSize.Width -= vScrollBar1.Size.Width;
					vScrollBar1.Location = new Point( newSize.Width, 0 );
					vScrollBar1.Size = new Size( vScrollBar1.Width, newSize.Height );
				}
				else
					vScrollBar1.Visible = false;

				using ( Graphics g = CreateGraphics() )
				{
					_masterPane.ReSize( g, new RectangleF( 0, 0, newSize.Width, newSize.Height ) );
					//g.Dispose();
				}
				Invalidate();
			}
		}
		/// <summary>This performs an axis change command on the graphPane.
		/// </summary>
		/// <remarks>
		/// This is the same as
		/// <c>ZedGraphControl.GraphPane.AxisChange( ZedGraphControl.CreateGraphics() )</c>, however,
		/// this method also calls <see c_ref="SetScrollRangeFromData" /> if <see c_ref="IsAutoScrollRange" />
		/// is true.
		/// </remarks>
		public virtual void AxisChange()
		{
			lock ( this )
			{
				if ( BeenDisposed || _masterPane == null )
					return;

				using ( Graphics g = CreateGraphics() )
				{
					_masterPane.AxisChange( g );
					//g.Dispose();
				}

				if ( _isAutoScrollRange )
					SetScrollRangeFromData();
			}
		}
	#endregion

	#region Zoom States

		/// <summary>
		/// Save the current states of the GraphPanes to a separate collection.  Save a single
		/// (<see paramref="primaryPane" />) GraphPane if the panes are not synchronized
		/// (see <see c_ref="IsSynchronizeXAxes" /> and <see c_ref="IsSynchronizeYAxes" />),
		/// or save a list of states for all GraphPanes if the panes are synchronized.
		/// </summary>
		/// <param name="primaryPane">The primary GraphPane on which zoom/pan/scroll operations
		/// are taking place</param>
		/// <param name="type">The <see c_ref="ZoomState.StateType" /> that describes the
		/// current operation</param>
		/// <returns>The <see c_ref="ZoomState" /> that corresponds to the
		/// <see paramref="primaryPane" />.
		/// </returns>
		private ZoomState ZoomStateSave( GraphPane primaryPane, ZoomState.StateType type )
		{
			ZoomStateClear();

			if ( _isSynchronizeXAxes || _isSynchronizeYAxes )
			{
				foreach ( GraphPane pane in _masterPane._paneList )
				{
					ZoomState state = new ZoomState( pane, type );
					if ( pane == primaryPane )
						_zoomState = state;
					_zoomStateStack.Add( state );
				}
			}
			else
				_zoomState = new ZoomState( primaryPane, type );

			return _zoomState;
		}

		/// <summary>
		/// Restore the states of the GraphPanes to a previously saved condition (via
		/// <see c_ref="ZoomStateSave" />.  This is essentially an "undo" for live
		/// pan and scroll actions.  Restores a single
		/// (<see paramref="primaryPane" />) GraphPane if the panes are not synchronized
		/// (see <see c_ref="IsSynchronizeXAxes" /> and <see c_ref="IsSynchronizeYAxes" />),
		/// or save a list of states for all GraphPanes if the panes are synchronized.
		/// </summary>
		/// <param name="primaryPane">The primary GraphPane on which zoom/pan/scroll operations
		/// are taking place</param>
		private void ZoomStateRestore( GraphPane primaryPane )
		{
			if ( _isSynchronizeXAxes || _isSynchronizeYAxes )
			{
				for ( int i = 0; i < _masterPane._paneList.Count; i++ )
				{
					if ( i < _zoomStateStack.Count )
						_zoomStateStack[i].ApplyState( _masterPane._paneList[i] );
				}
			}
			else if ( _zoomState != null )
				_zoomState.ApplyState( primaryPane );

			ZoomStateClear();
		}

		/// <summary>
		/// Place the previously saved states of the GraphPanes on the individual GraphPane
		/// <see c_ref="ZedGraph.GraphPane.ZoomStack" /> collections.  This provides for an
		/// option to undo the state change at a later time.  Save a single
		/// (<see paramref="primaryPane" />) GraphPane if the panes are not synchronized
		/// (see <see c_ref="IsSynchronizeXAxes" /> and <see c_ref="IsSynchronizeYAxes" />),
		/// or save a list of states for all GraphPanes if the panes are synchronized.
		/// </summary>
		/// <param name="primaryPane">The primary GraphPane on which zoom/pan/scroll operations
		/// are taking place</param>
		/// <returns>The <see c_ref="ZoomState" /> that corresponds to the
		/// <see paramref="primaryPane" />.
		/// </returns>
		private void ZoomStatePush( GraphPane primaryPane )
		{
			if ( _isSynchronizeXAxes || _isSynchronizeYAxes )
			{
				for ( int i = 0; i < _masterPane._paneList.Count; i++ )
				{
					if ( i < _zoomStateStack.Count )
						_masterPane._paneList[i].ZoomStack.Add( _zoomStateStack[i] );
				}
			}
			else if ( _zoomState != null )
				primaryPane.ZoomStack.Add( _zoomState );

			ZoomStateClear();
		}

		/// <summary>
		/// Clear the collection of saved states.
		/// </summary>
		private void ZoomStateClear()
		{
			_zoomStateStack.Clear();
			_zoomState = null;
		}

		/// <summary>
		/// Clear all states from the undo stack for each GraphPane.
		/// </summary>
		private void ZoomStatePurge()
		{
			foreach ( GraphPane pane in _masterPane._paneList )
				pane.ZoomStack.Clear();
		}

	#endregion

	}
}
