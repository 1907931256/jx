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
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace UIGraphLib
{
	/// <summary>
	/// A class than contains information about the position of an object on the graph.
	/// </summary>
	/// 
	/// <author> John Champion </author>
	/// <version> $Revision: 3.14 $ $Date: 2006-06-24 20:26:43 $ </version>
	[Serializable]
	public class Location : ICloneable, ISerializable
	{
	#region Private Fields
		/// <summary> Private field to store the vertical alignment property for
		/// this object.  Use the public property <see c_ref="Location.AlignV"/>
		/// to access this value.  The value of this field is a <see c_ref="AlignV"/> enum.
		/// </summary>
		private AlignV	_alignV;
		/// <summary> Private field to store the horizontal alignment property for
		/// this object.  Use the public property <see c_ref="Location.AlignH"/>
		/// to access this value.  The value of this field is a <see c_ref="AlignH"/> enum.
		/// </summary>
		private AlignH	_alignH;

		/// <summary> Private fields to store the X and Y coordinate positions for
		/// this object.  Use the public properties <see c_ref="X"/> and
		/// <see c_ref="Y"/> to access these values.  The coordinate type stored here is
		/// dependent upon the setting of <see c_ref="CoordinateFrame"/>.
		/// </summary>
		private double	_x,
							_y,
							_width,
							_height;
							
		/// <summary>
		/// Private field to store the coordinate system to be used for defining the
		/// object position.  Use the public property
		/// <see c_ref="CoordinateFrame"/> to access this value. The coordinate system
		/// is defined with the <see c_ref="CoordType"/> enum.
		/// </summary>
		private CoordType	_coordinateFrame;
	#endregion

	#region Properties
		/// <summary>
		/// A horizontal alignment parameter for this object specified
		/// using the <see c_ref="AlignH"/> enum type.
		/// </summary>
		public AlignH AlignH
		{
			get { return _alignH; }
			set { _alignH = value; }
		}
		/// <summary>
		/// A vertical alignment parameter for this object specified
		/// using the <see c_ref="AlignV"/> enum type.
		/// </summary>
		public AlignV AlignV
		{
			get { return _alignV; }
			set { _alignV = value; }
		}
		/// <summary>
		/// The coordinate system to be used for defining the object position
		/// </summary>
		/// <value> The coordinate system is defined with the <see c_ref="CoordType"/>
		/// enum</value>
		public CoordType CoordinateFrame
		{
			get { return _coordinateFrame; }
			set { _coordinateFrame = value; }
		}
		/// <summary>
		/// The x position of the object.
		/// </summary>
		/// <remarks>
		/// The units of this position
		/// are specified by the <see c_ref="CoordinateFrame"/> property.
		/// The object will be aligned to this position based on the
		/// <see c_ref="AlignH"/> property.
		/// </remarks>
		public double X
		{
			get { return _x; }
			set { _x = value; }
		}
		/// <summary>
		/// The y position of the object.
		/// </summary>
		/// <remarks>
		/// The units of this position
		/// are specified by the <see c_ref="CoordinateFrame"/> property.
		/// The object will be aligned to this position based on the
		/// <see c_ref="AlignV"/> property.
		/// </remarks>
		public double Y
		{
			get { return _y; }
			set { _y = value; }
		}
		/// <summary>
		/// The x1 position of the object (an alias for the x position).
		/// </summary>
		/// <remarks>
		/// The units of this position
		/// are specified by the <see c_ref="CoordinateFrame"/> property.
		/// The object will be aligned to this position based on the
		/// <see c_ref="AlignH"/> property.
		/// </remarks>
		public double X1
		{
			get { return _x; }
			set { _x = value; }
		}
		/// <summary>
		/// The y1 position of the object (an alias for the y position).
		/// </summary>
		/// <remarks>
		/// The units of this position
		/// are specified by the <see c_ref="CoordinateFrame"/> property.
		/// The object will be aligned to this position based on the
		/// <see c_ref="AlignV"/> property.
		/// </remarks>
		public double Y1
		{
			get { return _y; }
			set { _y = value; }
		}
		/// <summary>
		/// The width of the object.
		/// </summary>
		/// <remarks>
		/// The units of this position are specified by the
		/// <see c_ref="CoordinateFrame"/> property.
		/// </remarks>
		public double Width
		{
			get { return _width; }
			set { _width = value; }
		}
		/// <summary>
		/// The height of the object.
		/// </summary>
		/// <remarks>
		/// The units of this position are specified by the
		/// <see c_ref="CoordinateFrame"/> property.
		/// </remarks>
		public double Height
		{
			get { return _height; }
			set { _height = value; }
		}
		/// <summary>
		/// The x2 position of the object.
		/// </summary>
		/// <remarks>
		/// The units of this position are specified by the
		/// <see c_ref="CoordinateFrame"/> property.
		/// The object will be aligned to this position based on the
		/// <see c_ref="AlignH"/> property.  This position is only used for
		/// objects such as <see c_ref="ArrowObj"/>, where it makes sense
		/// to have a second coordinate.  Note that the X2 position is stored
		/// internally as a <see c_ref="Width"/> offset from <see c_ref="X"/>.
		/// </remarks>
		public double X2
		{
			get { return _x+_width; }
			//set { width = value-x; }
		}
		/// <summary>
		/// The y2 position of the object.
		/// </summary>
		/// <remarks>
		/// The units of this position
		/// are specified by the <see c_ref="CoordinateFrame"/> property.
		/// The object will be aligned to this position based on the
		/// <see c_ref="AlignV"/> property.  This position is only used for
		/// objects such as <see c_ref="ArrowObj"/>, where it makes sense
		/// to have a second coordinate.  Note that the Y2 position is stored
		/// internally as a <see c_ref="Height"/> offset from <see c_ref="Y"/>.
		/// </remarks>
		public double Y2
		{
			get { return _y+_height; }
			//set { height = value-y; }
		}

		/// <summary>
		/// The <see c_ref="RectangleF"/> for this object as defined by the
		/// <see c_ref="X"/>, <see c_ref="Y"/>, <see c_ref="Width"/>, and
		/// <see c_ref="Height"/> properties.
		/// </summary>
		/// <remarks>
		/// Note that this method reduces the precision of the location coordinates from double
		/// precision to single precision.  In some cases, such as <see c_ref="AxisType.Date" />, it
		/// may affect the resolution of the point location.
		/// </remarks>
		/// <value>A <see c_ref="RectangleF"/> in <see c_ref="CoordinateFrame"/>
		/// units.</value>
		public RectangleF Rect
		{
			get { return new RectangleF( (float)_x, (float)_y, (float)_width, (float)_height ); }
			set
			{
				_x = value.X;
				_y = value.Y;
				_width = value.Width;
				_height = value.Height;
			}
		}

		/// <summary>
		/// The top-left <see c_ref="PointF"/> for this <see c_ref="Location"/>.
		/// </summary>
		/// <remarks>
		/// Note that this method reduces the precision of the location coordinates from double
		/// precision to single precision.  In some cases, such as <see c_ref="AxisType.Date" />, it
		/// may affect the resolution of the point location.
		/// </remarks>
		/// <value>A <see c_ref="PointF"/> in <see c_ref="CoordinateFrame"/> units.</value>
		public PointF TopLeft
		{
			get { return new PointF( (float)_x, (float)_y ); }
			set { _x = value.X; _y = value.Y; }
		}

		/// <summary>
		/// The bottom-right <see c_ref="PointF"/> for this <see c_ref="Location"/>.
		/// </summary>
		/// <remarks>
		/// Note that this method reduces the precision of the location coordinates from double
		/// precision to single precision.  In some cases, such as <see c_ref="AxisType.Date" />, it
		/// may affect the resolution of the point location.
		/// </remarks>
		/// <value>A <see c_ref="PointF"/> in <see c_ref="CoordinateFrame"/> units.</value>
		public PointF BottomRight
		{
			get { return new PointF( (float)this.X2, (float)this.Y2 ); }
			//set { this.X2 = value.X; this.Y2 = value.Y; }
		}
	#endregion
	
	#region Constructors

		/// <summary>
		/// Default constructor for the <see c_ref="Location"/> class.
		/// </summary>
		public Location() : this( 0, 0, CoordType.ChartFraction )
		{
		}

		/// <summary>
		/// Constructor for the <see c_ref="Location"/> class that specifies the
		/// x, y position and the <see c_ref="CoordType"/>.
		/// </summary>
		/// <remarks>
		/// The (x,y) position corresponds to the top-left corner;
		/// </remarks>
		/// <param name="x">The x position, specified in units of <see paramref="coordType"/>.
		/// </param>
		/// <param name="y">The y position, specified in units of <see paramref="coordType"/>.
		/// </param>
		/// <param name="coordType">The <see c_ref="CoordType"/> enum that specifies the
		/// units for <see paramref="x"/> and <see paramref="y"/></param>
		public Location( double x, double y, CoordType coordType ) :
				this( x, y, coordType, AlignH.Left, AlignV.Top )
		{
		}
		
		/// <summary>
		/// Constructor for the <see c_ref="Location"/> class that specifies the
		/// x, y position and the <see c_ref="CoordType"/>.
		/// </summary>
		/// <remarks>
		/// The (x,y) position corresponds to the top-left corner;
		/// </remarks>
		/// <param name="x">The x position, specified in units of <see paramref="coordType"/>.
		/// </param>
		/// <param name="y">The y position, specified in units of <see paramref="coordType"/>.
		/// </param>
		/// <param name="coordType">The <see c_ref="CoordType"/> enum that specifies the
		/// units for <see paramref="x"/> and <see paramref="y"/></param>
		/// <param name="alignH">The <see c_ref="ZedGraph.AlignH"/> enum that specifies
		/// the horizontal alignment of the object with respect to the (x,y) location</param>
		/// <param name="alignV">The <see c_ref="ZedGraph.AlignV"/> enum that specifies
		/// the vertical alignment of the object with respect to the (x,y) location</param>
		public Location( double x, double y, CoordType coordType, AlignH alignH, AlignV alignV )
		{
			_x = x;
			_y = y;
			_width = 0;
			_height = 0;
			_coordinateFrame = coordType;
			_alignH = alignH;
			_alignV = alignV;
		}
		
		/// <summary>
		/// Constructor for the <see c_ref="Location"/> class that specifies the
		/// (x, y), (width, height), and the <see c_ref="CoordType"/>.
		/// </summary>
		/// <remarks>
		/// The (x,y) position
		/// corresponds to the starting position, the (x2, y2) coorresponds to the ending position
		/// (typically used for <see c_ref="ArrowObj"/>'s).
		/// </remarks>
		/// <param name="x">The x position, specified in units of <see paramref="coordType"/>.
		/// </param>
		/// <param name="y">The y position, specified in units of <see paramref="coordType"/>.
		/// </param>
		/// <param name="width">The width, specified in units of <see paramref="coordType"/>.
		/// </param>
		/// <param name="height">The height, specified in units of <see paramref="coordType"/>.
		/// </param>
		/// <param name="coordType">The <see c_ref="CoordType"/> enum that specifies the
		/// units for <see paramref="x"/> and <see paramref="y"/></param>
		/// <param name="alignH">The <see c_ref="ZedGraph.AlignH"/> enum that specifies
		/// the horizontal alignment of the object with respect to the (x,y) location</param>
		/// <param name="alignV">The <see c_ref="ZedGraph.AlignV"/> enum that specifies
		/// the vertical alignment of the object with respect to the (x,y) location</param>
		public Location( double x, double y, double width, double height,
			CoordType coordType, AlignH alignH, AlignV alignV ) :
				this( x, y, coordType, alignH, alignV )
		{
			_width = width;
			_height = height;
		}
		
		/// <summary>
		/// The Copy Constructor
		/// </summary>
		/// <param name="rhs">The <see c_ref="Location"/> object from which to copy</param>
		public Location( Location rhs )
		{
			_x = rhs._x;
			_y = rhs._y;
			_width = rhs._width;
			_height = rhs._height;
			_coordinateFrame = rhs.CoordinateFrame;
			_alignH = rhs.AlignH;
			_alignV = rhs.AlignV;
		}

		/// <summary>
		/// Implement the <see c_ref="ICloneable" /> interface in a typesafe manner by just
		/// calling the typed version of <see c_ref="Clone" />
		/// </summary>
		/// <returns>A deep copy of this object</returns>
		object ICloneable.Clone()
		{
			return this.Clone();
		}

		/// <summary>
		/// Typesafe, deep-copy clone method.
		/// </summary>
		/// <returns>A new, independent copy of this class</returns>
		public Location Clone()
		{
			return new Location( this );
		}

	#endregion

	#region Serialization
		/// <summary>
		/// Current schema value that defines the version of the serialized file
		/// </summary>
		public const int schema = 10;

		/// <summary>
		/// Constructor for deserializing objects
		/// </summary>
		/// <param name="info">A <see c_ref="SerializationInfo"/> instance that defines the serialized data
		/// </param>
		/// <param name="context">A <see c_ref="StreamingContext"/> instance that contains the serialized data
		/// </param>
		protected Location( SerializationInfo info, StreamingContext context )
		{
			// The schema value is just a file version parameter.  You can use it to make future versions
			// backwards compatible as new member variables are added to classes
			int sch = info.GetInt32( "schema" );

			_alignV = (AlignV) info.GetValue( "alignV", typeof(AlignV) );
			_alignH = (AlignH) info.GetValue( "alignH", typeof(AlignH) );
			_x = info.GetDouble( "x" );
			_y = info.GetDouble( "y" );
			_width = info.GetDouble( "width" );
			_height = info.GetDouble( "height" );
			_coordinateFrame = (CoordType) info.GetValue( "coordinateFrame", typeof(CoordType) );
		}
		/// <summary>
		/// Populates a <see c_ref="SerializationInfo"/> instance with the data needed to serialize the target object
		/// </summary>
		/// <param name="info">A <see c_ref="SerializationInfo"/> instance that defines the serialized data</param>
		/// <param name="context">A <see c_ref="StreamingContext"/> instance that contains the serialized data</param>
		[SecurityPermissionAttribute(SecurityAction.Demand,SerializationFormatter=true)]
		public virtual void GetObjectData( SerializationInfo info, StreamingContext context )
		{
			info.AddValue( "schema", schema );
			info.AddValue( "alignV", _alignV );
			info.AddValue( "alignH", _alignH );
			info.AddValue( "x", _x );
			info.AddValue( "y", _y );
			info.AddValue( "width", _width );
			info.AddValue( "height", _height );
			info.AddValue( "coordinateFrame", _coordinateFrame );
		}
	#endregion

	#region Methods
		/// <summary>
		/// Transform this <see c_ref="Location"/> object to display device
		/// coordinates using the properties of the specified <see c_ref="GraphPane"/>.
		/// </summary>
		/// <param name="pane">
		/// A reference to the <see c_ref="PaneBase"/> object that contains
		/// the <see c_ref="Axis"/> classes which will be used for the transform.
		/// </param>
		/// <returns>A point in display device coordinates that corresponds to the
		/// specified user point.</returns>
		public PointF Transform( PaneBase pane )
		{
			return Transform( pane, _x, _y,
						_coordinateFrame );
		}
		
		/// <summary>
		/// Transform a data point from the specified coordinate type
		/// (<see c_ref="CoordType"/>) to display device coordinates (pixels).
		/// </summary>
		/// <remarks>
		/// If <see paramref="pane"/> is not of type <see c_ref="GraphPane"/>, then
		/// only the <see c_ref="CoordType.PaneFraction"/> transformation is available.
		/// </remarks>
		/// <param name="pane">
		/// A reference to the <see c_ref="PaneBase"/> object that contains
		/// the <see c_ref="Axis"/> classes which will be used for the transform.
		/// </param>
		/// <param name="x">The x coordinate that defines the point in user
		/// space.</param>
		/// <param name="y">The y coordinate that defines the point in user
		/// space.</param>
		/// <param name="coord">A <see c_ref="CoordType"/> type that defines the
		/// coordinate system in which the X,Y pair is defined.</param>
		/// <returns>A point in display device coordinates that corresponds to the
		/// specified user point.</returns>
		public static PointF Transform( PaneBase pane, double x, double y, CoordType coord )
		{
			return pane.TransformCoord( x, y, coord );
		}
		
		/// <summary>
		/// Transform this <see c_ref="Location"/> from the coordinate system
		/// as specified by <see c_ref="CoordinateFrame"/> to the device coordinates
		/// of the specified <see c_ref="PaneBase"/> object.
		/// </summary>
		/// <remarks>
		/// The returned
		/// <see c_ref="PointF"/> struct represents the top-left corner of the
		/// object that honors the <see c_ref="Location"/> properties.
		/// The <see c_ref="AlignH"/> and <see c_ref="AlignV"/> properties are honored in 
		/// this transformation.
		/// </remarks>
		/// <param name="pane">
		/// A reference to the <see c_ref="PaneBase"/> object that contains
		/// the <see c_ref="Axis"/> classes which will be used for the transform.
		/// </param>
		/// <param name="width">The width of the object in device pixels</param>
		/// <param name="height">The height of the object in device pixels</param>
		/// <returns>The top-left corner of the object</returns>
		public PointF TransformTopLeft( PaneBase pane, float width, float height )
		{
			PointF pt = Transform( pane );
			
			if ( _alignH == AlignH.Right )
				pt.X -= width;
			else if ( _alignH == AlignH.Center )
				pt.X -= width / 2.0F;
				
			if ( _alignV == AlignV.Bottom )
				pt.Y -= height;
			else if ( _alignV == AlignV.Center )
				pt.Y -= height / 2.0F;
			
			return pt;
		}

		/// <summary>
		/// The <see c_ref="PointF"/> for this object as defined by the
		/// <see c_ref="X"/> and <see c_ref="Y"/>
		/// properties.
		/// </summary>
		/// <remarks>
		/// This method transforms the location to output device pixel units.
		/// The <see c_ref="AlignH"/> and <see c_ref="AlignV"/> properties are ignored for
		/// this transformation (see <see c_ref="TransformTopLeft(PaneBase,float,float)"/>).
		/// </remarks>
		/// <value>A <see c_ref="PointF"/> in pixel units.</value>
		public PointF TransformTopLeft( PaneBase pane )
		{
			return Transform( pane );
		}

		/// <summary>
		/// The <see c_ref="PointF"/> for this object as defined by the
		/// <see c_ref="X2"/> and <see c_ref="Y2"/> properties.
		/// </summary>
		/// <remarks>
		/// This method transforms the location to output device pixel units.
		/// The <see c_ref="AlignH"/> and <see c_ref="AlignV"/> properties are ignored for
		/// this transformation (see <see c_ref="TransformTopLeft(PaneBase,float,float)"/>).
		/// </remarks>
		/// <value>A <see c_ref="PointF"/> in pixel units.</value>
		public PointF TransformBottomRight( PaneBase pane )
		{
			return Transform( pane, this.X2, this.Y2, _coordinateFrame );
		}

		/// <summary>
		/// Transform the <see c_ref="RectangleF"/> for this object as defined by the
		/// <see c_ref="X"/>, <see c_ref="Y"/>, <see c_ref="Width"/>, and
		/// <see c_ref="Height"/> properties.
		/// </summary>
		/// <remarks>
		/// This method transforms the location to output device pixel units.
		/// The <see c_ref="AlignH"/> and <see c_ref="AlignV"/> properties are honored in 
		/// this transformation.
		/// </remarks>
		/// <value>A <see c_ref="RectangleF"/> in pixel units.</value>
		public RectangleF TransformRect( PaneBase pane )
		{
			PointF pix1 = TransformTopLeft( pane );
			PointF pix2 = TransformBottomRight( pane );
			//PointF pix3 = TransformTopLeft( pane, pix2.X - pix1.X, pix2.Y - pix1.Y );

			return new RectangleF( pix1.X, pix1.Y, Math.Abs(pix2.X - pix1.X), Math.Abs(pix2.Y - pix1.Y) );
		}

	#endregion

	}
}
