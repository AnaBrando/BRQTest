public static class Constants{

    public static string CreateSuccess = "Create Trunk";
    public static string UpdateSuccess = "Update Trunk";
    public static string UpdateError = "Error In Update Trunk";
    public static string ErrorCreate = "Error In Create Trunk";
    public static string DeleteSuccess = "Success In Delete Trunk";
    public static string DeleteError = "Error In Delete Trunk";
    public static string ErrorDefault(this string message) =>  $"Error in {message}";
    public static string SuccessDefault(this string message) =>  $"Success in {message}";
    public static string InvalidFieldsDefault(this string message) => $"{message} - Invalid Fields";
}