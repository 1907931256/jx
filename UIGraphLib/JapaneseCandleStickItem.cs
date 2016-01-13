//============================================================================
//ZedGraph Class Library - A Flexible Line Graph/Bar Graph Library in C#
//Copyright ?2006  John Champion
//
//This library is free software; you can redistribute it and/or
//modify it under the terms of the GNU Lesser General Public
//License as published by the Free Software Foundation; either
//version 2.1 of the License, or (at your option) any later version.
//
//This library is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
//Lesser General Public License for more details.
//
//You should have received a copy of the GNU Lesser General Public
//License along with this library; if not, write to the Free Software
//Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
//=============================================================================

#region Using directives

using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;

#endregion

namespace UIGraphLib
{
	/// <summary>
	/// Encapsulates a Japanese CandleStick curve type that displays a vertical (or horizontal)
	/// line displaying the range of data values at each sample point, plus a filled bar
	/// signifying the opening and closing value for the sample.
	/// </summary>
	/// <remarks>For this type to work properly, your <see c_ref="IPointList" /> must contain
	/// <see c_ref="StockPt" /> objects, rather than ordinary <see c_ref="PointPair" /> types.
	/// This is because the <see c_ref="OHLCBarItem"/> type actually displays 5 data values
	/// but the <see c_ref="PointPair" /> only stores 3 data values.  The <see c_ref="StockPt" />
	/// stores <see c_ref="StockPt.Date" />, <see c_ref="StockPt.Close" />,
	/// <see c_ref="StockPt.Open" />, <see c_ref="StockPt.High" />, and
	/// <see c_ref="StockPt.Low" /> members.
	/// For a JapaneseCandleStick chart, the range between opening and closing values
	/// is drawn as a filled bar, with the filled color different
	/// (<see c_ref="ZedGraph.JapaneseCandleStick.RisingFill" />) for the case of
	/// <see c_ref="StockPt.Close" />
	/// higher than <see c_ref="StockPt.Open" />, and
	/// <see c_ref="ZedGraph.JapaneseCandleStick.FallingFill" />
	/// for the reverse.  The width of the bar is controlled
	/// by the <see c_ref="ZedGraph.OHLCBar.Size" /> property, which is specified in
	/// points (1/72nd inch), and scaled according to <see c_ref="PaneBase.CalcScaleFactor" />.
	/// The candlesticks are drawn horizontally or vertically depending on the
	/// value of <see c_ref="BarSettings.Base"/>, which is a
	/// <see c_ref="ZedGraph.BarBase"/> enum type.</remarks>
	/// <author> John Champion </author>
	/// <version> $Revision: 3.6 $ $Date: 2007-12-31 00:23:05 $ </version>
	[Serializable]
	public class JapaneseCandleStickItem : CurveItem, ICloneable, ISerializable
	{
	#region Fields

		/// <summary>
		/// Private field that stores a reference to the <see c_ref="ZedGraph.OHLCBar"/>
		/// class defined for this <see c_ref="OHLCBarItem"/>.  Use the public
		/// property <see c_ref="OHLCBar"/> to access this value.
		/// </summary>
		/// 
		private JapaneseCandleStick _stick;

	#endregion

	#region Properties
		/// <summary>
		/// Gets a reference to the <see c_ref="JapaneseCandleStick"/> class defined
		/// for this <see c_ref="JapaneseCandleStickItem"/>.
		/// </summary>
		public JapaneseCandleStick Stick
		{
			get { return _stick; }
		}

		/// <summary>
		/// Gets a flag indicating if the X axis is the independent axis for this <see c_ref="CurveItem" />
		/// </summary>
		/// <param name="pane">The parent <see c_ref="GraphPane" /> of this <see c_ref="CurveItem" />.
		/// </param>
		/// <value>true if the X axis is independent, false otherwise</value>
		override internal bool IsXIndependent( GraphPane pane )
		{
			return pane._barSettings.Base == BarBase.X;
		}

		/// <summary>
		/// Gets a flag indicating if the Z data range should be included in the axis scaling calculations.
		/// </summary>
		/// <remarks>
		/// IsZIncluded is true for <see c_ref="JapaneseCandleStickItem" /> objects, since the Y and Z
		/// values are defined as the High and Low values for the day.</remarks>
		/// <param name="pane">The parent <see c_ref="GraphPane" /> of this <see c_ref="CurveItem" />.
		/// </param>
		/// <value>true if the Z data are included, false otherwise</value>
		override internal bool IsZIncluded( GraphPane pane )
		{
			return true;
		}

	#endregion

	#region Constructors

		/// <summary>
		/// Create a new <see c_ref="OHLCBarItem"/>, specifying only the legend label.
		/// </summary>
		/// <param name="label">The label that will appear in the legend.</param>
		public JapaneseCandleStickItem( string label )
			: base( label )
		{
			_stick = new JapaneseCandleStick();
		}

