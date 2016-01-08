//============================================================================
//IPointListEdit interface
//Copyright ?2006  John Champion
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
using System.Text;

namespace UIGraphLib
{
	/// <summary>
	/// An interface to a collection class containing data
	/// that define the set of points to be displayed on the curve.
	/// </summary>
	/// <remarks>
	/// This interface is designed to allow customized data abstraction.  The default data
	/// collection class is <see c_ref="PointPairList" />, however, you can define your own
	/// data collection class using the <see c_ref="IPointList" /> interface.  This
	/// <see c_ref="IPointListEdit" /> interface adds the ability to remove and add points
	/// to the list, and so is used by the <see c_ref="CurveItem" /> class for the
	/// <see c_ref="CurveItem.AddPoint(double,double)" />, <see c_ref="CurveItem.RemovePoint" />, and
	/// <see c_ref="CurveItem.Clear" /> methods.
	/// </remarks>
	/// <seealso c_ref="PointPairList" />
	/// <seealso c_ref="BasicArrayPointList" />
	/// <seealso c_ref="IPointList" />
	/// <seealso c_ref="FilteredPointList" />
	/// 
	/// <author> John Champion</author>
	/// <version> $Revision: 3.6 $ $Date: 2006-10-19 04:40:14 $ </version>
	public interface IPointListEdit : IPointList
	{
		/// <summary>
		/// Indexer to access a data point by its ordinal position in the collection.
		/// </summary>
		/// <remarks>
		/// This is the standard interface that ZedGraph uses to access the data.  Although
		/// you must pass a <see c_ref="PointPair" /> here, your internal data storage format
		/// can be anything.
		/// </remarks>
		/// <param name="index">The ordinal position (zero-based) of the
		/// data point to be accessed.</param>
		/// <value>A <see c_ref="PointPair"/> object instance.</value>
		new PointPair this[int index] { get; set; }

		/// <summary>
		/// Appends a point to the end of the list.  The data are passed in as a <see c_ref="PointPair" />
		/// object.
		/// </summary>
		/// <param name="point">The <see c_ref="PointPair" /> object containing the data to be added.</param>
		void Add( PointPair point );

		/// <summary>
		/// Appends a point to the end of the list.  The data are passed in as two <see c_ref="Double" />
		/// types.
		/// </summary>
		/// <param name="x">The <see c_ref="Double" /> value containing the X data to be added.</param>
		/// <param name="y">The <see c_ref="Double" /> value containing the Y data to be added.</param>
		/// <returns>The ordinal position (zero-based), at which the new point was added.</returns>
		void Add( double x, double y );

		/// <summary>
		/// Removes a single data point from the list at the specified ordinal location
		/// (zero based).
		/// </summary>
		void RemoveAt( int index );

		/// <summary>
		/// Clears all data points from the list.  After calling this method,
		/// <see c_ref="IPointList.Count" /> will be zero.
		/// </summary>
		void Clear();

	}
}
