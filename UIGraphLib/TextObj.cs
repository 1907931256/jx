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
using System.Collections;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace UIGraphLib
{
	/// <summary>
	/// A class that represents a text object on the graph.  A list of
	/// <see c_ref="GraphObj"/> objects is maintained by the
	/// <see c_ref="GraphObjList"/> collection class.
	/// </summary>
	/// 
	/// <author> John Champion </author>
	/// <version> $Revision: 3.4 $ $Date: 2007-01-25 07:56:09 $ </version>
	[Serializable]
	public class TextObj : GraphObj, ICloneable, ISerializable
	{
	#region Fields
		/// <summary> Private field to store the actual text string for this
		/// <see c_ref="TextObj"/>.  Use the public property <see c_ref="TextObj.Text"/>
		/// to access this value.
		/// </summary>
		private string _text;
		/// <summary>
		/// Private field to store the <see c_ref="FontSpec"/> class used to render
		/// this <see c_ref="TextObj"/>.  Use the public property <see c_ref="FontSpec"/>
		/// to access this class.
		/// </summary>
		private FontSpec	_fontSpec;

		/*
		/// <summary>
		/// Private field to indicate whether this <see c_ref="TextObj"/> is to be
		/// wrapped when rendered.  Wrapping is to be done within <see c_ref="TextObj.wrappedRect"/>.
		/// Use the public property <see c_ref="TextObj.IsWrapped"/>
		/// to access this value.
		/// </summary>
		private bool isWrapped;
		*/

		/// <summary>
		/// Private field holding the SizeF into which this <see c_ref="TextObj"/>
		/// should be rendered. Use the public property <see c_ref="TextObj.LayoutArea"/>
		/// to access this value.
		/// </summary>
		private SizeF _layoutArea;


		#endregion

	#region Defaults
		/// <summary>
		/// A simple struct that defines the
		/// default property values for the <see c_ref="TextObj"/> class.
		/// </summary>
		new public struct Default
		{
			/*
			/// <summary>
			/// The default wrapped flag for rendering this <see c_ref="TextObj,Text"/>. 
			/// </summary>
			public static bool IsWrapped = false ;
			/// <summary>
			/// The default RectangleF for rendering this <see c_ref="TextObj.Text"/> 
			/// </summary>
			public static SizeF WrappedSize = new SizeF( 0,0 );
			*/

			/// <summary>
			/// The default font family for the <see c_ref="TextObj"/> text
			/// (<see c_ref="ZedGraph.FontSpec.Family"/> property).
			/// </summary>
			public static string FontFamily = "Arial";
			/// <summary>
			/// The default font size for the <see c_ref="TextObj"/> text
			/// (<see c_ref="ZedGraph.FontSpec.Size"/> property).  Units are
			/// in points (1/72 inch).
			/// </summary>
			public static float FontSize = 12.0F;
			/// <summary>
			/// The default font color for the <see c_ref="TextObj"/> text
			/// (<see c_ref="ZedGraph.FontSpec.FontColor"/> property).
			/// </summary>
			public static Color FontColor = Color.Black;
			/// <summary>
			/// The default font bold mode for the <see c_ref="TextObj"/> text
			/// (<see c_ref="ZedGraph.FontSpec.IsBold"/> property). true
			/// for a bold typeface, false otherwise.
			/// </summary>
			public static bool FontBold = false;
			/// <summary>
			/// The default font underline mode for the <see c_ref="TextObj"/> text
			/// (<see c_ref="ZedGraph.FontSpec.IsUnderline"/> property). true
			/// for an underlined typeface, false otherwise.
			/// </summary>
			public static bool FontUnderline = false;
			/// <summary>
			/// The default font italic mode for the <see c_ref="TextObj"/> text
			/// (<see c_ref="ZedGraph.FontSpec.IsItalic"/> property). true
			/// for an italic typeface, false otherwise.
			/// </summary>
			public static bool FontItalic = false;
		}
	#endregion

	#region Properties
		
		/*
		/// <summary>
		/// 
		/// </summary>
		internal bool IsWrapped
		{
			get { return (this.isWrapped); }
			set { this.isWrapped = value; } 
		}
		*/

		/// <summary>
		/// 
		/// </summary>
		public SizeF LayoutArea
		{
			get { return _layoutArea; }
			set { _layoutArea = value; } 
		}


		/// <summary>
		/// The <see c_ref="TextObj"/> to be displayed.  This text can be multi-line by
		/// including newline ('\n') characters between the lines.
		/// </summary>
		public string Text
		{
			get { return _text; }
			set { _text = value; }
		}
		/// <summary>
		/// Gets a reference to the <see c_ref="FontSpec"/> class used to render
		/// this <see c_ref="TextObj"/>
		/// </summary>
		/// <seealso c_ref="Default.FontColor"/>
		/// <seealso c_ref="Default.FontBold"/>
		/// <seealso c_ref="Default.FontItalic"/>
		/// <seealso c_ref="Default.FontUnderline"/>
		/// <seealso c_ref="Default.FontFamily"/>
		/// <seealso c_ref="Default.FontSize"/>
		public FontSpec FontSpec
		{
			get { return _fontSpec; }
			set
			{
				if ( value == null )
					throw new ArgumentNullException( "Uninitialized FontSpec in TextObj" );
				_fontSpec = value;
			}
		}
	#endregion
	
	#region Constructors
		/// <summary>
		/// Constructor that sets all <see c_ref="TextObj"/> properties to default
		/// values as defined in the <see c_ref="Default"/> class.
		/// </summary>
		/// <param name="text">The text to be displayed.</param>
		/// <param name="x">The x position of the text.  The units
		/// of this position are specified by the
		/// <see c_ref="ZedGraph.Location.CoordinateFrame"/> property.  The text will be
		/// aligned to this position based on the <see c_ref="AlignH"/>
		/// property.</param>
		/// <param name="y">The y position of the text.  The units
		/// of this position are specified by the
		/// <see c_ref="ZedGraph.Location.CoordinateFrame"/> property.  The text will be
		/// aligned to this position based on the
		/// <see c_ref="AlignV"/> property.</param>
		public TextObj( string text, double x, double y )
			: base( x, y )
		{
			Init( text );
		}

		private void Init( string text )
		{
			if ( text != null )
				_text = text;
			else
				text = "Text";
			
			_fontSpec = new FontSpec(
				Default.FontFamily, Default.FontSize,
				Default.FontColor, Default.FontBold,
				Default.FontItalic, Default.FontUnderline );
			
			//this.isWrapped = Default.IsWrapped ;
			_layoutArea = new SizeF( 0, 0 );
		}
		
		/// <summary>
		/// Constructor that sets all <see c_ref="TextObj"/> properties to default
		/// values as defined in the <see c_ref="Default"/> class.
		/// </summary>
		/// <param name="text">The text to be displayed.</param>
		/// <param name="x">The x position of the text.  The units
		/// of this position are specified by the
		/// <see c_ref="ZedGraph.Location.CoordinateFrame"/> property.  The text will be
		/// aligned to this position based on the <see c_ref="AlignH"/>
		/// property.</param>
		/// <param name="y">The y position of the text.  The units
		/// of this position are specified by the
		/// <see c_ref="ZedGraph.Location.CoordinateFrame"/> property.  The text will be
		/// aligned to this position based on the
		/// <see c_ref="AlignV"/> property.</param>
		/// <param name="coordType">The <see c_ref="CoordType"/> enum value that
		/// indicates what type of coordinate system the x and y parameters are
		/// referenced to.</param>
		public TextObj( string text, double x, double y, CoordType coordType )
			: base( x, y, coordType )
		{
			Init( text );
		}

		/// <summary>
		/// Constructor that sets all <see c_ref="TextObj"/> properties to default
		/// values as defined in the <see c_ref="Default"/> class.
		/// </summary>
		/// <param name="text">The text to be displayed.</param>
		/// <param name="x">The x position of the text.  The units
		/// of this position are specified by the
		/// <see c_ref="ZedGraph.Location.CoordinateFrame"/> property.  The text will be
		/// aligned to this position based on the <see c_ref="AlignH"/>
		/// property.</param>
		/// <param name="y">The y position of the text.  The units
		/// of this position are specified by the
		/// <see c_ref="ZedGraph.Location.CoordinateFrame"/> property.  The text will be
		/// aligned to this position based on the
		/// <see c_ref="AlignV"/> property.</param>
		/// <param name="coordType">The <see c_ref="CoordType"/> enum value that
		/// indicates what type of coordinate system the x and y parameters are
		/// referenced to.</param>
		/// <param name="alignH">The <see c_ref="ZedGraph.AlignH"/> enum that specifies
		/// the horizontal alignment of the object with respect to the (x,y) location</param>
		/// <param name="alignV">The <see c_ref="ZedGraph.AlignV"/> enum that specifies
		/// the vertical alignment of the object with respect to the (x,y) location</param>
		public TextObj( string text, double x, double y, CoordType coordType, AlignH alignH, AlignV alignV )
			: base( x, y, coordType, alignH, alignV )
		{
			Init( text );
		}

		/// <summary>
		/// Parameterless constructor that initializes a new <see c_ref="TextObj"/>.
		/// </summary>
		public TextObj() : base( 0, 0 )
		{
			Init( "" );
		}
		
		/// <summary>
		/// The Copy Constructor
		/// </summary>
		/// <param name="rhs">The <see c_ref="TextObj"/> object from which to copy</param>
		public TextObj( TextObj rhs ) : base( rhs )
		{
			_text = rhs.Text;
			_fontSpec = new FontSpec( rhs.FontSpec );
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
		public TextObj Clone()
		{
			return new TextObj( this );
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
		protected TextObj( SerializationInfo info, StreamingContext context ) : base( info, context )
		{
			// The schema value is just a file version parameter.  You can use it to make future versions
			// backwards compatible as new member variables are added to classes
			int sch = info.GetInt32( "schema2" );

			_text = info.GetString( "text" );
			_fontSpec = (FontSpec) info.GetValue( "fontSpec", typeof(FontSpec) );
			//isWrapped = info.GetBoolean ("isWrapped") ;
			_layoutArea = (SizeF) info.GetValue( "layoutArea", typeof(SizeF) );
		}
		/// <summary>
		/// Populates a <see c_ref="SerializationInfo"/> instance with the data needed to serialize the target object
		/// </summary>
		/// <param name="info">A <see c_ref="SerializationInfo"/> instance that defines the serialized data</param>
		/// <param name="context">A <see c_ref="StreamingContext"/> instance that contains the serialized data</param>
		[SecurityPermissionAttribute(SecurityAction.Demand,SerializationFormatter=true)]
		public override void GetObjectData( SerializationInfo info, StreamingContext context )
		{
			base.GetObjectData( info, context );
			info.AddValue( "schema2", schema2 );
			info.AddValue( "text", _text );
			info.AddValue( "fontSpec", _fontSpec );
			//info.AddValue( "isWrapped", isWrapped );
			info.AddValue( "layoutArea", _layoutArea );
		}
	#endregion

	#region Rendering Methods
		/// <summary>
		/// Render this <see c_ref="TextObj"/> object to the specified <see c_ref="Graphics"/> device
		/// This method is normally only called by the Draw method
		/// of the parent <see c_ref="GraphObjList"/> collection object.
		/// </summary>
		/// <param name="g">
		/// A graphic device object to be drawn into.  This is normally e.Graphics from the
		/// PaintEventArgs argument to the Paint() method.
		/// </param>
		/// <param name="pane">
		/// A reference to the <see c_ref="PaneBase"/> object that is the parent or
		/// owner of this object.
		/// </param>
		/// <param name="scaleFactor">
		/// The scaling factor to be used for rendering objects.  This is calculated and
		/// passed down by the parent <see c_ref="GraphPane"/> object using the
		/// <see c_ref="PaneBase.CalcScaleFactor"/> method, and is used to proportionally adjust
		/// font sizes, etc. according to the actual size of the graph.
		/// </param>
		override public void Draw( Graphics g, PaneBase pane, float scaleFactor )
		{
			// transform the x,y location from the user-defined
			// coordinate frame to the screen pixel location
			PointF pix = _location.Transform( pane );
			
			// Draw the text on the screen, including any frame and background
			// fill elements
			if ( pix.X > -100000 && pix.X < 100000 && pix.Y > -100000 && pix.Y < 100000 )
			{
				//if ( this.layoutSize.IsEmpty )
				//	this.FontSpec.Draw( g, pane.IsPenWidthScaled, this.text, pix.X, pix.Y,
				//		this.location.AlignH, this.location.AlignV, scaleFactor );
				//else
					this.FontSpec.Draw( g, pane, _text, pix.X, pix.Y,
						_location.AlignH, _location.AlignV, scaleFactor, _layoutArea );

			}
		}
		
		/// <summary>
		/// Determine if the specified screen point lies inside the bounding box of this
		/// <see c_ref="TextObj"/>.  This method takes into account rotation and alignment
		/// parameters of the text, as specified in the <see c_ref="FontSpec"/>.
		/// </summary>
		/// <param name="pt">The screen point, in pixels</param>
		/// <param name="pane">
		/// A reference to the <see c_ref="PaneBase"/> object that is the parent or
		/// owner of this object.
		/// </param>
		/// <param name="g">
		/// A graphic device object to be drawn into.  This is normally e.Graphics from the
		/// PaintEventArgs argument to the Paint() method.
		/// </param>
		/// <param name="scaleFactor">
		/// The scaling factor to be used for rendering objects.  This is calculated and
		/// passed down by the parent <see c_ref="GraphPane"/> object using the
		/// <see c_ref="PaneBase.CalcScaleFactor"/> method, and is used to proportionally adjust
		/// font sizes, etc. according to the actual size of the graph.
		/// </param>
		/// <returns>true if the point lies in the bounding box, false otherwise</returns>
		override public bool PointInBox( PointF pt, PaneBase pane, Graphics g, float scaleFactor )
		{
			if ( ! base.PointInBox(pt, pane, g, scaleFactor ) )
				return false;

			// transform the x,y location from the user-defined
			// coordinate frame to the screen pixel location
			PointF pix = _location.Transform( pane );
			
			return _fontSpec.PointInBox( pt, g, _text, pix.X, pix.Y,
								_location.AlignH, _location.AlignV, scaleFactor, this.LayoutArea );
		}

		/// <summary>
		/// Determines the shape type and Coords values for this GraphObj
		/// </summary>
		override public void GetCoords( PaneBase pane, Graphics g, float scaleFactor,
				out string shape, out string coords )
		{
			// transform the x,y location from the user-defined
			// coordinate frame to the screen pixel location
			PointF pix = _location.Transform( pane );

			PointF[] pts = _fontSpec.GetBox( g, _text, pix.X, pix.Y, _location.AlignH,
				_location.AlignV, scaleFactor, new SizeF() );

			shape = "poly";
			coords = String.Format( "{0:f0},{1:f0},{2:f0},{3:f0},{4:f0},{5:f0},{6:f0},{7:f0},",
						pts[0].X, pts[0].Y, pts[1].X, pts[1].Y,
						pts[2].X, pts[2].Y, pts[3].X, pts[3].Y );
		}

		
	#endregion
	
	}
}
