//============================================================================
//PieItem Class
//Copyright ?2005  Bob Kaye
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
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace UIGraphLib
{
	/// <summary>
	/// A class representing a pie chart object comprised of one or more
	/// <see c_ref="PieItem"/>s.
	/// </summary>
	/// <author> Bob Kaye </author>
	/// <version> $Revision: 1.32 $ $Date: 2007-07-30 05:26:23 $ </version>
	[Serializable]
	public class PieItem : CurveItem, ICloneable, ISerializable
	{

		#region Fields
		/*
		/// <summary>
		/// Private field instance of the <see c_ref="PieItem"/> class indicating whether
		/// the instance is displayed in 2D or 3D.(see <see c_ref="PieItem.PieType"/>)
		/// </summary>
		private PieType pieType;
*/
		/// <summary>
		/// Percentage (expressed as #.##) of <see c_ref="PieItem"/>	radius  to
		/// which this <see c_ref="PieItem"/> is to be displaced from the center.
		///   Displacement is done outward  along the radius
		/// bisecting the chord of this <see c_ref="PieItem"/>.  Maximum allowable value
		/// is 0.5.
		/// </summary>
		private double _displacement;

		/// <summary>
		/// A <see c_ref="ZedGraph.TextObj"/> which will customize the label display of this
		/// <see c_ref="PieItem"/>
		/// </summary>
		private TextObj _labelDetail;

		/// <summary>
		/// Private	field	that stores the	<see c_ref="ZedGraph.Fill"/> data for this
		/// <see	c_ref="PieItem"/>.	 Use the public property <see	c_ref="Fill"/> to
		/// access this value.
		/// </summary>
		private Fill _fill;

		/// <summary>
		/// Private	field	that stores the	<see c_ref="Border"/> class that defines	the
		/// properties of the	border around	this <see c_ref="PieItem"/>. Use the public
		/// property	<see c_ref="Border"/> to access this value.
		/// </summary>
		private Border _border;

		/// <summary>
		/// Private field that stores the absolute value of this <see c_ref="PieItem"/> instance.
		/// Value will be set to zero if submitted value is less than zero. 
		/// </summary>
		private double _pieValue;

		/// <summary>
		/// An enum that specifies how each <see c_ref="CurveItem.Label"/> for this <see c_ref="PieItem"/> object 
		/// will be displayed.  Use the public property <see c_ref="LabelType"/> to access this data.  
		/// Use enum <see c_ref="ZedGraph.PieLabelType"/>.
		/// </summary>
		private PieLabelType _labelType;
		/// <summary>
		/// The point on the arc of this <see c_ref="PieItem"/> representing the intersection of
		/// the arc and the explosion radius.
		/// </summary>
		private PointF _intersectionPoint;

		/// <summary>
		/// The bounding rectangle for this <see c_ref="PieItem"/>.
		/// </summary>
		private RectangleF _boundingRectangle;

		/// <summary>
		/// The formatted string for this <see c_ref="PieItem"/>'s label.  Formatting is
		/// done based on  the <see c_ref="PieLabelType"/>.
		/// </summary>
		private string _labelStr;
		/// <summary>
		/// The point at which the line between this <see c_ref="PieItem"/> and its
		/// label bends to the horizontal.
		/// </summary>
		private PointF _pivotPoint;
		/// <summary>
		/// The point at the end of the line between	this <see c_ref="PieItem"/> and 
		/// it's label (i.e. the beginning of the label display)
		/// </summary>
		private PointF _endPoint;

		/// <summary>
		/// Private field to hold the GraphicsPath of this <see c_ref="PieItem"/> to be
		/// used for 'hit testing'.
		/// </summary>
		private GraphicsPath _slicePath;

		/// <summary>
		/// Private field which holds the angle (in degrees) at which the display of this <see c_ref="PieItem"/>
		/// object will begin.
		/// </summary>
		private float _startAngle;

		/// <summary>
		///Private field which holds the length (in degrees) of the arc representing this <see c_ref="PieItem"/> 
		///object.
		/// </summary>
		private float _sweepAngle;

		/// <summary>
		///Private field which represents the angle (in degrees) of the radius along which this <see c_ref="PieItem"/>
		///object will be displaced, if desired.
		/// </summary>
		private float _midAngle;

		/// <summary>
		///Private field which determines the number of decimal digits displayed to 
		///in a <see c_ref="PieItem"/> label containing a value. 
		/// </summary>
		private int _valueDecimalDigits;

		/// <summary>
		///Private field which determines the number of decimal digits displayed 
		///in a <see c_ref="PieItem"/> label containing a percent. 
		/// </summary>
		private int _percentDecimalDigits;

		private static ColorSymbolRotator _rotator = new ColorSymbolRotator();

		#endregion

		#region Defaults
		/// <summary>
		/// Specify the default property values for the <see c_ref="PieItem"/> class.
		/// </summary>
		public struct Default
		{
			/// <summary>
			///Default <see c_ref="PieItem "/> displacement.
			/// </summary>
			public static double Displacement = 0;

			/// <summary>
			/// The default pen width	to be used for drawing the	border around	the PieItem
			/// (<see c_ref="ZedGraph.LineBase.Width"/> property). Units are points.
			/// </summary>
			public static float BorderWidth = 1.0F;
			/// <summary>
			/// The default fill mode for this PieItem (<see	c_ref="ZedGraph.Fill.Type"/> property).
			/// </summary>
			public static FillType FillType = FillType.Brush;
			/// <summary>
			/// The default border mode for PieItem (<see c_ref="ZedGraph.LineBase.IsVisible"/> property).
			/// true to	display frame around PieItem, false otherwise
			/// </summary>
			public static bool IsBorderVisible = true;
			/// <summary>
			/// The default color for drawing	frames around	PieItem
			/// (<see c_ref="ZedGraph.LineBase.Color"/> property).
			/// </summary>
			public static Color BorderColor = Color.Black;
			/// <summary>
			/// The default color for filling in	the PieItem
			/// (<see c_ref="ZedGraph.Fill.Color"/>	property).
			/// </summary>
			public static Color FillColor = Color.Red;
			/// <summary>
			/// The default custom brush for filling in the PieItem.
			/// (<see c_ref="ZedGraph.Fill.Brush"/> property).
			/// </summary>
			public static Brush FillBrush = null;

			/// <summary>
			///Default value for controlling <see c_ref="PieItem"/> display.
			/// </summary>
			public static bool isVisible = true;

			/// <summary>
			/// Default value for <see c_ref="PieItem.LabelType"/>.
			/// </summary>
			public static PieLabelType LabelType = PieLabelType.Name;

			/// <summary>
			/// The default font size for  <see c_ref="PieItem.LabelDetail"/> entries
			/// (<see c_ref="ZedGraph.FontSpec.Size"/> property).  Units are
			/// in points (1/72 inch).
			/// </summary>
			public static float FontSize = 10;

			/// <summary>
			/// Default value for the number of decimal digits  
			/// to be displayed when <see c_ref="LabelType"/>  contains a value.
			/// </summary>
			public static int ValueDecimalDigits = 0;

			/// <summary>
			/// Default value for the number of decimal digits  
			/// to be displayed where <see c_ref="LabelType"/> contains a percent.
			/// </summary>
			public static int PercentDecimalDigits = 2;
		}
		#endregion Defaults

		#region PieItem Properties
		/// <summary>
		/// Gets or sets the a value which determines the amount, if any, of this <see c_ref="PieItem"/>  
		/// displacement.
		/// </summary>
		public double Displacement
		{
			get { return ( _displacement ); }
			set { _displacement = value > .5 ? .5 : value; }
		}

		/// <summary>
		/// Gets a path representing this <see c_ref="PieItem"/>
		/// </summary>
		public GraphicsPath SlicePath
		{
			get { return _slicePath; }
		}

		/// <summary>
		/// Gets or sets the <see c_ref="TextObj"/> to be used
		/// for displaying this <see c_ref="PieItem"/>'s label.
		/// </summary>
		public TextObj LabelDetail
		{
			get { return _labelDetail; }
			set { _labelDetail = value; }
		}

		/// <summary>
		/// Gets or sets the <see c_ref="Border"/> object so as to be able to modify
		/// its properties.
		/// </summary>
		public Border Border
		{
			get { return ( _border ); }
			set { _border = value; }
		}

		/// <summary>
		/// Gets or sets the <see c_ref="Fill" /> object which is used to fill the
		/// pie slice with color.
		/// </summary>
		public Fill Fill
		{
			get { return _fill; }
			set { _fill = value; }
		}

		/// <summary>
		/// Gets or sets the arc length (in degrees) of this <see c_ref="PieItem"/>.
		/// </summary>
		private float SweepAngle
		{
			get { return _sweepAngle; }
			set { _sweepAngle = value; }
		}

		/// <summary>
		/// Gets or sets the starting angle (in degrees) of this <see c_ref="PieItem"/>.
		/// </summary>
		private float StartAngle
		{
			get { return ( _startAngle ); }
			set { _startAngle = value; }
		}

		/// <summary>
		/// Gets or sets the angle (in degrees) of the radius along which 
		/// this <see c_ref="PieItem"/> will be displaced.
		/// </summary>
		private float MidAngle
		{
			get { return ( _midAngle ); }
			set { _midAngle = value; }
		}

		/// <summary>
		///  Gets or sets the value of this <see c_ref="PieItem"/>.  
		///  Minimum value is 0. 
		/// </summary>
		public double Value
		{
			get { return ( _pieValue ); }
			set { _pieValue = value > 0 ? value : 0; }
		}

		/// <summary>
		/// Gets or sets the <see c_ref="PieLabelType"/> to be used in displaying 
		/// <see c_ref="PieItem"/> labels.
		/// </summary>
		public PieLabelType LabelType
		{
			get { return ( _labelType ); }
			set
			{
				_labelType = value;
				if ( value == PieLabelType.None )
					LabelDetail.IsVisible = false;
				else
					LabelDetail.IsVisible = true;
			}
		}

		/// <summary>
		/// Gets or sets the number of decimal digits to be displayed in a <see c_ref="PieItem"/> 
		/// value label.
		/// </summary>
		public int ValueDecimalDigits
		{
			get { return ( _valueDecimalDigits ); }
			set { _valueDecimalDigits = value; }
		}

		/// <summary>
		/// Gets or sets the number of decimal digits to be displayed in a <see c_ref="PieItem"/> 
		/// percent label.
		/// </summary>
		public int PercentDecimalDigits
		{
			get { return ( _percentDecimalDigits ); }
			set { _percentDecimalDigits = value; }
		}

		/*
		/// <summary>
		/// Getsor sets enum <see c_ref="PieType"/> to be used	for drawing this <see c_ref="PieItem"/>.
		/// </summary>
		public PieType PieType
		{
			get { return (this.pieType); }
			set { this.pieType = value; }
		}
 */
		/// <summary>
		/// Gets a flag indicating if the Z data range should be included in the axis scaling calculations.
		/// </summary>
		/// <param name="pane">The parent <see c_ref="GraphPane" /> of this <see c_ref="CurveItem" />.
		/// </param>
		/// <value>true if the Z data are included, false otherwise</value>
		override internal bool IsZIncluded( GraphPane pane )
		{
			return false;
		}

		/// <summary>
		/// Gets a flag indicating if the X axis is the independent axis for this <see c_ref="CurveItem" />
		/// </summary>
		/// <param name="pane">The parent <see c_ref="GraphPane" /> of this <see c_ref="CurveItem" />.
		/// </param>
		/// <value>true if the X axis is independent, false otherwise</value>
		override internal bool IsXIndependent( GraphPane pane )
		{
			return true;
		}

		#endregion

		#region Constructors
		/// <summary>
		/// Create a new <see c_ref="PieItem"/>, providing a gradient fill for the pie color.
		/// </summary>
		/// <param name="pieValue">The value associated with this <see c_ref="PieItem"/> instance.</param>
		/// <param name="color1">The starting display color for the gradient <see c_ref="Fill"/> for this
		/// <see c_ref="PieItem"/> instance.</param>
		/// <param name="color2">The ending display color for the gradient <see c_ref="Fill"/> for this
		/// <see c_ref="PieItem"/> instance.</param>
		/// <param name="fillAngle">The angle for the gradient <see c_ref="Fill"/>.</param>
		/// <param name="displacement">The amount this <see c_ref="PieItem"/>  instance will be 
		/// displaced from the center point.</param>
		/// <param name="label">Text label for this <see c_ref="PieItem"/> instance.</param>
		public PieItem( double pieValue, Color color1, Color color2, float fillAngle,
						double displacement, string label )
			:
						this( pieValue, color1, displacement, label )
		{
			if ( !color1.IsEmpty && !color2.IsEmpty )
				_fill = new Fill( color1, color2, fillAngle );
		}

		/// <summary>
		/// Create a new <see c_ref="PieItem"/>.
		/// </summary>
		/// <param name="pieValue">The value associated with this <see c_ref="PieItem"/> instance.</param>
		/// <param name="color">The display color for this <see c_ref="PieItem"/> instance.</param>
		/// <param name="displacement">The amount this <see c_ref="PieItem"/>  instance will be 
		/// displaced from the center point.</param>
		/// <param name="label">Text label for this <see c_ref="PieItem"/> instance.</param>
		public PieItem( double pieValue, Color color, double displacement, string label )
			: base( label )
		{
			_pieValue = pieValue;
			_fill = new Fill( color.IsEmpty ? _rotator.NextColor : color );
			_displacement = displacement;
			_border = new Border( Default.BorderColor, Default.BorderWidth );
			_labelDetail = new TextObj();
			_labelDetail.FontSpec.Size = Default.FontSize;
			_labelType = Default.LabelType;
			_valueDecimalDigits = Default.ValueDecimalDigits;
			_percentDecimalDigits = Default.PercentDecimalDigits;
			_slicePath = null;
		}

		/// <summary>
		/// Create a  new <see c_ref="PieItem"/>.
		/// </summary>
		/// <param name="pieValue">The value associated with this <see c_ref="PieItem"/> instance.</param>
		/// <param name="label">Text label for this <see c_ref="PieItem"/> instance</param>
		public PieItem( double pieValue, string label )
			:
			this( pieValue, _rotator.NextColor, Default.Displacement, label )
		{
		}

		/// <summary>
		/// The Copy Constructor
		/// </summary>
		/// <param name="rhs">The <see c_ref="PieItem"/> object from which to copy</param>
		public PieItem( PieItem rhs )
			: base( rhs )
		{
			_pieValue = rhs._pieValue;
			_fill = rhs._fill.Clone();
			Border = rhs._border.Clone();
			_displacement = rhs._displacement;
			_labelDetail = rhs._labelDetail.Clone();
			_labelType = rhs._labelType;
			_valueDecimalDigits = rhs._valueDecimalDigits;
			_percentDecimalDigits = rhs._percentDecimalDigits;
		}

		/// <summary>
		/// Implement the <see c_ref="ICloneable" /> interface in a typesafe manner by just
		/// calling the typed version of <see c_ref="Clone" />
		/// </summary>
		/// <returns>A deep copy of this object</returns>
		object ICloneable.Clone()
		{
			return Clone();
		}

		/// <summary>
		/// Typesafe, deep-copy clone method.
		/// </summary>
		/// <returns>A new, independent copy of this class</returns>
		public PieItem Clone()
		{
			return new PieItem( this );
		}


		#endregion

		#region Serialization
		/// <summary>
		/// Current schema value that defines the version of the serialized file
		/// </summary>
		public const int schema2 = 10;

		/// <summary>
		/// Constructor for deserializing objects
		/// </summary>
		/// <param name="info">A <see c_ref="SerializationInfo"/> instance that defines the serialized data
		/// </param>
		/// <param name="context">A <see c_ref="StreamingContext"/> instance that contains the serialized data
		/// </param>
		protected PieItem( SerializationInfo info, StreamingContext context )
			: base( info, context )
		{
			// The schema value is just a file version parameter.  You can use it to make future versions
			// backwards compatible as new member variables are added to classes
			int sch = info.GetInt32( "schema2" );

			_displacement = info.GetDouble( "displacement" );
			_labelDetail = (TextObj)info.GetValue( "labelDetail", typeof( TextObj ) );
			_fill = (Fill)info.GetValue( "fill", typeof( Fill ) );
			_border = (Border)info.GetValue( "border", typeof( Border ) );
			_pieValue = info.GetDouble( "pieValue" );
			_labelType = (PieLabelType)info.GetValue( "labelType", typeof( PieLabelType ) );
			_intersectionPoint = (PointF)info.GetValue( "intersectionPoint", typeof( PointF ) );
			_boundingRectangle = (RectangleF)info.GetValue( "boundingRectangle", typeof( RectangleF ) );
			_pivotPoint = (PointF)info.GetValue( "pivotPoint", typeof( PointF ) );
			_endPoint = (PointF)info.GetValue( "endPoint", typeof( PointF ) );
			// _slicePath = (GraphicsPath)info.GetValue( "slicePath", typeof( GraphicsPath ) );
			_startAngle = (float)info.GetDouble( "startAngle" );
			_sweepAngle = (float)info.GetDouble( "sweepAngle" );
			_midAngle = (float)info.GetDouble( "midAngle" );
			_labelStr = info.GetString( "labelStr" );
			_valueDecimalDigits = info.GetInt32( "valueDecimalDigits" );
			_percentDecimalDigits = info.GetInt32( "percentDecimalDigits" );
		}
		/// <summary>
		/// Populates a <see c_ref="SerializationInfo"/> instance with the data needed to serialize the target object
		/// </summary>
		/// <param name="info">A <see c_ref="SerializationInfo"/> instance that defines the serialized data</param>
		/// <param name="context">A <see c_ref="StreamingContext"/> instance that contains the serialized data</param>
		[SecurityPermission( SecurityAction.Demand, SerializationFormatter = true )]
		public override void GetObjectData( SerializationInfo info, StreamingContext context )
		{
			base.GetObjectData( info, context );
			info.AddValue( "schema2", schema2 );
			info.AddValue( "displacement", _displacement );
			info.AddValue( "labelDetail", _labelDetail );
			info.AddValue( "fill", _fill );
			info.AddValue( "border", _border );
			info.AddValue( "pieValue", _pieValue );
			info.AddValue( "labelType", _labelType );
			info.AddValue( "intersectionPoint", _intersectionPoint );
			info.AddValue( "boundingRectangle", _boundingRectangle );
			info.AddValue( "pivotPoint", _pivotPoint );
			info.AddValue( "endPoint", _endPoint );
			// info.AddValue( "slicePath", _slicePath );
			info.AddValue( "startAngle", _startAngle );
			info.AddValue( "sweepAngle", _sweepAngle );
			info.AddValue( "midAngle", _midAngle );
			info.AddValue( "labelStr", _labelStr );
			info.AddValue( "valueDecimalDigits", _valueDecimalDigits );
			info.AddValue( "percentDecimalDigits", _percentDecimalDigits );
		}

		#endregion

		#region Methods
		/// <summary>
		/// Do all rendering associated with this <see c_ref="PieItem"/> item to the specified
		/// <see c_ref="Graphics"/> device.  This method is normally only
		/// called by the Draw method of the parent <see c_ref="ZedGraph.CurveList"/>
		/// collection object.
		/// </summary>
		/// <param name="g">
		/// A graphic device object to be drawn into.  This is normally e.Graphics from the
		/// PaintEventArgs argument to the Paint() method.
		/// </param>
		/// <param name="pane">
		/// A reference to the <see c_ref="ZedGraph.GraphPane"/> object that is the parent or
		/// owner of this object.
		/// </param>
		/// <param name="pos">Not used for rendering Pies</param>param>
		/// <param name="scaleFactor">
		/// The scaling factor to be used for rendering objects.  This is calculated and
		/// passed down by the parent <see c_ref="ZedGraph.GraphPane"/> object using the
		/// <see c_ref="PaneBase.CalcScaleFactor"/> method, and is used to proportionally adjust
		/// font sizes, etc. according to the actual size of the graph.
		/// </param>				
		override public void Draw( Graphics g, GraphPane pane, int pos, float scaleFactor )
		{
			if ( pane.Chart._rect.Width <= 0 && pane.Chart._rect.Height <= 0 )
			{
				//pane.PieRect = RectangleF.Empty;
				_slicePath = null;
			}
			else
			{
				//pane.PieRect = CalcPieRect( g, pane, scaleFactor, pane.ChartRect );
				CalcPieRect( g, pane, scaleFactor, pane.Chart._rect );

				_slicePath = new GraphicsPath();

				if ( !_isVisible )
					return;

				RectangleF tRect = _boundingRectangle;

				if ( tRect.Width >= 1 && tRect.Height >= 1 )
				{
					SmoothingMode sMode = g.SmoothingMode;
					g.SmoothingMode = SmoothingMode.AntiAlias;

					Fill tFill = _fill;
					Border tBorder = _border;
					if ( IsSelected )
					{
						tFill = Selection.Fill;
						tBorder = Selection.Border;
					}

					using ( Brush brush = tFill.MakeBrush( _boundingRectangle ) )
					{
						g.FillPie( brush, tRect.X, tRect.Y, tRect.Width, tRect.Height, StartAngle, SweepAngle );

						//add GraphicsPath for hit testing
						_slicePath.AddPie( tRect.X, tRect.Y, tRect.Width, tRect.Height,
							StartAngle, SweepAngle );

						if ( Border.IsVisible )
						{
							using ( Pen borderPen = tBorder.GetPen( pane, scaleFactor ) )
							{
								g.DrawPie( borderPen, tRect.X, tRect.Y, tRect.Width, tRect.Height,
									StartAngle, SweepAngle );
							}
						}

						if ( _labelType != PieLabelType.None )
							DrawLabel( g, pane, tRect, scaleFactor );

						//brush.Dispose();
					}

					g.SmoothingMode = sMode;
				}
			}
		}

		/// <summary>
		/// Calculate the <see c_ref="RectangleF"/> that will be used to define the bounding rectangle of
		/// the Pie.
		/// </summary>
		/// <remarks>This rectangle always lies inside of the <see c_ref="Chart.Rect"/>, and it is
		/// normally a square so that the pie itself is not oval-shaped.</remarks>
		/// <param name="g">
		/// A graphic device object to be drawn into.  This is normally e.Graphics from the
		/// PaintEventArgs argument to the Paint() method.
		/// </param>
		/// <param name="pane">
		/// A reference to the <see c_ref="ZedGraph.GraphPane"/> object that is the parent or
		/// owner of this object.
		/// </param>
		/// <param name="scaleFactor">
		/// The scaling factor to be used for rendering objects.  This is calculated and
		/// passed down by the parent <see c_ref="ZedGraph.GraphPane"/> object using the
		/// <see c_ref="PaneBase.CalcScaleFactor"/> method, and is used to proportionally adjust
		/// font sizes, etc. according to the actual size of the graph.
		/// </param>				
		/// <param name="chartRect">The <see c_ref="RectangleF"/> (normally the <see c_ref="Chart.Rect"/>)
		/// that bounds this pie.</param>
		/// <returns></returns>
		public static RectangleF CalcPieRect( Graphics g, GraphPane pane, float scaleFactor, RectangleF chartRect )
		{
			//want to draw the largest pie possible within ChartRect
			//but want to leave  5% slack around the pie so labels will not overrun clip area
			//largest pie is limited by the smaller of ChartRect.height or ChartRect.width...
			//this rect (nonExplRect)has to be re-positioned so that it's in the center of ChartRect.
			//Where ChartRect is almost a square - low Aspect Ratio -, need to contract pieRect so that there's some
			//room for labels, if they're visible.
			double maxDisplacement = 0;
			RectangleF tempRect;   //= new RectangleF(0,0,0,0);

			RectangleF nonExplRect = chartRect;

			if ( pane.CurveList.IsPieOnly )
			{
				if ( nonExplRect.Width < nonExplRect.Height )
				{
					//create slack rect
					nonExplRect.Inflate( -0.05F * nonExplRect.Height, -0.05F * nonExplRect.Width );
					//get the difference between dimensions
					float delta = ( nonExplRect.Height - nonExplRect.Width ) / 2;
					//make a square	so we end up with circular pie
					nonExplRect.Height = nonExplRect.Width;
					//keep the center point  the same
					nonExplRect.Y += delta;
				}
				else
				{
					nonExplRect.Inflate( -0.05F * nonExplRect.Height, -0.05F * nonExplRect.Width );
					float delta = ( nonExplRect.Width - nonExplRect.Height ) / 2;
					nonExplRect.Width = nonExplRect.Height;
					nonExplRect.X += delta;
				}
				//check aspect ratio
				double aspectRatio = chartRect.Width / chartRect.Height;
				//make an adjustment in rect size,as aspect ratio varies
				if ( aspectRatio < 1.5 )
					nonExplRect.Inflate( -(float)( .1 * ( 1.5 / aspectRatio ) * nonExplRect.Width ),
											-(float)( .1 * ( 1.5 / aspectRatio ) * nonExplRect.Width ) );

				//modify the rect to determine if any of the labels need to be wrapped....
				//first see if there's any exploded slices and if so, what's the max displacement...
				//also, might as well get all the display params we can
				CalculatePieChartParams( pane, ref maxDisplacement );

				if ( maxDisplacement != 0 )			 //need new rectangle if any slice exploded	
					CalcNewBaseRect( maxDisplacement, ref nonExplRect );

				foreach ( PieItem slice in pane.CurveList )
				{
					slice._boundingRectangle = nonExplRect;
					//if exploded, need to re-calculate rectangle for slice
					if ( slice.Displacement != 0 )
					{
						tempRect = nonExplRect;
						slice.CalcExplodedRect( ref tempRect );
						slice._boundingRectangle = tempRect;
					}
					//now get all the other slice specific drawing details, including need for wrapping label
					slice.DesignLabel( g, pane, slice._boundingRectangle, scaleFactor );
				}
			}
			return nonExplRect;
		}

		/// <summary>
		/// Recalculate the bounding rectangle when a piee slice is displaced.
		/// </summary>
		/// <param name="explRect">rectangle to be used for drawing exploded pie</param>
		private void CalcExplodedRect( ref RectangleF explRect )
		{
			//pie exploded out along the slice bisector - modify upper left of bounding rect to account for displacement
			//keep height and width same
			explRect.X += (float)( Displacement * explRect.Width / 2 * Math.Cos( _midAngle * Math.PI / 180 ) );
			explRect.Y += (float)( Displacement * explRect.Height / 2 * Math.Sin( _midAngle * Math.PI / 180 ) );
		}

		/// <summary>
		/// Calculate the values needed to properly display this <see c_ref="PieItem"/>.
		/// </summary>
		/// <param name="pane">
		/// A graphic device object to be drawn into.  This is normally e.Graphics from the
		/// PaintEventArgs argument to the Paint() method.
		/// </param>
		/// <param name="maxDisplacement">maximum slice displacement</param>
		private static void CalculatePieChartParams( GraphPane pane, ref double maxDisplacement )
		{
			string lblStr = " ";

			//loop thru slices and get total value and maxDisplacement
			double pieTotalValue = 0;
			foreach ( PieItem curve in pane.CurveList )
				if ( curve.IsPie )
				{
					pieTotalValue += curve._pieValue;
					if ( curve.Displacement > maxDisplacement )
						maxDisplacement = curve.Displacement;
				}

			double nextStartAngle = 0;
			//now loop thru and calculate the various angle values
			foreach ( PieItem curve in pane.CurveList )
			{
				lblStr = curve._labelStr;
				curve.StartAngle = (float)nextStartAngle;
				curve.SweepAngle = (float)( 360 * curve.Value / pieTotalValue );
				curve.MidAngle = curve.StartAngle + curve.SweepAngle / 2;
				nextStartAngle = curve._startAngle + curve._sweepAngle;
				BuildLabelString( curve );
			}
		}

		/// <summary>
		/// Render the label for this <see c_ref="PieItem"/>.
		/// </summary>
		/// <param name="g">
		/// A graphic device object to be drawn into.  This is normally e.Graphics from the
		/// PaintEventArgs argument to the Paint() method.
		/// </param>
		/// <param name="pane">
		/// A graphic device object to be drawn into.  This is normally e.Graphics from the
		/// PaintEventArgs argument to the Paint() method.
		/// </param>
		/// <param name="rect">Bounding rectangle for this <see c_ref="PieItem"/>.</param>
		/// <param name="scaleFactor">
		/// The scaling factor to be used for rendering objects.  This is calculated and
		/// passed down by the parent <see c_ref="ZedGraph.GraphPane"/> object using the
		/// <see c_ref="PaneBase.CalcScaleFactor"/> method, and is used to proportionally adjust
		/// font sizes, etc. according to the actual size of the graph.
		/// </param>				
		public void DrawLabel( Graphics g, GraphPane pane, RectangleF rect, float scaleFactor )
		{
			if ( !_labelDetail.IsVisible )
				return;

			using ( Pen labelPen = Border.GetPen( pane, scaleFactor ) )
			{
				//draw line from intersection point to pivot point -
				g.DrawLine( labelPen, _intersectionPoint, _pivotPoint );

				//draw horizontal line to move label away from pie...
				g.DrawLine( labelPen, _pivotPoint, _endPoint );
			}

			//draw the label (TextObj)
			_labelDetail.Draw( g, pane, scaleFactor );
		}

		/// <summary>
		/// This method collects all the data relative to rendering this <see c_ref="PieItem"/>'s label.
		/// </summary>
		/// <param name="g">
		///  A graphic device object to be drawn into.  This is normally e.Graphics from the
		/// PaintEventArgs argument to the Paint() method.
		/// </param>
		/// <param name="pane">
		/// A graphic device object to be drawn into.  This is normally e.Graphics from the
		/// PaintEventArgs argument to the Paint() method.
		/// </param>
		/// <param name="rect">The rectangle used for rendering this <see c_ref="PieItem"/>
		/// </param>
		/// <param name="scaleFactor">
		/// The scaling factor to be used for rendering objects.  This is calculated and
		/// passed down by the parent <see c_ref="ZedGraph.GraphPane"/> object using the
		/// <see c_ref="PaneBase.CalcScaleFactor"/> method, and is used to proportionally adjust
		/// font sizes, etc. according to the actual size of the graph.
		/// </param>
		public void DesignLabel( Graphics g, GraphPane pane, RectangleF rect, float scaleFactor )
		{
			if ( !_labelDetail.IsVisible )
				return;

			_labelDetail.LayoutArea = new SizeF();
			//this.labelDetail.IsWrapped = false;

			//label line will come off the explosion radius and then pivot to the horizontal right or left,
			//dependent on position.. 
			//text will be at the end of horizontal segment...
			CalculateLinePoints( rect, _midAngle );

			//now get size of bounding rect for label
			SizeF size = _labelDetail.FontSpec.BoundingBox( g, _labelStr, scaleFactor );

			//how much room left for the label - most likely midangles for wrapping
			//Right - 315 -> 45 degrees
			//Bottom - 45 -> 135
			//Left - 135 -> 225
			//Top - 225 -> 315
			RectangleF chartRect = pane.Chart._rect;
			float fill = 0;
			if ( _midAngle > 315 || _midAngle <= 45 )
			{
				//correct by wrapping text
				fill = chartRect.X + chartRect.Width - _endPoint.X - 5;
				if ( size.Width > fill )
				{
					//need to wrap, so create label rectangle for overloaded DrawString - two rows, max
					_labelDetail.LayoutArea = new SizeF( fill, size.Height * 3.0F );
				}
			}

			if ( _midAngle > 45 && _midAngle <= 135 )
			{
				//correct by moving radial line toward one or the other end of the range
				fill = chartRect.Y + chartRect.Height - _endPoint.Y - 5;
				//is there enuf room for the label
				if ( size.Height / 2 > fill )
				{
					//no, so got to move explosion radius
					if ( _midAngle > 90 )	//move _label clockwise one-third of way to the end of the arc
						CalculateLinePoints( rect, _midAngle + ( _sweepAngle + _startAngle - _midAngle ) / 3 );
					else						//move _label counter-clockwise one-third of way to the start of the arc
						CalculateLinePoints( rect, _midAngle - ( _midAngle - ( _midAngle - _startAngle ) / 3 ) );
				}
			}

			if ( _midAngle > 135 && _midAngle <= 225 )
			{
				//wrap text 
				fill = _endPoint.X - chartRect.X - 5;
				//need to wrap, so create label rectangle for overloaded DrawString - two rows, max
				if ( size.Width > fill )
				{
					_labelDetail.LayoutArea = new SizeF( fill, size.Height * 3.0F );
				}
			}

			if ( _midAngle > 225 && _midAngle <= 315 )
			{
				//correct by moving radial line toward one or the other end of the range
				fill = _endPoint.Y - 5 - chartRect.Y;
				//is there enuf room for the label
				if ( size.Height / 2 > fill )
				{
					//no, so got to move explosion radius
					if ( _midAngle < 270 )	//move _label counter-clockwise one-third of way to the start of the arc
						CalculateLinePoints( rect, _midAngle - ( _sweepAngle + _startAngle - _midAngle ) / 3 );
					else						//move _label clockwise one-third of way to the end of the arc
						CalculateLinePoints( rect, _midAngle + ( _midAngle - _startAngle ) / 3 );
				}
			}

			//complete the location Detail info
			_labelDetail.Location.AlignV = AlignV.Center;
			_labelDetail.Location.CoordinateFrame = CoordType.PaneFraction;
			_labelDetail.Location.X = ( _endPoint.X - pane.Rect.X ) / pane.Rect.Width;
			_labelDetail.Location.Y = ( _endPoint.Y - pane.Rect.Y ) / pane.Rect.Height;
			_labelDetail.Text = _labelStr;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="rect"></param>
		/// <param name="midAngle"></param>
		private void CalculateLinePoints( RectangleF rect, double midAngle )
		{
			//get the point where the explosion radius intersects the this arc
			PointF rectCenter = new PointF( ( rect.X + rect.Width / 2 ), ( rect.Y + rect.Height / 2 ) );

			_intersectionPoint = new PointF( (float)( rectCenter.X + ( rect.Width / 2 * Math.Cos( ( midAngle ) * Math.PI / 180 ) ) ),
				(float)( rectCenter.Y + ( rect.Height / 2 * Math.Sin( ( midAngle ) * Math.PI / 180 ) ) ) );

			//draw line from intersection point to pivot point - length to be .05 * pieRect.Width pixels long
			_pivotPoint = new PointF( (float)( _intersectionPoint.X + .05 * rect.Width * Math.Cos( ( midAngle ) * Math.PI / 180 ) ),
				(float)( _intersectionPoint.Y + .05 * rect.Width * Math.Sin( ( midAngle ) * Math.PI / 180 ) ) );

			//add horizontal line to move label away from pie...length to be 5% of rect.Width
			//does line go to left or right....label alignment is to the opposite
			if ( _pivotPoint.X >= rectCenter.X )		//goes to right
			{
				_endPoint = new PointF( (float)( _pivotPoint.X + .05 * rect.Width ), _pivotPoint.Y );
				_labelDetail.Location.AlignH = AlignH.Left;
			}
			else
			{
				_endPoint = new PointF( (float)( _pivotPoint.X - .05 * rect.Width ), _pivotPoint.Y );
				_labelDetail.Location.AlignH = AlignH.Right;
			}
			_midAngle = (float)midAngle;
		}

		/// <summary>
		/// Build the string that will be displayed as the slice label as determined by 
		/// <see c_ref="LabelType"/>.
		/// </summary>
		/// <param name="curve">reference to the <see c_ref="PieItem"/></param>
		private static void BuildLabelString( PieItem curve )
		{
			//set up label string formatting
			NumberFormatInfo labelFormat = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();

			labelFormat.NumberDecimalDigits = curve._valueDecimalDigits;
			labelFormat.PercentPositivePattern = 1;					//no space between number and % sign
			labelFormat.PercentDecimalDigits = curve._percentDecimalDigits;

			switch ( curve._labelType )
			{
				case PieLabelType.Value:
					curve._labelStr = curve._pieValue.ToString( "F", labelFormat );
					break;
				case PieLabelType.Percent:
					curve._labelStr = ( curve._sweepAngle / 360 ).ToString( "P", labelFormat );
					break;
				case PieLabelType.Name_Value:
					curve._labelStr = curve._label._text + ": " + curve._pieValue.ToString( "F", labelFormat );
					break;
				case PieLabelType.Name_Percent:
					curve._labelStr = curve._label._text + ": " + ( curve._sweepAngle / 360 ).ToString( "P", labelFormat );
					break;
				case PieLabelType.Name_Value_Percent:
					curve._labelStr = curve._label._text + ": " + curve._pieValue.ToString( "F", labelFormat ) +
						" (" + ( curve._sweepAngle / 360 ).ToString( "P", labelFormat ) + ")";
					break;
				case PieLabelType.Name:
					curve._labelStr = curve._label._text;
					break;
				case PieLabelType.None:
				default:
					break;
			}
		}

		/// <summary>
		/// A method which calculates a new size for the bounding rectangle for the non-displaced 
		/// <see c_ref="PieItem"/>'s in the pie chart.  This method is called after it is found
		/// that at least one slice is displaced.
		/// </summary>
		/// <param name="maxDisplacement">The biggest displacement among the <see c_ref="PieItem"/>s
		/// making up the pie chart.</param>
		/// <param name="baseRect">The current bounding rectangle</param>
		private static void CalcNewBaseRect( double maxDisplacement, ref RectangleF baseRect )
		{
			//displacement expressed in terms of % of pie radius	...do not want exploded slice to 
			//go beyond nonExplRect, but want to maintain the same center point...therefore, got to 
			//reduce the diameter of the nonexploded pie by the alue of the displacement

			float xDispl = (float)( ( maxDisplacement * baseRect.Width ) );
			float yDispl = (float)( ( maxDisplacement * baseRect.Height ) );

			baseRect.Inflate( -(xDispl / 10), -(xDispl / 10) );
		}

		/// <summary>
		/// Draw a legend key entry for this <see c_ref="PieItem"/> at the specified location
		/// </summary>
		/// <param name="g">
		/// A graphic device object to be drawn into.  This is normally e.Graphics from the
		/// PaintEventArgs argument to the Paint() method.
		/// </param>
		/// <param name="pane">
		/// A reference to the <see c_ref="ZedGraph.GraphPane"/> object that is the parent or
		/// owner of this object.
		/// </param>
		/// <param name="rect">The <see c_ref="RectangleF"/> struct that specifies the
		/// location for the legend key</param>
		/// <param name="scaleFactor">
		/// The scaling factor to be used for rendering objects.  This is calculated and
		/// passed down by the parent <see c_ref="ZedGraph.GraphPane"/> object using the
		/// <see c_ref="PaneBase.CalcScaleFactor"/> method, and is used to proportionally adjust
		/// font sizes, etc. according to the actual size of the graph.
		/// </param>
		override public void DrawLegendKey( Graphics g, GraphPane pane, RectangleF rect, float scaleFactor )
		{
			if ( !_isVisible )
				return;

			// Fill the slice
			if ( _fill.IsVisible )
			{
				// just avoid height/width being less than 0.1 so GDI+ doesn't cry
				using ( Brush brush = _fill.MakeBrush( rect ) )
				{
					g.FillRectangle( brush, rect );
					//brush.Dispose();
				}
			}

			// Border the bar
			if ( !_border.Color.IsEmpty )
				_border.Draw( g, pane, scaleFactor, rect );
		}

		/// <summary>
		/// Determine the coords for the rectangle associated with a specified point for 
		/// this <see c_ref="CurveItem" />
		/// </summary>
		/// <param name="pane">The <see c_ref="GraphPane" /> to which this curve belongs</param>
		/// <param name="i">The index of the point of interest</param>
		/// <param name="coords">A list of coordinates that represents the "rect" for
		/// this point (used in an html AREA tag)</param>
		/// <returns>true if it's a valid point, false otherwise</returns>
		override public bool GetCoords( GraphPane pane, int i, out string coords )
		{
			coords = string.Empty;

			PointF pt = _boundingRectangle.Location;
			pt.X += _boundingRectangle.Width / 2.0f;
			pt.Y += _boundingRectangle.Height / 2.0f;

			float radius = _boundingRectangle.Width / 2.0f;
			Matrix matrix = new Matrix();

			// Move the coordinate system to local coordinates
			// of this text object (that is, at the specified
			// x,y location)
			matrix.Translate( pt.X, pt.Y );

			matrix.Rotate( StartAngle );
			//One mark every 5'ish degrees
			int count = (int)Math.Floor ( SweepAngle / 5 ) + 1;
			PointF[] pts = new PointF[2 + count];
			pts[0] = new PointF( 0, 0 );
			pts[1] = new PointF( radius, 0 );
			double angle = 0.0;
			for ( int j = 2; j < count + 2; j++ )
			{
				angle += SweepAngle / count;

				pts[j] = new PointF(radius * (float)Math.Cos(angle * Math.PI / 180.0),
											radius * (float)Math.Sin( angle * Math.PI / 180.0 ) );
			}

			matrix.TransformPoints( pts );

			coords = String.Format("{0:f0},{1:f0},{2:f0},{3:f0},",
						pts[0].X, pts[0].Y, pts[1].X, pts[1].Y );
			for (int j = 2; j < count + 2; j++)
				coords += String.Format(j > count ? "{0:f0},{1:f0}" : "{0:f0},{1:f0},", pts[j].X, pts[j].Y);

			return true;
		}

		#endregion

	}
}
