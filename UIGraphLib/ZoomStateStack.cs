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
using System.Collections.Generic;

#endregion

namespace UIGraphLib
{
	/// <summary>
	/// A LIFO stack of prior <see c_ref="ZoomState"/> objects, used to allow zooming out to prior
	/// states (of scale range settings).
	/// </summary>
	/// <author> John Champion </author>
	/// <version> $Revision: 3.1 $ $Date: 2006-06-24 20:26:44 $ </version>
	public class ZoomStateStack : List<ZoomState>, ICloneable
	{
		/// <summary>
		/// Default Constructor
		/// </summary>
		public ZoomStateStack()
		{
		}

		/// <summary>
		/// The Copy Constructor
		/// </summary>
		/// <param name="rhs">The <see c_ref="ZoomStateStack"/> object from which to copy</param>
		public ZoomStateStack( ZoomStateStack rhs )
		{
			foreach ( ZoomState state in rhs )
			{
				Add( new ZoomState( state ) );
			}
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
		public ZoomStateStack Clone()
		{
			return new ZoomStateStack( this );
		}


		/// <summary>
		/// Public readonly property that indicates if the stack is empty
		/// </summary>
		/// <value>true for an empty stack, false otherwise</value>
		public bool IsEmpty
		{
			get { return Count == 0; }
		}

		/// <summary>
		/// Add the scale range information from the specified <see c_ref="GraphPane"/> object as a
		/// new <see c_ref="ZoomState"/> entry on the stack.
		/// </summary>
		/// <param name="pane">The <see c_ref="GraphPane"/> object from which the scale range
		/// information should be copied.</param>
		/// <param name="type">A <see c_ref="ZoomState.StateType"/> enumeration that indicates whether this
		/// state is the result of a zoom or pan operation.</param>
		/// <returns>The resultant <see c_ref="ZoomState"/> object that was pushed on the stack.</returns>
		public ZoomState Push( GraphPane pane, ZoomState.StateType type )
		{
			ZoomState state = new ZoomState( pane, type );
			Add( state );
			return state;
		}

		/// <summary>
		/// Add the scale range information from the specified <see c_ref="ZoomState"/> object as a
		/// new <see c_ref="ZoomState"/> entry on the stack.
		/// </summary>
		/// <param name="state">The <see c_ref="ZoomState"/> object to be placed on the stack.</param>
		/// <returns>The <see c_ref="ZoomState"/> object (same as the <see paramref="state"/>
		/// parameter).</returns>
		public ZoomState Push( ZoomState state )
		{
			Add( state );
			return state;
		}

		/// <summary>
		/// Pop a <see c_ref="ZoomState"/> entry from the top of the stack, and apply the properties
		/// to the specified <see c_ref="GraphPane"/> object.
		/// </summary>
		/// <param name="pane">The <see c_ref="GraphPane"/> object to which the scale range
		/// information should be copied.</param>
		/// <returns>The <see c_ref="ZoomState"/> object that was "popped" from the stack and applied
		/// to the specified <see c_ref="GraphPane"/>.  null if no <see c_ref="ZoomState"/> was
		/// available (the stack was empty).</returns>
		public ZoomState Pop( GraphPane pane )
		{
		    if ( !IsEmpty )
			{
				ZoomState state = this[ Count - 1 ];
				RemoveAt( Count - 1 );

				state.ApplyState( pane );
				return state;
			}
		    return null;
		}

	    /// <summary>
		/// Pop the <see c_ref="ZoomState"/> entry from the bottom of the stack, and apply the properties
		/// to the specified <see c_ref="GraphPane"/> object.  Clear the stack completely.
		/// </summary>
		/// <param name="pane">The <see c_ref="GraphPane"/> object to which the scale range
		/// information should be copied.</param>
		/// <returns>The <see c_ref="ZoomState"/> object at the bottom of the stack that was applied
		/// to the specified <see c_ref="GraphPane"/>.  null if no <see c_ref="ZoomState"/> was
		/// available (the stack was empty).</returns>
		public ZoomState PopAll( GraphPane pane )
	    {
	        if ( !IsEmpty )
			{
				ZoomState state = this[ 0 ];
				Clear();

				state.ApplyState( pane );

				return state;
			}
	        return null;
	    }

	    /// <summary>
		/// Gets a reference to the <see c_ref="ZoomState"/> object at the top of the stack,
		/// without actually removing it from the stack.
		/// </summary>
		/// <value>A <see c_ref="ZoomState"/> object reference, or null if the stack is empty.</value>
		public ZoomState Top
		{
			get
			{
			    if ( !IsEmpty )
					return this[ Count - 1 ];
			    return null;
			}
		}
	}
}
