using System;

namespace BarCodeLib
{
	
	sealed class BlockPair
	{
		public ByteArray DataBytes
		{
			get
			{
				return dataBytes;
			}
			
		}
		public ByteArray ErrorCorrectionBytes
		{
			get
			{
				return errorCorrectionBytes;
			}
			
		}
		
		//UPGRADE_NOTE: Final was removed from the declaration of 'dataBytes '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private ByteArray dataBytes;
		//UPGRADE_NOTE: Final was removed from the declaration of 'errorCorrectionBytes '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		private ByteArray errorCorrectionBytes;
		
		internal BlockPair(ByteArray data, ByteArray errorCorrection)
		{
			dataBytes = data;
			errorCorrectionBytes = errorCorrection;
		}
	}
}