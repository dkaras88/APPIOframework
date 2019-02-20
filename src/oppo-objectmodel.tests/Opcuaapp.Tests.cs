﻿using Newtonsoft.Json;
using NUnit.Framework;
using System.Linq;

namespace Oppo.ObjectModel.Tests
{
    public class OpcuaappShould
    {
        private Opcuaapp _defaultopcuaApp, _opcuaapp;
        private string _name = "mvpSmartPump";
        private string _url = "opc.tcp://127.0.1.1:4840";
        private OpcuaappType _type = OpcuaappType.Server;

        [SetUp]
        public void SetupTest()
        {
            _defaultopcuaApp = new Opcuaapp();
            _opcuaapp = new Opcuaapp(_name, _type, _url);   
        }

        [TearDown]
        public void CleanUpTest()
        {
        }

        [Test]
        public void BeAsDefaultOfClientServerType()
        {
            // Arrange

            // Act
            
            // Assert
            Assert.AreEqual(OpcuaappType.ClientServer, _defaultopcuaApp.Type);
        }

        [Test]
        public void ContainAllPassedInitValues()
        {
            // Arrange

            // Act

            // Assert
            Assert.AreEqual(_name, _opcuaapp.Name);
            Assert.AreEqual(_type, _opcuaapp.Type);
            Assert.AreEqual(_url, _opcuaapp.Url);
        }

        [Test]
        public void BeSerializableToJson()
        {
            // Arrange

            // Act
            var opcuaappAsJson = JsonConvert.SerializeObject(_opcuaapp, Formatting.Indented);
            
            // Assert
            Assert.IsNotNull(opcuaappAsJson);
            Assert.AreNotEqual(string.Empty, opcuaappAsJson);
        }

        [Test]
        public void ContainOneProjectAndBeSerializableToJson()
        {
            // Arrange

            // Act
            var opcuaappAsJson = JsonConvert.SerializeObject(_opcuaapp, Formatting.Indented);

            // Assert
            Assert.IsNotNull(opcuaappAsJson);
            Assert.AreNotEqual(string.Empty, opcuaappAsJson);
            Assert.IsTrue(opcuaappAsJson.Contains(_name)); // don't care where
        }

        [Test]
        public void BeDeSerializableFromJson()
        {
            // Arrange
            var opcuaappAsJson = "" +
                "{" +    
                    "\"Name\": \"" + _name + "\"," +
                    "\"Type\": \"" +  _type.ToString() + "\"," +
                    "\"Url\": \"" + _url + "\"" +
                "}";

            // Act
            Opcuaapp opcuaappForSln = JsonConvert.DeserializeObject<Opcuaapp>(opcuaappAsJson);

            // Assert
            Assert.IsNotNull(opcuaappForSln);
            Assert.AreEqual(_name, opcuaappForSln.Name);
            Assert.AreEqual(_type, opcuaappForSln.Type);
            Assert.AreEqual(_url, opcuaappForSln.Url);
        }

        [Test]
        public void BeOfTypeClientAndDontHaveUrlAndBeSerializableFromJson()
        {
            // Arrange
            var opcuaappAsJson = "" +
                "{" +
                    "\"Name\": \"" + _name + "\"," +
                    "\"Type\": \"" + OpcuaappType.Client.ToString() + "\"" +
                "}";

			// Act
			Opcuaapp opcuaapp = JsonConvert.DeserializeObject<Opcuaapp>(opcuaappAsJson);

            // Assert
            Assert.IsNotNull(opcuaapp);
            Assert.AreEqual(_name, opcuaapp.Name);
            Assert.AreEqual(OpcuaappType.Client, opcuaapp.Type);
            Assert.IsNull(opcuaapp.Url);
        }

        [Test]
        public void BeOfTypeClientAndDontHaveUrlAndBeDeSerializableToJson()
        {
			// Arrange
			_opcuaapp.Name = _name;
			_opcuaapp.Type = OpcuaappType.Client;
			_opcuaapp.Url = null;

            // Act
            var opcuaappAsJson = JsonConvert.SerializeObject(_opcuaapp, Formatting.Indented);

            // Assert
            Assert.IsNotNull(opcuaappAsJson);
            Assert.AreNotEqual(string.Empty, opcuaappAsJson);
            Assert.IsTrue(opcuaappAsJson.Contains(_name)); // don't care where
            Assert.IsTrue(opcuaappAsJson.Contains("\"url\": null")); // don't care where
        }

    }
}