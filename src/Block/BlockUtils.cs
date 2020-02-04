using System;
using System.Security.Cryptography;
using System.Text;

namespace ASF.Node.Block {
    public static class BlockUtils {
        public static string GenSHA512 (string s) {
            string r = "";
            try {
                byte[] d = Encoding.UTF8.GetBytes (s);
                using (SHA512 a = new SHA512Managed ()) {
                    byte[] h = a.ComputeHash (d);
                    r = BitConverter.ToString (h).Replace ("-", "");
                }
            } catch {

            }
            return r;
        }
        public static string GenSHA256 (string s) {
            string r = "";
            try {
                byte[] d = Encoding.UTF8.GetBytes (s);
                using (SHA256 a = new SHA256Managed ()) {
                    byte[] h = a.ComputeHash (d);
                    r = BitConverter.ToString (h).Replace ("-", "");
                }
            } catch {

            }
            return r;
        }
    }
}