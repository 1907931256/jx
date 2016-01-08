//============================================================================
//IPointList interface
//Copyright ?2005  John Champion
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
	/// data collection class using the <see c_ref="IPointList" /> interface.
	/// </remarks>
	/// <seealso c_ref="PointPairList" />
	/// <seealso c_ref="BasicArrayPointList" />
	/// 
	/// <author> John Champion</author>
	/// <version> $Revision: 1.6 $ $Date: 2007-11-11 07:29:43 $ </version>
	public interface IPointList : ICloneable
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
		PointPair this[ int index ]  { get; }
		/// <summary>
		/// Gets the number of points available in the list.
		/// </summary>
		int Count { get; }
	}
}
