namespace Backend.Controllers;

public record struct OkStatus(bool IsOk, int Nr, string? Error = null);

[Route("[controller]")]
[ApiController]
public class UserController(UserService userService) : ControllerBase {

    [HttpPost("register")]
    public ResponseEntity<UserDto> Register(UserDto userDto) {
        return userService.Register(userDto);
    }


    [HttpPost("login")]
    public ResponseEntity<UserDto> Login(UserDto userDto) {
        return userService.Login(userDto);
    }
}
