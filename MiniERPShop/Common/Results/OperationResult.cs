namespace MiniERPShop.Common.Results; 
/// Đại diện cho kết quả thực hiện một nghiệp vụ.
/// Được sử dụng chung cho toàn bộ hệ thống.

public class OperationResult
{  
    /// Cho biết nghiệp vụ thành công hay thất bại.   
    public bool Success { get; }   
    /// Thông báo trả về cho Presenter hoặc View.    
    public string Message { get; }     
    /// Khởi tạo kết quả.
    private OperationResult(
        bool success,
        string message)
    {
        Success = success;
        Message = message;
    }
    /// Tạo kết quả thành công.
    public static OperationResult Ok(string message = "Thành công.")
    {
        return new OperationResult(
            true,
            message);
    }
    /// Tạo kết quả thất bại.
    public static OperationResult Fail(string message)
    {
        return new OperationResult(
            false,
            message);
    }
}