//============================================================================
//ZedGraph Class Library - A Flexible Charting Library for .Net
//Copyright ?2005 John Champion and Jerry Vos
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
using System.Collections;

namespace UIGraphLib
{
	/// <summary>
	/// An enum used to specify the X or Y data type of interest -- see
	/// <see c_ref="SampleMultiPointList.XData" /> and <see c_ref="SampleMultiPointList.YData" />.
	/// </summary>
	public enum PerfDataType
	{
		/// <summary>
		/// The time (seconds) at which these data are measured
		/// </summary>
		Time,
		/// <summary>
		/// The distance traveled, meters
		/// </summary>
		Distance,
		/// <summary>
		/// The instantaneous velocity, meters per second
		/// </summary>
		Velocity,
		/// <summary>
		/// The instantaneous acceleration, meters per second squared
		/// </summary>
		Acceleration
	};

	/// <summary>
	/// Sample data structure containing a variety of data values, in this case the values
	/// are related in that they correspond to the same time value.
	/// </summary>
	public class PerformanceData
	{
		/// <summary>
		/// The time (seconds) at which these data are measured
		/// </summary>
		public double	time;
		/// <summary>
		/// The distance traveled, meters
		/// </summary>
		public double	distance;
		/// <summary>
		/// The instantaneous velocity, meters per second
		/// </summary>
		public double	velocity;
		/// <summary>
		/// The instantaneous acceleration, meters per second squared
		/// </summary>
		public double	acceleration;

		/// <summary>
		/// Constructor that specifies each data value in the PerformanceData struct
		/// </summary>
		/// <param name="time">The time (seconds) at which these data are measured</param>
		/// <param name="distance">The distance traveled, meters</param>
		/// <param name="velocity">The instantaneous velocity, meters per second</param>
		/// <param name="acceleration">The instantaneous acceleration, meters per second squared</param>
		public PerformanceData( double time, double distance, double velocity, double acceleration )
		{
			this.time = time;
			this.distance = distance;
			this.velocity = velocity;
			this.acceleration = acceleration;
		}

		/// <summary>
		/// Gets or sets the data value as specified by the <see c_ref="PerfDataType" /> enum
		/// </summary>
		/// <param name="type">The required data value type</param>
		public double this[ PerfDataType type ]
		{
			get
			{
				switch( type )
				{
					default:
					case PerfDataType.Time:
						return time;
					case PerfDataType.Distance:
						return distance;
					case PerfDataType.Velocity:
						return velocity;
					case PerfDataType.Acceleration:
						return acceleration;
				}
			}
			set
			{
				switch( type )
				{
					case PerfDataType.Time:
						time = value;
						break;
					case PerfDataType.Distance:
						distance = value;
						break;
					case PerfDataType.Velocity:
						velocity = value;
						break;
					case PerfDataType.Acceleration:
						acceleration = value;
						break;
				}
			}
		}
	}

	/// <summary>
	/// A sample class that holds an internal collection, and implements the
	/// <see c_ref="IPointList" /> interface so that it can be used by ZedGraph as curve data.
	/// </summary>
	/// <remarks>
	/// This particular class efficiently implements the data storage so that the class
	/// can be cloned without duplicating the data points.  For example, you can create
	/// a <see c_ref="SampleMultiPointList" />, populate it with values, and set
	/// <see c_ref="XData" /> = <see c_ref="PerfDataType.Time" /> and
	/// <see c_ref="YData" /> = <see c_ref="PerfDataType.Distance" />.
	/// You can then clone this <see c_ref="SampleMultiPointList" /> to a new one, and set
	/// <see c_ref="YData" /> = <see c_ref="PerfDataType.Velocity" />.
	/// Each of these <see c_ref="SampleMultiPointList" />'s can then be used as an
	/// <see c_ref="ZedGraph.GraphPane.AddCurve(string,IPointList,Color)" /> argument,
	/// thereby plotting a distance vs time curve and a velocity vs time curve.  There
	/// will still be only one copy of the data in memory.
	/// </remarks>
	[Serializable]
	public class SampleMultiPointList : IPointList
	{
		/// <summary>
		/// This is where the data are stored.  Duplicating the <see c_ref="SampleMultiPointList" />
		/// copies the reference to this <see c_ref="ArrayList" />, but does not actually duplicate
		/// the data.
		/// </summary>
		private ArrayList	DataCollection;