		/// <summary>
		/// Create a new <see c_ref="JapaneseCandleStickItem"/> using the specified properties.
		/// </summary>
		/// <param name="label">The label that will appear in the legend.</param>
		/// <param name="points">An <see c_ref="IPointList"/> of double precision values that define
		/// the Date, Close, Open, High, and Low values for the curve.  Note that this
		/// <see c_ref="IPointList" /> should contain <see c_ref="StockPt" /> items rather
		/// than <see c_ref="PointPair" /> items.
		/// </param>
		public JapaneseCandleStickItem( string label, IPointList points )
			: base( label, points )
		{
			_stick = new JapaneseCandleStick();
		}

		/// <summary>
		/// The Copy Constructor
		/// </summary>
		/// <param name="rhs">The <see c_ref="JapaneseCandleStickItem"/> object from which to copy</param>
		public JapaneseCandleStickItem( JapaneseCandleStickItem rhs )
			: base( rhs )
		{
			_stick = rhs._stick.Clone();
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
		public JapaneseCandleStickItem Clone()
		{
			return new JapaneseCandleStickItem( this );
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
		protected JapaneseCandleStickItem( SerializationInfo info, StreamingContext context )
			: base( info, context )
		{
			// The schema value is just a file version parameter.  You can use it to make future versions
			// backwards compatible as new member variables are added to classes
			int sch = info.GetInt32( "schema2" );

			_stick = (JapaneseCandleStick) info.GetValue( "stick",
						typeof( JapaneseCandleStick ) );
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
			info.AddValue( "stick", _stick );
		}

		#endregion

	#region Methods

		/// <summary>
		/// Do all rendering associated with this <see c_ref="OHLCBarItem"/> to the specified
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
		/// <param name="pos">The ordinal position of the current <see c_ref="OHLCBarItem"/>
		/// curve.</param>
		/// <param name="scaleFactor">
		/// The scaling factor to be used for rendering objects.  This is calculated and
		/// passed down by the parent <see c_ref="ZedGraph.GraphPane"/> object using the
		/// <see c_ref="PaneBase.CalcScaleFactor"/> method, and is used to proportionally adjust
		/// font sizes, etc. according to the actual size of the graph.
		/// </param>
		override public void Draw( Graphics g, GraphPane pane, int pos, float scaleFactor )
		{
			if ( _isVisible )
			{
				_stick.Draw( g, pane, this, BaseAxis( pane ),
									ValueAxis( pane ), scaleFactor );
			}
		}

		/// <summary>
		/// Draw a legend key entry for this <see c_ref="OHLCBarItem"/> at the specified location
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
		override public void DrawLegendKey( Graphics g, GraphPane pane, RectangleF rect,
									float scaleFactor )
		{
			float pixBase, pixHigh, pixLow, pixOpen, pixClose;

			if ( pane._barSettings.Base == BarBase.X )
			{
				pixBase = rect.Left + rect.Width / 2.0F;
				pixHigh = rect.Top;
				pixLow = rect.Bottom;
				pixOpen = pixHigh + rect.Height / 3;
				pixClose = pixLow - rect.Height / 3;
			}
			else
			{
				pixBase = rect.Top + rect.Height / 2.0F;
				pixHigh = rect.Right;
				pixLow = rect.Left;
				pixOpen = pixHigh - rect.Width / 3;
				pixClose = pixLow + rect.Width / 3;
			}

			Axis baseAxis = BaseAxis( pane );
			//float halfSize = _stick.GetBarWidth( pane, baseAxis, scaleFactor );
			float halfSize = 2 * scaleFactor;

			using ( Pen pen = new Pen( _stick.Color, _stick._width ) )
			{
				_stick.Draw( g, pane, pane._barSettings.Base == BarBase.X, pixBase, pixHigh,
									pixLow, pixOpen, pixClose, halfSize, scaleFactor, pen,
									_stick.RisingFill,
									_stick.RisingBorder, null );
			}
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

			if ( i < 0 || i >= _points.Count )
				return false;

			Axis valueAxis = ValueAxis( pane );
			Axis baseAxis = BaseAxis( pane );

			float halfSize = _stick.Size * pane.CalcScaleFactor();

			PointPair pt = _points[i];
			double date = pt.X;
			double high = pt.Y;
			double low = pt.Z;

			if ( !pt.IsInvalid3D &&
					( date > 0 || !baseAxis._scale.IsLog ) &&
					( ( high > 0 && low > 0 ) || !valueAxis._scale.IsLog ) )
			{
				float pixBase, pixHigh, pixLow;
				pixBase = baseAxis.Scale.Transform( _isOverrideOrdinal, i, date );
				pixHigh = valueAxis.Scale.Transform( _isOverrideOrdinal, i, high );
				pixLow = valueAxis.Scale.Transform( _isOverrideOrdinal, i, low );

				// Calculate the pixel location for the side of the bar (on the base axis)
				float pixSide = pixBase - halfSize;

				// Draw the bar
				if ( baseAxis is XAxis || baseAxis is X2Axis )
					coords = String.Format( "{0:f0},{1:f0},{2:f0},{3:f0}",
								pixSide, pixLow,
								pixSide + halfSize * 2, pixHigh );
				else
					coords = String.Format( "{0:f0},{1:f0},{2:f0},{3:f0}",
								pixLow, pixSide,
								pixHigh, pixSide + halfSize * 2 );

				return true;
			}

			return false;
		}

	#endregion

	}
}
