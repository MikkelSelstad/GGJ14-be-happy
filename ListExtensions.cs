﻿using System;
using System.Collections;
using System.Collections.Generic;

public static class ListExtensions {

    public static void Shuffle<T>(this List<T> list)
    {
        int n = list.Count;
        Random rnd = new Random();
        while (n > 1)
        {
            int k = (rnd.Next(0, n) % n);
            n--;
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