		/// <summary>
		/// Determines what X data will be returned by the indexer of this list.
		/// </summary>
		public PerfDataType XData;
		/// <summary>
		/// Determines what Y data will be returned by the indexer of this list.
		/// </summary>
		public PerfDataType YData;

		/// <summary>
		/// Default constructor
		/// </summary>
		public SampleMultiPointList()
		{
			XData = PerfDataType.Time;
			YData = PerfDataType.Distance;
			DataCollection = new ArrayList();
		}

		/// <summary>
		/// The Copy Constructor.  This method does NOT duplicate the data, it merely makes
		/// another "Window" into the same collection.  You can make multiple copies and
		/// set the <see c_ref="XData" /> and/or <see c_ref="YData" /> properties to different
		/// values to plot different data, while maintaining only one copy of the original values.
		/// </summary>
		/// <param name="rhs">The <see c_ref="SampleMultiPointList" /> from which to copy</param>
		public SampleMultiPointList( SampleMultiPointList rhs )
		{
			DataCollection = rhs.DataCollection;
			XData = rhs.XData;
			YData = rhs.YData;
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
		public SampleMultiPointList Clone()
		{
			return new SampleMultiPointList( this );
		}

		/// <summary>
		/// Indexer to access the data.  This gets the appropriate data and converts to
		/// the <see c_ref="PointPair" /> struct that is compatible with ZedGraph.  The
		/// actual data returned depends on the values of <see c_ref="XData" /> and
		/// <see c_ref="YData" />.
		/// </summary>
		/// <param name="index">The ordinal position of the desired point in the list</param>
		/// <returns>A <see c_ref="PointPair" /> corresponding to the specified ordinal data position</returns>
		public PointPair this[ int index ]
		{
			get
			{
				double xVal, yVal;
				if ( index >= 0 && index < Count )
				{
					// grab the specified PerformanceData struct
					PerformanceData perfData = (PerformanceData) DataCollection[index];
					// extract the values from the struct according to the user-set
					// enum values of XData and YData
					xVal = perfData[XData];
					yVal = perfData[YData];
				}
				else
				{
					xVal = PointPair.Missing;
					yVal = PointPair.Missing;
				}

				// insert the values into a pointpair and return
				return new PointPair( xVal, yVal, PointPair.Missing, null );
			}
		}

		/// <summary>
		/// Gets the number of data points in the collection
		/// </summary>
		public int Count
		{
			get { return DataCollection.Count; }
		}

		/// <summary>
		/// Adds the specified <see c_ref="PerformanceData" /> struct to the end of the collection.
		/// </summary>
		/// <param name="perfData">A <see c_ref="PerformanceData" /> struct to be added</param>
		/// <returns>The ordinal position in the collection where the values were added</returns>
		public int Add( PerformanceData perfData )
		{
			return DataCollection.Add( perfData );
		}

		/// <summary>
		/// Remove the <see c_ref="PerformanceData" /> struct from the list at the specified
		/// ordinal location.
		/// </summary>
		/// <param name="index">The ordinal location of the <see c_ref="PerformanceData" />
		/// struct to be removed</param>
		public void RemoveAt( int index )
		{
			DataCollection.RemoveAt( index );
		}

		/// <summary>
		/// Insert the specified <see c_ref="PerformanceData" /> struct into the list at
		/// the specified ordinal location.
		/// </summary>
		/// <param name="index">The ordinal location at which to insert</param>
		/// <param name="perfData">The <see c_ref="PerformanceData" /> struct to be inserted</param>
		public void Insert( int index, PerformanceData perfData )
		{
			DataCollection.Insert( index, perfData );
		}

	}
}
