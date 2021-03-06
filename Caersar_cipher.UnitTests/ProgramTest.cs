﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Caesar_chipher;

namespace Caersar_cipher.UnitTests
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void KeyModule_KeyIsLower_ReturnKey()
        {
            int key = 22;

            int result = Program.KeyModule(key);

            Assert.AreEqual(key, result);
        }

        [TestMethod]
        public void KeyModule_KeyIsHigher_ReturnKeyModule()
        {
            int key = 28;

            int result = Program.KeyModule(key);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void DoCaesar_PlainTextToMethod_ReturnCipher()
        {
            string text = "ABC";
            int key = 2;

            string cipherText = Program.DoCaesar(key, text);

            Assert.AreEqual("CDE", cipherText);
        }

        [TestMethod]
        public void DoCaesar_KeyEqualsZero_ReturnPlainText()
        {
            string text = "ABC";
            int key = 0;

            string cipherText = Program.DoCaesar(key, text);

            Assert.AreEqual(text, cipherText);
        }

        [TestMethod]
        public void DoCaesar_EncryptAndDecrypt_ReturnSameText()
        {
            string text = "ABC";
            int encryptionKey = 5;
            int decryptionKey = -5;

            string cipherText = Program.DoCaesar(encryptionKey, text);
            string decryptedCipherText = Program.DoCaesar(decryptionKey, cipherText);

            Assert.AreEqual(text, decryptedCipherText);
        }
    }
}
