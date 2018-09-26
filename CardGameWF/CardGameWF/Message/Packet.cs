using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using PacketProperties;

namespace PacketData
{
    [Serializable]
    public class Packet
    {
        private Destination destAddr;
        public Destination DestinationAddress
        {
            get
            {
                return destAddr;
            }
        }
        private ActionType eventName;
        public ActionType ActionType
        {

            get
            {
                return eventName;
            }
        }
        private byte[] data;
        public byte[] Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }
        private int socketIndex;
        public int SocketIndex
        {
            get { return socketIndex; }
            set { socketIndex = value; }
        }

        public Packet(Destination destAdress, ActionType EventName, byte[] Data = null, int socketIndex = 0)
        {
            destAddr = destAdress;
            eventName = EventName;
            data = Data;
            SocketIndex = socketIndex;
        }
        public Packet(byte[] byteArray)
        {
            using (var memStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                memStream.Write(byteArray, 0, byteArray.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                memStream.Position = 0;
                var obj = (Packet)binaryFormatter.Deserialize(memStream);
                this.destAddr = obj.destAddr;
                this.eventName = obj.eventName;
                this.data = obj.data;
            }
        }

        public byte[] GetBytes()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, this);
                return memoryStream.ToArray();
            }
        }
        public override string ToString()
        {
            return "Name: " + this.destAddr.ToString() + " Event: " + this.eventName.ToString() + " Data: " + (data == null ? "No data" : Encoding.UTF8.GetString(data));
        }
    }
}
