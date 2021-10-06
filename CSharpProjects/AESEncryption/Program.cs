using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace AES_Encryption
{
  class Program
  {
    public static void Main()
    {
      // for randomizing the byte array elements
      Random random = new Random();
      byte[] randByte = new byte[16];

      // byte version of the password, will store hash version later for safe use if needed
      //byte[] pw = Encoding.UTF8.GetBytes("testPassword"); // what kind of encoding, guessing utf-8, which is the default for .NET
      //byte[] prodPassword = Encoding.UTF8.GetBytes("actualPassword");

      string password = "somehash"; // same as the hashed password
      //string prodPassword = "anotherhash";
      byte[] hashedPassword = Convert.FromBase64String(password); // need to do this to use in encryption process (only takes byte arrays)

      // creating hash for the password, no salt
      //HashAlgorithm hash = SHA256.Create();
      //// convert password to SHA-256 hash, 32 bytes, store this later
      //byte[] prodP = hash.ComputeHash(prodPassword);

      string aa = "link";
      string oid = aa;
      string mrn = "121212";

      /////// full parameter list
      string urlParameters = $"something={aa}&something2={mrn}&something3=CR12345&something4={oid}&something5=John&something6=Smith&something7=20001010&something8=BOTH";

      // encrypting process
      string input = "y";
      while (input == "y")
      {
        Console.WriteLine("ENCRYPTION PROCESS");

        // using the random byte array for the IV
        random.NextBytes(randByte);

        // Encrypt the string to an array of bytes. Where all the magic occurs.
        byte[] encrypted = EncryptStringToBytes_Aes(urlParameters, hashedPassword, randByte);

        // combine byte arrays into single array
        byte[] combinedIVEncryptedText = randByte.Concat(encrypted).ToArray();

        ///////// manual way to convert to base64 safe url without installing the package
        // var fix = Convert.ToBase64String(encrypted);
        // fix = fix.Split('=')[0]; // Remove any trailing '='s
        // fix = fix.Replace('+', '-');
        // fix = fix.Replace('/', '_');

        Console.WriteLine();

        ///////// Encrypted data in different formats

        Console.ForegroundColor = ConsoleColor.Green;
        //Console.WriteLine("Hash for password (key) in UTF-8:\n{0}\n\n", byteToDefEncode(hashedPassword)); // this doesn't really help
        Console.WriteLine("Hash for password (key) in Base64, store later:\n{0}\n\n", byteToBase64(hashedPassword)); // store this later for the password
        //Console.WriteLine("Hash for prod password (key) in Base64, store later:\n{0}\n\n", byteToBase64(prodP)); // store this later for the password for prod

        ///////// Encoding lets me choose what standard I want to encode to (UTF-8, Unicode, ASCII, etc.)
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Default Base64 Encode for URL parameters:\n{0}\n\n", byteToBase64(encrypted));
        Console.WriteLine("Default Base64 Encode for combined IV and URL params:\n{0}\n\n", byteToBase64(combinedIVEncryptedText));
        //Console.WriteLine("UTF8 encoding of encrypted array:\n{0}\n\n", byteToDefEncode(encrypted));

        ///////// IV values
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("IV values---------------------------------");
        Console.WriteLine("Default Base64 Encode for IV:\n{0}\nIV Length: {1}\n", byteToBase64(randByte), byteToBase64(randByte).Length);
        Console.WriteLine("Byte array to string for IV:\n{0}\n\n", byteToHex(randByte));
        Console.WriteLine();


        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Currently encrypting...\n");
        //string query = Convert.ToBase64String(encrypted) + Convert.ToBase64String(myAes.IV);
        string target = $"http://something.com?{byteToBase64(combinedIVEncryptedText)}";

        Console.WriteLine(target);

        // Decrypting -----------------------------------------------------------------------------
        Console.WriteLine("\nCurrently decrypting...\n");

        string decryptedParameters = DecryptStringFromBytes_Aes(encrypted, hashedPassword, randByte);
        string decryptedURL = $"http://something.com?{byteToHex(randByte)}{decryptedParameters}";

        //Console.WriteLine($"{decryptedURL}");
        // see if I can "replicate" what should be happening on their end
        //Console.WriteLine($"\n{DecryptURL(target, hashedPassword)}");
        Console.WriteLine("\nPress y to continue");
        input = Console.ReadLine();
      }
    }

    /// <summary>
    /// Converts byte array to Base64, no cleaning
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    static string byteToBase64(byte[] input) => Convert.ToBase64String(input);

    /// <summary>
    /// Encodes byte array using UTF-8
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    static string byteToDefEncode(byte[] input) => Encoding.UTF8.GetString(input);

    /// <summary>
    /// Converts byte array to hex values
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    static string byteToHex(byte[] input) => BitConverter.ToString(input);

    /// <summary>
    /// Encryption process
    /// </summary>
    /// <param name="plainText"></param>
    /// <param name="Key"></param>
    /// <param name="IV"></param>
    /// <returns></returns>
    static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
    {
      // Check arguments. Kind of optional, depends on what you want to validate
      if (plainText == null || plainText.Length <= 0)
        throw new ArgumentNullException("plainText");
      if (Key == null || Key.Length <= 0)
        throw new ArgumentNullException("Key");
      if (IV == null || IV.Length <= 0)
        throw new ArgumentNullException("IV");

      byte[] encrypted;

      // Create an AesManaged object
      // with the specified key and IV.
      using (AesManaged aesAlg = new AesManaged())
      {
        // CBC is the default mode, 256 is the default size
        aesAlg.Key = Key;
        aesAlg.IV = IV;

        // Create an encryptor to perform the stream transform.
        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        // Create the streams used for encryption.
        using (MemoryStream msEncrypt = new MemoryStream())
        {
          // takes care of encrypting
          using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
          {
            // writing on the crypostream
            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
            {
              //Write all data to the stream.
              swEncrypt.Write(plainText);
            }
            encrypted = msEncrypt.ToArray();
          }
        }
      }

      // Return the encrypted bytes from the memory stream, this is a byte array!
      return encrypted;
    }

    /// <summary>
    /// Local decryptor
    /// </summary>
    /// <param name="cipherText"></param>
    /// <param name="Key"></param>
    /// <param name="IV"></param>
    /// <returns></returns>
    static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
    {
      // Check arguments.
      if (cipherText == null || cipherText.Length <= 0)
        throw new ArgumentNullException("cipherText");
      if (Key == null || Key.Length <= 0)
        throw new ArgumentNullException("Key");
      if (IV == null || IV.Length <= 0)
        throw new ArgumentNullException("IV");

      // Declare the string used to hold
      // the decrypted text.
      string plaintext = null;

      // Create an AesManaged object
      // with the specified key and IV.
      using (AesManaged aesAlg = new AesManaged())
      {
        aesAlg.Key = Key;
        aesAlg.IV = IV;

        // Create a decryptor to perform the stream transform.
        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

        // Create the streams used for decryption.
        using (MemoryStream msDecrypt = new MemoryStream(cipherText))
        {
          using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
          {
            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
            {
              // Read the decrypted bytes from the decrypting stream
              // and place them in a string.
              plaintext = srDecrypt.ReadToEnd();
            }
          }
        }
      }

      return plaintext;
    }

    /// <summary>
    /// Decrypting the URL (basically splitting the IV and URL and then returning both values)
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    static string DecryptURL(string url, byte[] hashedKey)
    {
      // filter the URL so we can grab just the IV and the encrypted text
      string[] splitUrl = url.Split('?');
      string IVKey = splitUrl[1];
      // this might be the issue with the URL
      byte[] IV = Convert.FromBase64String(IVKey.Substring(0, 22));
      string encryptedData = IVKey.Substring(22);
      //return IV + "\n\n" + key;

      string plaintext = null;

      // Create an AesManaged object
      // with the specified key and IV.
      using (AesManaged aesAlg = new AesManaged())
      {
        aesAlg.Key = hashedKey;
        aesAlg.IV = IV;

        // Create a decryptor to perform the stream transform.
        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

        // Create the streams used for decryption.
        using (MemoryStream msDecrypt = new MemoryStream())
        {
          using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
          {
            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
            {

              // Read the decrypted bytes from the decrypting stream
              // and place them in a string.
              plaintext = srDecrypt.ReadToEnd();
            }
          }
        }
      }

      return plaintext;
    }
  }
}
