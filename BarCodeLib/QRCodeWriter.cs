
using System;

namespace BarCodeLib
{

	public sealed class QRCodeWriter : Writer
	{
		
		private const int QUIET_ZONE_SIZE = 4;
		
		public ByteMatrix encode(System.String contents, BarcodeFormat format,  int width,  int height)
		{
			
			return encode(contents, format,  width,  height, null);
		}
		
		public ByteMatrix encode(System.String contents, BarcodeFormat format,  int width,  int height, System.Collections.Hashtable hints)
		{
			
			if (contents == null || contents.Length == 0)
			{
				throw new System.ArgumentException("Found empty contents");
			}
			
			if (format != BarcodeFormat.QR_CODE)
			{
				throw new System.ArgumentException("Can only encode QR_CODE, but got " + format);
			}
			
			if (width < 0 || height < 0)
			{
				throw new System.ArgumentException("Requested dimensions are too small: " + width + 'x' + height);
			}
			
			ErrorCorrectionLevel errorCorrectionLevel = ErrorCorrectionLevel.L;
			if (hints != null)
			{
				ErrorCorrectionLevel requestedECLevel = (ErrorCorrectionLevel) hints[EncodeHintType.ERROR_CORRECTION];
				if (requestedECLevel != null)
				{
					errorCorrectionLevel = requestedECLevel;
				}
			}
			
			QRCode code = new QRCode();
			Encoder.encode(contents, errorCorrectionLevel, hints, code);
			return renderResult(code,  width,  height);
		}
		
		// Note that the input matrix uses 0 == white, 1 == black, while the output matrix uses
		// 0 == black, 255 == white (i.e. an 8 bit greyscale bitmap).
		private static ByteMatrix renderResult(QRCode code,  int width,  int height)
		{
			ByteMatrix input = code.Matrix;
			int inputWidth = input.Width;
			int inputHeight = input.Height;
			int qrWidth = inputWidth + (QUIET_ZONE_SIZE << 1);
			int qrHeight = inputHeight + (QUIET_ZONE_SIZE << 1);
			int outputWidth = System.Math.Max(width, qrWidth);
			int outputHeight = System.Math.Max(height, qrHeight);
           
			int multiple = System.Math.Min(outputWidth / qrWidth, outputHeight / qrHeight);

            int leftPadding =0;// (outputWidth - (inputWidth * multiple)) / 2;
            int topPadding = 0;// (outputHeight - (inputHeight * multiple)) / 2;
			
			ByteMatrix output = new ByteMatrix(outputWidth, outputHeight);
			sbyte[][] outputArray = output.Array;
			
			// We could be tricky and use the first row in each set of multiple as the temporary storage,
			// instead of allocating this separate array.
			sbyte[] row = new sbyte[outputWidth];
			
			// 1. Write the white lines at the top
			for (int y = 0; y < topPadding; y++)
			{
				setRowColor(outputArray[y], (sbyte) SupportClass.Identity(255));
			}
			
			// 2. Expand the QR image to the multiple
			sbyte[][] inputArray = input.Array;
			for (int y = 0; y < inputHeight; y++)
			{
				// a. Write the white pixels at the left of each row
				for (int x = 0; x < leftPadding; x++)
				{
					row[x] = (sbyte) SupportClass.Identity(255);
				}
				
				// b. Write the contents of this row of the barcode
				int offset = leftPadding;
				for (int x = 0; x < inputWidth; x++)
				{
                    sbyte value_Renamed = (sbyte)((inputArray[y][x] == 1) ? 0 : SupportClass.Identity(255));
					for (int z = 0; z < multiple; z++)
					{
						row[offset + z] = value_Renamed;
					}
					offset += multiple;
				}
				
				// c. Write the white pixels at the right of each row
				offset = leftPadding + (inputWidth * multiple);
				for (int x = offset; x < outputWidth; x++)
				{
					row[x] = (sbyte) SupportClass.Identity(255);
				}
				
				// d. Write the completed row multiple times
				offset = topPadding + (y * multiple);
				for (int z = 0; z < multiple; z++)
				{
					Array.Copy(row, 0, outputArray[offset + z], 0, outputWidth);
				}
			}
			
			// 3. Write the white lines at the bottom
			int offset2 = topPadding + (inputHeight * multiple);
			for (int y = offset2; y < outputHeight; y++)
			{
				setRowColor(outputArray[y], (sbyte) SupportClass.Identity(255));
			}
			
			return output;
		}
		
		private static void  setRowColor(sbyte[] row, sbyte value_Renamed)
		{
			for (int x = 0; x < row.Length; x++)
			{
				row[x] = value_Renamed;
			}
		}
	}
}