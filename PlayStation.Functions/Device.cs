using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;

namespace PlayStation.Functions
{
    public class Device
    {
        private static string _portName;
        private static SerialPort _sPort;
        private readonly string[] _ports = SerialPort.GetPortNames();
        //public byte[] DeviceInfo = new byte[9];
        //byte DeviceSlotA, DeviceSlotB, DeviceSlotC, DeviceSlotD, DeviceSlotE, DeviceSlotF;
        //CommandLine _command;

        public struct CommandLine
        {
            //<STX><ModulID><BaytF><BaytE><BaytD><BaytC><BaytB><BaytA><ETX>
            public byte Stx;
            public byte ModulId;
            public byte BaytF;
            public byte BaytE;
            public byte BaytD;
            public byte BaytC;
            public byte BaytB;
            public byte BaytA;
            public byte Etx;
        }

        public string[] PortList()
        {
            return _ports;
        }

        public void SetPort(bool deviceStatus)
        {
            if (!deviceStatus) return;

            if (_sPort == null)
            {
                _portName = _ports.FirstOrDefault(item => !string.IsNullOrEmpty(item));
                _sPort = new SerialPort
                {
                    BaudRate = 115200,
                    DataBits = 8,
                    StopBits = StopBits.One,
                    Parity = Parity.None,
                    PortName = _portName,
                    NewLine = "\n",
                    Handshake = Handshake.None                    
                };
            }

            if (!_sPort.IsOpen)
                _sPort.Open();
        }

        public void OpenPort()
        {
            try
            {
                if (!_sPort.IsOpen)
                    _sPort.Open();
            }
            catch (Exception ex)
            { 
                //MessageBox.Show("Port Açılamadı Hata Mesajı :\n " + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ClosePort()
        {
            try
            {
                if (_sPort.IsOpen)
                    _sPort.Close();
            }catch{//MessageBox.Show("Port Kapatılamadı Hata Mesajı :\n " + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AllMachineClose()
        {
            //DeviceInfo[0] = _command.STX;
            //DeviceInfo[1] = _command.ModulID;
            //DeviceInfo[2] = 0;
            //DeviceInfo[3] = 0;
            //DeviceInfo[4] = 0;
            //DeviceInfo[5] = 0;
            //DeviceInfo[6] = 0;
            //DeviceInfo[7] = 0;
            //DeviceInfo[8] = _command.ETX;
            //_sPort.Write(DeviceInfo, 0, DeviceInfo.Length);
            //System.Threading.Thread.Sleep(50);
        }

        public void PortControl(List<Model.Machine> machineList)
        {
            //_command.STX = 0x2;

            //DeviceSlotA = 255;
            //DeviceSlotB = 255;
            //DeviceSlotC = 255;
            //DeviceSlotD = 255;
            //DeviceSlotE = 255;
            //DeviceSlotF = 255;
            
            var openMachines = machineList.Where(
                item =>
                    item.MACHINESTATUS != Convert.ToInt32(Model.Base.MachineType.Kapali) &&
                    item.MACHINESTATUS != Convert.ToInt32(Model.Base.MachineType.Durduruldu)).Select(
                        machine =>
                        {
                            var onCommand = string.Format("{0}", machine.BYTENR);
                            return onCommand;
                        }).ToArray();

            var closedMachines = machineList.Where(
                item =>
                    item.MACHINESTATUS == Convert.ToInt32(Model.Base.MachineType.Kapali) ||
                    item.MACHINESTATUS == Convert.ToInt32(Model.Base.MachineType.Durduruldu)).Select(
                        machine =>
                        {
                            var offCommand = string.Format("{0}", (machine.BYTENR + 100));
                            return offCommand;
                        }).ToArray();

            var merge = string.Join(",", openMachines) + "," + string.Join(",", closedMachines);

            _sPort.Write(merge);
            //foreach (var portCommand in MachineList.Where(item => item.MACHINESTATUS != Convert.ToInt32(Model.Base.MachineType.Kapali) && item.MACHINESTATUS != Convert.ToInt32(Model.Base.MachineType.Durduruldu)).Select(item => string.Format("on{0}", item.BYTENR)))
            //{
            //    _sPort.Write(portCommand);
            //}
            //BitSet(Convert.ToInt64(Convert.ToInt32(item.BYTENR).ToString()));

            //_command.BaytA = DeviceSlotA;
            //_command.BaytB = DeviceSlotB;
            //_command.BaytC = DeviceSlotC;
            //_command.BaytD = DeviceSlotD;
            //_command.BaytE = DeviceSlotE;
            //_command.BaytF = DeviceSlotF;
            //_command.ModulID = byte.Parse("1");
            //_command.ETX = 0x3;

            //DeviceInfo[0] = _command.STX;
            //DeviceInfo[1] = _command.ModulID;
            //DeviceInfo[2] = _command.BaytC;
            //DeviceInfo[3] = _command.BaytB;
            //DeviceInfo[4] = _command.BaytA;
            //DeviceInfo[5] = _command.BaytF;
            //DeviceInfo[6] = _command.BaytE;
            //DeviceInfo[7] = _command.BaytD;
            //DeviceInfo[8] = _command.ETX;

            //_sPort.Write(DeviceInfo, 0, DeviceInfo.Length);
        }

        public long BitSet(long number)
        {
            long Number2 = 0;
            if (number > -1 && number < 9)
            {
                Number2 = Convert.ToInt64((Math.Pow(2, (number - 1))));
                //DeviceSlotA -= (byte)Number2;
                Number2 = 0;
            }
            if (number > 8 && number < 17)
            {
                Number2 = Convert.ToInt64((Math.Pow(2, (number - 9))));
                //DeviceSlotB -= (byte)Number2;
                Number2 = 0;
            }
            if (number > 16 && number < 25)
            {
                Number2 = Convert.ToInt64((Math.Pow(2, (number - 17))));
                //DeviceSlotC -= (byte)Number2;
                Number2 = 0;
            }
            if (number > 24 && number < 33)
            {
                Number2 = Convert.ToInt64((Math.Pow(2, (number - 25))));
                //DeviceSlotD -= (byte)Number2;
                Number2 = 0;
            }
            if (number > 32 && number < 41)
            {
                Number2 = Convert.ToInt64((Math.Pow(2, (number - 33))));
                //DeviceSlotE -= (byte)Number2;
                Number2 = 0;
            }
            if (number > 40 && number < 49)
            {
                Number2 = Convert.ToInt64((Math.Pow(2, (number - 41))));
                //DeviceSlotF -= (byte)Number2;
                Number2 = 0;
            }
            return number;
        }
    }
}
