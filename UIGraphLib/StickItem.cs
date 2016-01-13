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
	/// Encapsulates a curve type that is displayed as a series of vertical "sticks",
	/// one at each defined point.
	/// </summary>
	/// <remarks>
	/// The sticks run from the zero value of the Y axis, to the Y point defined in each
	/// <see c_ref="PointPair"/> of the <see c_ref="IPointList" /> (see <see c_ref="CurveItem.Points"/>).
	/// The properties of the sticks are defined in the <see c_ref="Line"/> property.
	/// Normally, the <see c_ref="Symbol"/> is not visible.  However, if you manually enable the
	/// <see c_ref="Symbol"/> using the <see c_ref="ZedGraph.Symbol.IsVisible"/> property, the
	/// symbols will be drawn at the "Z" value from each <see c_ref="PointPair" /> (see
	/// <see c_ref="PointPair.Z" />).
	/// </remarks>
	/// 
	/// <author> John Champion </author>
	/// <version> $Revision: 1.7 $ $Date: 2007-01-25 07:56:09 $ </version>
	[Serializable]
	public class StickItem : LineItem, ICloneable, ISerializable
	{
	#region Fields

	#endregion

	#region Properties

		/// <summary>
		/// Gets a flag indicating if the Z data range should be included in the axis scaling calculations.
		/// </summary>
		/// <param name="pane">The parent <see c_ref="GraphPane" /> of this <see c_ref="CurveItem" />.
		/// </param>
		/// <value>true if the Z data are included, false otherwise</value>
		override internal bool IsZIncluded( GraphPane pane )
		{
			return _symbol.IsVisible;
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
		/// Create a new <see c_ref="StickItem"/>, specifying only the legend <see c_ref="CurveItem.Label" />.
		/// </summary>
		/// <param name="label">The label that will appear in the legend.</param>
		public StickItem( string label ) : base( label )
		{
			_symbol.IsVisible = false;
		}
		
		/// <summary>
		/// Create a new <see c_ref="StickItem"/> using the specified properties.
		/// </summary>
		/// <param name="label">The label that will appear in the legend.</param>
		/// <param name="x">An array of double precision values that define
		/// the independent (X axis) values for this curve</param>
		/// <param name="y">An array of double precision values that define
		/// the dependent (Y axis) values for this curve</param>
		/// <param name="color">A <see c_ref="Color"/> value that will be applied to
		/// the <see c_ref="Line"/> and <see c_ref="Symbol"/> properties.
		/// </param>
		/// <param name="lineWidth">The width (in points) to be used for the <see c_ref="Line"/>.  This
		/// width is scaled based on <see c_ref="PaneBase.CalcScaleFactor"/>.  Use a value of zero to
		/// hide the line (see <see c_ref="ZedGraph.LineBase.IsVisible"/>).</param>
		public StickItem( string label, double[] x, double[] y, Color color, float lineWidth )
			: this( label, new PointPairList( x, y ), color, lineWidth )
		{
		}

		/// <summary>
		/// Create a new <see c_ref="StickItem"/> using the specified properties.
		/// </summary>
		/// <param name="label">The label that will appear in the legend.</param>
		/// <param name="x">An array of double precision values that define
		/// the independent (X axis) values for this curve</param>
		/// <param name="y">An array of double precision values that define
		/// the dependent (Y axis) values for this curve</param>
		/// <param name="color">A <see c_ref="Color"/> value that will be applied to
		/// the <see c_ref="Line"/> and <see c_ref="Symbol"/> properties.
		/// </param>
		public StickItem( string label, double[] x, double[] y, Color color )
			: this( label, new PointPairList( x, y ), color )
		{
		}

		/// <summary>
		/// Create a new <see c_ref="StickItem"/> using the specified properties.
		/// </summary>
		/// <param name="label">The label that will appear in the legend.</param>
		/// <param name="points">A <see c_ref="IPointList"/> of double precision value pairs that define
		/// the X and Y values for this curve</param>
		/// <param name="color">A <see c_ref="Color"/> value that will be applied to
		/// the <see c_ref="Line"/> and <see c_ref="Symbol"/> properties.
		/// </param>
		public StickItem( string label, IPointList points, Color color )
            : this(label, points, color, LineBase.Default.Width)
		{
		}

		/// <summary>
		/// Create a new <see c_ref="StickItem"/> using the specified properties.
		/// </summary>
		/// <param name="label">The label that will appear in the legend.</param>
		/// <param name="points">A <see c_ref="IPointList"/> of double precision value pairs that define
		/// the X and Y values for this curve</param>
		/// <param name="color">A <see c_ref="Color"/> value that will be applied to
		/// the <see c_ref="Line"/> and <see c_ref="Symbol"/> properties.
		/// </param>
		/// <param name="lineWidth">The width (in points) to be used for the <see c_ref="Line"/>.  This
		/// width is scaled based on <see c_ref="PaneBase.CalcScaleFactor"/>.  Use a value of zero to
		/// hide the line (see <see c_ref="ZedGraph.LineBase.IsVisible"/>).</param>
		public StickItem( string label, IPointList points, Color color, float lineWidth )
			: base( label, points, color, Symbol.Default.Type, lineWidth )
		{
			_symbol.IsVisible = false;
		}

		/// <summary>
		/// The Copy Constructor
		/// </summary>
		/// <param name="rhs">The <see c_ref="StickItem"/> object from which to copy</param>
		public StickItem( StickItem rhs ) : base( rhs )
		{
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
		public new StickItem Clone()
		{
			return new StickItem( this );
		}

	#endregion

	#region Serialization
		/// <summary>
		/// Current schema value that defines the version of the serialized file
		/// </summary>
		public const int schema3 = 10;

		/// <summary>
		/// Constructor for deserializing objects
		/// </summary>
		/// <param name="info">A <see c_ref="SerializationInfo"/> instance that defines the serialized data
		/// </param>
		/// <param name="context">A <see c_ref="StreamingContext"/> instance that contains the serialized data
		/// </param>
		protected StickItem( SerializationInfo info, StreamingContext context ) : base( info, context )
		{
			// The schema value is just a file version parameter.  You can use it to make future versions
			// backwards compatible as new member variables are added to classes
			int sch = info.GetInt32( "schema3" );

		}
		/// <summary>
		/// Populates a <see c_ref="SerializationInfo"/> instance with the data needed to serialize the target object
		/// </summary>
		/// <param name="info">A <see c_ref="SerializationInfo"/> instance that defines the serialized data</param>
		/// <param name="context">A <see c_ref="StreamingContext"/> instance that contains the serialized data</param>
		[SecurityPermission(SecurityAction.Demand,SerializationFormatter=true)]
		public override void GetObjectData( SerializationInfo info, StreamingContext context )
		{
			base.GetObjectData( info, context );
			info.AddValue( "schema3", schema3 );
		}
	#endregion

	#region Methods

	#endregion
	}
}
