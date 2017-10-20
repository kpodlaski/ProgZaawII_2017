using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Zajecia3 {
    class Program {
        static void Main(String[] args) {

           

            String www = readFromUrl("http://onet.pl");
            findLinksInString(www);
            Console.ReadKey();

            
        }

        private static void fileReadWrite() {
            String text = "Ala ma kota a kot ma katar";
            int liczba = 1728123;
            byte[] bliczba = BitConverter.GetBytes(liczba);
            FileStream fs = File.Open("plik.txt", FileMode.Truncate);
            foreach (char c in text.ToCharArray())
                fs.WriteByte((byte)c);
            fs.WriteByte((byte)'\r');
            fs.WriteByte((byte)'\n');
            byte[] btext = System.Text.UTF8Encoding.UTF8.GetBytes(text);
            fs.Write(btext, 0, btext.Length);
            fs.Write(bliczba, 0, bliczba.Length);

            fs.Close();

            StreamWriter sw = new StreamWriter(File.Open("plik.txt", FileMode.Append));
            sw.WriteLine(text);
            sw.WriteLine(liczba);
            sw.Close();

            StreamReader sr = new StreamReader(File.Open("plik.txt", FileMode.Open));
            int ci;
            while ((ci = sr.Read()) >= 0) {
                Console.WriteLine(ci + ":" + (char)ci);
            }
            sr.Close();
            sr = new StreamReader(File.Open("plik.txt", FileMode.Open));
            String line;
            while ((line = sr.ReadLine()) != null) {
                Console.Write(line);
            }
            sr.Close();
        }

        private static void findLinksInString(String text) {
            String pattern = "<a (([\\w,\\._]+)=[\"\']([\\w,\\._:/\\?]+)[\"\']\\s*)+>"; 
            Regex reg = new Regex (pattern,RegexOptions.IgnoreCase);
            Match match = reg.Match(text);
            while (match.Success) {
                Console.WriteLine("Match");
                Console.WriteLine(match.Value);
                match = match.NextMatch();
            }
        }

        public static string readFromUrl(string urlAddress) {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = null;
            if (response.CharacterSet == null) {
               readStream = new StreamReader(receiveStream);
            }
            else {
               readStream = new StreamReader(receiveStream, 
                   Encoding.GetEncoding(response.CharacterSet));
            }
            string data = readStream.ReadToEnd();
            response.Close();
            readStream.Close();
            return data;
        }
    }
}
