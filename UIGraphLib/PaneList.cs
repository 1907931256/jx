//============================================================================
//ZedGraph Class Library - A Flexible Line Graph/Bar Graph Library in C#
//Copyright © 2004  John Champion
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
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;

#endregion

namespace UIGraphLib
{
	/// <summary>
	/// A collection class containing a list of <see c_ref="GraphPane"/> objects.
	/// </summary>
	/// 
	/// <author>John Champion</author>
	/// <version> $Revision: 3.6 $ $Date: 2006-06-24 20:26:43 $ </version>
	[Serializable]
	public class PaneList : List<GraphPane>, ICloneable
	{

	#region Constructors

		/// <summary>
		/// Default constructor for the collection class.
		/// </summary>
		public PaneList()
		{
		}

		/// <summary>
		/// The Copy Constructor
		/// </summary>
		/// <param name="rhs">The <see c_ref="PaneList"/> object from which to copy</param>
		public PaneList( PaneList rhs )
		{
			foreach ( GraphPane item in rhs )
			{
				this.Add( item.Clone() );
			}
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
		public PaneList Clone()
		{
			return new PaneList( this );
		}

		
	#endregion

	#region Serialization
		/// <summary>
		/// Current schema value that defines the version of the serialized file
		/// </summary>
		public const int schema = 10;

		/// <summary>
		/// Constructor for deserializing objects
		/// </summary>
		/// <param name="info">A <see c_ref="SerializationInfo"/> instance that defines the serialized data
		/// </param>
		/// <param name="context">A <see c_ref="StreamingContext"/> instance that contains the serialized data
		/// </param>
		protected PaneList( SerializationInfo info, StreamingContext context )
		{
			// The schema value is just a file version parameter.  You can use it to make future versions
			// backwards compatible as new member variables are added to classes
			int sch = info.GetInt32( "schema" );
		}
		/// <summary>
		/// Populates a <see c_ref="SerializationInfo"/> instance with the data needed to serialize the target object
		/// </summary>
		/// <param name="info">A <see c_ref="SerializationInfo"/> instance that defines the serialized data</param>
		/// <param name="context">A <see c_ref="StreamingContext"/> instance that contains the serialized data</param>
		[SecurityPermissionAttribute(SecurityAction.Demand,SerializationFormatter=true)]
		public virtual void GetObjectData( SerializationInfo info, StreamingContext context )
		{
			info.AddValue( "schema", schema );
		}
	#endregion

	#region List Methods
/*		/// <summary>
		/// Indexer to access the specified <see c_ref="GraphPane"/> object by
		/// its ordinal position in the list.
		/// </summary>
		/// <param name="index">The ordinal position (zero-based) of the
		/// <see c_ref="GraphPane"/> object to be accessed.</param>
		/// <value>A <see c_ref="GraphPane"/> object reference.</value>
		public GraphPane this[ int index ]  
		{
			get { return( (GraphPane) List[index] ); }
			set { List[index] = value; }
		}
*/
		/// <summary>
		/// Indexer to access the specified <see c_ref="GraphPane"/> object by
		/// its <see c_ref="PaneBase.Title"/> string.
		/// </summary>
		/// <param name="title">The string title of the
		/// <see c_ref="GraphPane"/> object to be accessed.</param>
		/// <value>A <see c_ref="GraphPane"/> object reference.</value>
		public GraphPane this[ string title ]  
		{
			get
			{
				int index = IndexOf( title );
				if ( index >= 0 )
					return( (GraphPane) this[index]  );
				else
					return null;
			}
		}
/*
		/// <summary>
		/// Add a <see c_ref="GraphPane"/> object to the collection at the end of the list.
		/// </summary>
		/// <param name="pane">A reference to the <see c_ref="GraphPane"/> object to
		/// be added</param>
		/// <seealso c_ref="IList.Add"/>
		public void Add( GraphPane pane )
		{
			List.Add( pane );
		}

		/// <summary>
		/// Remove a <see c_ref="GraphPane"/> object from the collection based on an object reference.
		/// </summary>
		/// <param name="pane">A reference to the <see c_ref="GraphPane"/> object that is to be
		/// removed.</param>
		/// <seealso c_ref="IList.Remove"/>
		public void Remove( GraphPane pane )
		{
			List.Remove( pane );
		}

		/// <summary>
		/// Insert a <see c_ref="GraphPane"/> object into the collection at the specified
		/// zero-based index location.
		/// </summary>
		/// <param name="index">The zero-based index location for insertion.</param>
		/// <param name="pane">A reference to the <see c_ref="GraphPane"/> object that is to be
		/// inserted.</param>
		/// <seealso c_ref="IList.Insert"/>
		public void Insert( int index, GraphPane pane )
		{
			List.Insert( index, pane );
		}
*/
		/// <summary>
		/// Return the zero-based position index of the
		/// <see c_ref="GraphPane"/> with the specified <see c_ref="PaneBase.Title"/>.
		/// </summary>
		/// <remarks>The comparison of titles is not case sensitive, but it must include
		/// all characters including punctuation, spaces, etc.</remarks>
		/// <param name="title">The <see c_ref="String"/> label that is in the
		/// <see c_ref="PaneBase.Title"/> attribute of the item to be found.
		/// </param>
		/// <returns>The zero-based index of the specified <see c_ref="GraphPane"/>,
		/// or -1 if the <see c_ref="PaneBase.Title"/> was not found in the list</returns>
		/// <seealso c_ref="IndexOfTag"/>
		public int IndexOf( string title )
		{
			int index = 0;
			foreach ( GraphPane pane in this )
			{
				if ( String.Compare( pane.Title.Text, title, true ) == 0 )
					return index;
				index++;
			}

			return -1;
		}

		/// <summary>
		/// Return the zero-based position index of the
		/// <see c_ref="GraphPane"/> with the specified <see c_ref="PaneBase.Tag"/>.
		/// </summary>
		/// <remarks>In order for this method to work, the <see c_ref="PaneBase.Tag"/>
		/// property must be of type <see c_ref="String"/>.</remarks>
		/// <param name="tagStr">The <see c_ref="String"/> tag that is in the
		/// <see c_ref="PaneBase.Tag"/> attribute of the item to be found.
		/// </param>
		/// <returns>The zero-based index of the specified <see c_ref="GraphPane"/>,
		/// or -1 if the <see c_ref="PaneBase.Tag"/> string is not in the list</returns>
		public int IndexOfTag( string tagStr )
		{
			int index = 0;
			foreach ( GraphPane pane in this )
			{
				if ( pane.Tag is string &&
						String.Compare( (string) pane.Tag, tagStr, true ) == 0 )
					return index;
				index++;
			}

			return -1;
		}

	#endregion

	}
}
