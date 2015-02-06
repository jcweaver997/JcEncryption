/*
 *  Copyright 2015
 * 	Jacob Weaver (jcweaver) 
 *  All Rights Reserved
 * 
 */ 
using System;
namespace Encryption
{
	public class JcEncryption
	{
		
		private long o1, o2, o3;

		/// <summary>
		/// Initializes a new instance of the <see cref="Encryption.JcEncryption"/> class, and sets the keys.
		/// </summary>
		/// <param name="n1">first key.</param>
		/// <param name="n2">sencond key.</param>
		/// <param name="n3">third key.</param>
		public JcEncryption (string n1, string n2, string n3)
		{
			this.o1 = convert (n1);
			this.o2 = convert (n2);
			this.o3 = convert (n3);
		}
		

		/// <summary>
		/// Encrypt the specified string.
		/// </summary>
		/// <param name="toen">The string to encrypt.</param>
		public string encrypt(string toen)
		{
			// creating temporary variables
			long n1 = o1, n2 = o2, n3 = o3;
			int size = toen.Length;

			// convert the string to a byte array
			byte[] b = getBytes(toen);

			// adds the key to the value
			for(int i = 0; i < size; i++){
				b[i] =(byte)((b[i]+(n1%128)));
				n2+=n3;
				n1+=n2;
			}

			return getString(b);
		}

		// decrypts an already encrypted message
		// does the same thing as encrypting, but
		// subtracts instead of adds.
		// in: toen is the encrypted message
		// return: the string in plain text


		/// <summary>
		/// Decrypt the specified string.
		/// </summary>
		/// <param name="toen">The string to decrypt.</param>
		public string decrypt(string toen)
		{
			long n1 = o1, n2 = o2, n3 = o3;
			int size = toen.Length;
			byte[] b = getBytes(toen);
			for(int i = 0; i < size; i++){
				b[i] =(byte)((b[i]-(n1%128))); // subtracts
				n2+=n3;
				n1+=n2;
			}
			return getString(b);
		}

		/// <summary>
		/// Encrypt the specified byte[].
		/// </summary>
		/// <param name="toen">The byte[] to encrypt.</param>
		public byte[] encrypt(byte[] toen)
		{
			long n1 = o1, n2 = o2, n3 = o3;
			int size = toen.Length;

			// adds the key to the value
			for(int i = 0; i < size; i++){
				toen[i] =(byte)((toen[i]+(n1%128)));
				n2+=n3;
				n1+=n2;
			}
			return toen;
		}

		/// <summary>
		/// Decrypt the specified byte[].
		/// </summary>
		/// <param name="toen">The byte[] to decrypt.</param>
		public byte[] decrypt(byte[] toen)
		{
			long n1 = o1, n2 = o2, n3 = o3;
			int size = toen.Length;
			for(int i = 0; i < size; i++){
				toen[i] =(byte)((toen[i]-(n1%128))); // subtracts
				n2+=n3;
				n1+=n2;
			}
			return toen;
		}

		/// <summary>
		/// converts a hex or int value in a string to a long.
		/// </summary>
		/// <returns>a long representing that number.</returns>
		/// <param name="s">string with number.</param>
		private long convert(string s){
			if (s.StartsWith ("0x"))
				return Convert.ToInt64 (s.Substring (2), 16);
			else
				return long.Parse (s);
		}

		/// <summary>
		/// Gets the bytes from the inputed string.
		/// </summary>
		/// <returns>The bytes.</returns>
		/// <param name="r">The string to turn into bytes.</param>
		public byte[] getBytes(string r){
			char[] c = r.ToCharArray ();
			byte[] b = new byte[r.Length];
			for(int i = 0; i < r.Length; i++){
				b[i]= (byte)c[i];
			}
			return b;
		}
		/// <summary>
		/// Gets the string from a byte array.
		/// </summary>
		/// <returns>The string.</returns>
		/// <param name="b">The byte array to turn to a string.</param>
		public string getString(byte[] b){
			int length = b.Length;
			char[] c = new char[length];
			for(int i = 0; i < length; i++){
				c[i]= (char)b[i];
			}
			return new String(c);
		}


	}
}

