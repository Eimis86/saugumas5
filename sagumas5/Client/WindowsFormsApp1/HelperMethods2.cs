using System;
using System.Security.Cryptography;
using System.Text;

namespace WindowsFormsApp1
{
    internal class HelperMethods2
    {
        public static byte[] DigitalMessage(string msg)
        {
            try
            {
                using (SHA256 sHA256 = SHA256Managed.Create())
                {
                    byte[] hash = sHA256.ComputeHash(Encoding.UTF8.GetBytes(msg));

                    CspParameters csp = new CspParameters();

                    csp.KeyContainerName = "KeyContainer";

                    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(csp);

                    var format = new RSAPKCS1SignatureFormatter(rsa);

                    format.SetHashAlgorithm("SHA256");

                    return format.CreateSignature(hash);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}