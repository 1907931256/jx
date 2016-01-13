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


#region Using directives

using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;

#endregion

namespace UIGraphLib
{
	/// <summary>
	/// Encapsulates an "High-Low" Bar curve type that displays a bar in which both
	/// the bottom and the top of the bar are set by data valuesfrom the
	/// <see c_ref="PointPair"/> struct.
	/// </summary>
	/// <remarks>The <see c_ref="HiLowBarItem"/> type is intended for displaying
	/// bars that cover a band of data, such as a confidence interval, "waterfall"
	/// chart, etc.  The position of each bar is set
	/// according to the <see c_ref="PointPair"/> values.  The independent axis
	/// is assigned with <see c_ref="BarSettings.Base"/>, and is a
	/// <see c_ref="BarBase"/> enum type.  If <see c_ref="BarSettings.Base"/>
	/// is set to <see c_ref="ZedGraph.BarBase.Y"/> or <see c_ref="ZedGraph.BarBase.Y2"/>, then
	/// the bars will actually be horizontal, since the X axis becomes the
	/// value axis and the Y or Y2 axis becomes the independent axis.</remarks>
	/// <author> John Champion </author>
	/// <version> $Revision: 3.18 $ $Date: 2007-11-03 04:41:28 $ </version>
	[Serializable]
	public class HiLowBarItem : BarItem, ICloneable, ISerializable
	{

	#region Constructors
		/// <summary>
		/// Create a new <see c_ref="HiLowBarItem"/> using the specified properties.
		/// </summary>
		/// <param name="label">The label that will appear in the legend.</param>
		/// <param name="x">An array of double precision values that define
		/// the independent (X axis) values for this curve</param>
		/// <param name="y">An array of double precision values that define
		/// the dependent (Y axis) values for this curve</param>
		/// <param name="baseVal">An array of double precision values that define the
		/// base value (the bottom) of the bars for this curve.
		/// </param>
		/// <param name="color">A <see c_ref="Color"/> value that will be applied to
		/// the <see c_ref="ZedGraph.Bar.Fill"/> and <see c_ref="ZedGraph.Bar.Border"/> properties.
		/// </param>
		public HiLowBarItem( string label, double[] x, double[] y, double[] baseVal, Color color ) :
			this( label, new PointPairList( x, y, baseVal ), color )
		{
		}
		
		/// <summary>
		/// Create a new <see c_ref="HiLowBarItem"/> using the specified properties.
		/// </summary>
		/// <param name="label">The label that will appear in the legend.</param>
		/// <param name="points">A <see c_ref="IPointList"/> of double precision value trio's that define
		/// the X, Y, and lower dependent values for this curve</param>
		/// <param name="color">A <see c_ref="Color"/> value that will be applied to
		/// the <see c_ref="ZedGraph.Bar.Fill"/> and <see c_ref="ZedGraph.Bar.Border"/> properties.
		/// </param>
		public HiLowBarItem( string label, IPointList points, Color color )
			: base( label, points, color )
		{
		}

		/// <summary>
		/// The Copy Constructor
		/// </summary>
		/// <param name="rhs">The <see c_ref="HiLowBarItem"/> object from which to copy</param>
		public HiLowBarItem( HiLowBarItem rhs ) : base( rhs )
		{
			_bar = rhs._bar.Clone(); // new HiLowBar( rhs.Bar );
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
		new public HiLowBarItem Clone()
		{
			return new HiLowBarItem( this );
		}

	#endregion

	#region Serialization
		/// <summary>
		/// Current schema value that defines the version of the serialized file
		/// </summary>
		public const int schema3 = 11;

		/// <summary>
		/// Constructor for deserializing objects
		/// </summary>
		/// <param name="info">A <see c_ref="SerializationInfo"/> instance that defines the serialized data
		/// </param>
		/// <param name="context">A <see c_ref="StreamingContext"/> instance that contains the serialized data
		/// </param>
		protected HiLowBarItem( SerializationInfo info, StreamingContext context ) : base( info, context )
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
		}
	#endregion

	}
}
