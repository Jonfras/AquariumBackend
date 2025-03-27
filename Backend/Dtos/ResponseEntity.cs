namespace Backend.Dtos; 
public class ResponseEntity<T> {
    public T Data { get; set; }
    public string ErrorMessage { get; set; }
}
