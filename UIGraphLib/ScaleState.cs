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

#endregion

namespace UIGraphLib
{
	/// <summary>
	/// A class that captures an <see c_ref="Axis"/> scale range.
	/// </summary>
	/// <remarks>This structure is used by the <see c_ref="ZoomState"/> class to store
	/// <see c_ref="Axis"/> scale range settings in a collection for later retrieval.
	/// The class stores the <see c_ref="Scale.Min"/>, <see c_ref="Scale.Max"/>,
	/// <see c_ref="Scale.MinorStep"/>, and <see c_ref="Scale.MajorStep"/> properties, along with
	/// the corresponding auto-scale settings: <see c_ref="Scale.MinAuto"/>,
	/// <see c_ref="Scale.MaxAuto"/>, <see c_ref="Scale.MinorStepAuto"/>,
	/// and <see c_ref="Scale.MajorStepAuto"/>.</remarks>
	/// <author> John Champion </author>
	/// <version> $Revision: 3.2 $ $Date: 2007-02-19 08:05:24 $ </version>
	public class ScaleState : ICloneable
	{
		/// <summary>
		/// The axis range data for <see c_ref="Scale.Min"/>, <see c_ref="Scale.Max"/>,
		/// <see c_ref="Scale.MinorStep"/>, and <see c_ref="Scale.MajorStep"/>
		/// </summary>
		private double _min, _minorStep, _majorStep, _max;
		/// <summary>
		/// The status of <see c_ref="Scale.MinAuto"/>,
		/// <see c_ref="Scale.MaxAuto"/>, <see c_ref="Scale.MinorStepAuto"/>,
		/// and <see c_ref="Scale.MajorStepAuto"/>
		/// </summary>
		private bool _minAuto, _minorStepAuto,
							_majorStepAuto, _maxAuto,
							_formatAuto, _magAuto;

		/// <summary>
		/// The status of <see c_ref="Scale.MajorUnit"/> and <see c_ref="Scale.MinorUnit"/>
		/// </summary>
		private DateUnit _minorUnit, _majorUnit;

		private string _format;
		private int _mag;

		/// <summary>
		/// Construct a <see c_ref="ScaleState"/> from the specified <see c_ref="Axis"/>
		/// </summary>
		/// <param name="axis">The <see c_ref="Axis"/> from which to collect the scale
		/// range settings.</param>
		public ScaleState( Axis axis )
		{
			_min = axis._scale._min;
			_minorStep = axis._scale._minorStep;
			_majorStep = axis._scale._majorStep;
			_max = axis._scale._max;
			_majorUnit = axis._scale._majorUnit;
			_minorUnit = axis._scale._minorUnit;

			_format = axis._scale._format;
			_mag = axis._scale._mag;
			//this.numDec = axis.NumDec;

			_minAuto = axis._scale._minAuto;
			_majorStepAuto = axis._scale._majorStepAuto;
			_minorStepAuto = axis._scale._minorStepAuto;
			_maxAuto = axis._scale._maxAuto;

			_formatAuto = axis._scale._formatAuto;
			_magAuto = axis._scale._magAuto;
		}

		/// <summary>
		/// The Copy Constructor
		/// </summary>
		/// <param name="rhs">The <see c_ref="ScaleState"/> object from which to copy</param>
		public ScaleState( ScaleState rhs )
		{
			_min = rhs._min;
			_majorStep = rhs._majorStep;
			_minorStep = rhs._minorStep;
			_max = rhs._max;
			_majorUnit = rhs._majorUnit;
			_minorUnit = rhs._minorUnit;

			_format = rhs._format;
			_mag = rhs._mag;

			_minAuto = rhs._minAuto;
			_majorStepAuto = rhs._majorStepAuto;
			_minorStepAuto = rhs._minorStepAuto;
			_maxAuto = rhs._maxAuto;

			_formatAuto = rhs._formatAuto;
			_magAuto = rhs._magAuto;
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
		public ScaleState Clone()
		{
			return new ScaleState( this );
		}

		/// <summary>
		/// Copy the properties from this <see c_ref="ScaleState"/> out to the specified <see c_ref="Axis"/>.
		/// </summary>
		/// <param name="axis">The <see c_ref="Axis"/> reference to which the properties should be
		/// copied</param>
		public void ApplyScale( Axis axis )
		{
			axis._scale._min = _min;
			axis._scale._majorStep = _majorStep;
			axis._scale._minorStep = _minorStep;
			axis._scale._max = _max;
			axis._scale._majorUnit = _majorUnit;
			axis._scale._minorUnit = _minorUnit;

			axis._scale._format = _format;
			axis._scale._mag = _mag;

			// The auto settings must be made after the min/step/max settings, since setting those
			// properties actually affects the auto settings.
			axis._scale._minAuto = _minAuto;
			axis._scale._minorStepAuto = _minorStepAuto;
			axis._scale._majorStepAuto = _majorStepAuto;
			axis._scale._maxAuto = _maxAuto;

			axis._scale._formatAuto = _formatAuto;
			axis._scale._magAuto = _magAuto;

		}

		/// <summary>
		/// Determine if the state contained in this <see c_ref="ScaleState"/> object is different from
		/// the state of the specified <see c_ref="Axis"/>.
		/// </summary>
		/// <param name="axis">The <see c_ref="Axis"/> object with which to compare states.</param>
		/// <returns>true if the states are different, false otherwise</returns>
		public bool IsChanged( Axis axis )
		{
			return axis._scale._min != _min ||
					axis._scale._majorStep != _majorStep ||
					axis._scale._minorStep != _minorStep ||
					axis._scale._max != _max ||
					axis._scale._minorUnit != _minorUnit ||
					axis._scale._majorUnit != _majorUnit ||
					axis._scale._minAuto != _minAuto ||
					axis._scale._minorStepAuto != _minorStepAuto ||
					axis._scale._majorStepAuto != _majorStepAuto ||
					axis._scale._maxAuto != _maxAuto;
		}

	}
}