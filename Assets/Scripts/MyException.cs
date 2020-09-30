using System;

public class MyException : Exception
{
    public override string Message { get; }

    public MyException(string message) : base(message)
    {
        Message = $"Ошибка заполнения полей игрового объекта: {base.Message}";
    }
}