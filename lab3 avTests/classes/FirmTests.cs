﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab3_av;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_av.Tests
{
    [TestClass()]
    public class FirmTests
    {
        public static FirmFactory FirmFactory { get; } = new FirmFactory();
        private Contact _contact = new Contact(new ContactType("", ""), "", "", new DateTime(), new DateTime());
        //todo: проверить создание фирмы, проверить все 5 польз полей, что она main
        [TestMethod()]
        public void AddSubFirmTest()
        {
            SubFirm subFirm = new SubFirm(new SubFirmType(false, "qev;e"), "qev;e", "QWrgergw'e", "qerlgqer;", "-74346758076", "qefihwdf.nbv");
            Firm firm = FirmFactory.Instance.Create("Kazakhstan", "qebe", "Astana", "NurSultan",
                "143585", "efvw;ijbrb", ";wjlefhb;wrtb;", new DateTime(1345, 6, 7),
                "SUPERBOSS", "SUPER SUPERBOSS", "+712845734346");
            SubFirm createdSubFirm = firm.AddSubFirm(subFirm.Type, subFirm.Name, subFirm.BossName, subFirm.OfficialBossName, subFirm.PhoneNumber, subFirm.Email);
            Assert.IsNotNull(createdSubFirm);
        }

        [TestMethod()]
        public void RenameFieldTest()
        {
            Firm firm = FirmFactory.Instance.Create("qekfle", "qebe", "Astana", "NurSultan",
                "143585", "efvw;ijbrb", ";wjlefhb;wrtb;", new DateTime(1345, 6, 7),
                "SUPERBOSS", "SUPER SUPERBOSS", "+712845734346");
            string newFieldNameTest = "adkfhf";
            string value = "value";
            firm.SetField(FirmFactory.FieldName1, value);
            firm.RenameField(FirmFactory.FieldName1, newFieldNameTest);

            string newValue = firm.GetField(newFieldNameTest);
            Assert.AreEqual(newValue, value);
        }
        [TestMethod()]
        public void AddContactTestMain()
        {
            Firm firm = FirmFactory.Instance.Create("qekfle", "qebe", "Astana", "NurSultan",
                "143585", "efvw;ijbrb", ";wjlefhb;wrtb;", new DateTime(1345, 6, 7),
                "SUPERBOSS", "SUPER SUPERBOSS", "+712845734346");
           
            Contact addedContact = firm.AddContact(_contact);
            Assert.AreNotSame(_contact, addedContact);
            Assert.IsTrue(firm.IsContactExists(_contact));
            Assert.IsNotNull(firm.GetContact(_contact));

            Assert.IsTrue(addedContact == _contact);

        }
        [TestMethod()]
        public void AddContactTest()
        {
            Firm firm = FirmFactory.Instance.Create("qekfle", "qebe", "Astana", "NurSultan",
                "143585", "efvw;ijbrb", ";wjlefhb;wrtb;", new DateTime(1345, 6, 7),
                "SUPERBOSS", "SUPER SUPERBOSS", "+712845734346");
            Contact contact = new Contact(new ContactType("name", "note"), "description", "information", new DateTime(1990, 2, 2), new DateTime(2000, 2, 2));
            Contact addedContact = firm.AddContact(contact);
            Assert.IsNotNull(addedContact);
            Assert.AreNotSame(contact, addedContact);
            Assert.IsTrue(firm.Main.IsContactExists(contact));

        }
        [TestMethod()]
        public void AddContactToSubFirmTest()
        {
            Firm firm = FirmFactory.Instance.Create("qekfle", "qebe", "Astana", "NurSultan",
                "143585", "efvw;ijbrb", ";wjlefhb;wrtb;", new DateTime(1345, 6, 7),
                "SUPERBOSS", "SUPER SUPERBOSS", "+712845734346");
            SubFirm subFirm = new SubFirm(new SubFirmType(false, "name"), "name", "bossName", "officialBossName", "phoneNumber", "email");

            Contact contact = new Contact(new ContactType("name", "note"), "description", "information", new DateTime(1990, 2, 2), new DateTime(2000, 2, 2));

            firm.AddSubFirm(subFirm.Type, subFirm.Name, subFirm.BossName, subFirm.OfficialBossName, subFirm.PhoneNumber, subFirm.Email);
            Contact addedContact = firm.AddContactToSubFirm(subFirm.Type, contact);
            Assert.IsNotNull(addedContact);
            Assert.AreNotSame(contact, addedContact);
            SubFirm addedSubFirm = firm.GetSubFirm(subFirm.Type);
            Assert.IsNotNull(addedSubFirm);
            Assert.IsTrue(addedSubFirm.IsContactExists(contact));
            Contact gotContact = firm.GetSubFirmContact(subFirm.Type, contact);
            Assert.IsNotNull(gotContact);
            
            Assert.IsNotNull(gotContact);
            Assert.AreNotSame(contact, gotContact);
        }

    }
}