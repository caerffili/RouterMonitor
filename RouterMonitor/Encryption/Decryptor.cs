using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace RouterMonitor.Encryption
{
    class Decryptor
    {
        private DecryptTransformer transformer;
        private byte[] initVec;


        public Decryptor(EncryptionAlgorithm algId)
        {
            transformer = new DecryptTransformer(algId);
        }


        public byte[] IV
        {
            set { initVec = value; }
        }


        public byte[] Decrypt(byte[] bytesData, byte[] bytesKey)
        {
            //Set up the memory stream for the decrypted data.
            MemoryStream memStreamDecryptedData = new MemoryStream();

            //Pass in the initialization vector.
            transformer.IV = initVec;
            ICryptoTransform transform = transformer.GetCryptoServiceProvider(bytesKey);
            CryptoStream decStream = new CryptoStream(memStreamDecryptedData,
                                                      transform,
                                                      CryptoStreamMode.Write);
            try
            {
                decStream.Write(bytesData, 0, bytesData.Length);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while writing encrypted data to the stream: \n"
                                    + ex.Message);
            }
            decStream.FlushFinalBlock();
            decStream.Close();
            // Send the data back.
            return memStreamDecryptedData.ToArray();
        } //end Decrypt
    }
}
