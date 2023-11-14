using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab3_av;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_av.Tests
{

    [TestClass()]
    public class FirmFactoryTests
    {
        public static FirmFactory FirmFactory { get; } = new FirmFactory();

        [TestMethod()]
        public void CreateTest()
        {

            const string name = "name";
            const string country = "country";
            const string region = "region";
            const string town = "town";
            const string street = "street";
            const string postIndex = "postIndex";
            const string email = "email";
            const string websiteUrl = "websiteUrl";
            DateTime enterDate = new DateTime(2004, 4, 7);
            const string bossName = "bossName";
            const string officialBossName = "officialBossName";
            const string phoneNumber = "phoneNumber";

            Firm createdFirm = FirmFactory.Instance.Create(country, region, town, street, postIndex, email, websiteUrl,
                enterDate, bossName, officialBossName, phoneNumber);


            Assert.IsTrue(createdFirm.Country == country);
            Assert.IsTrue(createdFirm.Region == region);
            Assert.IsTrue(createdFirm.Town == town);
            Assert.IsTrue(createdFirm.Street == street);
            Assert.IsTrue(createdFirm.PostIndex == postIndex);
            Assert.IsTrue(createdFirm.Email == email);
            Assert.IsTrue(createdFirm.WebsiteUrl == websiteUrl);
            Assert.IsTrue(createdFirm.EnterDate == enterDate);
            Assert.IsTrue(createdFirm.Main.BossName == bossName);
            Assert.IsTrue(createdFirm.Main.OfficialBossName == officialBossName);
            Assert.IsTrue(createdFirm.Main.PhoneNumber == phoneNumber);

            foreach (var userField in FirmFactory.Instance.UserFields)
            {
                string fieldValue = null;
                fieldValue = createdFirm.GetField(userField.Key);
                Assert.IsNotNull(fieldValue);
            }

            Assert.IsNotNull(createdFirm.Main);
            Assert.IsTrue(createdFirm.Main.Type.IsMain);
        }
        //создать 2 фирмы, проверить совпадение польз полей
        [TestMethod()]
        public void CreateTest_2Firms()
        {
            const string name = "name";
            const string country = "country";
            const string region = "region";
            const string town = "town";
            const string street = "street";
            const string postIndex = "postIndex";
            const string email = "email";
            const string websiteUrl = "websiteUrl";
            DateTime enterDate = new DateTime(2004, 4, 7);
            const string bossName = "bossName";
            const string officialBossName = "officialBossName";
            const string phoneNumber = "phoneNumber";

            Firm firm1 = FirmFactory.Instance.Create(country, region, town, street, postIndex, email, websiteUrl,
                enterDate, bossName, officialBossName, phoneNumber);

            Firm firm2 = FirmFactory.Instance.Create(country, region, town, street, postIndex, email, websiteUrl,
                enterDate, bossName, officialBossName, phoneNumber);

            const string value1 = "value1";
            const string value2 = "value2";

            firm1.SetField(FirmFactory.Instance.FieldName1, value1);
            firm2.SetField(FirmFactory.Instance.FieldName1, value2);

            Assert.IsFalse(firm1.GetField(FirmFactory.Instance.FieldName1)
                == firm2.GetField(FirmFactory.Instance.FieldName1));
        }
    }
}