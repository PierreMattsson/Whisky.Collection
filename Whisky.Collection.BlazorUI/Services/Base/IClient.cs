﻿namespace Whisky.Collection.BlazorUI.Services.Base;

public partial interface IClient
{
    public HttpClient HttpClient { get; }
}