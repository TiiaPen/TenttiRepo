using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Teht2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fStream = null;

            // lista pisteistä
            List<Piste> pisteLista = new List<Piste>();

            // luodaan kaksi Piste-oliota ja lisätään listaan
            Piste a = new Piste("A", 1, 2); 
            Piste b = new Piste("B", 2, 3);
            
            pisteLista.Add(a);
            pisteLista.Add(b);

            // sarjallistetaan lista JSON-muotoon ja tulostetaan konsoliin
            var jsonList = JsonConvert.SerializeObject(pisteLista);
            Console.WriteLine("\nJSON-lista: " + jsonList);

            // TIEDOSTON LUOMINEN
            try
            {
                // avataan stream ja luodaan uusi tiedosto kirjoitettavaksi
                fStream = new FileStream(@"C:/tmp/bindataTentti.bin", FileMode.Create);

                BinaryWriter binWriter = new BinaryWriter(fStream); // luodaan uusi binarywriter

                // luodaan muuttujat, jotka kirjoitetaan
                string nimi1 = a.Nimi;
                double xKoord1 = a.X;
                double yKoord1 = a.Y;
                string nimi2 = b.Nimi;
                double xKoord2 = b.X;
                double yKoord2 = b.Y;

                // kirjoitetaan binarywriterilla data tiedostoon
                binWriter.Write(nimi1);
                binWriter.Write(xKoord1);
                binWriter.Write(yKoord1);
                binWriter.Write(nimi2);
                binWriter.Write(xKoord2);
                binWriter.Write(yKoord2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                if (fStream != null)
                {
                    fStream.Close(); // suljetaan stream
                }
            }
            // TIEDOSTON LUKEMINEN
            fStream = new FileStream("C:/tmp/bindataTentti.bin", FileMode.Open);

            // luodaan binääridatan lukija 
            BinaryReader binReader = new BinaryReader(fStream);

            // aloittaa tiedoston lukemisen alusta
            binReader.BaseStream.Seek(0, SeekOrigin.Begin);

            // lukiessa binääridataa pitää tietää mitä ollaan lukemassa
            // -> jokaiselle tyypille oma metodi!
            string aNimi = binReader.ReadString();
            double aKoordx = binReader.ReadDouble();
            double aKoordy = binReader.ReadDouble();
            string bNimi = binReader.ReadString();
            double bKoordx = binReader.ReadDouble();
            double bKoordy = binReader.ReadDouble();

            // tulostetaan konsoliin 
            Console.WriteLine("\nBINÄÄRITIEDOSTON LUKU: ");
            Console.WriteLine(aNimi + ": " + aKoordx + "," + aKoordy);
            Console.WriteLine(bNimi + ": " + bKoordx + "," + bKoordy);

            // luodaan jokaista tiedostosta luettua pistettä kohti Piste-olio ja lisätään listaan
            Piste x = new Piste(aNimi, aKoordy, aKoordx);
            Piste y = new Piste(bNimi, bKoordy, bKoordx);

            pisteLista.Add(x);
            pisteLista.Add(y);

            // sarjallistetaan lista JSON-muotoon ja tulostetaan konsoliin
            var jsonList2 = JsonConvert.SerializeObject(pisteLista);
            Console.WriteLine("\nToinen JSON-lista: " + jsonList2);
        }
    }
}
