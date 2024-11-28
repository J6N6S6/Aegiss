using System;
using System.Security.Cryptography;
using System.Text;

namespace Aegiss.Core.Services
{
    public class AesEncryptionService
    {
        //Para usar o AES precisa de duas chaves, uma de 32 bytes e uma de 16 (IV) - Vetor de Inicialização
        private readonly byte[] _key;
        private readonly byte[] _iv;

        //Construtor
        public AesEncryptionService()
        {
            //Need to take the key and the initializer vector to other place
            _key = Encoding.UTF8.GetBytes("12345678901234567890123456789012");
            _iv = Encoding.UTF8.GetBytes("abcdefghijklmnop");

        }

        //Método para criptografar
        public string Encrypt(string textToEncrypt)
        {
            //Preciso instanciar o algoritmo de criptografia
            using (Aes aesAlg = Aes.Create())
            {
                //Preciso passar para o algoritmo AEV a key e o IV definidos
                aesAlg.Key = _key;
                aesAlg.IV = _iv;

                //Transformador do AES (com chave e IV)
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                //Stream de Memória para armazenar os dados
                //Preciso criar um MemoryStream para armazenar o texto criptografado
                using (MemoryStream memoryStreamEncrypt = new MemoryStream())
                {
                    //Stream de Criptografia
                    //Agora preciso criar um CryptoStream que criptografe
                    //e escreva na MemoryStream o resultado criptografado
                    //a CryptoStream precisa receber o texto para criptografar¹
                    using (CryptoStream cryptoStreamEncrypt =
                        new CryptoStream(memoryStreamEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        //Agora preciso de um StreamWriter para escrever o texto 
                        //a ser criptografado na stream de criptografia¹
                        using (StreamWriter streamWriterEncrypt = new StreamWriter(cryptoStreamEncrypt))
                        {
                            streamWriterEncrypt.Write(textToEncrypt);
                        }

                        //Converto o texto criptografado para base 64
                        //para facilitar o trasnsporte e retorno
                        return Convert.ToBase64String(memoryStreamEncrypt.ToArray());
                    }

                }

            }
        }

        //Método para descriptografar
        public string Decrypt(string textToDecrypt)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _key;
                aesAlg.IV = _iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                //Crio a stream de memória e coloco nela o texto criptografado no formato de array de bytes
                using (MemoryStream memoryStreamDecrypt = new MemoryStream(Convert.FromBase64String(textToDecrypt)))
                {
                    //Crio a stream de criptografia para descriptografar no modo leitura
                    using (CryptoStream cryptoStreamDecrypt = new CryptoStream(memoryStreamDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        //Crio um leitor de stream para ler o que está na minha stream já descriptografado
                        using (StreamReader streamReaderDecrypt = new StreamReader(cryptoStreamDecrypt))
                        {
                            //Retorno minha leitura toda
                            return streamReaderDecrypt.ReadToEnd();
                        }
                    }
                }
                
            }

        }
    }
}

