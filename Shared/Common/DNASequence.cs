using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedResources.Common
{
	internal class DNASequence
	{
		#region Methods

		public static string ConvertBinaryToDNA(string binary)
		{
			// Ensure that the input string is 8 characters long
			if (binary.Length != 8)
			{
				throw new ArgumentException("Input string must have a length of 8.");
			}
			// Create a dictionary to map 2-bit values to DNA characters
			var key = new Dictionary<string, char>
				{
					{"00", 'A'},
					{"01", 'T'},
					{"10", 'C'},
					{"11", 'G'}
				};
			// Split the binary string into two-bit substrings
			var substrings = Enumerable.Range(0, binary.Length / 2)
										.Select(i => binary.Substring(i * 2, 2));
			// Convert each two-bit substring to its corresponding DNA character
			var dnaChars = substrings.Select(s => key[s]);
			// Join the DNA characters into a single string and return it
			return string.Join("", dnaChars);
		}

		public static string ConvertStringToGeneticSequence(string input)
		{
			// Convert the input string to a byte array
			byte[] bytes = Encoding.ASCII.GetBytes(input);

			// Convert each byte to an 8-bit binary string and concatenate them
			string sequence = string.Join("", bytes.Select(b => ConvertBinaryToDNA(Convert.ToString(b, 2).PadLeft(8, '0'))));

			return sequence;
		}


		#endregion

	}
}
