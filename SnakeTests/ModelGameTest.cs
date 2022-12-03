using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.Objects;

namespace SnakeTests
{
    /// <summary>
    /// Тестовый класс ModelGame
    /// </summary>
    [TestClass]
    public class ModelGameTest
    {
        /// <summary>
        /// Тестовый метод инициализации игры
        /// </summary>
        [TestMethod]
        public void TestInitGame()
        {
            ModelGame model = new ModelGame();
            model.InitGame();
            Assert.IsNotNull(model.FoodFactory);
            Assert.IsNotNull(model.Food);
            Assert.IsNotNull(model.Snake);
            Assert.IsNotNull(model.Walls);
        }

        /// <summary>
        /// Тестовый метод инициализации стен
        /// </summary>
        [TestMethod]
        public void TestInitWalls()
        {
            ModelGame modelGame = new ModelGame();
            modelGame.InitGame();
            modelGame.InitWalls(2, 2);
            Assert.AreEqual(9, modelGame.Walls.Count);
        }

        /// <summary>
        /// Тестовый метод инициализации горизонтальных стен
        /// </summary>
        [TestMethod]
        public void TestInitHorizontalWalls()
        {
            ModelGame modelGame = new ModelGame();
            modelGame.InitGame();
            modelGame.Walls.Clear();
            modelGame.InitHorizontalWalls(2, 0);
            foreach (var elWall in modelGame.Walls)
            {
                Assert.AreEqual(0, elWall.Y);
            }
        }
        
        /// <summary>
        /// Тестовый метод инициализации горизонтальных стен
        /// </summary>
        [TestMethod]
        public void TestInitHorizontalWallsCount()
        {
            ModelGame modelGame = new ModelGame();
            modelGame.InitGame();
            modelGame.Walls.Clear();
            modelGame.InitHorizontalWalls(2, 0);
            Assert.AreEqual(2, modelGame.Walls.Count);
        }
        
        /// <summary>
        /// Тестовый метод инициализации горизонтальных стен
        /// </summary>
        [TestMethod]
        public void TestInitVerticalWalls()
        {
            ModelGame modelGame = new ModelGame();
            modelGame.InitGame();
            modelGame.Walls.Clear();
            modelGame.InitVerticalWalls(0, 3);
            foreach (var elWall in modelGame.Walls)
            {
                Assert.AreEqual(0, elWall.X);
            }
        }
        
        /// <summary>
        /// Тестовый метод инициализации горизонтальных стен
        /// </summary>
        [TestMethod]
        public void TestInitVerticalWallsCount()
        {
            ModelGame modelGame = new ModelGame();
            modelGame.InitGame();
            modelGame.Walls.Clear();
            modelGame.InitVerticalWalls(0, 3);
            Assert.AreEqual(3, modelGame.Walls.Count);
        }

        /// <summary>
        /// Тестовый метод столкновения со стеной
        /// </summary>
        [TestMethod]
        public void TestIsWallHitTrue()
        {
            ModelGame modelGame = new ModelGame();
            modelGame.InitGame();
            Wall wall = new Wall(modelGame.Snake.GetHead().X, modelGame.Snake.GetHead().Y);
            modelGame.Walls.Add(wall);
            Assert.IsTrue(modelGame.CheckGameOver());
        }
        
        /// <summary>
        /// Тестовый метод столкновения со стеной
        /// </summary>
        [TestMethod]
        public void TestIsWallHitFalse()
        {
            ModelGame modelGame = new ModelGame();
            modelGame.InitGame();
            Assert.IsFalse(modelGame.CheckGameOver());
        }

        /// <summary>
        /// Тестовый метод инициализации змеи по длине
        /// </summary>
        [TestMethod]
        public void TestInitSnakeLength()
        {
            ModelGame modelGame = new ModelGame();
            modelGame.InitGame();
            Assert.AreEqual(3, modelGame.Snake.SnakeObjects.Count);
        }
        
        /// <summary>
        /// Тестовый метод инициализации змеи по координатам
        /// </summary>
        [TestMethod]
        public void TestInitSnakeCoordinates()
        {
            ModelGame modelGame = new ModelGame();
            modelGame.InitGame();
            Assert.AreEqual(14, modelGame.Snake.GetHead().X);
            Assert.AreEqual(7, modelGame.Snake.GetHead().Y);
        }
    }
}
