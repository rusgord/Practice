using Shop.Logic.Enums;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Xml.Linq;
using Shop.Logic.Modules;

namespace Shop.Logic.Modules
{
    public class HardwareShop
    {
        private static int cash;
        private static int id;
        private static int count;
        private static List<string> items = new List<string>();
        private List<int> cpu = new List<int>() { 100, 150, 300, 400 };
        private List<int> gpu = new List<int>() { 60, 80, 120, 160, 240, 300, 400, 500, 550, 700, 800, 1000, 1200 };
        private List<int> gpu_i = new List<int>() { 90, 140, 290, 330 };
        public HardwareShop()
        {
            if (items.Count != 0)
                count++;
        }
        public HardwareShop(int idc, int modelcpu)
        {
            Id = idc;
            Purchased_cpu(modelcpu);
            count++;
        }
        public HardwareShop(int idc, int idg, int modelcpu, int modelgpu) : this(idc, modelcpu)
        {
            Id = idg;
            Purchased_gpu(modelgpu);
            count++;
        }
        public HardwareShop(int idc, int idg, int modelcpu, int modelgpu, int money)
        {
            Cash = money;
            Id = idc;
            Purchased_cpu(modelcpu);
            Id = idg;
            Purchased_gpu(modelgpu);
            ChangeCash(money);
            count += 4;
        }
        [JsonInclude]
        public int Balance { get => cash; set => ChangeCash(value); }
        public static int Cash
        {
            get { return cash; }
            set
            {
                if (value >= 0 && value < 5000)
                {
                    cash += value;
                    count++;
                }
            }
        }
        public static void ChangeCash(int a)
        {
            cash = a;
        }
        private void ReturnCash(bool cg)
        {
            int returnMoney;
            if (!cg)
            {
                returnMoney = Convert.ToInt32(items[1]);
                Cash = returnMoney;
                return;
            }
            returnMoney = Convert.ToInt32(items[3]);
            Cash = returnMoney;
        }
        public static int Id { get; set; } = 0;
        [JsonInclude]
        public string CpuInp 
        {
            get => items[0];
            set 
            {
                int id = 0, model = 0, temp;
                if (Processor.Equal(value, ref model, ref id))
                {
                    Id = id;
                    temp = Cash;
                    ChangeCash(5000);
                    Purchased_cpu(model);
                    ChangeCash(temp); 
                } 
            } 
        }
        [JsonInclude]
        public string GpuInp 
        { 
            get => items[2];
            set 
            {
                int id = 0, model = 0, temp;
                if (Videocard.Equal(value, ref model, ref id)) 
                { 
                    Id = id;
                    temp = Cash;
                    ChangeCash(5000);
                    Purchased_gpu(model);
                    ChangeCash(temp);
                }
            }
        }
        public static int Count { get => count; set => count = value; }
        [JsonIgnore]
        public string Remove
        {
            get { items.Clear(); Count = 0; return "Список очищенний"; }
        }
        public void Purchased_cpu(int a)
        {
            if (items.Count > 1) ReturnCash(false);
            if (cash - cpu[a - 1] >= 0)
            {
                if (items.Count > 1)
                {
                    cash -= cpu[a - 1];
                    switch (Id)
                    {
                        case 1:
                            items[0] = $"{(INTEL_CPU)a}";
                            items[1] = $"{cpu[a - 1]}";
                            break;
                        case 2:
                            items[0] = $"{(AMD_CPU)a}";
                            items[1] = $"{cpu[a - 1]}"; break;
                        default:
                            id = 0; throw new ArgumentOutOfRangeException("Неправильне ID");
                    }
                }
                else
                {
                    cash -= cpu[a - 1];
                    switch (Id) {
                        case 1:
                            items.Add($"{(INTEL_CPU)a}");
                            items.Add($"{cpu[a - 1]}");
                            break;
                        case 2:
                            items.Add($"{(AMD_CPU)a}");
                            items.Add($"{cpu[a - 1]}");
                            break;
                        default:
                            id = 0; throw new ArgumentOutOfRangeException("Неправильне ID");
                    }
                }
            }
            else { id = 0; throw new Exception("У вас не вистачає грошей на процессор"); }
        }
        public void Purchased_gpu(int a)
        {
            if (items.Count > 2) ReturnCash(true);
            if (cash - gpu[a - 1] >= 0 || cash - gpu_i[a - 1] >= 0)
            {
                if (items.Count > 2)
                {
                    if (Id == 3) { cash -= gpu_i[a - 1]; items[2] = $"{(INTEL_GPU)a}"; items[3] = $"{gpu_i[a - 1]}"; }
                    else
                    {
                        cash -= gpu[a - 1];
                        switch (Id)
                        {
                            case 1:
                                items[2] = $"{(NVIDIA_GPU)a}";
                                items[3] = $"{gpu[a - 1]}";
                                break;
                            case 2:
                                items[2] = $"{(AMD_GPU)a}";
                                items[3] = $"{gpu[a - 1]}";
                                break;
                            default: id = 0; throw new ArgumentOutOfRangeException("Неправильне ID");
                        }
                    }
                }
                else
                {
                    if (Id == 3) { cash -= gpu_i[a - 1]; items.Add($"{(INTEL_GPU)a}"); items.Add($"{gpu_i[a - 1]}"); }
                    else
                    {
                        cash -= gpu[a - 1];
                        switch (Id)
                        {
                            case 1:
                                items.Add($"{(NVIDIA_GPU)a}");
                                items.Add($"{gpu[a - 1]}");
                                break;
                            case 2:
                                items.Add($"{(AMD_GPU)a}");
                                items.Add($"{gpu[a - 1]}");
                                break;
                            default: id = 0; throw new ArgumentOutOfRangeException("Неправильне ID");
                        }
                    }
                }
            }
            else { id = 0; throw new Exception("У вас не вистачає грошей на вiдеокарту"); }
        }
        public static HardwareShop Parse(string deviceInfo)
        {
            if (string.IsNullOrWhiteSpace(deviceInfo))
            {
                throw new ArgumentException("Строка не може бути пустою!");
            }
            string[] deviceInfoArray = deviceInfo.Split(',');
            if (deviceInfoArray.Length != 3)
            {
                throw new FormatException("Введено неправильний формат. Формат введення: Баланс;МодельПроцессора;МодельВiдеокарти");
            }
            if (!int.TryParse(deviceInfoArray[0], out int money))
            {
                throw new FormatException("Введено неправильний формат. Баланс повинен бути типу int!");
            }
            int modelprocessor = 0;
            int idc = 0;
            if (!Processor.Equal(deviceInfoArray[1], ref modelprocessor, ref idc))
            {
                throw new FormatException("Цей процессор вiдсутiнiй в продажу");
            }
            int modelvideocard = 0;
            int idg = 0;
            if (!Videocard.Equal(deviceInfoArray[2], ref modelvideocard, ref idg))
            {
                throw new FormatException("Ця вiдеокарта вiдсутня в продажу");
            }
            HardwareShop parsedDevice = new HardwareShop(idc, idg, modelprocessor, modelvideocard, money);
            return parsedDevice;
        }
        public static bool TryParse(string deviceInfo, out HardwareShop parsedDevice)
        {
            parsedDevice = null;
            try
            {
                parsedDevice = Parse(deviceInfo);
                return true;
            }
            catch (FormatException ex) { return false; }
            catch (ArgumentOutOfRangeException ex) { return false; }
            catch (ArgumentException ex) { return false; }
        }
        public string String()
        {
            if (items.Count != 0)
                return $"Дякуємо за придбання: \n{CpuInp} - {items[1]}$\n{GpuInp} - {items[3]}$\nЗалишок {Cash}$\nКiлькiсть: {Count}, створених об'єктiв";
            return "Ви ще нiчого не придбали!";
        }

        public override string ToString()
        {
            return $"{Cash},{CpuInp},{GpuInp}";
        }
    }
}