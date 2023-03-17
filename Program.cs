using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace lab_serialization___RAF
{
    internal class Program : Event
    {
        static void Main(string[] args)
        {
            Event myEvent = new Event();
            myEvent.EventNumber = 1;
            myEvent.Location = "Calgary";

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream filestream = new FileStream("lab6.txt", FileMode.OpenOrCreate))
            {
                formatter.Serialize(filestream, myEvent);
            }

            using (FileStream filestream = new FileStream("lab6.txt", FileMode.Open))
            {
                Event deserialize = (Event)formatter.Deserialize(filestream);
                Console.WriteLine(deserialize.EventNumber);
                Console.WriteLine(deserialize.Location);
            }
            ReadFromFile();
            Console.ReadLine();
        }
        static void ReadFromFile()
        { 
            string word = "Hackathon";
            using (StreamWriter writer = new StreamWriter("lab6.txt"))
            {
                writer.Write(word);
            }

            using (FileStream stream = new FileStream("lab6.txt", FileMode.Open))
            {
     
                Console.WriteLine("Tech Competition");
                Console.WriteLine("In Word: " + word);

                stream.Seek(0, SeekOrigin.Begin);
                char firstChar = (char)stream.ReadByte();
                Console.WriteLine("The First Character is: \"" + firstChar + "\"");

                stream.Seek(0, SeekOrigin.End);
                long fileSize = stream.Position;
                long middle = fileSize / 2;
                stream.Seek(middle, SeekOrigin.Begin);
                char middleChar = (char)stream.ReadByte();
                Console.WriteLine("The Middle Character is: \"" + middleChar + "\"");

                // Read the last character from the file and print it
                stream.Seek(-1, SeekOrigin.End);
                char lastChar = (char)stream.ReadByte();
                Console.WriteLine("The Last Character is: \"" + lastChar + "\"");
                
            }
            Console.ReadLine();
        }
       
    }
    
}
