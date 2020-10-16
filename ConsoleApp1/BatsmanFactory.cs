﻿using ConsoleApp1.Models;

namespace ConsoleApp1
{
    public abstract class BatsmanFactory
    {
        public abstract IBatsman GetBatsman(int batsmanType);
    }
}