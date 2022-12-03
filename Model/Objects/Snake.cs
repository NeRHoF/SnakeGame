using System.Collections.Generic;
using System.Linq;

namespace Model.Objects
{
    /// <summary>
    /// Модель змеи
    /// </summary>
    public class Snake
    {
        /// <summary>
        /// Массив игровых объектов, входящих в состав змеи
        /// </summary>
        private List<GameObject> _snake;

        /// <summary>
        /// Шаг змеи
        /// </summary>
        private int _step = 1;

        /// <summary>
        /// Хвост змеи
        /// </summary>
        private GameObject _tail;

        /// <summary>
        /// Голова змеи
        /// </summary>
        private GameObject _head;

        /// <summary>
        /// Свойство списка объектов змеи
        /// </summary>
        public List<GameObject> SnakeObjects
        {
            get => _snake;
        }

        /// <summary>
        /// Повернута ли змея
        /// </summary>
        public bool IsRotate { get; set; } = true;

        /// <summary>
        /// Направление движения змеи
        /// </summary>
        public Direction Direction { get; private set; }

        /// <summary>
        /// Получение головы
        /// </summary>
        /// <returns></returns>
        public GameObject GetHead() => _snake.Last();
        
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        /// <param name="parLength">Длина змеи</param>
        public Snake(int parX, int parY, int parLength)
        {
            Direction = Direction.Right;

            _snake = new List<GameObject>();
            InitSnake(parX, parY, parLength);
        }
        
        /// <summary>
        /// Инициализация змеи
        /// </summary>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        /// <param name="parLength">Длина змеи</param>
        private void InitSnake(int parX, int parY, int parLength)
        {
            for (int i = parX - parLength; i < parX - 1; i++)
            {
                _snake.Add(new SnakeTail(i, parY));
            }
            
            _snake.Add(new SnakeHead(parX - 1, parY, Direction));
        }

        /// <summary>
        /// Перемещение змеи
        /// </summary>
        public void Move()
        {
            this._head = GetHead();
            this._tail = new SnakeTail(this._head.X, this._head.Y);
            this._snake.Remove(this._head);
            this._snake.Add(this._tail);
            this._tail = _snake.First();
            this._snake.Remove(this._tail);
            this._head = GetNextPoint();
            this._snake.Add(new SnakeHead(this._head.X, this._head.Y, Direction));
            IsRotate = true;
        }

        /// <summary>
        /// Поедание еды
        /// </summary>
        /// <param name="parGameObject">игровой объект</param>
        /// <returns></returns>
        public bool Eat(GameObject parGameObject)
        {
            this._head = GetNextPoint();
            if (this._head.Equals(parGameObject))
            {
                GameObject previusHead = GetHead();
                _snake.Remove(previusHead);
                _snake.Add(new SnakeTail(previusHead.X, previusHead.Y));
                _snake.Add(_head);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Получение следующего места
        /// </summary>
        /// <returns></returns>
        public GameObject GetNextPoint()
        {
            GameObject head = GetHead();
            GameObject nextPoint = new SnakeHead(head.X, head.Y, Direction);
            switch (Direction)
            {
                case Direction.Left:
                    nextPoint.X -= _step;
                    break;
                case Direction.Right:
                    nextPoint.X += _step;
                    break;
                case Direction.Up:
                    nextPoint.Y -= _step;
                    break;
                case Direction.Down:
                    nextPoint.Y += _step;
                    break;
            }

            return nextPoint;
        }

        /// <summary>
        /// Поворот змеи
        /// </summary>
        /// <param name="parDirection">Следующее направление</param>
        public void Rotation(Direction parDirection)
        {
            if (IsRotate)
            {
                switch (Direction)
                {
                    case Direction.Left:
                    case Direction.Right:
                        if (parDirection == Direction.Down)
                        {
                            Direction = parDirection;
                        }
                        else if (parDirection == Direction.Up)
                        {
                            Direction = parDirection;
                        }

                        break;
                    case Direction.Up:
                    case Direction.Down:
                        if (parDirection == Direction.Left)
                        {
                            Direction = parDirection;
                        }
                        else if (parDirection == Direction.Right)
                        {
                            Direction = parDirection;
                        }
                        break;
                }

                IsRotate = false;
            }
        }

        /// <summary>
        /// Проверка на столкновение
        /// </summary>
        /// <returns></returns>
        public bool IsHit(GameObject parGameObject)
        {
            for (int i = _snake.Count - 2; i > 0; i--)
            {
                if (_snake[i].Equals(parGameObject))
                {
                    return true;
                }
            }

            return false;
        }
    }
}