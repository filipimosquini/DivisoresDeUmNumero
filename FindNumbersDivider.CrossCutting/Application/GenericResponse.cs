﻿namespace FindNumbersDivider.CrossCutting.Application
{
    public class GenericResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}