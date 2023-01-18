namespace InternetShop.Domain.Enum
{
    public enum StatusCode
    {
        UserNotFound = 0,
        UserAlreadyExists = 1,

        OK =200,
        InternalServerError=500,

        ClothesNotFound=10,

        OrdersNotFound = 501,
        UserBasketsNotFound = 502,
        BasketAlreadyExists = 503
    }
}
