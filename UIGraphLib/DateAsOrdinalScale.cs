//============================================================================
//ZedGraph Class Library - A Flexible Line Graph/Bar Graph Library in C#
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
using System.Collections;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace UIGraphLib
{
	/// <summary>
	/// The DateAsOrdinalScale class inherits from the <see c_ref="Scale" /> class, and implements
	/// the features specific to <see c_ref="AxisType.DateAsOrdinal" />.
	/// </summary>
	/// <remarks>DateAsOrdinalScale is an ordinal axis that will have labels formatted with dates from the
	/// actual data values of the first <see c_ref="CurveItem" /> in the <see c_ref="CurveList" />.
	/// Although the tics are labeled with real data values, the actual points will be
	/// evenly-spaced in spite of the data values.  For example, if the X values of the first curve
	/// are 1, 5, and 100, then the tic labels will show 1, 5, and 100, but they will be equal
	/// distance from each other.
	/// </remarks>
	/// 
	/// <author> John Champion  </author>
	/// <version> $Revision: 1.13 $ $Date: 2007-11-28 02:38:22 $ </version>
	[Serializable]
	class DateAsOrdinalScale : Scale, ISerializable //, ICloneable
	{

	#region constructors

		/// <summary>
		/// Default constructor that defines the owner <see c_ref="Axis" />
		/// (containing object) for this new object.
		/// </summary>
		/// <param name="owner">The owner, or containing object, of this instance</param>
		public DateAsOrdinalScale( Axis owner )
			: base( owner )
		{
		}

		/// <summary>
		/// The Copy Constructor
		/// </summary>
		/// <param name="rhs">The <see c_ref="DateAsOrdinalScale" /> object from which to copy</param>
		/// <param name="owner">The <see c_ref="Axis" /> object that will own the
		/// new instance of <see c_ref="DateAsOrdinalScale" /></param>
		public DateAsOrdinalScale( Scale rhs, Axis owner )
			: base( rhs, owner )
		{
		}

		/// <summary>
		/// Create a new clone of the current item, with a new owner assignment
		/// </summary>
		/// <param name="owner">The new <see c_ref="Axis" /> instance that will be
		/// the owner of the new Scale</param>
		/// <returns>A new <see c_ref="Scale" /> clone.</returns>
		public override Scale Clone( Axis owner )
		{
			return new DateAsOrdinalScale( this, owner );
		}

	#endregion

	#region properties

		/// <summary>
		/// Return the <see c_ref="AxisType" /> for this <see c_ref="Scale" />, which is
		/// <see c_ref="AxisType.DateAsOrdinal" />.
		/// </summary>
		public override AxisType Type
		{
			get { return AxisType.DateAsOrdinal; }
		}

		/// <summary>
		/// Gets or sets the minimum value for this scale.
		/// </summary>
		/// <remarks>
		/// The set property is specifically adapted for <see c_ref="AxisType.DateAsOrdinal" /> scales,
		/// in that it automatically limits the value to the range of valid dates for the
		/// <see c_ref="XDate" /> struct.
		/// </remarks>
		public override double Min
		{
			get { return _min; }
			set { _min = XDate.MakeValidDate( value ); _minAuto = false; }
		}

		/// <summary>
		/// Gets or sets the maximum value for this scale.
		/// </summary>
		/// <remarks>
		/// The set property is specifically adapted for <see c_ref="AxisType.DateAsOrdinal" /> scales,
		/// in that it automatically limits the value to the range of valid dates for the
		/// <see c_ref="XDate" /> struct.
		/// </remarks>
		public override double Max
		{
			get { return _max; }
			set { _max = XDate.MakeValidDate( value ); _maxAuto = false; }
		}

	#endregion

	#region methods

		/// <summary>
		/// Select a reasonable ordinal axis scale given a range of data values, with the expectation that
		/// dates will be displayed.
		/// </summary>
		/// <remarks>
		/// This method only applies to <see c_ref="AxisType.DateAsOrdinal"/> type axes, and it
		/// is called by the general <see c_ref="PickScale"/> method.  For this type,
		/// the first curve is the "master", which contains the dates to be applied.
		/// <para>On Exit:</para>
		/// <para><see c_ref="Scale.Min"/> is set to scale minimum (if <see c_ref="Scale.MinAuto"/> = true)</para>
		/// <para><see c_ref="Scale.Max"/> is set to scale maximum (if <see c_ref="Scale.MaxAuto"/> = true)</para>
		/// <para><see c_ref="Scale.MajorStep"/> is set to scale step size (if <see c_ref="Scale.MajorStepAuto"/> = true)</para>
		/// <para><see c_ref="Scale.MinorStep"/> is set to scale minor step size (if <see c_ref="Scale.MinorStepAuto"/> = true)</para>
		/// <para><see c_ref="Scale.Mag"/> is set to a magnitude multiplier according to the data</para>
		/// <para><see c_ref="Scale.Format"/> is set to the display format for the values (this controls the
		/// number of decimal places, whether there are thousands separators, currency types, etc.)</para>
		/// </remarks>
		/// <param name="pane">A reference to the <see c_ref="GraphPane"/> object
		/// associated with this <see c_ref="Axis"/></param>
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
		/// <seealso c_ref="PickScale"/>
		/// <seealso c_ref="AxisType.Ordinal"/>
		override public void PickScale( GraphPane pane, Graphics g, float scaleFactor )
		{
			// call the base class first
			base.PickScale( pane, g, scaleFactor );

/*			// First, get the date ranges from the first curve in the list
			double xMin; // = Double.MaxValue;
			double xMax; // = Double.MinValue;
			double yMin; // = Double.MaxValue;
			double yMax; // = Double.MinValue;
			double range = 1;

			foreach ( CurveItem curve in pane.CurveList )
			{
				if ( ( _ownerAxis is Y2Axis && curve.IsY2Axis ) ||
						( _ownerAxis is YAxis && !curve.IsY2Axis ) ||
						( _ownerAxis is X2Axis && curve.IsX2Axis ) ||
						( _ownerAxis is XAxis && !curve.IsX2Axis ) )
				{
					curve.GetRange( out xMin, out xMax, out yMin, out yMax, false, pane.IsBoundedRanges, pane );
					if ( _ownerAxis is XAxis || _ownerAxis is X2Axis )
						range = xMax - xMin;
					else
						range = yMax - yMin;
				}
			}
*/
			// Set the DateFormat by calling CalcDateStepSize
			//			DateScale.CalcDateStepSize( range, Default.TargetXSteps, this );
			SetDateFormat( pane );

			// Now, set the axis range based on a ordinal scale
			base.PickScale( pane, g, scaleFactor );
			OrdinalScale.PickScale( pane, g, scaleFactor, this );
		}

		internal void SetDateFormat( GraphPane pane )
		{
			if ( _formatAuto )
			{
				double range = 10;

				if ( pane.CurveList.Count > 0 && pane.CurveList[0].Points.Count > 1 )
				{
					double val1, val2;

					PointPair pt1 = pane.CurveList[0].Points[0];
					PointPair pt2 = pane.CurveList[0].Points[pane.CurveList[0].Points.Count - 1];
					int p1 = 1;
					int p2 = pane.CurveList[0].Points.Count;
					if ( pane.IsBoundedRanges )
					{
						p1 = (int) Math.Floor( _ownerAxis.Scale.Min );
						p2 = (int) Math.Ceiling( _ownerAxis.Scale.Max );
						p1 = Math.Min( Math.Max( p1, 1 ), pane.CurveList[0].Points.Count );
						p2 = Math.Min( Math.Max( p2, 1 ), pane.CurveList[0].Points.Count );
						if ( p2 > p1 )
						{
							pt1 = pane.CurveList[0].Points[p1-1];
							pt2 = pane.CurveList[0].Points[p2-1];
						}
					}
					if ( _ownerAxis is XAxis || _ownerAxis is X2Axis )
					{
						val1 = pt1.X;
						val2 = pt2.X;
					}
					else
					{
						val1 = pt1.Y;
						val2 = pt2.Y;
					}

					if (	val1 != PointPair.Missing &&
							val2 != PointPair.Missing &&
							!Double.IsNaN( val1 ) &&
							!Double.IsNaN( val2 ) &&
							!Double.IsInfinity( val1 ) &&
							!Double.IsInfinity( val2 ) &&
							Math.Abs( val2 - val1 ) > 1e-10 )
						range = Math.Abs( val2 - val1 );
				}

				if ( range > Default.RangeYearYear )
					_format = Default.FormatYearYear;
				else if ( range > Default.RangeYearMonth )
					_format = Default.FormatYearMonth;
				else if ( range > Default.RangeMonthMonth )
					_format = Default.FormatMonthMonth;
				else if ( range > Default.RangeDayDay )
					_format = Default.FormatDayDay;
				else if ( range > Default.RangeDayHour )
					_format = Default.FormatDayHour;
				else if ( range > Default.RangeHourHour )
					_format = Default.FormatHourHour;
				else if ( range > Default.RangeHourMinute )
					_format = Default.FormatHourMinute;
				else if ( range > Default.RangeMinuteMinute )
					_format = Default.FormatMinuteMinute;
				else if ( range > Default.RangeMinuteSecond )
					_format = Default.FormatMinuteSecond;
				else if ( range > Default.RangeSecondSecond )
					_format = Default.FormatSecondSecond;
				else // MilliSecond
					_format = Default.FormatMillisecond;
			}
		}

		/// <summary>
		/// Make a value label for an <see c_ref="AxisType.DateAsOrdinal" /> <see c_ref="Axis" />.
		/// </summary>
		/// <param name="pane">
		/// A reference to the <see c_ref="GraphPane"/> object that is the parent or
		/// owner of this object.
		/// </param>
		/// <param name="index">
		/// The zero-based, ordinal index of the label to be generated.  For example, a value of 2 would
		/// cause the third value label on the axis to be generated.
		/// </param>
		/// <param name="dVal">
		/// The numeric value associated with the label.  This value is ignored for log
		/// (<see c_ref="Scale.IsLog"/>)
		/// and text (<see c_ref="Scale.IsText"/>) type axes.
		/// </param>
		/// <returns>The resulting value label as a <see c_ref="string" /></returns>
		override internal string MakeLabel( GraphPane pane, int index, double dVal )
		{
			if ( _format == null )
				_format = Scale.Default.Format;

			double val;

			int tmpIndex = (int) dVal - 1;

			if ( pane.CurveList.Count > 0 && pane.CurveList[0].Points.Count > tmpIndex )
			{
				if ( _ownerAxis is XAxis || _ownerAxis is X2Axis )
				val = pane.CurveList[0].Points[tmpIndex].X;
				else
					val = pane.CurveList[0].Points[tmpIndex].Y;
				return XDate.ToString( val, _format );
			}
			else
				return string.Empty;
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
		protected DateAsOrdinalScale( SerializationInfo info, StreamingContext context ) : base( info, context )
		{
			// The schema value is just a file version parameter.  You can use it to make future versions
			// backwards compatible as new member variables are added to classes
			int sch = info.GetInt32( "schema2" );

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
		}
	#endregion

	}
}
