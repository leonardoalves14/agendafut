﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace SocietyAgendor.UI.Service
{
    internal static class CryptoService
    {
        /// <summary>
        /// This security key should be very complex and Random for encrypting the text. This playing vital role in encrypting the text.
        /// </summary>
        private const string _securityKey = "Banana";

        /// <summary>
        /// This method is used to convert the plain text to Encrypted/Un-Readable Text format.
        /// </summary>
        /// <param name="plainText">Plain Text to Encrypt before transferring over the network.</param>
        /// <returns>Cipher Text</returns>
        public static string EncryptPlainTextToCipherText(string plainText)
        {
            //Getting the bytes of Input String.
            byte[] toEncryptedArray = Encoding.UTF8.GetBytes(plainText);

            MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();

            //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.
            byte[] securityKeyArray = objMD5CryptoService.ComputeHash(Encoding.UTF8.GetBytes(_securityKey));

            //De-allocatinng the memory after doing the Job.
            objMD5CryptoService.Clear();

            var objTripleDESCryptoService = new TripleDESCryptoServiceProvider
            {

                //Assigning the Security key to the TripleDES Service Provider.
                Key = securityKeyArray,

                //Mode of the Crypto service is Electronic Code Book.
                Mode = CipherMode.ECB,

                //Padding Mode is PKCS7 if there is any extra byte is added.
                Padding = PaddingMode.PKCS7
            };

            var objCrytpoTransform = objTripleDESCryptoService.CreateEncryptor();

            //Transform the bytes array to resultArray
            byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptedArray, 0, toEncryptedArray.Length);

            //Releasing the Memory Occupied by TripleDES Service Provider for Encryption.
            objTripleDESCryptoService.Clear();

            //Convert and return the encrypted data/byte into string format.
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// This method is used to convert the Cipher/Encypted text to Plain Text.
        /// </summary>
        /// <param name="CipherText">Encrypted Text</param>
        /// <returns>Plain/Decrypted Text</returns>
        public static string DecryptCipherTextToPlainText(string CipherText)
        {
            byte[] toEncryptArray = Convert.FromBase64String(CipherText);

            MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();

            //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.
            byte[] securityKeyArray = objMD5CryptoService.ComputeHash(Encoding.UTF8.GetBytes(_securityKey));

            //De-allocatinng the memory after doing the Job.
            objMD5CryptoService.Clear();

            var objTripleDESCryptoService = new TripleDESCryptoServiceProvider
            {
                //Assigning the Security key to the TripleDES Service Provider.
                Key = securityKeyArray,

                //Mode of the Crypto service is Electronic Code Book.
                Mode = CipherMode.ECB,

                //Padding Mode is PKCS7 if there is any extra byte is added.
                Padding = PaddingMode.PKCS7
            };

            var objCrytpoTransform = objTripleDESCryptoService.CreateDecryptor();

            //Transform the bytes array to resultArray
            byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            //Releasing the Memory Occupied by TripleDES Service Provider for Decryption.
            objTripleDESCryptoService.Clear();

            //Convert and return the decrypted data/byte into string format.
            return Encoding.UTF8.GetString(resultArray);
        }
    }
}
