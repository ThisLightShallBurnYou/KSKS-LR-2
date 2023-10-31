using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace CSCS1
{
    [TestClass]
    public class UnitTest1
    {
        Commands command = new Commands();
        [TestMethod]
        public void Command1Test1()
        {
            /***** Encode *****/
            // Arrange
            byte commandNum = 1;
            string hexcolor = "59FF";
            byte[] resultExpect = { 1, 255, 89 };
            // Act
            byte[] result = command.ClearDisplayEncode(commandNum, hexcolor);
            // Assert
            CollectionAssert.AreEqual(resultExpect, result);
            /***** Decode *****/
            // Arrange
            byte[] message = { 1, 68, 236 };
            string hexcolorExpect = "EC44";
            byte commandExpect = 1;
            // Act
            command.ClearDisplayDecode(message, out byte commandResult, out string
            hexcolorResult);
            // Assert
            Assert.AreEqual(commandExpect, commandResult);
            Assert.AreEqual(hexcolorExpect, hexcolorResult);
        }
        [TestMethod]
        public void Command1Test2()
        {
            /***** Decode *****/
            // Arrange
            byte[] messageEmpty = { };
            string hexcolorExpect = "EC44";
            byte commandExpect = 1;
            // Act
            command.ClearDisplayDecode(messageEmpty, out byte commandResultEmpty,
            out string hexcolorResultEmpty);
            // Assert
            Assert.AreEqual(commandExpect, commandResultEmpty);
            Assert.AreEqual(hexcolorExpect, hexcolorResultEmpty);
        }
        [TestMethod]
        public void Command1Test3()
        {
            /***** Decode *****/
            // Arrange
            byte[] messageShort = { 1, 68 };
            string hexcolorExpect = "EC44";
            byte commandExpect = 1;
            // Act
            command.ClearDisplayDecode(messageShort, out byte commandResultShort,
            out string hexcolorResultShort);
            // Assert
            Assert.AreEqual(commandExpect, commandResultShort);
            Assert.AreEqual(hexcolorExpect, hexcolorResultShort);
        }
        [TestMethod]
        public void Command1Test4()
        {
            /***** Decode *****/
            // Arrange
            byte[] messageLong = { 1, 68, 236, 20, 8 };
            string hexcolorExpect = "EC44";
            byte commandExpect = 1;
            // Act
            command.ClearDisplayDecode(messageLong, out byte commandResultLong,
            out string hexcolorResultLong);
            // Assert
            Assert.AreEqual(commandExpect, commandResultLong);
            Assert.AreEqual(hexcolorExpect, hexcolorResultLong);
        }
        [TestMethod]
        public void Command2Test1()
        {
            /***** Encode *****/
            // Arrange
            byte commandNum = 2;
            Int16 x0 = 50;
            Int16 y0 = 35;
            string hexcolor = "1D6C";
            byte[] resultExpect = { 2, 50, 0, 35, 0, 108, 29 };
            // Act
            byte[] result = command.PixelEncode(commandNum, x0, y0, hexcolor);
            // Assert
            CollectionAssert.AreEqual(resultExpect, result);
            /***** Decode *****/
            // Arrange
            byte[] message = { 2, 12, 0, 20, 0, 233, 215 };
            byte commandExpect = 2;
            Int16 x0Expect = 12;
            Int16 y0Expect = 20;
            string hexcolorExpect = "D7E9";
            // Act
            command.PixelDecode(message, out byte commandResult, out Int16
            x0Result, out Int16 y0Result, out string hexcolorResult);
            // Assert
            Assert.AreEqual(commandExpect, commandResult); Assert.AreEqual(x0Expect, x0Result);
            Assert.AreEqual(y0Expect, y0Result);
            Assert.AreEqual(hexcolorExpect, hexcolorResult);
        }
        [TestMethod]
        public void Command2Test2()
        {
            /***** Decode *****/
            // Arrange
            byte[] messageEmpty = { };
            byte commandExpect = 2;
            Int16 x0Expect = 12;
            Int16 y0Expect = 20;
            string hexcolorExpect = "D7E9";
            // Act
            command.PixelDecode(messageEmpty, out byte commandResultEmpty, out
            Int16 x0ResultEmpty, out Int16 y0ResultEmpty, out string hexcolorResultEmpty);
            // Assert
            Assert.AreEqual(commandExpect, commandResultEmpty);
            Assert.AreEqual(x0Expect, x0ResultEmpty);
            Assert.AreEqual(y0Expect, y0ResultEmpty);
            Assert.AreEqual(hexcolorExpect, hexcolorResultEmpty);
        }
        [TestMethod]
        public void Command2Test3()
        {
            /***** Decode *****/
            // Arrange
            byte[] messageShort = { 2, 12, 0 };
            byte commandExpect = 2;
            Int16 x0Expect = 12;
            Int16 y0Expect = 20;
            string hexcolorExpect = "D7E9";
            // Act
            command.PixelDecode(messageShort, out byte commandResultShort, out
            Int16 x0ResultShort, out Int16 y0ResultShort, out string hexcolorResultShort);
            // Assert
            Assert.AreEqual(commandExpect, commandResultShort);
            Assert.AreEqual(x0Expect, x0ResultShort);
            Assert.AreEqual(y0Expect, y0ResultShort);
            Assert.AreEqual(hexcolorExpect, hexcolorResultShort);
        }
        [TestMethod]
        public void Command2Test4()
        {
            /***** Decode *****/
            // Arrange
            byte[] messageLong = { 2, 12, 0, 20, 0, 233, 215, 24, 45 };
            byte commandExpect = 2;
            Int16 x0Expect = 12;
            Int16 y0Expect = 20;
            string hexcolorExpect = "D7E9";
            // Act
            command.PixelDecode(messageLong, out byte commandResultLong, out Int16
            x0ResultLong, out Int16 y0ResultLong, out string hexcolorResultLong);
            // Assert
            Assert.AreEqual(commandExpect, commandResultLong);
            Assert.AreEqual(x0Expect, x0ResultLong); Assert.AreEqual(y0Expect, y0ResultLong);
            Assert.AreEqual(hexcolorExpect, hexcolorResultLong);
        }
        [TestMethod]
        public void Command3Test1()
        {
            /***** Encode *****/
            // Arrange
            byte commandNum = 3;
            Int16 x0 = 40;
            Int16 y0 = 31;
            Int16 x1 = 62;
            Int16 y1 = 39;
            string hexcolor = "2A28";
            byte[] resultExpect = { 3, 40, 0, 31, 0, 62, 0, 39, 0, 40, 42 };
            // Act
            byte[] result = command.FourNumbersEncode(commandNum, x0, y0, x1, y1,
            hexcolor);
            // Assert
            CollectionAssert.AreEqual(resultExpect, result);
            /***** Decode *****/
            // Arrange
            byte[] message = { 3, 42, 0, 55, 0, 34, 0, 75, 0, 232, 40 };
            byte commandExpect = 3;
            Int16 x0Expect = 42;
            Int16 y0Expect = 55;
            Int16 x1Expect = 34;
            Int16 y1Expect = 75;
            string hexcolorExpect = "28E8";
            // Act
            command.FourNumbersDecode(message, out byte commandResult, out Int16
            x0Result, out Int16 y0Result, out Int16 x1Result, out Int16 y1Result, out string
            hexcolorResult);
            // Assert
            Assert.AreEqual(commandExpect, commandResult);
            Assert.AreEqual(x0Expect, x0Result);
            Assert.AreEqual(y0Expect, y0Result);
            Assert.AreEqual(x1Expect, x1Result);
            Assert.AreEqual(y1Expect, y1Result);
            Assert.AreEqual(hexcolorExpect, hexcolorResult);
        }
        [TestMethod]
        public void Command3Test2()
        {
            /***** Decode *****/
            // Arrange
            byte[] messageEmpty = { };
            byte commandExpect = 3;
            Int16 x0Expect = 42;
            Int16 y0Expect = 55;
            Int16 x1Expect = 34;
            Int16 y1Expect = 75;
            string hexcolorExpect = "28E8";
            // Act
            command.FourNumbersDecode(messageEmpty, out byte commandResultEmpty,
            out Int16 x0ResultEmpty, out Int16 y0ResultEmpty, out Int16 x1ResultEmpty, out
            Int16 y1ResultEmpty, out string hexcolorResultEmpty);// Assert
            Assert.AreEqual(commandExpect, commandResultEmpty);
            Assert.AreEqual(x0Expect, x0ResultEmpty);
            Assert.AreEqual(y0Expect, y0ResultEmpty);
            Assert.AreEqual(x1Expect, x1ResultEmpty);
            Assert.AreEqual(y1Expect, y1ResultEmpty);
            Assert.AreEqual(hexcolorExpect, hexcolorResultEmpty);
        }
        [TestMethod]
        public void Command3Test3()
        {
            /***** Decode *****/
            // Arrange
            byte[] messageShort = { 3, 42, 0, 55, 0, 34 };
            byte commandExpect = 3;
            Int16 x0Expect = 42;
            Int16 y0Expect = 55;
            Int16 x1Expect = 34;
            Int16 y1Expect = 75;
            string hexcolorExpect = "28E8";
            // Act
            command.FourNumbersDecode(messageShort, out byte commandResultShort,
            out Int16 x0ResultShort, out Int16 y0ResultShort, out Int16 x1ResultShort, out
            Int16 y1ResultShort, out string hexcolorResultShort);
            // Assert
            Assert.AreEqual(commandExpect, commandResultShort);
            Assert.AreEqual(x0Expect, x0ResultShort);
            Assert.AreEqual(y0Expect, y0ResultShort);
            Assert.AreEqual(x1Expect, x1ResultShort);
            Assert.AreEqual(y1Expect, y1ResultShort);
            Assert.AreEqual(hexcolorExpect, hexcolorResultShort);
        }
        [TestMethod]
        public void Command3Test4()
        {
            /***** Decode *****/
            // Arrange
            byte[] messageLong = { 3, 42, 0, 55, 0, 34, 0, 75, 0, 232, 40, 84, 22
};
            byte commandExpect = 3;
            Int16 x0Expect = 42;
            Int16 y0Expect = 55;
            Int16 x1Expect = 34;
            Int16 y1Expect = 75;
            string hexcolorExpect = "28E8";
            // Act
            command.FourNumbersDecode(messageLong, out byte commandResultLong, out
            Int16 x0ResultLong, out Int16 y0ResultLong, out Int16 x1ResultLong, out Int16
            y1ResultLong, out string hexcolorResultLong);
            // Assert
            Assert.AreEqual(commandExpect, commandResultLong);
            Assert.AreEqual(x0Expect, x0ResultLong);
            Assert.AreEqual(y0Expect, y0ResultLong);
            Assert.AreEqual(x1Expect, x1ResultLong);
            Assert.AreEqual(y1Expect, y1ResultLong);
            Assert.AreEqual(hexcolorExpect, hexcolorResultLong);
        }
        [TestMethod]
        public void Command4Test1()
        {
            /***** Encode *****/
            // Arrange
            byte commandNum = 4;
            Int16 x0 = 32;
            Int16 y0 = 54;
            Int16 radius = 10;
            string hexcolor = "4240";
            byte[] resultExpect = { 4, 32, 0, 54, 0, 10, 0, 64, 66 };
            // Act
            byte[] result = command.CircleEncode(commandNum, x0, y0, radius,
            hexcolor);
            // Assert
            CollectionAssert.AreEqual(resultExpect, result);
            /***** Decode *****/
            // Arrange
            byte[] message = { 4, 67, 0, 95, 0, 18, 0, 255, 255 };
            byte commandExpect = 4;
            Int16 x0Expect = 67;
            Int16 y0Expect = 95;
            Int16 radiusExpect = 18;
            string hexcolorExpect = "FFFF";
            // Act
            command.CircleDecode(message, out byte commandResult, out Int16
            x0Result, out Int16 y0Result, out Int16 radiusResult, out string hexcolorResult);
            // Assert
            Assert.AreEqual(commandExpect, commandResult);
            Assert.AreEqual(x0Expect, x0Result);
            Assert.AreEqual(y0Expect, y0Result);
            Assert.AreEqual(radiusExpect, radiusResult);
            Assert.AreEqual(hexcolorExpect, hexcolorResult);
        }
        [TestMethod]
        public void Command4Test2()
        {
            /***** Decode *****/
            // Arrange
            byte[] messageEmpty = { };
            byte commandExpect = 4;
            Int16 x0Expect = 67;
            Int16 y0Expect = 95;
            Int16 radiusExpect = 18;
            string hexcolorExpect = "FFFF";
            // Act
            command.CircleDecode(messageEmpty, out byte commandResultEmpty, out
            Int16 x0ResultEmpty, out Int16 y0ResultEmpty, out Int16 radiusResultEmpty, out
            string hexcolorResultEmpty);
            // Assert
            Assert.AreEqual(commandExpect, commandResultEmpty);
            Assert.AreEqual(x0Expect, x0ResultEmpty);
            Assert.AreEqual(y0Expect, y0ResultEmpty);
            Assert.AreEqual(radiusExpect, radiusResultEmpty);
            Assert.AreEqual(hexcolorExpect, hexcolorResultEmpty);
        }
        [TestMethod]
        public void Command4Test3()
        {
            /***** Decode *****/
            // Arrange
            byte[] messageShort = { 4, 67, 0, 95, 0, 18 };
            byte commandExpect = 4;
            Int16 x0Expect = 67;
            Int16 y0Expect = 95;
            Int16 radiusExpect = 18;
            string hexcolorExpect = "FFFF";
            // Act
            command.CircleDecode(messageShort, out byte commandResultShort, out
            Int16 x0ResultShort, out Int16 y0ResultShort, out Int16 radiusResultShort, out
            string hexcolorResultShort);
            // Assert
            Assert.AreEqual(commandExpect, commandResultShort);
            Assert.AreEqual(x0Expect, x0ResultShort);
            Assert.AreEqual(y0Expect, y0ResultShort);
            Assert.AreEqual(radiusExpect, radiusResultShort);
            Assert.AreEqual(hexcolorExpect, hexcolorResultShort);
        }
        [TestMethod]
        public void Command4Test4()
        {
            /***** Decode *****/
            // Arrange
            byte[] messageLong = { 4, 67, 0, 95, 0, 18, 0, 255, 255, 95, 0 };
            byte commandExpect = 4;
            Int16 x0Expect = 67;
            Int16 y0Expect = 95;
            Int16 radiusExpect = 18;
            string hexcolorExpect = "FFFF";
            // Act
            command.CircleDecode(messageLong, out byte commandResultLong, out
            Int16 x0ResultLong, out Int16 y0ResultLong, out Int16 radiusResultLong, out string
            hexcolorResultLong);
            // Assert
            Assert.AreEqual(commandExpect, commandResultLong);
            Assert.AreEqual(x0Expect, x0ResultLong);
            Assert.AreEqual(y0Expect, y0ResultLong);
            Assert.AreEqual(radiusExpect, radiusResultLong);
            Assert.AreEqual(hexcolorExpect, hexcolorResultLong);
        }
        [TestMethod]
        public void Command5Test1()
        {
            /***** Encode *****/
            // Arrange
            byte commandNum = 5;
            Int16 x0 = 3;
            Int16 y0 = 6;
            Int16 x1 = 2;
            Int16 y1 = 11;
            Int16 radius = 10;
            string hexcolor = "34E7";
            byte[] resultExpect = { 5, 3, 0, 6, 0, 2, 0, 11, 0, 10, 0, 231, 52 };
            // Act
            byte[] result = command.RoundedRectEncode(commandNum, x0, y0, x1, y1,
            radius, hexcolor);// Assert
            CollectionAssert.AreEqual(resultExpect, result);
            /***** Decode *****/
            // Arrange
            byte[] message = { 5, 44, 0, 12, 0, 34, 0, 56, 0, 18, 0, 225, 154 };
            byte commandExpect = 5;
            Int16 x0Expect = 44;
            Int16 y0Expect = 12;
            Int16 x1Expect = 34;
            Int16 y1Expect = 56;
            Int16 radiusExpect = 18;
            string hexcolorExpect = "9AE1";
            // Act
            command.RoundedRectDecode(message, out byte commandResult, out Int16
            x0Result, out Int16 y0Result, out Int16 x1Result, out Int16 y1Result, out Int16
            radiusResult, out string hexcolorResult);
            // Assert
            Assert.AreEqual(commandExpect, commandResult);
            Assert.AreEqual(x0Expect, x0Result);
            Assert.AreEqual(y0Expect, y0Result);
            Assert.AreEqual(x1Expect, x1Result);
            Assert.AreEqual(y1Expect, y1Result);
            Assert.AreEqual(radiusExpect, radiusResult);
            Assert.AreEqual(hexcolorExpect, hexcolorResult);
        }
        [TestMethod]
        public void Command5Test2()
        {
            /***** Decode *****/
            // Arrange
            byte[] messageEmpty = { };
            byte commandExpect = 5;
            Int16 x0Expect = 44;
            Int16 y0Expect = 12;
            Int16 x1Expect = 34;
            Int16 y1Expect = 56;
            Int16 radiusExpect = 18;
            string hexcolorExpect = "9AE1";
            // Act
            command.RoundedRectDecode(messageEmpty, out byte commandResultEmpty,
            out Int16 x0ResultEmpty, out Int16 y0ResultEmpty, out Int16 x1ResultEmpty, out
            Int16 y1ResultEmpty, out Int16 radiusResultEmpty, out string hexcolorResultEmpty);
            // Assert
            Assert.AreEqual(commandExpect, commandResultEmpty);
            Assert.AreEqual(x0Expect, x0ResultEmpty);
            Assert.AreEqual(y0Expect, y0ResultEmpty);
            Assert.AreEqual(x1Expect, x1ResultEmpty);
            Assert.AreEqual(y1Expect, y1ResultEmpty);
            Assert.AreEqual(radiusExpect, radiusResultEmpty);
            Assert.AreEqual(hexcolorExpect, hexcolorResultEmpty);
        }
        [TestMethod]
        public void Command5Test3()
        {
            /***** Decode *****/
            // Arrange
            byte[] messageShort = { 5, 44, 0, 12, 0, 34, 0 };
            byte commandExpect = 5; Int16 x0Expect = 44;
            Int16 y0Expect = 12;
            Int16 x1Expect = 34;
            Int16 y1Expect = 56;
            Int16 radiusExpect = 18;
            string hexcolorExpect = "9AE1";
            // Act
            command.RoundedRectDecode(messageShort, out byte commandResultShort,
            out Int16 x0ResultShort, out Int16 y0ResultShort, out Int16 x1ResultShort, out
            Int16 y1ResultShort, out Int16 radiusResultShort, out string hexcolorResultShort);
            // Assert
            Assert.AreEqual(commandExpect, commandResultShort);
            Assert.AreEqual(x0Expect, x0ResultShort);
            Assert.AreEqual(y0Expect, y0ResultShort);
            Assert.AreEqual(x1Expect, x1ResultShort);
            Assert.AreEqual(y1Expect, y1ResultShort);
            Assert.AreEqual(radiusExpect, radiusResultShort);
            Assert.AreEqual(hexcolorExpect, hexcolorResultShort);
        }
        [TestMethod]
        public void Command5Test4()
        {
            /***** Decode *****/
            // Arrange
            byte[] messageLong = { 5, 44, 0, 12, 0, 34, 0, 56, 0, 18, 0, 225, 154,
19, 57 };
            byte commandExpect = 5;
            Int16 x0Expect = 44;
            Int16 y0Expect = 12;
            Int16 x1Expect = 34;
            Int16 y1Expect = 56;
            Int16 radiusExpect = 18;
            string hexcolorExpect = "9AE1";
            // Act
            command.RoundedRectDecode(messageLong, out byte commandResultLong, out
            Int16 x0ResultLong, out Int16 y0ResultLong, out Int16 x1ResultLong, out Int16
            y1ResultLong, out Int16 radiusResultLong, out string hexcolorResultLong);
            // Assert
            Assert.AreEqual(commandExpect, commandResultLong);
            Assert.AreEqual(x0Expect, x0ResultLong);
            Assert.AreEqual(y0Expect, y0ResultLong);
            Assert.AreEqual(x1Expect, x1ResultLong);
            Assert.AreEqual(y1Expect, y1ResultLong);
            Assert.AreEqual(radiusExpect, radiusResultLong);
            Assert.AreEqual(hexcolorExpect, hexcolorResultLong);
        }
        [TestMethod]
        public void Command6Test1()
        {
            /***** Encode *****/
            // Arrange
            byte commandNum = 6;
            Int16 x0 = 43;
            Int16 y0 = 12;
            string hexcolor = "04E0";
            Int16 x1 = 14;
            string text = "Hello, World!";
            Int16 y1 = Convert.ToInt16(text.Length); byte[] resultExpect = { 6, 43, 0, 12, 0, 224, 4, 14, 0, 13, 0, 72, 0,
101, 0, 108, 0, 108, 0, 111, 0, 44, 0, 32, 0, 87, 0, 111, 0, 114, 0, 108, 0, 100,
0, 33, 0 };
            // Act
            byte[] result = command.TextEncode(commandNum, x0, y0, hexcolor, x1,
            y1, text);
            // Assert
            CollectionAssert.AreEqual(resultExpect, result);
            /***** Decode *****/
            // Arrange
            byte[] message = { 6, 21, 0, 45, 0, 240, 153, 12, 0, 13, 0, 71, 0,
111, 0, 111, 0, 100, 0, 32, 0, 77, 0, 111, 0, 114, 0, 110, 0, 105, 0, 110, 0, 103,
0, 33, 0 };
            byte commandExpect = 6;
            Int16 x0Expect = 21;
            Int16 y0Expect = 45;
            string hexcolorExpect = "99F0";
            Int16 x1Expect = 12;
            Int16 y1Expect = 13;
            string textExpect = "Good Morning!";
            // Act
            command.TextDecode(message, out byte commandResult, out Int16
            x0Result, out Int16 y0Result, out string hexcolorResult, out Int16 x1Result, out
            Int16 y1Result, out string textResult);
            // Assert
            Assert.AreEqual(commandExpect, commandResult);
            Assert.AreEqual(x0Expect, x0Result);
            Assert.AreEqual(y0Expect, y0Result);
            Assert.AreEqual(hexcolorExpect, hexcolorResult);
            Assert.AreEqual(x1Expect, x1Result);
            Assert.AreEqual(y1Expect, y1Result);
            Assert.AreEqual(textExpect, textResult);
        }
        [TestMethod]
        public void Command6Test2()
        {
            /***** Decode *****/
            // Arrange
            byte[] messageEmpty = { };
            byte commandExpect = 6;
            Int16 x0Expect = 21;
            Int16 y0Expect = 45;
            string hexcolorExpect = "99F0";
            Int16 x1Expect = 12;
            Int16 y1Expect = 13;
            string textExpect = "Good Morning!";
            // Act
            command.TextDecode(messageEmpty, out byte commandResultEmpty, out
            Int16 x0ResultEmpty, out Int16 y0ResultEmpty, out string hexcolorResultEmpty, out
            Int16 x1ResultEmpty, out Int16 y1ResultEmpty, out string textResultEmpty);
            // Assert
            Assert.AreEqual(commandExpect, commandResultEmpty);
            Assert.AreEqual(x0Expect, x0ResultEmpty);
            Assert.AreEqual(y0Expect, y0ResultEmpty);
            Assert.AreEqual(hexcolorExpect, hexcolorResultEmpty);
            Assert.AreEqual(x1Expect, x1ResultEmpty); Assert.AreEqual(y1Expect, y1ResultEmpty);
            Assert.AreEqual(textExpect, textResultEmpty);
        }
        [TestMethod]
        public void Command6Test3()
        {
            /***** Decode *****/
            // Arrange
            byte[] messageShort = { 6, 21, 0, 45, 0, 240, 153, 12, 0, 13, 0, 71,
0, 111, 0, 111, 0, 100, 0, 32, 0, 77, 0, 111, 0, 114, 0, 110, 0, 105 };
            byte commandExpect = 6;
            Int16 x0Expect = 21;
            Int16 y0Expect = 45;
            string hexcolorExpect = "99F0";
            Int16 x1Expect = 12;
            Int16 y1Expect = 13;
            string textExpect = "Good Morning!";
            // Act
            command.TextDecode(messageShort, out byte commandResultShort, out
            Int16 x0ResultShort, out Int16 y0ResultShort, out string hexcolorResultShort, out
            Int16 x1ResultShort, out Int16 y1ResultShort, out string textResultShort);
            // Assert
            Assert.AreEqual(commandExpect, commandResultShort);
            Assert.AreEqual(x0Expect, x0ResultShort);
            Assert.AreEqual(y0Expect, y0ResultShort);
            Assert.AreEqual(hexcolorExpect, hexcolorResultShort);
            Assert.AreEqual(x1Expect, x1ResultShort);
            Assert.AreEqual(y1Expect, y1ResultShort);
            Assert.AreEqual(textExpect, textResultShort);
        }
        [TestMethod]
        public void Command6Test4()
        {
            /***** Decode *****/
            // Arrange
            byte[] messageLong = { 6, 21, 0, 45, 0, 240, 153, 12, 0, 13, 0, 71, 0,
111, 0, 111, 0, 100, 0, 32, 0, 77, 0, 111, 0, 114, 0, 110, 0, 105, 0, 110, 0, 103,
0, 33, 0, 110, 0, 105, 0, 110, 0, 103, 0, 33, 0 };
            byte commandExpect = 6;
            Int16 x0Expect = 21;
            Int16 y0Expect = 45;
            string hexcolorExpect = "99F0";
            Int16 x1Expect = 12;
            Int16 y1Expect = 13;
            string textExpect = "Good Morning!";
            // Act
            command.TextDecode(messageLong, out byte commandResultLong, out Int16
            x0ResultLong, out Int16 y0ResultLong, out string hexcolorResultLong, out Int16
            x1ResultLong, out Int16 y1ResultLong, out string textResultLong);
            // Assert
            Assert.AreEqual(commandExpect, commandResultLong);
            Assert.AreEqual(x0Expect, x0ResultLong);
            Assert.AreEqual(y0Expect, y0ResultLong);
            Assert.AreEqual(hexcolorExpect, hexcolorResultLong);
            Assert.AreEqual(x1Expect, x1ResultLong);
            Assert.AreEqual(y1Expect, y1ResultLong);
            Assert.AreEqual(textExpect, textResultLong);
        }
    }
}
