namespace WizardEmporium.Common.Constant
{
    public enum GlobalResponseCode
    {
        None = 0,
        UnexpectedError = 10,

        // Authentication
        UserDoesNotExist = 101,
        UserAlreadyExists = 102,
        InvalidPasswordOrUsername = 103,
        AccountHasBeenSuspended = 104,
        AccountNotSuspended = 105,

        // No Stock
        NoStockAvailable = 201,
        InsufficientFunds = 202,
        ItemDoesNotExist = 203,
        OrderNotFound = 204
    }
}
