using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace PointReaction.Classes
{
    public class Game
    {
        private int DEFAULT_MAXIMAL_FAILURE_TRIES = 50000;
        private int DEFAULT_GAME_DOT_COUNT = 30;
        private int DEFAULT_ANIMATION_DOT_COUNT = 20;
        private int MINIMAL_GAME_WIDTH = 0;
        private int MINIMAL_GAME_HEIGHT = 0;

        private List<Dot> _Dots = new List<Dot>();
        private int _DotsCount = 0;
        private int _GameWidth = 0;
        private int _GameHeight = 0;
        private bool _IsGameNotAnimation = true;

        public List<Dot> Dots
        {
            get => _Dots;
            set => SetDots(value);
        }
        public int DotsCount
        {
            get => _DotsCount;
            set => SetDotsCount(value);
        }
        public int GameWidth
        {
            get => _GameWidth;
            set => SetGameWidth(value);
        }
        public int GameHeight
        {
            get => _GameHeight;
            set => SetGameHeight(value);
        }
        public bool IsGameNotAnimation
        {
            get => _IsGameNotAnimation;
            set => SetIsGameNotAnimation(value);
        }

        public Game(int gameWidth, int gameHeight)
        {
            SetGameWidth(gameWidth);
            SetGameHeight(gameHeight);
            SetIsGameNotAnimation(true);
            SetDotsCount(DEFAULT_GAME_DOT_COUNT);
            GenerateDots();
        }
        public Game(int gameWidth, int gameHeight, bool isGameNotAnimation)
        {
            SetGameWidth(gameWidth);
            SetGameHeight(gameHeight);

            if (isGameNotAnimation)
            {
                SetIsGameNotAnimation(true);
                SetDotsCount(DEFAULT_GAME_DOT_COUNT);
            } else
            {
                SetIsGameNotAnimation(false);
                SetDotsCount(DEFAULT_ANIMATION_DOT_COUNT);
            }

            GenerateDots();
        }
        public Game(int gameWidth, int gameHeight, bool isGameNotAnimation, int dotsCount)
        {
            SetGameWidth(gameWidth);
            SetGameHeight(gameHeight);

            if (isGameNotAnimation != false)
            {
                SetIsGameNotAnimation(true);
                SetDotsCount(dotsCount);
            }
            else
            {
                SetIsGameNotAnimation(false);
                SetDotsCount(dotsCount);
            }

            GenerateDots();
        }

        private void SetDots(List<Dot> dots) {
            if (dots != null)
            {
                _Dots = dots;
            }
        }
        private void SetGameWidth(int gameWidth)
        {
            if (gameWidth >= MINIMAL_GAME_WIDTH)
            {
                _GameWidth = gameWidth;
            }
        }
        private void SetGameHeight(int gameHeight)
        {
            if (gameHeight >= MINIMAL_GAME_HEIGHT)
            {
                _GameHeight = gameHeight;
            }
        }
        private void SetDotsCount(int dotsCount)
        {
            if (dotsCount >= 0)
            {
                _DotsCount = dotsCount;
            }
        }
        private void SetIsGameNotAnimation(bool isGameNotAnimation)
        {
            _IsGameNotAnimation = isGameNotAnimation;
        }

        private void GenerateDots()
        {
            List<Dot> dotList = new List<Dot>();
            int dotFailCount = 0;

            for (int newDotCounter = 0; newDotCounter < _DotsCount; newDotCounter++)
            {
                Dot dot = new Dot(0, 0);
                dot.X = Generator.RandomNumber(dot.Radius, _GameWidth - dot.Radius);
                dot.Y = Generator.RandomNumber(dot.Radius, _GameHeight - dot.Radius);

                for (int existingDotCounter = 0; existingDotCounter < dotList.Count; existingDotCounter++)
                {
                    double distance = Calculate.GetDistance(dot.X, dotList[existingDotCounter].X, dot.Y, dotList[existingDotCounter].Y);
                    int sumRadius = dotList[existingDotCounter].Radius + dot.Radius;

                    if (sumRadius > distance)
                    {
                        dot.Radius = Generator.RandomNumber(dot.MINIMAL_RADIUS, dot.MAXIMAL_RADIUS);
                        dot.X = Generator.RandomNumber(dot.Radius, _GameWidth - dot.Radius);
                        dot.Y = Generator.RandomNumber(dot.Radius, _GameHeight - dot.Radius);
                        existingDotCounter = -1;
                        dotFailCount++;
                    }
                }

                if (dotFailCount >= DEFAULT_MAXIMAL_FAILURE_TRIES)
                {
                    break;
                }

                dot.Color = new Color(255 - dotList.Count, 0 + (dotList.Count * 2), 0);

                dotList.Add(dot);
            }

            _Dots = dotList;
        }

        public List<Dot> GetDots()
        {
            return _Dots;
        }
    }
}