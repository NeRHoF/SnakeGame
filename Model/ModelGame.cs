using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Model.Objects;
using Model.Objects.Factories;

namespace Model
{
    /// <summary>
    /// Модель игры
    /// </summary>
    public class ModelGame
    {
        /// <summary>
        /// Делегат событий
        /// </summary>
        public delegate void dEventHandler();

        /// <summary>
        /// Событие, возникающее при конце игры
        /// </summary>
        public event dEventHandler GameOver;

        /// <summary>
        /// Событие готовности поля к игре
        /// </summary>
        public event dEventHandler ReadyToPlay;

        /// <summary>
        /// Ширина карты
        /// </summary>
        public const int WIDTH_MAP = 30;

        /// <summary>
        /// Высота карты
        /// </summary>
        public const int HEIGHT_MAP = 15;

        /// <summary>
        /// Начальная длина змеи
        /// </summary>
        public const int SNAKE_LENGTH = 3;

        /// <summary>
        /// Очки игрока
        /// </summary>
        public int Scores { get; set; }

        /// <summary>
        /// Змея
        /// </summary>
        public Snake Snake { get; private set; }

        /// <summary>
        /// Стены
        /// </summary>
        public List<GameObject> Walls { get; private set; }

        /// <summary>
        /// Фабрика еды
        /// </summary>
        public FoodFactory FoodFactory { get; private set; }

        /// <summary>
        /// Еда
        /// </summary>
        public Food Food { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ModelGame()
        {
            
        }

        /// <summary>
        /// Инициализация игры
        /// </summary>
        public void InitGame()
        {
            Walls = new List<GameObject>();
            InitWalls(WIDTH_MAP, HEIGHT_MAP);
            Snake = new Snake(WIDTH_MAP / 2, HEIGHT_MAP / 2, SNAKE_LENGTH);
            FoodFactory = new FoodFactory(WIDTH_MAP, HEIGHT_MAP);
            Food = FoodFactory.CreateFood();
            ReadyToPlay?.Invoke();
        }

        /// <summary>
        /// Инициализация стен
        /// </summary>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        public void InitWalls(int parX, int parY)
        {
            Walls.Clear();
            InitHorizontalWalls(parX, 0);
            InitHorizontalWalls(parX, parY);
            InitVerticalWalls(0, parY);
            InitVerticalWalls(parX, parY + 1);
        }

        /// <summary>
        /// Инициализация горизонтальных стен
        /// </summary>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        public void InitHorizontalWalls(int parX, int parY)
        {
            for (int i = 0; i < parX; i++)
            {
                Wall wall = new Wall(i, parY);
                Walls.Add(wall);
            }
        }

        /// <summary>
        /// Инициализация вертикальных стен
        /// </summary>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        public void InitVerticalWalls(int parX, int parY)
        {
            for (int i = 0; i < parY; i++)
            {
                Wall wall = new Wall(parX, i);
                Walls.Add(wall);
            }
        }

        /// <summary>
        /// проверка на столкновения со всеми стенами
        /// </summary>
        /// <returns></returns>
        public bool IsWallsHit()
        {
            foreach (var elWall in Walls)
            {
                if (elWall.Equals(Snake.GetHead()))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Проверка на конец игры
        /// </summary>
        /// <returns></returns>
        public bool CheckGameOver()
        {
            if (IsWallsHit() || Snake.IsHit(Snake.GetHead()))
            {
                GameOver?.Invoke();
                return true;
            }

            return false;
        }

    }
}