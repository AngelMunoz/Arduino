﻿using System;
using System.Text;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Solid.Arduino;
using Solid.Arduino.Firmata;

namespace Solid.Arduino.Test
{
    /// <summary>
    /// Performs unit tests for struct DigitalPortState.
    /// </summary>
    [TestClass]
    public class DigitalPortStateTester
    {
        public DigitalPortStateTester()
        {

        }

        private TestContext _testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return _testContextInstance;
            }
            set
            {
                _testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void IsHigh_Pins_Is0()
        {
            var state = new DigitalPortState() { Pins = 0 };
            Assert.AreEqual(false, state.IsHigh(0));
            Assert.AreEqual(false, state.IsHigh(1));
            Assert.AreEqual(false, state.IsHigh(2));
            Assert.AreEqual(false, state.IsHigh(3));
            Assert.AreEqual(false, state.IsHigh(4));
            Assert.AreEqual(false, state.IsHigh(5));
            Assert.AreEqual(false, state.IsHigh(6));
            Assert.AreEqual(false, state.IsHigh(7));
        }

        [TestMethod]
        public void IsHigh_Pins_Is255()
        {
            var state = new DigitalPortState() { Pins = 255 };
            Assert.AreEqual(true, state.IsHigh(0));
            Assert.AreEqual(true, state.IsHigh(1));
            Assert.AreEqual(true, state.IsHigh(2));
            Assert.AreEqual(true, state.IsHigh(3));
            Assert.AreEqual(true, state.IsHigh(4));
            Assert.AreEqual(true, state.IsHigh(5));
            Assert.AreEqual(true, state.IsHigh(6));
            Assert.AreEqual(true, state.IsHigh(7));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IsHigh_Pin_Argument_IsNegative()
        {
            var state = new DigitalPortState();
            state.IsHigh(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IsHigh_Pin_Argument_Is8()
        {
            var state = new DigitalPortState();
            typeof(DigitalPortState).GetProperty("Pins").SetValue(state, 0);
            state.IsHigh(8);
        }
    }
}
