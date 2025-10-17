using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.CompilerServices;

namespace Academy
{

	internal class EncDecClass
	{
		public string connectionStroke_path = string.Empty,
		connectionIV_path = string.Empty,
		connectionKey_path = string.Empty;
		public string connectionStroke {get; set;}

		byte[] connectionKey,
		connectionIV,
		connectionNewIV;

		public EncDecClass(string connectionStroke_path_, string connectionIV_path_, string connectionKey_path_)
		{
			this.connectionStroke_path = connectionStroke_path_;
			this.connectionIV_path = connectionIV_path_;
			this.connectionKey_path = connectionKey_path_;

			//	Start_Write_Connection_Stroke();

			Get_IV();
			connectionNewIV = Generated_New_IV();
			Write_New_IV();
			Get_Key();
			this.connectionStroke = DecryptStringAES(File.ReadAllBytes(connectionStroke_path));
			File.WriteAllBytes(connectionStroke_path, EncryptStringAES(connectionStroke, connectionNewIV, connectionKey));

		}

		public void Get_IV()=>this.connectionIV = File.ReadAllBytes(connectionIV_path);

		public void Get_Key()
		{
			byte[] key = Encoding.UTF8.GetBytes("ThisKeyForDecryptKey1234");
			byte[] iv = Encoding.UTF8.GetBytes("ThisIVForDecrypt");
			if (this.connectionIV.Length == 0)
				Get_IV();

			byte[] dec_key = File.ReadAllBytes(connectionKey_path);

			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.Key = key;
				aesAlg.IV = iv;

				ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
				this.connectionKey = decryptor.TransformFinalBlock(dec_key, 0, dec_key.Length);
			}
		}

		public byte[] Generated_New_IV()
		{
			
			byte[] iv = new byte[16];
			using (var rng = new RNGCryptoServiceProvider())
			{
				rng.GetBytes(iv);
			}
			return iv;
		}

		public void Write_New_IV()=>File.WriteAllBytes(connectionIV_path, connectionNewIV);

		public byte[] EncryptStringAES(string plainText, byte[]iv, byte[] key)
		{
			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.Key = key;
				aesAlg.IV = iv;

				ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
				byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

				return encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
			}
		}

		public string DecryptStringAES(byte[] cipherText)
		{
			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.Key = connectionKey;
				aesAlg.IV = connectionIV;

				ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
				byte[] decryptedBytes = decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);
				return Encoding.UTF8.GetString(decryptedBytes);
			}
		}


		public void Start_Write_Connection_Stroke()
		{

			File.WriteAllBytes(connectionIV_path, Generated_New_IV());
			byte[] keyKey = Encoding.UTF8.GetBytes("ThisKeyForDecryptKey1234");
			byte[] ivIv = Encoding.UTF8.GetBytes("ThisIVForDecrypt");
			File.WriteAllBytes(connectionKey_path, EncryptStringAES("123456789012345678901234", ivIv, keyKey));
			string stroke = "Data Source=192.168.100.104;Initial Catalog=PD_321;Integrated Security=false;Encrypt=true;TrustServerCertificate=true;User ID=user;Password=password;";
			Get_IV();
			Get_Key();
			File.WriteAllBytes(connectionStroke_path, EncryptStringAES(stroke, connectionIV, connectionKey));

		}





	}
}
