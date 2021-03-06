//============================================================================
//PointPair4 Class
//Copyright ?2006  Jerry Vos & John Champion
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
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace UIGraphLib
{
	/// <summary>
	/// The basic <see c_ref="PointPair" /> class holds three data values (X, Y, Z).  This
	/// class extends the basic PointPair to contain four data values (X, Y, Z, T).
	/// </summary>
	/// 
	/// <author> John Champion </author>
	/// <version> $Revision: 3.3 $ $Date: 2007-03-17 18:43:44 $ </version>
	[Serializable]
	public class PointPair4 : PointPair, ISerializable
	{

	#region Member variables

		/// <summary>
		/// This PointPair4's T coordinate.
		/// </summary>
		public double T;

	#endregion

	#region Constructors

		/// <summary>
		/// Default Constructor
		/// </summary>
		public PointPair4()
		{
			T = 0;
		}

		/// <summary>
		/// Creates a point pair with the specified X, Y, Z, and T value.
		/// </summary>
		/// <param name="x">This pair's x coordinate.</param>
		/// <param name="y">This pair's y coordinate.</param>
		/// <param name="z">This pair's z coordinate.</param>
		/// <param name="t">This pair's t coordinate.</param>
		public PointPair4( double x, double y, double z, double t ) : base( x, y, z )
		{
			T = t;
		}

		/// <summary>
		/// Creates a point pair with the specified X, Y, base value, and
		/// label (<see c_ref="PointPair.Tag"/>).
		/// </summary>
		/// <param name="x">This pair's x coordinate.</param>
		/// <param name="y">This pair's y coordinate.</param>
		/// <param name="z">This pair's z coordinate.</param>
		/// <param name="t">This pair's t coordinate.</param>
		/// <param name="label">This pair's string label (<see c_ref="PointPair.Tag"/>)</param>
		public PointPair4( double x, double y, double z, double t, string label ) :
					base( x, y, z, label )
		{
			T = t;
		}

		/// <summary>
		/// The PointPair4 copy constructor.
		/// </summary>
		/// <param name="rhs">The basis for the copy.</param>
		public PointPair4( PointPair4 rhs ) : base( rhs )
		{
			T = rhs.T;
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
		protected PointPair4( SerializationInfo info, StreamingContext context ) : base( info, context )
		{
			// The schema value is just a file version parameter.  You can use it to make future versions
			// backwards compatible as new member variables are added to classes
			int sch = info.GetInt32( "schema3" );

			T = info.GetDouble( "T" );
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
			info.AddValue( "schema2", schema3 );
			info.AddValue( "T", T );
		}

	#endregion

	#region Properties

		/// <summary>
		/// Readonly value that determines if either the X, Y, Z, or T
		/// coordinate in this PointPair4 is an invalid (not plotable) value.
		/// It is considered invalid if it is missing (equal to System.Double.Max),
		/// Infinity, or NaN.
		/// </summary>
		/// <returns>true if any value is invalid</returns>
		public bool IsInvalid4D
		{
			get
			{
				return X == Missing ||
						Y == Missing ||
						Z == Missing ||
						T == Missing ||
						Double.IsInfinity( X ) ||
						Double.IsInfinity( Y ) ||
						Double.IsInfinity( Z ) ||
						Double.IsInfinity( T ) ||
						Double.IsNaN( X ) ||
						Double.IsNaN( Y ) ||
						Double.IsNaN( Z ) ||
						Double.IsNaN( T );
			}
		}

	#endregion

	#region Methods

		/// <summary>
		/// Format this PointPair4 value using the default format.  Example:  "( 12.345, -16.876 )".
		/// The two double values are formatted with the "g" format type.
		/// </summary>
		/// <param name="isShowZT">true to show the third "Z" and fourth "T" value coordinates</param>
		/// <returns>A string representation of the PointPair4</returns>
		public new string ToString( bool isShowZT )
		{
			return ToString( DefaultFormat, isShowZT );
		}

		/// <summary>
		/// Format this PointPair value using a general format string.
		/// Example:  a format string of "e2" would give "( 1.23e+001, -1.69e+001 )".
		/// If <see paramref="isShowZ"/>
		/// is true, then the third "Z" coordinate is also shown.
		/// </summary>
		/// <param name="format">A format string that will be used to format each of
		/// the two double type values (see <see c_ref="System.Double.ToString()"/>).</param>
		/// <returns>A string representation of the PointPair</returns>
		/// <param name="isShowZT">true to show the third "Z" or low dependent value coordinate</param>
		public new string ToString( string format, bool isShowZT )
		{
			return "( " + X.ToString( format ) +
					", " + Y.ToString( format ) +
					( isShowZT ? ( ", " + Z.ToString( format ) +
							", " + T.ToString( format ) ): "" ) + " )";
		}

		/// <summary>
		/// Format this PointPair value using different general format strings for the X, Y, and Z values.
		/// Example:  a format string of "e2" would give "( 1.23e+001, -1.69e+001 )".
		/// </summary>
		/// <param name="formatX">A format string that will be used to format the X
		/// double type value (see <see c_ref="System.Double.ToString()"/>).</param>
		/// <param name="formatY">A format string that will be used to format the Y
		/// double type value (see <see c_ref="System.Double.ToString()"/>).</param>
		/// <param name="formatZ">A format string that will be used to format the Z
		/// double type value (see <see c_ref="System.Double.ToString()"/>).</param>
		/// <param name="formatT">A format string that will be used to format the T
		/// double type value (see <see c_ref="System.Double.ToString()"/>).</param>
		/// <returns>A string representation of the PointPair</returns>
		public string ToString( string formatX, string formatY, string formatZ, string formatT )
		{
			return "( " + X.ToString( formatX ) +
					", " + Y.ToString( formatY ) +
					", " + Z.ToString( formatZ ) +
					", " + T.ToString( formatT ) +
					" )";
		}

	#endregion
	}
}
