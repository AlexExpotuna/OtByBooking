﻿namespace OtByBooking.Services.Interfaces;
public interface IDto
{
    public TModel ToModel<TModel>(); //where TModel : class;
}
