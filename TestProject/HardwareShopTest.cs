using Shop.Logic.Modules;

namespace TestProject
{
    [TestClass]
    public class HardwareShopTest
    {
        [TestMethod]
        public void AddCash_amount_less_0()
        {
            HardwareShop.Cash = -400;
            int expected = 0;
            int actual = HardwareShop.Cash;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddCash_amount_more_5000()
        {
            HardwareShop.Cash = 10000;
            int expected = 0;
            int actual = HardwareShop.Cash;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddCash_amount_normal()
        {
            HardwareShop.Cash = 2000;
            HardwareShop.Cash = 500;
            int expected = 2500;
            int actual = HardwareShop.Cash;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BuyCpu_notenough_money_normal_id_normal_model()
        {
            HardwareShop.ChangeCash(0);
            HardwareShop.Id = 1;
            int a = 1;
            HardwareShop shop = new HardwareShop();
            string job = shop.Remove;
            Assert.ThrowsException<Exception>(() => shop.Purchased_cpu(a));
        }
        [TestMethod]
        public void BuyCpu_enough_money_normal_id_normal_model()
        {
            HardwareShop shop = new HardwareShop();
            HardwareShop.Cash = 500;
            HardwareShop.Id = 2;
            int a = 1;
            shop.Purchased_cpu(a);
            string expected = "Ryzen3";
            string actual = shop.CpuInp;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BuyCpu_enough_money_normal_id_strange_model()
        {
            HardwareShop.Cash = 500;
            HardwareShop.Id = 1;
            int a = 5;
            HardwareShop shop = new HardwareShop();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => shop.Purchased_cpu(a));
        }
        [TestMethod]
        public void BuyCpu_enough_money_strange_id_normal_model()
        {
            HardwareShop.Cash = 500;
            HardwareShop.Id = 3;
            int a = 1;
            HardwareShop shop = new HardwareShop();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => shop.Purchased_cpu(a));
        }
        [TestMethod]
        public void BuyCpu_enough_money_strange_id_strange_model()
        {
            HardwareShop.Cash = 500;
            HardwareShop.Id = 3;
            int a = 5;
            HardwareShop shop = new HardwareShop();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => shop.Purchased_cpu(a));
        }
        public void BuyGpu_notenough_money_normal_id_normal_model()
        {
            HardwareShop.ChangeCash(0);
            HardwareShop.Id = 1;
            int a = 1;
            HardwareShop shop = new HardwareShop();
            Assert.ThrowsException<Exception>(() => shop.Purchased_gpu(a));
        }
        [TestMethod]
        public void BuyGpu_enough_money_normal_id_normal_model()
        {
            HardwareShop shop = new HardwareShop();
            HardwareShop.Cash = 500;
            HardwareShop.Id = 2;
            int a = 1;
            shop.Purchased_cpu(a);
            HardwareShop.Id = 1;
            a = 1;
            shop.Purchased_gpu(a);
            string expected = "GTX_1650";
            string actual = shop.GpuInp;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BuyGpu_enough_money_normal_id_strange_model()
        {
            HardwareShop.Cash = 500;
            HardwareShop.Id = 1;
            int a = 15;
            HardwareShop shop = new HardwareShop();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => shop.Purchased_gpu(a));
        }
        [TestMethod]
        public void BuyGpu_enough_money_strange_id_normal_model()
        {
            HardwareShop.Cash = 500;
            HardwareShop.Id = 10;
            int a = 1;
            HardwareShop shop = new HardwareShop();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => shop.Purchased_gpu(a));
        }
        [TestMethod]
        public void BuyGpu_enough_money_strange_id_strange_model()
        {
            HardwareShop.Cash = 500;
            HardwareShop.Id = 10;
            int a = 20;
            HardwareShop shop = new HardwareShop();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => shop.Purchased_gpu(a));
        }
        [TestMethod]
        public void Check_bought1()
        {
            HardwareShop shop = new HardwareShop();
            string expected = "1960,Ryzen3,GTX_1650";
            string actual = shop.ToString();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ClearList1()
        {
            HardwareShop shop = new HardwareShop();
            string expected = "Список очищенний";
            string actual = shop.Remove;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Check_bought2()
        {
            HardwareShop shop = new HardwareShop();
            string expected = "Ви ще нiчого не придбали!";
            string job = shop.Remove;
            string actual = shop.String();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ClearList2()
        {
            HardwareShop shop = new HardwareShop();
            string job = shop.Remove;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => shop.CpuInp);
        }
        [TestMethod]
        public void TestTryParse_NOTnormal_bool()
        {
            HardwareShop shop = new HardwareShop();
            string job = shop.Remove;
            string expected = "500";
            bool a = HardwareShop.TryParse(expected, out shop);
            Assert.IsFalse(a);
        }
        [TestMethod]
        public void TestTryParse_NOTnormal()
        {
            HardwareShop shop = new HardwareShop();
            string job = shop.Remove;
            string input = "500,Ryzen2,GTS_250";
            HardwareShop.TryParse(input, out shop);
            Assert.ThrowsException<NullReferenceException>(() => shop.ToString());
        }
        [TestMethod]
        public void TestTryParse_normal_bool()
        {
            HardwareShop shop = new HardwareShop();
            string job = shop.Remove;
            string expected = "500,Ryzen3,GTX_1650";
            bool a = HardwareShop.TryParse(expected, out shop);
            Assert.IsTrue(a);
        }
        [TestMethod]
        public void TestTryParse_normal()
        {
            HardwareShop.ChangeCash(0);
            HardwareShop shop = new HardwareShop();
            string job = shop.Remove;
            string expected = "500,Ryzen3,GTX_1650";
            HardwareShop.TryParse("500,Ryzen3,GTX_1650", out shop);
            string actual = shop.ToString();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ReturnMoneyTest()
        {
            HardwareShop.ChangeCash(1000);
            HardwareShop shop = new HardwareShop(1, 1, 4, 7);
            shop = new HardwareShop(1, 1, 3, 6);
            int expected = 400;
            int actual = HardwareShop.Cash;
            Assert.AreEqual(expected, actual);
        }
    }
}