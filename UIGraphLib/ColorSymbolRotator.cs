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

using System.Drawing;

namespace UIGraphLib
{
	/// <summary>
	/// Class used to get the next color/symbol for GraphPane.AddCurve methods.
	/// </summary>
	/// 
	/// <author> Jerry Vos modified by John Champion </author>
	/// <version> $Revision: 3.4 $ $Date: 2006-06-24 20:26:43 $ </version>
	public class ColorSymbolRotator
	{
	#region Static fields
		/// <summary>
		/// The <see c_ref="Color"/>s <see c_ref="ColorSymbolRotator"/> 
		/// rotates through.
		/// </summary>
		public static readonly Color[] COLORS = {
			Color.Red,
			Color.Blue,
			Color.Green,
			Color.Purple,
			Color.Cyan,
			Color.Pink,
			Color.LightBlue,
			Color.PaleVioletRed,
			Color.SeaGreen,
			Color.Yellow
		};

		/// <summary>
		/// The <see c_ref="SymbolType"/>s <see c_ref="ColorSymbolRotator"/> 
		/// rotates through.
		/// </summary>
		public static readonly SymbolType[] SYMBOLS = {
			SymbolType.Circle,
			SymbolType.Diamond,
			SymbolType.Plus,
			SymbolType.Square,
			SymbolType.Star,
			SymbolType.Triangle,
			SymbolType.TriangleDown,
			SymbolType.XCross,
			SymbolType.HDash,
			SymbolType.VDash
		};		

		private static ColorSymbolRotator _staticInstance;
	#endregion
	
	#region Fields
		/// <summary>
		/// The index of the next color to be used. Note: may be 
		/// > COLORS.Length, it is reset to 0 on the next call if it is.
		/// </summary>
		protected int colorIndex;

		/// <summary>
		/// The index of the next symbol to be used. Note: may be 
		/// > SYMBOLS.Length, it is reset to 0 on the next call if it is.
		/// </summary>
		protected int symbolIndex;
	#endregion

	#region Properties
		/// <summary>
		/// Retrieves the next color in the rotation  Calling this
		/// method has the side effect of incrementing the color index.
		/// <seealso c_ref="NextSymbol"/>
		/// <seealso c_ref="NextColorIndex"/>
		/// </summary>
		public Color NextColor
		{
			get { return COLORS[NextColorIndex]; }
		}

		/// <summary>
		/// Retrieves the index of the next color to be used.  Calling this
		/// method has the side effect of incrementing the color index.
		/// </summary>
		public int NextColorIndex
		{
			get
			{
				if (colorIndex >= COLORS.Length)
					colorIndex = 0;

				return colorIndex++;
			}
			set
			{
				colorIndex = value;
			}
		}

		/// <summary>
		/// Retrieves the next color in the rotation.  Calling this
		/// method has the side effect of incrementing the symbol index.
		/// <seealso c_ref="NextColor"/>
		/// <seealso c_ref="NextSymbolIndex"/>
		/// </summary>
		public SymbolType NextSymbol
		{
			get { return SYMBOLS[NextSymbolIndex]; }
		}

		/// <summary>
		/// Retrieves the index of the next symbol to be used.  Calling this
		/// method has the side effect of incrementing the symbol index.
		/// </summary>
		public int NextSymbolIndex
		{
			get
			{
				if (symbolIndex >= SYMBOLS.Length)
					symbolIndex = 0;

				return symbolIndex++;
			}
			set
			{
				symbolIndex = value;
			}
		}

		/// <summary>
		/// Retrieves the <see c_ref="ColorSymbolRotator"/> instance used by the
		/// static methods.
		/// <seealso c_ref="StaticNextColor"/>
		/// <seealso c_ref="StaticNextSymbol"/>
		/// </summary>
		public static ColorSymbolRotator StaticInstance
		{
			get
			{
				if (_staticInstance == null)
					_staticInstance = new ColorSymbolRotator();

				return _staticInstance;
			}
		}
		
		/// <summary>
		/// Retrieves the next color from this class's static 
		/// <see c_ref="ColorSymbolRotator"/> instance
		/// <seealso c_ref="StaticInstance"/>
		/// <seealso c_ref="StaticNextSymbol"/>
		/// </summary>
		public static Color StaticNextColor
		{
			get { return StaticInstance.NextColor; } 
		}

		/// <summary>
		/// Retrieves the next symbol type from this class's static 
		/// <see c_ref="ColorSymbolRotator"/> instance
		/// <seealso c_ref="StaticInstance"/>
		/// <seealso c_ref="StaticNextColor"/>
		/// </summary>
		public static SymbolType StaticNextSymbol
		{
			get { return StaticInstance.NextSymbol; } 
		}
	#endregion
	}
}
