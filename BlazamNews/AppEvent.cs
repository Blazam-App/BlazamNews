namespace BlazamNews
{
    public delegate Task AppEvent();
    public delegate Task AppEvent<T>(T data);
}
